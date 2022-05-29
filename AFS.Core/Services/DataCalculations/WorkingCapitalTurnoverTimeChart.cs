using AFS.Core.Model;
using AFS.Core.Models;

namespace AFS.Core.Services.DataCalculations
{
    public class WorkingCapitalTurnoverTimeChart
    {
        FactorsAffectingTurnoverOfWorkingCapital? FactorsAffectingTurnoverOfWorkingCapital { get; set; }
        AFSModel model { get; set; } = new();

        public WorkingCapitalTurnoverTimeChart(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            FactorsAffectingTurnoverOfWorkingCapital = new(model);
            this.model = model;
        }
        public List<ChartDateTimeItem> GetMoney()
        {
            List<ChartDateTimeItem> items = new();

            var moneyBaseYear = (FactorsAffectingTurnoverOfWorkingCapital?.Money.BaseYear).GetValueOrDefault(0);
            if (moneyBaseYear != 0 && !Double.IsNaN(moneyBaseYear) && !Double.IsInfinity(moneyBaseYear))
            {
                items.Add(new ChartDateTimeItem
                {
                    Date = new DateTime(model.BaseYear, 1, 1),
                    Value = moneyBaseYear
                });
            }

            var moneyCurrentYear = (FactorsAffectingTurnoverOfWorkingCapital?.Money.CurrentYear).GetValueOrDefault(0); ;
            if (moneyCurrentYear != 0 && !Double.IsNaN(moneyCurrentYear) && !Double.IsInfinity(moneyCurrentYear))
            {
                items.Add(new ChartDateTimeItem
                {
                    Date = new DateTime(model.CurrentYear, 12, 31),
                    Value = moneyCurrentYear
                });
            }
            return items;
        }
        public List<ChartDateTimeItem> GetReceivables()
        {
            List<ChartDateTimeItem> items = new();

            var receivablesBaseYear = (FactorsAffectingTurnoverOfWorkingCapital?.Receivables.BaseYear).GetValueOrDefault(0); ;
            if (receivablesBaseYear != 0 && !Double.IsNaN(receivablesBaseYear) && !Double.IsInfinity(receivablesBaseYear))
            {
                items.Add(new ChartDateTimeItem
                {
                    Date = new DateTime(model.BaseYear, 1, 1),
                    Value = receivablesBaseYear
                });
            }
            var receivablesCurrentYear = (FactorsAffectingTurnoverOfWorkingCapital?.Receivables.CurrentYear).GetValueOrDefault(0); ;
            if (receivablesCurrentYear != 0 && !Double.IsNaN(receivablesCurrentYear) && !Double.IsInfinity(receivablesCurrentYear))
            {
                items.Add(new ChartDateTimeItem
                {
                    Date = new DateTime(model.CurrentYear, 12, 31),
                    Value = receivablesCurrentYear
                });
            }

            return items;
        }
        public List<ChartDateTimeItem> GetMaterialValues()
        {
            List<ChartDateTimeItem> items = new();

            var materialValuesBaseYear = (FactorsAffectingTurnoverOfWorkingCapital?.MaterialValues.BaseYear).GetValueOrDefault(0);
            if (materialValuesBaseYear != 0 && !Double.IsNaN(materialValuesBaseYear) && !Double.IsInfinity(materialValuesBaseYear))
            {
                items.Add(new ChartDateTimeItem
                {
                    Date = new DateTime(model.BaseYear, 1, 1),
                    Value = materialValuesBaseYear
                });
            }
            var materialValuesCurrentYear = (FactorsAffectingTurnoverOfWorkingCapital?.MaterialValues.CurrentYear).GetValueOrDefault(0);
            if (materialValuesCurrentYear != 0 && !Double.IsNaN(materialValuesCurrentYear) && !Double.IsInfinity(materialValuesCurrentYear))
            {
                items.Add(new ChartDateTimeItem
                {
                    Date = new DateTime(model.CurrentYear, 12, 31),
                    Value = materialValuesCurrentYear
                });
            }

            return items;
        }
    }
}
