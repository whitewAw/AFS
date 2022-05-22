using AFS.Core.Model;
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
            Money.BaseYear = iTCA.MoneyTurnover.BaseYear;
            Money.CurrentYear = iTCA.MoneyTurnover.CurrentYear;
            Money.AdjustedIndicator = iTCA.AverageFromMoney.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void ReceivablesInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            Receivables.BaseYear = iTCA.ReceivablesTurnover.BaseYear;
            Receivables.CurrentYear = iTCA.ReceivablesTurnover.CurrentYear;
            Receivables.AdjustedIndicator = iTCA.AverageFromReceivables.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void TangiblesInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            MaterialValues.BaseYear = iTCA.MaterialValuesTurnover.BaseYear;
            MaterialValues.CurrentYear = iTCA.MaterialValuesTurnover.CurrentYear;
            MaterialValues.AdjustedIndicator = iTCA.AverageFromMaterialValues.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void TotalCurrentAssetsInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            TotalWorkingCapital.BaseYear = iTCA.TurnoverOfWorkingCapital.BaseYear;
            TotalWorkingCapital.CurrentYear = iTCA.TurnoverOfWorkingCapital.CurrentYear;
            TotalWorkingCapital.AdjustedIndicator = iTCA.AverageWorkingCapitalBalances.BaseYear / iTCA.OneDaySalesRevenue.CurrentYear;
        }
        private void OneDaySalesRevenueInit(IndicatorsOfTurnoverOfCurrentAssets iTCA)
        {
            OneDaySalesRevenue.BaseYear = iTCA.OneDaySalesRevenue.BaseYear;
            OneDaySalesRevenue.CurrentYear = iTCA.OneDaySalesRevenue.CurrentYear;
        }
    }
}