using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class CalculationOfIndicatorsOfEfficiencyOfUseOfFixedAssets
    {
        public TwoYearsCalculationData ProceedsFromSales { get; private set; } = new();
        public TwoYearsCalculationData ProfitFromOperatingActivities { get; private set; } = new();
        public TwoYearsCalculationData AverageAnnualCostOfFixedAssets { get; private set; } = new();
        public TwoYearsCalculationData ReturnOnFixedAssets { get; private set; } = new();
        public TwoYearsCalculationData ProfitabilityOnFixedAssets { get; private set; } = new();
        public TwoYearsCalculationData IntegratedIndicatorOnFixedAssets { get; private set; } = new();

        public CalculationOfIndicatorsOfEfficiencyOfUseOfFixedAssets(AFSModel model) => Init(model);

        private void Init(AFSModel model)
        {
            ProceedsFromSalesInit(model);
            ProfitFromOperatingActivitiesInit(model);
            AverageAnnualCostOfFixedAssetsInit(model);
            ReturnOnFixedAssetsInit();
            ProfitabilityOnFixedAssetsInit();
            IntegratedIndicatorOnFixedAssetsInit();
        }
        private void ProceedsFromSalesInit(AFSModel model)
        {
            ProceedsFromSales.Number = "1.";
            ProceedsFromSales.BaseYear = model.F2Base.F2000.Current;
            ProceedsFromSales.CurrentYear = model.F2Current.F2000.Current;
        }
        private void ProfitFromOperatingActivitiesInit(AFSModel model)
        {
            ProfitFromOperatingActivities.Number = "2.";
            ProfitFromOperatingActivities.BaseYear = model.F2Base.GetF2190Current();
            ProfitFromOperatingActivities.CurrentYear = model.F2Current.GetF2190Current();
        }
        private void AverageAnnualCostOfFixedAssetsInit(AFSModel model)
        {
            AverageAnnualCostOfFixedAssets.Number = "3.";
            AverageAnnualCostOfFixedAssets.BaseYear = (model.F1Base.GetF1010Begin() + model.F1Base.GetF1010End()) / 2;
            AverageAnnualCostOfFixedAssets.CurrentYear = (model.F1Current.GetF1010Begin() + model.F1Current.GetF1010End()) / 2;
        }
        private void ReturnOnFixedAssetsInit()
        {
            ReturnOnFixedAssets.Number = "4.";
            ReturnOnFixedAssets.BaseYear = ProceedsFromSales.BaseYear / AverageAnnualCostOfFixedAssets.BaseYear;
            ReturnOnFixedAssets.CurrentYear = ProceedsFromSales.CurrentYear / AverageAnnualCostOfFixedAssets.CurrentYear;
        }
        private void ProfitabilityOnFixedAssetsInit()
        {
            ProfitabilityOnFixedAssets.Number = "5.";
            ProfitabilityOnFixedAssets.BaseYear = ProfitFromOperatingActivities.BaseYear / AverageAnnualCostOfFixedAssets.BaseYear * 100;
            ProfitabilityOnFixedAssets.CurrentYear = ProfitFromOperatingActivities.CurrentYear / AverageAnnualCostOfFixedAssets.CurrentYear * 100;
        }

        private void IntegratedIndicatorOnFixedAssetsInit()
        {
            IntegratedIndicatorOnFixedAssets.Number = "6.";
            IntegratedIndicatorOnFixedAssets.BaseYear = Math.Sqrt(ReturnOnFixedAssets.BaseYear * ProfitabilityOnFixedAssets.BaseYear / 100);
            IntegratedIndicatorOnFixedAssets.CurrentYear = Math.Sqrt(ReturnOnFixedAssets.CurrentYear * ProfitabilityOnFixedAssets.CurrentYear / 100);
        }
    }
}
