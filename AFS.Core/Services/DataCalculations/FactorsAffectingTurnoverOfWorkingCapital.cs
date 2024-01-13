using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class FactorsAffectingTurnoverOfWorkingCapital
    {
        public FactorsAffectingTurnover Money { get; private set; } = new();
        public FactorsAffectingTurnover Receivables { get; private set; } = new();
        public FactorsAffectingTurnover MaterialValues { get; private set; } = new();
        public FactorsAffectingTurnover TotalWorkingCapital { get; private set; } = new();
        public FactorsAffectingTurnover OneDaySalesRevenue { get; private set; } = new();

        public FactorsAffectingTurnoverOfWorkingCapital(AFSModel model) => Init(model);

        private void Init(AFSModel model)
        {
            IndicatorsOfTurnoverOfCurrentAssets iTCA = new(model);
            MoneyInit(iTCA);
            ReceivablesInit(iTCA);
            TangiblesInit(iTCA);
            TotalCurrentAssetsInit(iTCA);
            OneDaySalesRevenueInit(iTCA);
        }

        private void MoneyInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            Money.Number = "1.";
            Money.BaseYear = iTCA.MoneyTurnover.BaseYear;
            Money.CurrentYear = iTCA.MoneyTurnover.CurrentYear;
            Money.AdjustedIndicator = iTCA.AverageFromMoney.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void ReceivablesInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            Receivables.Number = "2.";
            Receivables.BaseYear = iTCA.ReceivablesTurnover.BaseYear;
            Receivables.CurrentYear = iTCA.ReceivablesTurnover.CurrentYear;
            Receivables.AdjustedIndicator = iTCA.AverageFromReceivables.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void TangiblesInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            MaterialValues.Number = "3.";
            MaterialValues.BaseYear = iTCA.MaterialValuesTurnover.BaseYear;
            MaterialValues.CurrentYear = iTCA.MaterialValuesTurnover.CurrentYear;
            MaterialValues.AdjustedIndicator = iTCA.AverageFromMaterialValues.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void TotalCurrentAssetsInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            TotalWorkingCapital.Number = "4.";
            TotalWorkingCapital.BaseYear = iTCA.TurnoverOfWorkingCapital.BaseYear;
            TotalWorkingCapital.CurrentYear = iTCA.TurnoverOfWorkingCapital.CurrentYear;
            TotalWorkingCapital.AdjustedIndicator = iTCA.AverageWorkingCapitalBalances.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void OneDaySalesRevenueInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            OneDaySalesRevenue.Number = "5.";
            OneDaySalesRevenue.BaseYear = iTCA.OneDaySalesRevenue.BaseYear;
            OneDaySalesRevenue.CurrentYear = iTCA.OneDaySalesRevenue.CurrentYear;
        }
    }
}