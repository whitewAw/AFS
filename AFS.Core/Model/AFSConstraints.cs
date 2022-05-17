namespace AFS.Core.Model
{
    public class AFSConstraints
    {
        public int MinYear { get; private set; } = 2014;
        public int MaxYear { get; private set; } = DateTime.Now.AddYears(-1).Year;
        public int DurationOAnalyzedPeriod { get; private set; } = 360;
        public string FileExtension { get; private set; } = ".json";
        public int MaxFileSize { get; private set; } = 15*1024;
    }
}
