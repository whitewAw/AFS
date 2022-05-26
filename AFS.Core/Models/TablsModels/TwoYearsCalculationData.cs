namespace AFS.Core.Models.TablsModels
{
    public class TwoYearsCalculationData
    {
        public string? Number { get; set; }
        public double BaseYear { get; set; }
        public double CurrentYear { get; set; }
        public double Deviations => CurrentYear - BaseYear;
        public double GrowthRate => CurrentYear / BaseYear * 100;
    }
}
