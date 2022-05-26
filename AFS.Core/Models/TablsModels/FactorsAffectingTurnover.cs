namespace AFS.Core.Models.TablsModels
{
    public class FactorsAffectingTurnover
    {
        public string? Number { get; set; }
        public double BaseYear { get; set; }
        public double CurrentYear { get; set; }
        public double AdjustedIndicator { get; set; }
        public double Total => CurrentYear - BaseYear;
        public double DueToRevenue => AdjustedIndicator - BaseYear;
        public double DueToAverageBalances => CurrentYear - AdjustedIndicator;
    }
}
