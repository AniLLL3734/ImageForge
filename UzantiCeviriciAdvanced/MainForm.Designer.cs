namespace ImageForge
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pnlDropZone = new System.Windows.Forms.Panel();
            this.lblDropInfo = new System.Windows.Forms.Label();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.lblQualityValue = new System.Windows.Forms.Label();
            this.trackBarQuality = new System.Windows.Forms.TrackBar();
            this.lblQuality = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.cmbTargetFormat = new System.Windows.Forms.ComboBox();
            this.lblTargetFormat = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.pnlDropZone.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQuality)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDropZone
            // 
            this.pnlDropZone.AllowDrop = true;
            this.pnlDropZone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDropZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlDropZone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDropZone.Controls.Add(this.lblDropInfo);
            this.pnlDropZone.Location = new System.Drawing.Point(12, 12);
            this.pnlDropZone.Name = "pnlDropZone";
            this.pnlDropZone.Size = new System.Drawing.Size(660, 100);
            this.pnlDropZone.TabIndex = 0;
            // 
            // lblDropInfo
            // 
            this.lblDropInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDropInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDropInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.lblDropInfo.Location = new System.Drawing.Point(0, 0);
            this.lblDropInfo.Name = "lblDropInfo";
            this.lblDropInfo.Size = new System.Drawing.Size(658, 98);
            this.lblDropInfo.TabIndex = 0;
            this.lblDropInfo.Text = "Drag and Drop Files or Folders Here";
            this.lblDropInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.IntegralHeight = false;
            this.lstFiles.ItemHeight = 15;
            this.lstFiles.Location = new System.Drawing.Point(12, 118);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstFiles.Size = new System.Drawing.Size(660, 129);
            this.lstFiles.TabIndex = 1;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(522, 431);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(150, 40);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Convert";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 489);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(684, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(567, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Ready.";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.Controls.Add(this.lblQualityValue);
            this.grpOptions.Controls.Add(this.trackBarQuality);
            this.grpOptions.Controls.Add(this.lblQuality);
            this.grpOptions.Controls.Add(this.btnSelectFolder);
            this.grpOptions.Controls.Add(this.cmbDestination);
            this.grpOptions.Controls.Add(this.lblDestination);
            this.grpOptions.Controls.Add(this.chkOverwrite);
            this.grpOptions.Controls.Add(this.cmbTargetFormat);
            this.grpOptions.Controls.Add(this.lblTargetFormat);
            this.grpOptions.Location = new System.Drawing.Point(12, 269);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(504, 202);
            this.grpOptions.TabIndex = 8;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Conversion Options";
            // 
            // lblQualityValue
            // 
            this.lblQualityValue.AutoSize = true;
            this.lblQualityValue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualityValue.Location = new System.Drawing.Point(448, 140);
            this.lblQualityValue.Name = "lblQualityValue";
            this.lblQualityValue.Size = new System.Drawing.Size(22, 17);
            this.lblQualityValue.TabIndex = 8;
            this.lblQualityValue.Text = "90";
            // 
            // trackBarQuality
            // 
            this.trackBarQuality.LargeChange = 10;
            this.trackBarQuality.Location = new System.Drawing.Point(145, 133);
            this.trackBarQuality.Maximum = 100;
            this.trackBarQuality.Minimum = 1;
            this.trackBarQuality.Name = "trackBarQuality";
            this.trackBarQuality.Size = new System.Drawing.Size(297, 45);
            this.trackBarQuality.TabIndex = 7;
            this.trackBarQuality.TickFrequency = 10;
            this.trackBarQuality.Value = 90;
            // 
            // lblQuality
            // 
            this.lblQuality.AutoSize = true;
            this.lblQuality.Location = new System.Drawing.Point(16, 140);
            this.lblQuality.Name = "lblQuality";
            this.lblQuality.Size = new System.Drawing.Size(70, 15);
            this.lblQuality.TabIndex = 6;
            this.lblQuality.Text = "JPG Quality:";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Enabled = false;
            this.btnSelectFolder.Location = new System.Drawing.Point(344, 76);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(127, 27);
            this.btnSelectFolder.TabIndex = 5;
            this.btnSelectFolder.Text = "Browse...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // cmbDestination
            // 
            this.cmbDestination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(149, 78);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(189, 23);
            this.cmbDestination.TabIndex = 4;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(16, 82);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(111, 15);
            this.lblDestination.TabIndex = 3;
            this.lblDestination.Text = "Output Destination:";
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Location = new System.Drawing.Point(20, 172);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(144, 19);
            this.chkOverwrite.TabIndex = 2;
            this.chkOverwrite.Text = "Overwrite existing files";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // cmbTargetFormat
            // 
            this.cmbTargetFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetFormat.FormattingEnabled = true;
            this.cmbTargetFormat.Location = new System.Drawing.Point(149, 34);
            this.cmbTargetFormat.Name = "cmbTargetFormat";
            this.cmbTargetFormat.Size = new System.Drawing.Size(140, 23);
            this.cmbTargetFormat.TabIndex = 1;
            // 
            // lblTargetFormat
            // 
            this.lblTargetFormat.AutoSize = true;
            this.lblTargetFormat.Location = new System.Drawing.Point(16, 38);
            this.lblTargetFormat.Name = "lblTargetFormat";
            this.lblTargetFormat.Size = new System.Drawing.Size(84, 15);
            this.lblTargetFormat.TabIndex = 0;
            this.lblTargetFormat.Text = "Target Format:";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(522, 269);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 28);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear List";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select an output folder for the converted files.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 511);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.pnlDropZone);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(700, 550);
            this.Name = "MainForm";
            this.Text = "ImageForge";
            this.pnlDropZone.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarQuality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlDropZone;
        private System.Windows.Forms.Label lblDropInfo;
        private System.Windows.Forms.ListBox lstFiles;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.ComboBox cmbTargetFormat;
        private System.Windows.Forms.Label lblTargetFormat;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TrackBar trackBarQuality;
        private System.Windows.Forms.Label lblQuality;
        private System.Windows.Forms.Label lblQualityValue;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
    }
}