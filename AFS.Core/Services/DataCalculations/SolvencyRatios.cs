using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class SolvencyRatios
    {
        public SolvencyRatiosRow OverallLiquidityRatio { get; private set; } = new();
        public SolvencyRatiosRow AbsoluteLiquidityRatio { get; private set; } = new();
        public SolvencyRatiosRow IntermediateCoverageRatio { get; private set; } = new();
        public SolvencyRatiosRow CurrentLiquidityFactor { get; private set; } = new();
        public SolvencyRatiosRow SolvencyRecoveryRatio { get; private set; } = new();
        public SolvencyRatiosRow SolvencyLossRatio { get; private set; } = new();

        public SolvencyRatios(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            LiquidityIndicatorsOfBalance lIOB = new(model);
            OverallLiquidityRatioInit(lIOB);
            AbsoluteLiquidityRatioInit(model);
            IntermediateCoverageRatioInit(model, lIOB);
            CurrentLiquidityFactorInit(model);
            SolvencyRecoveryRatioInit();
            SolvencyLossRatioInit();
        }
        private void OverallLiquidityRatioInit(LiquidityIndicatorsOfBalance lIOB)
        {
            OverallLiquidityRatio.Number = "1.";
            OverallLiquidityRatio.BaseBegin = (lIOB.A1P1Bace.ABegin + 0.5 * lIOB.A2P2Bace.ABegin + 0.3 * lIOB.A3P3Bace.ABegin) / (lIOB.A1P1Bace.PBegin + 0.5 * lIOB.A2P2Bace.PBegin + 0.3 * lIOB.A3P3Bace.PBegin);
            OverallLiquidityRatio.BaseEnd = (lIOB.A1P1Bace.AEnd + 0.5 * lIOB.A2P2Bace.AEnd + 0.3 * lIOB.A3P3Bace.AEnd) / (lIOB.A1P1Bace.PEnd + 0.5 * lIOB.A2P2Bace.PEnd + 0.3 * lIOB.A3P3Bace.PEnd);
            OverallLiquidityRatio.CurrentBegin = (lIOB.A1P1Current.ABegin + 0.5 * lIOB.A2P2Current.ABegin + 0.3 * lIOB.A3P3Current.ABegin) / (lIOB.A1P1Current.PBegin + 0.5 * lIOB.A2P2Current.PBegin + 0.3 * lIOB.A3P3Current.PBegin);
            OverallLiquidityRatio.CurrentEnd = (lIOB.A1P1Current.AEnd + 0.5 * lIOB.A2P2Current.AEnd + 0.3 * lIOB.A3P3Current.AEnd) / (lIOB.A1P1Current.PEnd + 0.5 * lIOB.A2P2Current.PEnd + 0.3 * lIOB.A3P3Current.PEnd);
        }
        private void AbsoluteLiquidityRatioInit(AFSModel model)
        {
            AbsoluteLiquidityRatio.Number = "2.";
            AbsoluteLiquidityRatio.BaseBegin = model.F1Base.GetAccountsMoney(true) / (model.F1Base.GetF1695Begin() - model.F1Base.F1660.Begin - model.F1Base.F1665.Begin + model.F1Base.F1700.Begin);
            AbsoluteLiquidityRatio.BaseEnd = model.F1Base.GetAccountsMoney(false) / (model.F1Base.GetF1695End() - model.F1Base.F1660.End - model.F1Base.F1665.End + model.F1Base.F1700.End);
            AbsoluteLiquidityRatio.CurrentBegin = model.F1Current.GetAccountsMoney(true) / (model.F1Current.GetF1695Begin() - model.F1Current.F1660.Begin - model.F1Current.F1665.Begin + model.F1Current.F1700.Begin);
            AbsoluteLiquidityRatio.CurrentEnd = model.F1Current.GetAccountsMoney(false) / (model.F1Current.GetF1695End() - model.F1Current.F1660.End - model.F1Current.F1665.End + model.F1Current.F1700.End);
        }
        private void IntermediateCoverageRatioInit(AFSModel model, LiquidityIndicatorsOfBalance lIOB)
        {
            IntermediateCoverageRatio.Number = "3.";
            IntermediateCoverageRatio.BaseBegin = (lIOB.A1P1Bace.ABegin + lIOB.A2P2Bace.ABegin) / (model.F1Base.GetF1695Begin() - model.F1Base.F1660.Begin - model.F1Base.F1665.Begin + model.F1Base.F1700.Begin);
            IntermediateCoverageRatio.BaseEnd = (lIOB.A1P1Bace.AEnd + lIOB.A2P2Bace.AEnd) / (model.F1Base.GetF1695End() - model.F1Base.F1660.End - model.F1Base.F1665.End + model.F1Base.F1700.End);
            IntermediateCoverageRatio.CurrentBegin = (lIOB.A1P1Current.ABegin + lIOB.A2P2Current.ABegin) / (model.F1Current.GetF1695Begin() - model.F1Current.F1660.Begin - model.F1Current.F1665.Begin + model.F1Current.F1700.Begin);
            IntermediateCoverageRatio.CurrentEnd = (lIOB.A1P1Current.AEnd + lIOB.A2P2Current.AEnd) / (model.F1Current.GetF1695End() - model.F1Current.F1660.End - model.F1Current.F1665.End + model.F1Current.F1700.End);
        }
        private void CurrentLiquidityFactorInit(AFSModel model)
        {
            CurrentLiquidityFactor.Number = "4.";
            CurrentLiquidityFactor.BaseBegin = (model.F1Base.GetF1195Begin() + model.F1Base.F1200.Begin - model.F1Base.F1170.Begin) / (model.F1Base.GetF1695Begin() - model.F1Base.F1660.Begin - model.F1Base.F1665.Begin + model.F1Base.F1700.Begin);
            CurrentLiquidityFactor.BaseEnd = (model.F1Base.GetF1195End() + model.F1Base.F1200.End - model.F1Base.F1170.End) / (model.F1Base.GetF1695End() - model.F1Base.F1660.End - model.F1Base.F1665.End + model.F1Base.F1700.End);
            CurrentLiquidityFactor.CurrentBegin = (model.F1Current.GetF1195Begin() + model.F1Current.F1200.Begin - model.F1Current.F1170.Begin) / (model.F1Current.GetF1695Begin() - model.F1Current.F1660.Begin - model.F1Current.F1665.Begin + model.F1Current.F1700.Begin);
            CurrentLiquidityFactor.CurrentEnd = (model.F1Current.GetF1195End() + model.F1Current.F1200.End - model.F1Current.F1170.End) / (model.F1Current.GetF1695End() - model.F1Current.F1660.End - model.F1Current.F1665.End + model.F1Current.F1700.End);
        }
        private void SolvencyRecoveryRatioInit()
        {
            SolvencyRecoveryRatio.Number = "5.";
            SolvencyRecoveryRatio.BaseEnd = (CurrentLiquidityFactor.BaseEnd + 0.5 * (CurrentLiquidityFactor.BaseEnd - CurrentLiquidityFactor.BaseBegin)) / 2;
            SolvencyRecoveryRatio.CurrentEnd = (CurrentLiquidityFactor.CurrentEnd + 0.5 * (CurrentLiquidityFactor.CurrentEnd - CurrentLiquidityFactor.CurrentBegin)) / 2;
        }

        private void SolvencyLossRatioInit()
        {
            SolvencyLossRatio.Number = "6.";
            SolvencyLossRatio.BaseEnd = (CurrentLiquidityFactor.BaseEnd + 0.25 * (CurrentLiquidityFactor.BaseEnd - CurrentLiquidityFactor.BaseBegin)) / 2;
            SolvencyLossRatio.CurrentEnd = (CurrentLiquidityFactor.CurrentEnd + 0.25 * (CurrentLiquidityFactor.CurrentEnd - CurrentLiquidityFactor.CurrentBegin)) / 2;
        }
    }
}