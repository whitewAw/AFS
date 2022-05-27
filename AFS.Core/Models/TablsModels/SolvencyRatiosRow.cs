namespace AFS.Core.Models.TablsModels
{
    public class SolvencyRatiosRow
    {
        public string? Number { get; set; }
        public double BaseBegin { get; set; }
        public double BaseEnd { get; set; }
        public double CurrentBegin { get; set; }
        public double CurrentEnd { get; set; }
        public double BaseDeviation => BaseEnd - BaseBegin;
        public double CurrentDeviation => CurrentEnd - CurrentBegin;
    }
}