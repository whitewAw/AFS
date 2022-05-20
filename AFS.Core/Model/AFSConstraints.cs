namespace AFS.Core.Model
{
    public class AFSConstraints
    {
        public int MinYear { get; private set; } = 2014;
        public int MaxYear { get; private set; } = DateTime.Now.AddYears(-1).Year;
        public int DurationOAnalyzedPeriod { get; private set; } = 360;
        public string FileExtension { get; private set; } = ".json";
        public int MaxFileSize { get; private set; } = 15*1024;

        public static double RoundStat(double value, int digits=1) => Math.Round(value, digits, MidpointRounding.AwayFromZero);
        public static string RoundStrStat(double value, int digits = 1)
        {
            if (value == 0 || Double.IsNaN(value))
            {
                return String.Empty;
            }
            string mask = digits switch
            {
                1 => "0.0",
                2 => "0.00",
                _ => throw new ArgumentException("Invalid enum value for command", nameof(RoundStrStat)),
            };
            return RoundStat(value, digits).ToString(mask);
        }
        public double Round(double value, int digits = 1) => RoundStat(value, digits);
        public string RoundStr(double value, int digits = 1) => RoundStrStat(value, digits);
    }
}
