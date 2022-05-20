namespace AFS.Core.Model
{
    public class BasicCalculationData
    {
        public double BeginningOfyear { get; set; }
        public double EndOfYear { get; set; }
        public double Deviations => EndOfYear - BeginningOfyear;
        public double GrowthRate => AFSConstraints.RoundStat(EndOfYear / BeginningOfyear* 100);
    }
}
