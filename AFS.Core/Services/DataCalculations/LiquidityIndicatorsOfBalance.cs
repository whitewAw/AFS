using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class LiquidityIndicatorsOfBalance
    {
        public LiquidityIndicatorsOfBalanceRow A1P1Bace { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A2P2Bace { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A3P3Bace { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A4P4Bace { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow TotalBace { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A1P1Current { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A2P2Current { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A3P3Current { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow A4P4Current { get; private set; } = new();
        public LiquidityIndicatorsOfBalanceRow TotalCurrent { get; private set; } = new();

        public LiquidityIndicatorsOfBalance(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            A1P1BaceInit(model);
            A2P2BaceInit(model);
            A3P3BaceInit(model);
            A4P4BaceInit(model);
            TotalBaceInit();

            A1P1CurrentInit(model);
            A2P2CurrentInit(model);
            A3P3CurrentInit(model);
            A4P4CurrentInit(model);
            TotalCurrentInit();
        }
        private void A1P1BaceInit(AFSModel model)
        {
            A1P1Bace.ABegin = model.F1Base.F1160.Begin + model.F1Base.F1165.Begin;
            A1P1Bace.AEnd = model.F1Base.F1160.End + model.F1Base.F1165.End;
            A1P1Bace.PBegin = model.F1Base.GetF1695Begin() + model.F1Base.F1700.Begin - model.F1Base.F1600.Begin - model.F1Base.F1610.Begin - model.F1Base.F1660.Begin;
            A1P1Bace.PEnd = model.F1Base.GetF1695End() + model.F1Base.F1700.End - model.F1Base.F1600.End - model.F1Base.F1610.End - model.F1Base.F1660.End;
        }
        private void A2P2BaceInit(AFSModel model)
        {
            A2P2Bace.ABegin = model.F1Base.GetAccountsReceivable(true) + model.F1Base.F1190.Begin;
            A2P2Bace.AEnd = model.F1Base.GetAccountsReceivable(false) + model.F1Base.F1190.End;
            A2P2Bace.PBegin = model.F1Base.F1600.Begin + model.F1Base.F1610.Begin + model.F1Base.F1660.Begin;
            A2P2Bace.PEnd = model.F1Base.F1600.End + model.F1Base.F1610.End + model.F1Base.F1660.End;
        }
        private void A3P3BaceInit(AFSModel model)
        {
            A3P3Bace.ABegin = model.F1Base.GetAccountsTangibleAssets(true) + model.F1Base.F1170.Begin + model.F1Base.F1030.Begin + model.F1Base.F1035.Begin;
            A3P3Bace.AEnd = model.F1Base.GetAccountsTangibleAssets(false) + model.F1Base.F1170.End + model.F1Base.F1030.End + model.F1Base.F1035.End;
            A3P3Bace.PBegin = model.F1Base.GetF1595Begin() - model.F1Base.GetProvisionOfNextCostsAndPayments(true);
            A3P3Bace.PEnd = model.F1Base.GetF1595End() - model.F1Base.GetProvisionOfNextCostsAndPayments(false);
        }
        private void A4P4BaceInit(AFSModel model)
        {
            A4P4Bace.ABegin = model.F1Base.GetF1095Begin() - model.F1Base.F1030.Begin - model.F1Base.F1035.Begin;
            A4P4Bace.AEnd = model.F1Base.GetF1095End() - model.F1Base.F1030.End - model.F1Base.F1035.End;
            A4P4Bace.PBegin = model.F1Base.GetF1495Begin() + model.F1Base.GetProvisionOfNextCostsAndPayments(true);
            A4P4Bace.PEnd = model.F1Base.GetF1495End() + model.F1Base.GetProvisionOfNextCostsAndPayments(false);
        }
        private void TotalBaceInit()
        {
            TotalBace.ABegin = A1P1Bace.ABegin + A2P2Bace.ABegin + A3P3Bace.ABegin + A4P4Bace.ABegin;
            TotalBace.AEnd = A1P1Bace.AEnd + A2P2Bace.AEnd + A3P3Bace.AEnd + A4P4Bace.AEnd;
            TotalBace.PBegin = A1P1Bace.PBegin + A2P2Bace.PBegin + A3P3Bace.PBegin + A4P4Bace.PBegin;
            TotalBace.PEnd = A1P1Bace.PEnd + A2P2Bace.PEnd + A3P3Bace.PEnd + A4P4Bace.PEnd;
        }

        private void A1P1CurrentInit(AFSModel model)
        {
            A1P1Current.ABegin = model.F1Current.F1160.Begin + model.F1Current.F1165.Begin;
            A1P1Current.AEnd = model.F1Current.F1160.End + model.F1Current.F1165.End;
            A1P1Current.PBegin = model.F1Current.GetF1695Begin() + model.F1Current.F1700.Begin - model.F1Current.F1600.Begin - model.F1Current.F1610.Begin - model.F1Current.F1660.Begin;
            A1P1Current.PEnd = model.F1Current.GetF1695End() + model.F1Current.F1700.End - model.F1Current.F1600.End - model.F1Current.F1610.End - model.F1Current.F1660.End;
        }
        private void A2P2CurrentInit(AFSModel model)
        {
            A2P2Current.ABegin = model.F1Current.GetAccountsReceivable(true) + model.F1Current.F1190.Begin;
            A2P2Current.AEnd = model.F1Current.GetAccountsReceivable(false) + model.F1Current.F1190.End;
            A2P2Current.PBegin = model.F1Current.F1600.Begin + model.F1Current.F1610.Begin + model.F1Current.F1660.Begin;
            A2P2Current.PEnd = model.F1Current.F1600.End + model.F1Current.F1610.End + model.F1Current.F1660.End;
        }
        private void A3P3CurrentInit(AFSModel model)
        {
            A3P3Current.ABegin = model.F1Current.GetAccountsTangibleAssets(true) + model.F1Current.F1170.Begin + model.F1Current.F1030.Begin + model.F1Current.F1035.Begin;
            A3P3Current.AEnd = model.F1Current.GetAccountsTangibleAssets(false) + model.F1Current.F1170.End + model.F1Current.F1030.End + model.F1Current.F1035.End;
            A3P3Current.PBegin = model.F1Current.GetF1595Begin() - model.F1Current.GetProvisionOfNextCostsAndPayments(true);
            A3P3Current.PEnd = model.F1Current.GetF1595End() - model.F1Current.GetProvisionOfNextCostsAndPayments(false);
        }
        private void A4P4CurrentInit(AFSModel model)
        {
            A4P4Current.ABegin = model.F1Current.GetF1095Begin() - model.F1Current.F1030.Begin - model.F1Current.F1035.Begin;
            A4P4Current.AEnd = model.F1Current.GetF1095End() - model.F1Current.F1030.End - model.F1Current.F1035.End;
            A4P4Current.PBegin = model.F1Current.GetF1495Begin() + model.F1Current.GetProvisionOfNextCostsAndPayments(true);
            A4P4Current.PEnd = model.F1Current.GetF1495End() + model.F1Current.GetProvisionOfNextCostsAndPayments(false);
        }
        private void TotalCurrentInit()
        {
            TotalCurrent.ABegin = A1P1Current.ABegin + A2P2Current.ABegin + A3P3Current.ABegin + A4P4Current.ABegin;
            TotalCurrent.AEnd = A1P1Current.AEnd + A2P2Current.AEnd + A3P3Current.AEnd + A4P4Current.AEnd;
            TotalCurrent.PBegin = A1P1Current.PBegin + A2P2Current.PBegin + A3P3Current.PBegin + A4P4Current.PBegin;
            TotalCurrent.PEnd = A1P1Current.PEnd + A2P2Current.PEnd + A3P3Current.PEnd + A4P4Current.PEnd;
        }
    }
}
