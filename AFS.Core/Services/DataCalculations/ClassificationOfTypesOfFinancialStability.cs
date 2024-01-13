using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class ClassificationOfTypesOfFinancialStability
    {
        public ClassificationOfTypesOfFinancialStabilityRow AbsoluteFinancialStability { get; private set; } = new();
        public ClassificationOfTypesOfFinancialStabilityRow NormalFinancialStability { get; private set; } = new();
        public ClassificationOfTypesOfFinancialStabilityRow PreCrisisFinancialStability { get; private set; } = new();
        public ClassificationOfTypesOfFinancialStabilityRow CrisisFinancialStability { get; private set; } = new();

        public ClassificationOfTypesOfFinancialStability(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            LiquidityIndicatorsOfBalance lIOB = new(model);
            AbsoluteFinancialStabilityInit(lIOB);
            NormalFinancialStabilityInit(lIOB);
            PreCrisisFinancialStabilityInit(lIOB);
            CrisisFinancialStabilityInit(lIOB);
        }
        private void AbsoluteFinancialStabilityInit(LiquidityIndicatorsOfBalance lIOB)
        {
            AbsoluteFinancialStability.Number = "1.";
            AbsoluteFinancialStability.CurrentBVal = lIOB.A1P1Bace.AEnd >= lIOB.A1P1Bace.PEnd ? "+" : "-";
            AbsoluteFinancialStability.CurrentCVal = lIOB.A1P1Current.AEnd >= lIOB.A1P1Current.PEnd ? "+" : "-";
            AbsoluteFinancialStability.ShortBVal = lIOB.A1P1Bace.AEnd >= lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd ? "+" : "-";
            AbsoluteFinancialStability.ShortCVal = lIOB.A1P1Current.AEnd >= lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd ? "+" : "-";
            AbsoluteFinancialStability.LongBVal = lIOB.A1P1Bace.AEnd >= lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd + lIOB.A3P3Bace.PEnd ? "+" : "-";
            AbsoluteFinancialStability.LongCVal = lIOB.A1P1Current.AEnd >= lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd + lIOB.A3P3Current.PEnd ? "+" : "-";
        }
        private void NormalFinancialStabilityInit(LiquidityIndicatorsOfBalance lIOB)
        {
            NormalFinancialStability.Number = "2.";
            NormalFinancialStability.CurrentBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd >= lIOB.A1P1Bace.PEnd ? "+" : "-";
            NormalFinancialStability.CurrentCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd >= lIOB.A1P1Current.PEnd ? "+" : "-";
            NormalFinancialStability.ShortBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd >= lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd ? "+" : "-";
            NormalFinancialStability.ShortCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd >= lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd ? "+" : "-";
            NormalFinancialStability.LongBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd >= lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd + lIOB.A3P3Bace.PEnd ? "+" : "-";
            NormalFinancialStability.LongCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd >= lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd + lIOB.A3P3Current.PEnd ? "+" : "-";
        }
        private void PreCrisisFinancialStabilityInit(LiquidityIndicatorsOfBalance lIOB)
        {
            PreCrisisFinancialStability.Number = "3.";
            PreCrisisFinancialStability.CurrentBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd + lIOB.A3P3Bace.AEnd >= lIOB.A1P1Bace.PEnd ? "+" : "-";
            PreCrisisFinancialStability.CurrentCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd + lIOB.A3P3Current.AEnd >= lIOB.A1P1Current.PEnd ? "+" : "-";
            PreCrisisFinancialStability.ShortBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd + lIOB.A3P3Bace.AEnd >= lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd ? "+" : "-";
            PreCrisisFinancialStability.ShortCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd + lIOB.A3P3Current.AEnd >= lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd ? "+" : "-";
            PreCrisisFinancialStability.LongBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd + lIOB.A3P3Bace.AEnd >= lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd + lIOB.A3P3Bace.PEnd ? "+" : "-";
            PreCrisisFinancialStability.LongCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd + lIOB.A3P3Current.AEnd >= lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd + lIOB.A3P3Current.PEnd ? "+" : "-";
        }

        private void CrisisFinancialStabilityInit(LiquidityIndicatorsOfBalance lIOB)
        {
            CrisisFinancialStability.Number = "4.";
            CrisisFinancialStability.CurrentBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd + lIOB.A3P3Bace.AEnd < lIOB.A1P1Bace.PEnd ? "+" : "-";
            CrisisFinancialStability.CurrentCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd + lIOB.A3P3Current.AEnd < lIOB.A1P1Current.PEnd ? "+" : "-";
            CrisisFinancialStability.ShortBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd + lIOB.A3P3Bace.AEnd < lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd ? "+" : "-";
            CrisisFinancialStability.ShortCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd + lIOB.A3P3Current.AEnd < lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd ? "+" : "-";
            CrisisFinancialStability.LongBVal = lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd + lIOB.A3P3Bace.AEnd < lIOB.A1P1Bace.PEnd + lIOB.A2P2Bace.PEnd + lIOB.A3P3Bace.PEnd ? "+" : "-";
            CrisisFinancialStability.LongCVal = lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd + lIOB.A3P3Current.AEnd < lIOB.A1P1Current.PEnd + lIOB.A2P2Current.PEnd + lIOB.A3P3Current.PEnd ? "+" : "-";
        }
    }
}
