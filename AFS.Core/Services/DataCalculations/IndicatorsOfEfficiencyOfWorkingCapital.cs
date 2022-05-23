using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class IndicatorsOfEfficiencyOfWorkingCapital
    {
        public TwoYearsCalculationData NetIncomeFromSales { get; private set; } = new();
        public TwoYearsCalculationData AverageWorkingCapitalBalances { get; private set; } = new();
        public TwoYearsCalculationData NetProfit { get; private set; } = new();
        public TwoYearsCalculationData NumberOfRevolutionsOfCurrentAssets { get; private set; } = new();
        public TwoYearsCalculationData ProfitabilityOfCurrentAssets { get; private set; } = new();
        public TwoYearsCalculationData IntegratedIndicatorOfEfficiencyOfCurrentAssets { get; private set; } = new();

        public IndicatorsOfEfficiencyOfWorkingCapital(AFSModel model) => Init(model);

        private void Init(AFSModel model)
        {
            IndicatorsOfTurnoverOfCurrentAssets iTCA = new(model);

            NetIncomeFromSalesInit(model);
            AverageWorkingCapitalBalancesInit(iTCA);
            NetProfitInit(model);
            TurnoverOfWorkingCapitalTimesInit(iTCA);
            ProfitabilityOfCurrentAssetsInit();
            IntegratedIndicatorOfEfficiencyOfCurrentAssetsInit();
        }

        private void NetIncomeFromSalesInit(AFSModel model)
        {
            NetIncomeFromSales.Number = "1.";
            NetIncomeFromSales.BaseYear = model.F2Base.F2000.Current;
            NetIncomeFromSales.CurrentYear = model.F2Current.F2000.Current;
        }
        private void AverageWorkingCapitalBalancesInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            AverageWorkingCapitalBalances.Number = "2.";
            AverageWorkingCapitalBalances.BaseYear = iTCA.AverageWorkingCapitalBalances.BaseYear;
            AverageWorkingCapitalBalances.CurrentYear = iTCA.AverageWorkingCapitalBalances.CurrentYear;
        }
        private void NetProfitInit(AFSModel model)
        {
            NetProfit.Number = "3.";
            NetProfit.BaseYear = model.F2Base.GetF2465Current();
            NetProfit.CurrentYear = model.F2Current.GetF2465Current();
        }
        private void TurnoverOfWorkingCapitalTimesInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            NumberOfRevolutionsOfCurrentAssets.Number = "4.";
            NumberOfRevolutionsOfCurrentAssets.BaseYear = iTCA.NumberOfRevolutionsOfCurrentAssets.BaseYear;
            NumberOfRevolutionsOfCurrentAssets.CurrentYear = iTCA.NumberOfRevolutionsOfCurrentAssets.CurrentYear;
        }
        private void ProfitabilityOfCurrentAssetsInit()
        {
            ProfitabilityOfCurrentAssets.Number = "5.";
            ProfitabilityOfCurrentAssets.BaseYear = NetProfit.BaseYear / AverageWorkingCapitalBalances.BaseYear * 100;
            ProfitabilityOfCurrentAssets.CurrentYear = NetProfit.CurrentYear / AverageWorkingCapitalBalances.CurrentYear * 100;
        }
        private void IntegratedIndicatorOfEfficiencyOfCurrentAssetsInit()
        {
            IntegratedIndicatorOfEfficiencyOfCurrentAssets.Number = "6.";
            if (ProfitabilityOfCurrentAssets.BaseYear == 0)
            {
                IntegratedIndicatorOfEfficiencyOfCurrentAssets.BaseYear = Math.Sqrt(NumberOfRevolutionsOfCurrentAssets.BaseYear / 100);
            }
            else
            {
                IntegratedIndicatorOfEfficiencyOfCurrentAssets.BaseYear = Math.Sqrt(NumberOfRevolutionsOfCurrentAssets.BaseYear * ProfitabilityOfCurrentAssets.BaseYear / 100);
            }

            if (ProfitabilityOfCurrentAssets.CurrentYear == 0)
            {
                IntegratedIndicatorOfEfficiencyOfCurrentAssets.CurrentYear = Math.Sqrt(NumberOfRevolutionsOfCurrentAssets.CurrentYear / 100);
            }
            else
            {
                IntegratedIndicatorOfEfficiencyOfCurrentAssets.CurrentYear = Math.Sqrt(NumberOfRevolutionsOfCurrentAssets.CurrentYear * ProfitabilityOfCurrentAssets.CurrentYear / 100);
            }
        }
    }
}