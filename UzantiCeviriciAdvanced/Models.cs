namespace ImageForge
{
    public enum OutputDestination
    {
        SameAsSource,
        Desktop,
        Custom
    }

    public class ConversionOptions
    {
        public string TargetFormat { get; set; }
        public OutputDestination Destination { get; set; }
        public string CustomOutputPath { get; set; }
        public int JpgQuality { get; set; } = 90;
        public bool OverwriteExistingFiles { get; set; }
    }

    public class ProgressReport
    {
        public int PercentageComplete { get; set; }
        public string StatusMessage { get; set; }
    }

    public class FileProcessingResult
    {
        public bool WasSuccessful { get; set; }
        public string SourcePath { get; set; }
        public string OutputPath { get; set; }
        public string ErrorMessage { get; set; }
    }
}