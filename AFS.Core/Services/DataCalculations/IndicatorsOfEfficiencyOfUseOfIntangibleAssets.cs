using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class IndicatorsOfEfficiencyOfUseOfIntangibleAssets
    {
        public TwoYearsCalculationData NetIncomeFromSales { get; private set; } = new();
        public TwoYearsCalculationData AverageAnnualCostOfIntangibleAssets { get; private set; } = new();
        public TwoYearsCalculationData ReturnOnIntangibleAssets { get; private set; } = new();
        public TwoYearsCalculationData CapitalIntensityOfProducts { get; private set; } = new();

        public IndicatorsOfEfficiencyOfUseOfIntangibleAssets(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            NetIncomeFromSalesInit(model);
            AverageAnnualCostOfIntangibleAssetsInit(model);
            ReturnOnIntangibleAssetsInit();
            CapitalIntensityOfProductsInit();
        }
        private void NetIncomeFromSalesInit(AFSModel model)
        {
            NetIncomeFromSales.Number = "1.";
            NetIncomeFromSales.BaseYear = model.F2Base.F2000.Current;
            NetIncomeFromSales.CurrentYear = model.F2Current.F2000.Current;
        }
        private void AverageAnnualCostOfIntangibleAssetsInit(AFSModel model)
        {
            AverageAnnualCostOfIntangibleAssets.Number = "2.";
            AverageAnnualCostOfIntangibleAssets.BaseYear = (model.F1Base.GetF1000Begin() + model.F1Base.GetF1000End()) / 2;
            AverageAnnualCostOfIntangibleAssets.CurrentYear = (model.F1Current.GetF1000Begin() + model.F1Current.GetF1000End()) / 2;
        }

        private void ReturnOnIntangibleAssetsInit()
        {
            ReturnOnIntangibleAssets.Number = "3.";
            ReturnOnIntangibleAssets.BaseYear = NetIncomeFromSales.BaseYear / AverageAnnualCostOfIntangibleAssets.BaseYear;
            ReturnOnIntangibleAssets.CurrentYear = NetIncomeFromSales.CurrentYear / AverageAnnualCostOfIntangibleAssets.CurrentYear;
        }
        private void CapitalIntensityOfProductsInit()
        {
            CapitalIntensityOfProducts.Number = "4.";
            CapitalIntensityOfProducts.BaseYear = 1 / ReturnOnIntangibleAssets.BaseYear;
            CapitalIntensityOfProducts.CurrentYear = 1 / ReturnOnIntangibleAssets.CurrentYear;
        }
    }
}