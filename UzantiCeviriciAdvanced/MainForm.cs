using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageForge
{
    public partial class MainForm : Form
    {
        private readonly ImageProcessingService _processingService;
        private readonly HashSet<string> _fileQueue;
        private readonly IReadOnlyList<string> _supportedExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".tiff" };

        public MainForm()
        {
            InitializeComponent();
            _processingService = new ImageProcessingService();
            _fileQueue = new HashSet<string>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            InitializeApplicationState();
            WireUpEventHandlers();
        }

        private void InitializeApplicationState()
        {
            cmbTargetFormat.Items.AddRange(new object[] { "JPG", "PNG", "ICO", "BMP", "GIF", "TIFF" });
            cmbTargetFormat.SelectedIndex = 0;
            cmbDestination.DataSource = Enum.GetValues(typeof(OutputDestination));
            cmbDestination.SelectedIndex = 0;

            ToggleQualitySliderVisibility();
            ToggleUIState(true);
        }

        private void WireUpEventHandlers()
        {
            pnlDropZone.DragEnter += (s, e) => { if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; };
            pnlDropZone.DragDrop += HandleFileDrop;
            lblDropInfo.AllowDrop = true;
            lblDropInfo.DragEnter += (s, e) => { if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; };
            lblDropInfo.DragDrop += HandleFileDrop;

            btnProcess.Click += async (s, e) => await BeginProcessing();
            btnClear.Click += (s, e) => ClearQueue();
            btnSelectFolder.Click += HandleSelectFolder;

            cmbTargetFormat.SelectedIndexChanged += (s, e) => ToggleQualitySliderVisibility();
            cmbDestination.SelectedIndexChanged += (s, e) => {
                btnSelectFolder.Enabled = (OutputDestination)cmbDestination.SelectedItem == OutputDestination.Custom;
            };
            trackBarQuality.Scroll += (s, e) => lblQualityValue.Text = trackBarQuality.Value.ToString();
        }

        private void HandleFileDrop(object sender, DragEventArgs e)
        {
            var paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var path in paths)
            {
                if (Directory.Exists(path))
                {
                    var filesInDir = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories)
                                            .Where(f => _supportedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()));
                    foreach (var file in filesInDir) _fileQueue.Add(file);
                }
                else if (File.Exists(path) && _supportedExtensions.Contains(Path.GetExtension(path).ToLowerInvariant()))
                {
                    _fileQueue.Add(path);
                }
            }
            UpdateFileQueueList();
        }

        private void HandleSelectFolder(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                btnSelectFolder.Text = Path.GetFileName(folderBrowserDialog.SelectedPath);
            }
        }

        private void UpdateFileQueueList()
        {
            lstFiles.DataSource = null;
            if (_fileQueue.Any())
            {
                lstFiles.DataSource = _fileQueue.Select(Path.GetFileName).ToList();
                lblStatus.Text = $"{_fileQueue.Count} files queued for processing.";
            }
            else
            {
                lblStatus.Text = "Ready.";
            }
            ToggleUIState(true);
        }

        private void ClearQueue()
        {
            _fileQueue.Clear();
            UpdateFileQueueList();
            progressBar.Value = 0;
        }

        private void ToggleUIState(bool isEnabled)
        {
            grpOptions.Enabled = isEnabled;
            pnlDropZone.AllowDrop = isEnabled;
            btnProcess.Enabled = isEnabled && _fileQueue.Any();
            btnClear.Enabled = isEnabled && _fileQueue.Any();
        }

        private void ToggleQualitySliderVisibility()
        {
            string selectedFormat = cmbTargetFormat.SelectedItem.ToString();
            bool isVisible = selectedFormat.Equals("JPG", StringComparison.OrdinalIgnoreCase);

            lblQuality.Visible = isVisible;
            trackBarQuality.Visible = isVisible;
            lblQualityValue.Visible = isVisible;
        }

        private async Task BeginProcessing()
        {
            if (!_fileQueue.Any()) return;

            var options = new ConversionOptions
            {
                TargetFormat = cmbTargetFormat.SelectedItem.ToString(),
                Destination = (OutputDestination)cmbDestination.SelectedItem,
                CustomOutputPath = folderBrowserDialog.SelectedPath,
                JpgQuality = trackBarQuality.Value,
                OverwriteExistingFiles = chkOverwrite.Checked
            };

            if (options.Destination == OutputDestination.Custom && string.IsNullOrEmpty(options.CustomOutputPath))
            {
                MessageBox.Show("Please select a custom output folder before proceeding.", "Output Folder Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ToggleUIState(false);
            progressBar.Value = 0;

            var progressReporter = new Progress<ProgressReport>(report => {
                progressBar.Value = report.PercentageComplete;
                lblStatus.Text = report.StatusMessage;
            });

            var results = await _processingService.ProcessBatchAsync(_fileQueue, options, progressReporter);

            ShowProcessingSummary(results);
            ToggleUIState(true);
        }

        private void ShowProcessingSummary(List<FileProcessingResult> results)
        {
            int successCount = results.Count(r => r.WasSuccessful);
            int failureCount = results.Count - successCount;

            var summaryText = new StringBuilder();
            summaryText.AppendLine($"Processing Complete: {successCount} succeeded, {failureCount} failed.");

            if (failureCount > 0)
            {
                summaryText.AppendLine("\nFailed Files:");
                var failedFiles = results.Where(r => !r.WasSuccessful)
                                         .Take(10)
                                         .Select(r => $" - {Path.GetFileName(r.SourcePath)}: {r.ErrorMessage}");
                summaryText.Append(string.Join("\n", failedFiles));
                if (failureCount > 10)
                {
                    summaryText.AppendLine("\n...and more.");
                }
            }

            lblStatus.Text = "Processing complete. See dialog for details.";
            MessageBox.Show(summaryText.ToString(), "Conversion Summary", MessageBoxButtons.OK,
                failureCount > 0 ? MessageBoxIcon.Warning : MessageBoxIcon.Warning);

            ClearQueue();
        }
    }
}