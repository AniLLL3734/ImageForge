using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageForge
{
    public class ImageProcessingService
    {
        public async Task<List<FileProcessingResult>> ProcessBatchAsync(IEnumerable<string> filePaths, ConversionOptions options, IProgress<ProgressReport> progress)
        {
            var results = new List<FileProcessingResult>();
            var filesToProcess = filePaths.ToList();
            int totalCount = filesToProcess.Count;

            for (int i = 0; i < totalCount; i++)
            {
                var filePath = filesToProcess[i];

                var result = await Task.Run(() => ProcessSingleFile(filePath, options));
                results.Add(result);

                progress?.Report(new ProgressReport
                {
                    PercentageComplete = (i + 1) * 100 / totalCount,
                    StatusMessage = $"Processing: {Path.GetFileName(filePath)}"
                });
            }
            return results;
        }

        private FileProcessingResult ProcessSingleFile(string sourcePath, ConversionOptions options)
        {
            var result = new FileProcessingResult { SourcePath = sourcePath };
            try
            {
                string outputDirectory = ResolveOutputDirectory(sourcePath, options);
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                string newFileName = Path.ChangeExtension(Path.GetFileName(sourcePath), "." + options.TargetFormat.ToLowerInvariant());
                result.OutputPath = Path.Combine(outputDirectory, newFileName);

                if (!options.OverwriteExistingFiles && File.Exists(result.OutputPath))
                {
                    throw new IOException("File already exists and overwrite is disabled.");
                }

                using (var sourceImage = Image.FromFile(sourcePath))
                {
                    if (options.TargetFormat.Equals("ICO", StringComparison.OrdinalIgnoreCase))
                    {
                        SaveAsIcon(sourceImage, result.OutputPath);
                    }
                    else
                    {
                        SaveWithEncoder(sourceImage, result.OutputPath, options);
                    }
                }
                result.WasSuccessful = true;
            }
            catch (Exception ex)
            {
                result.WasSuccessful = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        private string ResolveOutputDirectory(string sourcePath, ConversionOptions options)
        {
            switch (options.Destination)
            {
                case OutputDestination.Desktop:
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                case OutputDestination.Custom:
                    return options.CustomOutputPath;
                case OutputDestination.SameAsSource:
                default:
                    return Path.GetDirectoryName(sourcePath);
            }
        }

        private void SaveWithEncoder(Image image, string path, ConversionOptions options)
        {
            ImageFormat targetFormat = GetGdiImageFormat(options.TargetFormat);

            if (targetFormat == ImageFormat.Jpeg)
            {
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, (long)options.JpgQuality);
                ImageCodecInfo jpgEncoder = ImageCodecInfo.GetImageDecoders().First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                image.Save(path, jpgEncoder, encoderParameters);
            }
            else
            {
                image.Save(path, targetFormat);
            }
        }

        private void SaveAsIcon(Image sourceImage, string outputPath)
        {
            using (var fs = new FileStream(outputPath, FileMode.Create))
            {
                int iconSize = 256;
                using (var iconBitmap = new Bitmap(sourceImage, new Size(iconSize, iconSize)))
                using (var bw = new BinaryWriter(fs))
                {
                    bw.Write((ushort)0); bw.Write((ushort)1); bw.Write((ushort)1);
                    bw.Write((byte)iconBitmap.Width); bw.Write((byte)iconBitmap.Height);
                    bw.Write((byte)0); bw.Write((byte)0); bw.Write((ushort)0); bw.Write((ushort)32);
                    long imageSizeOffset = fs.Position;
                    bw.Write((uint)0);
                    long imageDataOffset = fs.Position;
                    bw.Write((uint)0);
                    long actualDataOffset = fs.Position;
                    iconBitmap.Save(fs, ImageFormat.Png);
                    long dataSize = fs.Position - actualDataOffset;
                    fs.Seek(imageSizeOffset, SeekOrigin.Begin);
                    bw.Write((uint)dataSize);
                    fs.Seek(imageDataOffset, SeekOrigin.Begin);
                    bw.Write((uint)actualDataOffset);
                }
            }
        }

        private ImageFormat GetGdiImageFormat(string format)
        {
            switch (format.ToUpperInvariant())
            {
                case "JPG": return ImageFormat.Jpeg;
                case "PNG": return ImageFormat.Png;
                case "BMP": return ImageFormat.Bmp;
                case "GIF": return ImageFormat.Gif;
                case "TIFF": return ImageFormat.Tiff;
                default: throw new NotSupportedException($"GDI+ does not support the format '{format}'.");
            }
        }
    }
}