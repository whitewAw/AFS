namespace AFS.Core.Model
{
    public class TwoYearsCalculationData
    {
        public double BaseYear { get; set; }
        public double CurrentYear { get; set; }
        public double Deviations => CurrentYear - BaseYear;
        public double GrowthRate => AFSConstraints.RoundStat(CurrentYear / BaseYear * 100);
    }
}
