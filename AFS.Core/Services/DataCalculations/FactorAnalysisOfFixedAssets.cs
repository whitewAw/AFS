using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class FactorAnalysisOfFixedAssets
    {
        public TwoYearsCalculationData NetIncomeFromSales { get; private set; } = new();
        public TwoYearsCalculationData AverageNumberOfEmployees { get; private set; } = new();
        public TwoYearsCalculationData ProductivityOfOneAverageEmployee { get; private set; } = new();
        public TwoYearsCalculationData AverageAnnualCostOfFixedAssets { get; private set; } = new();
        public TwoYearsCalculationData LaborCapitalOfOneAverageEmployee { get; private set; } = new();
        public TwoYearsCalculationData ReturnOnFixedAssets { get; private set; } = new();

        public FactorAnalysisOfFixedAssets(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            CalculationOfIndicatorsOfEfficiencyOfUseOfFixedAssets cIEUFA = new(model);

            NetIncomeFromSalesInit(model);
            AverageNumberOfEmployeesInit(model);
            ProductivityOfOneAverageEmployeeInit();
            AverageAnnualCostOfFixedAssetsInit(cIEUFA);
            LaborCapitalOfOneAverageEmployeeInit();
            ReturnOnFixedAssetsInit();
        }
        private void NetIncomeFromSalesInit(AFSModel model)
        {
            NetIncomeFromSales.Number = "1.";
            NetIncomeFromSales.BaseYear = model.F2Base.F2000.Current;
            NetIncomeFromSales.CurrentYear = model.F2Current.F2000.Current;
        }
        private void AverageNumberOfEmployeesInit(AFSModel model)
        {
            AverageNumberOfEmployees.Number = "2.";
            AverageNumberOfEmployees.BaseYear = model.AdditionalInfo.AverageNumberOfEmployeesBase;
            AverageNumberOfEmployees.CurrentYear = model.AdditionalInfo.AverageNumberOfEmployeesCurrent;
        }
        private void ProductivityOfOneAverageEmployeeInit()
        {
            ProductivityOfOneAverageEmployee.Number = "3.";
            ProductivityOfOneAverageEmployee.BaseYear = NetIncomeFromSales.BaseYear / AverageNumberOfEmployees.BaseYear;
            ProductivityOfOneAverageEmployee.CurrentYear = NetIncomeFromSales.CurrentYear / AverageNumberOfEmployees.CurrentYear;
        }

        private void AverageAnnualCostOfFixedAssetsInit(CalculationOfIndicatorsOfEfficiencyOfUseOfFixedAssets cIEUFA)
        {
            AverageAnnualCostOfFixedAssets.Number = "4.";
            AverageAnnualCostOfFixedAssets.BaseYear = cIEUFA.AverageAnnualCostOfFixedAssets.BaseYear;
            AverageAnnualCostOfFixedAssets.CurrentYear = cIEUFA.AverageAnnualCostOfFixedAssets.CurrentYear;
        }

        private void LaborCapitalOfOneAverageEmployeeInit()
        {
            LaborCapitalOfOneAverageEmployee.Number = "5.";
            LaborCapitalOfOneAverageEmployee.BaseYear = AverageAnnualCostOfFixedAssets.BaseYear / AverageNumberOfEmployees.BaseYear;
            LaborCapitalOfOneAverageEmployee.CurrentYear = AverageAnnualCostOfFixedAssets.CurrentYear / AverageNumberOfEmployees.CurrentYear;
        }

        private void ReturnOnFixedAssetsInit()
        {
            ReturnOnFixedAssets.Number = "6.";
            ReturnOnFixedAssets.BaseYear = NetIncomeFromSales.BaseYear / AverageAnnualCostOfFixedAssets.BaseYear;
            ReturnOnFixedAssets.CurrentYear = NetIncomeFromSales.CurrentYear / AverageAnnualCostOfFixedAssets.CurrentYear;
        }
    }
}