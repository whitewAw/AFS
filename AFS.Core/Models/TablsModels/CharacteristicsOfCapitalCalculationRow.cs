using AFS.Core.Model;

namespace AFS.Core.Models.TablsModels
{
    public class CharacteristicsOfCapitalCalculationRow
    {
        public double BeginningOfyear { get; set; }
        public double EndOfYear { get; set; }
        public double Deviations => EndOfYear - BeginningOfyear;
        public double GrowthRate => AFSConstraints.RoundStat(EndOfYear / BeginningOfyear * 100);
    }
}
