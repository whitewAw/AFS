using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class IndicatorsOfTurnoverOfCurrentAssets
    {
        public TwoYearsCalculationData AverageWorkingCapitalBalances { get; private set; } = new();
        public TwoYearsCalculationData AverageFromMoney { get; private set; } = new();
        public TwoYearsCalculationData AverageFromReceivables { get; private set; } = new();
        public TwoYearsCalculationData AverageFromMaterialValues { get; private set; } = new();
        public TwoYearsCalculationData NetIncomeFromSales { get; private set; } = new();
        public TwoYearsCalculationData OneDaySalesRevenue { get; private set; } = new();
        public TwoYearsCalculationData TurnoverOfWorkingCapital { get; private set; } = new();
        public TwoYearsCalculationData MoneyTurnover { get; private set; } = new();
        public TwoYearsCalculationData ReceivablesTurnover { get; private set; } = new();
        public TwoYearsCalculationData MaterialValuesTurnover { get; private set; } = new();
        public TwoYearsCalculationData NumberOfRevolutionsOfCurrentAssets { get; private set; } = new();
        public TwoYearsCalculationData RevolutionsFromMoney { get; private set; } = new();
        public TwoYearsCalculationData RevolutionsFromReceivables { get; private set; } = new();
        public TwoYearsCalculationData RevolutionsFromTangibleAssets { get; private set; } = new();
        public TwoYearsCalculationData FixingRatioOfCurrentAssets { get; private set; } = new();
        public TwoYearsCalculationData ReleaseOrLackOfCurrentAssetsDueTurnover { get; private set; } = new();

        public IndicatorsOfTurnoverOfCurrentAssets(AFSModel model) => Init(model);

        private void Init(AFSModel model)
        {
            IndicatorsOfTurnoverOfCurrentAssetsInit(model);
            AverageFromMoneyInit(model);
            AverageFromReceivablesInit(model);
            AverageFromTangibleAssetsInit(model);
            NetIncomeFromSalesInit(model);
            OneDaySalesRevenueInit();
            TurnoverOfWorkingCapitalInit();
            MoneyTurnoverInit();
            ReceivablesTurnoverInit();
            MaterialValuesTurnoverInit();
            NumberOfRevolutionsOfCurrentAssetsInit();
            RevolutionsFromMoneyInit();
            RevolutionsFromReceivablesInit();
            RevolutionsFromTangibleAssetsInit();
            FixingRatioOfCurrentAssetsInit();
            ReleaseOrLackOfCurrentAssetsDueTurnoverInit();
        }

        private void IndicatorsOfTurnoverOfCurrentAssetsInit(AFSModel model)
        {
            AverageWorkingCapitalBalances.Number = "1.";
            AverageWorkingCapitalBalances.BaseYear = (model.F1Base.GetF1195Begin() + model.F1Base.GetF1195End()) / 2;
            AverageWorkingCapitalBalances.CurrentYear = (model.F1Current.GetF1195Begin() + model.F1Current.GetF1195End()) / 2;
        }
        private void AverageFromMoneyInit(AFSModel model)
        {
            AverageFromMoney.Number = "1.1.";
            AverageFromMoney.BaseYear = (model.F1Base.GetAccountsMoney(true) + model.F1Base.GetAccountsMoney(false)) / 2;
            AverageFromMoney.CurrentYear = (model.F1Current.F1160.Begin + model.F1Current.F1165.Begin + model.F1Current.F1160.End + model.F1Current.F1165.End) / 2;
        }
        private void AverageFromReceivablesInit(AFSModel model)
        {
            AverageFromReceivables.Number = "1.2.";
            AverageFromReceivables.BaseYear = (model.F1Base.GetAccountsReceivable(true) + model.F1Base.GetAccountsReceivable(false)) / 2;
            AverageFromReceivables.CurrentYear = (model.F1Current.GetAccountsReceivable(true) + model.F1Current.GetAccountsReceivable(false)) / 2;
        }
        private void AverageFromTangibleAssetsInit(AFSModel model)
        {
            AverageFromMaterialValues.Number = "1.3.";
            AverageFromMaterialValues.BaseYear = (model.F1Base.GetAccountsTangibleAssets(true) + model.F1Base.GetAccountsTangibleAssets(false)) / 2;
            AverageFromMaterialValues.CurrentYear = (model.F1Current.GetF1100Begin() + model.F1Current.F1110.Begin + model.F1Current.GetF1100End() + model.F1Current.F1110.End) / 2;
        }
        private void NetIncomeFromSalesInit(AFSModel model)
        {
            NetIncomeFromSales.Number = "2.";
            NetIncomeFromSales.BaseYear = model.F2Base.F2000.Current;
            NetIncomeFromSales.CurrentYear = model.F2Current.F2000.Current;
        }
        private void OneDaySalesRevenueInit()
        {
            OneDaySalesRevenue.Number = "2.1.";
            OneDaySalesRevenue.BaseYear = NetIncomeFromSales.BaseYear / AFSConstraints.DurationOAnalyzedPeriod;
            OneDaySalesRevenue.CurrentYear = NetIncomeFromSales.CurrentYear / AFSConstraints.DurationOAnalyzedPeriod;
        }
        private void TurnoverOfWorkingCapitalInit()
        {
            TurnoverOfWorkingCapital.Number = "3.";
            TurnoverOfWorkingCapital.BaseYear = AverageWorkingCapitalBalances.BaseYear / OneDaySalesRevenue.BaseYear;
            TurnoverOfWorkingCapital.CurrentYear = AverageWorkingCapitalBalances.CurrentYear / OneDaySalesRevenue.CurrentYear;
        }
        private void MoneyTurnoverInit()
        {
            MoneyTurnover.Number = "3.1.";
            MoneyTurnover.BaseYear = AverageFromMoney.BaseYear / OneDaySalesRevenue.BaseYear;
            MoneyTurnover.CurrentYear = AverageFromMoney.CurrentYear / OneDaySalesRevenue.CurrentYear;
        }
        private void ReceivablesTurnoverInit()
        {
            ReceivablesTurnover.Number = "3.2.";
            ReceivablesTurnover.BaseYear = AverageFromReceivables.BaseYear / OneDaySalesRevenue.BaseYear;
            ReceivablesTurnover.CurrentYear = AverageFromReceivables.CurrentYear / OneDaySalesRevenue.CurrentYear;
        }
        private void MaterialValuesTurnoverInit()
        {
            MaterialValuesTurnover.Number = "3.3.";
            MaterialValuesTurnover.BaseYear = AverageFromMaterialValues.BaseYear / OneDaySalesRevenue.BaseYear;
            MaterialValuesTurnover.CurrentYear = AverageFromMaterialValues.CurrentYear / OneDaySalesRevenue.CurrentYear;
        }
        private void NumberOfRevolutionsOfCurrentAssetsInit()
        {
            NumberOfRevolutionsOfCurrentAssets.Number = "4.";
            NumberOfRevolutionsOfCurrentAssets.BaseYear = NetIncomeFromSales.BaseYear / AverageWorkingCapitalBalances.BaseYear;
            NumberOfRevolutionsOfCurrentAssets.CurrentYear = NetIncomeFromSales.CurrentYear / AverageWorkingCapitalBalances.CurrentYear;
        }
        private void RevolutionsFromMoneyInit()
        {
            RevolutionsFromMoney.Number = "4.1.";
            RevolutionsFromMoney.BaseYear = NetIncomeFromSales.BaseYear / AverageFromMoney.BaseYear;
            RevolutionsFromMoney.CurrentYear = NetIncomeFromSales.CurrentYear / AverageFromMoney.CurrentYear;
        }
        private void RevolutionsFromReceivablesInit()
        {
            RevolutionsFromReceivables.Number = "4.2.";
            RevolutionsFromReceivables.BaseYear = NetIncomeFromSales.BaseYear / AverageFromReceivables.BaseYear;
            RevolutionsFromReceivables.CurrentYear = NetIncomeFromSales.CurrentYear / AverageFromReceivables.CurrentYear;
        }
        private void RevolutionsFromTangibleAssetsInit()
        {
            RevolutionsFromTangibleAssets.Number = "4.3.";
            RevolutionsFromTangibleAssets.BaseYear = NetIncomeFromSales.BaseYear / AverageFromMaterialValues.BaseYear;
            RevolutionsFromTangibleAssets.CurrentYear = NetIncomeFromSales.CurrentYear / AverageFromMaterialValues.CurrentYear;
        }
        private void FixingRatioOfCurrentAssetsInit()
        {
            FixingRatioOfCurrentAssets.Number = "5.";
            FixingRatioOfCurrentAssets.BaseYear = AverageWorkingCapitalBalances.BaseYear / NetIncomeFromSales.BaseYear;
            FixingRatioOfCurrentAssets.CurrentYear = AverageWorkingCapitalBalances.CurrentYear / NetIncomeFromSales.CurrentYear;
        }
        private void ReleaseOrLackOfCurrentAssetsDueTurnoverInit()
        {
            ReleaseOrLackOfCurrentAssetsDueTurnover.Number = "6.";
            ReleaseOrLackOfCurrentAssetsDueTurnover.CurrentYear = OneDaySalesRevenue.CurrentYear * TurnoverOfWorkingCapital.Deviations;
        }
    }
}