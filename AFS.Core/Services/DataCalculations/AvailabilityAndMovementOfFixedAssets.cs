using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class AvailabilityAndMovementOfFixedAssets
    {
        public FixedAssets Base { get; private set; } = new();
        public FixedAssets Current { get; private set; } = new();
        public AvailabilityAndMovementOfFixedAssets(AFSModel model) => Init(model);

        private void Init(AFSModel model)
        {
            BaseInit(model);
            CurrentInit(model);
        }
        private void BaseInit(AFSModel model)
        {
            Base.BalanceAtBeginInitialCost = model.F1Base.F1011.Begin;
            Base.Received = model.AdditionalInfo.FixedAssetsInfoBase.ReceivedFixedAssets;
            Base.ReceivedNew = model.AdditionalInfo.FixedAssetsInfoBase.ReceivedNewFixedAssets;
            Base.Left = model.AdditionalInfo.FixedAssetsInfoBase.LeftFixedAssets;
            Base.Liquidated = model.AdditionalInfo.FixedAssetsInfoBase.LiquidatedFixedAssets;
            Base.BalanceAtEndInitialCost = model.F1Base.F1011.End;
            Base.BalanceAtEndMinusDepreciation = model.F1Base.GetF1010End();
        }
        private void CurrentInit(AFSModel model)
        {
            Current.BalanceAtBeginInitialCost = model.F1Current.F1011.Begin;
            Current.Received = model.AdditionalInfo.FixedAssetsInfoCurrent.ReceivedFixedAssets;
            Current.ReceivedNew = model.AdditionalInfo.FixedAssetsInfoCurrent.ReceivedNewFixedAssets;
            Current.Left = model.AdditionalInfo.FixedAssetsInfoCurrent.LeftFixedAssets;
            Current.Liquidated = model.AdditionalInfo.FixedAssetsInfoCurrent.LiquidatedFixedAssets;
            Current.BalanceAtEndInitialCost = model.F1Current.F1011.End;
            Current.BalanceAtEndMinusDepreciation = model.F1Current.GetF1010End();
        }
    }
}