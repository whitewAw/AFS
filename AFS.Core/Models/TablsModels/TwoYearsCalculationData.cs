namespace AFS.Core.Models.TablsModels
{
    public class TwoYearsCalculationData
    {
        public double BaseYear { get; set; }
        public double CurrentYear { get; set; }
        public double Deviations => CurrentYear - BaseYear;
        public double GrowthRate => CurrentYear / BaseYear * 100;
    }
}
