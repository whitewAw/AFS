using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class IndicatorsOfStateAndMovementOfFixedAssets
    {
        public TwoYearsCalculationData CostOfNewFixedAssets { get; private set; } = new();
        public TwoYearsCalculationData InitialCostOfFixedAssetsAtEnd { get; private set; } = new();
        public TwoYearsCalculationData RecoveryRate { get; private set; } = new();
        public TwoYearsCalculationData CostOfLeftFixedAssets { get; private set; } = new();
        public TwoYearsCalculationData InitialCostOfFixedAssetsAtBegin { get; private set; } = new();
        public TwoYearsCalculationData DisposalRate { get; private set; } = new();
        public TwoYearsCalculationData AccruedDepreciationAtBegin { get; private set; } = new();
        public TwoYearsCalculationData AccruedDepreciationAtEnd { get; private set; } = new();
        public TwoYearsCalculationData DepreciationRateOfFixedAssetAtBegin { get; private set; } = new();
        public TwoYearsCalculationData DepreciationRateOfFixedAssetAtEnd { get; private set; } = new();
        public TwoYearsCalculationData SuitabilityRatioForBegin { get; private set; } = new();
        public TwoYearsCalculationData SuitabilityRatioForEnd { get; private set; } = new();

        public IndicatorsOfStateAndMovementOfFixedAssets(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            AvailabilityAndMovementOfFixedAssets aMFA = new(model);

            CostOfNewFixedAssetsInit(aMFA);
            InitialCostOfFixedAssetsAtEndInit(aMFA);
            RecoveryRateInit();
            CostOfLeftFixedAssetsInit(aMFA);
            InitialCostOfFixedAssetsAtBeginInit(aMFA);
            DisposalRateInit();
            AccruedDepreciationAtBeginInit(model);
            AccruedDepreciationAtEndInit(model);
            DepreciationRateOfFixedAssetAtBeginInit();
            DepreciationRateOfFixedAssetAtEndInit();
            SuitabilityRatioForBeginInit();
            SuitabilityRatioForEndInit();
        }
        private void CostOfNewFixedAssetsInit(AvailabilityAndMovementOfFixedAssets aMFA)
        {
            CostOfNewFixedAssets.Number = "1.";
            CostOfNewFixedAssets.BaseYear = aMFA.Base.ReceivedNew;
            CostOfNewFixedAssets.CurrentYear = aMFA.Current.ReceivedNew;
        }
        private void InitialCostOfFixedAssetsAtEndInit(AvailabilityAndMovementOfFixedAssets aMFA)
        {
            InitialCostOfFixedAssetsAtEnd.Number = "2.";
            InitialCostOfFixedAssetsAtEnd.BaseYear = aMFA.Base.BalanceAtEndInitialCost;
            InitialCostOfFixedAssetsAtEnd.CurrentYear = aMFA.Current.BalanceAtEndInitialCost;
        }
        private void RecoveryRateInit()
        {
            RecoveryRate.Number = "3.";
            RecoveryRate.BaseYear = CostOfNewFixedAssets.BaseYear / InitialCostOfFixedAssetsAtEnd.BaseYear;
            RecoveryRate.CurrentYear = CostOfNewFixedAssets.CurrentYear / InitialCostOfFixedAssetsAtEnd.CurrentYear;
        }
        private void CostOfLeftFixedAssetsInit(AvailabilityAndMovementOfFixedAssets aMFA)
        {
            CostOfLeftFixedAssets.Number = "4.";
            CostOfLeftFixedAssets.BaseYear = aMFA.Base.Left;
            CostOfLeftFixedAssets.CurrentYear = aMFA.Current.Left;
        }
        private void InitialCostOfFixedAssetsAtBeginInit(AvailabilityAndMovementOfFixedAssets aMFA)
        {
            InitialCostOfFixedAssetsAtBegin.Number = "5.";
            InitialCostOfFixedAssetsAtBegin.BaseYear = aMFA.Base.BalanceAtBeginInitialCost;
            InitialCostOfFixedAssetsAtBegin.CurrentYear = aMFA.Current.BalanceAtBeginInitialCost;
        }
        private void DisposalRateInit()
        {
            DisposalRate.Number = "6.";
            DisposalRate.BaseYear = CostOfLeftFixedAssets.BaseYear / InitialCostOfFixedAssetsAtBegin.BaseYear;
            DisposalRate.CurrentYear = CostOfLeftFixedAssets.CurrentYear / InitialCostOfFixedAssetsAtBegin.CurrentYear;
        }
        private void AccruedDepreciationAtBeginInit(AFSModel model)
        {
            AccruedDepreciationAtBegin.Number = "7.";
            AccruedDepreciationAtBegin.BaseYear = model.F1Base.F1012.Begin;
            AccruedDepreciationAtBegin.CurrentYear = model.F1Current.F1012.Begin;
        }
        private void AccruedDepreciationAtEndInit(AFSModel model)
        {
            AccruedDepreciationAtEnd.Number = "8.";
            AccruedDepreciationAtEnd.BaseYear = model.F1Base.F1012.End;
            AccruedDepreciationAtEnd.CurrentYear = model.F1Current.F1012.End;
        }
        private void DepreciationRateOfFixedAssetAtBeginInit()
        {
            DepreciationRateOfFixedAssetAtBegin.Number = "9.";
            DepreciationRateOfFixedAssetAtBegin.BaseYear = AccruedDepreciationAtBegin.BaseYear / InitialCostOfFixedAssetsAtBegin.BaseYear;
            DepreciationRateOfFixedAssetAtBegin.CurrentYear = AccruedDepreciationAtBegin.CurrentYear / InitialCostOfFixedAssetsAtBegin.CurrentYear;
        }
        private void DepreciationRateOfFixedAssetAtEndInit()
        {
            DepreciationRateOfFixedAssetAtEnd.Number = "10.";
            DepreciationRateOfFixedAssetAtEnd.BaseYear = AccruedDepreciationAtEnd.BaseYear / InitialCostOfFixedAssetsAtEnd.BaseYear;
            DepreciationRateOfFixedAssetAtEnd.CurrentYear = AccruedDepreciationAtEnd.CurrentYear / InitialCostOfFixedAssetsAtEnd.CurrentYear;
        }
        private void SuitabilityRatioForBeginInit()
        {
            SuitabilityRatioForBegin.Number = "11.";
            SuitabilityRatioForBegin.BaseYear = 1 - DepreciationRateOfFixedAssetAtBegin.BaseYear;
            SuitabilityRatioForBegin.CurrentYear = 1 - DepreciationRateOfFixedAssetAtBegin.CurrentYear;
        }
        private void SuitabilityRatioForEndInit()
        {
            SuitabilityRatioForEnd.Number = "12.";
            SuitabilityRatioForEnd.BaseYear = 1 - DepreciationRateOfFixedAssetAtEnd.BaseYear;
            SuitabilityRatioForEnd.CurrentYear = 1 - DepreciationRateOfFixedAssetAtEnd.CurrentYear;
        }
    }
}
