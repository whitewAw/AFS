using AFS.Core.Model;
using AFS.Core.Models;

namespace AFS.Core.Services.DataCalculations
{
    public class WorkingCapitalTurnoverTime
    {
        FactorsAffectingTurnoverOfWorkingCapital FactorsAffectingTurnoverOfWorkingCapital { get; set; }
        AFSModel model { get; set; }

        public WorkingCapitalTurnoverTime(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            FactorsAffectingTurnoverOfWorkingCapital = new(model);
            this.model = model;
        }
        public List<ChartDateTimeItem> GetMoney()
        {
            List<ChartDateTimeItem> items = new();
            items.Add(new ChartDateTimeItem
            {
                Date = new DateTime(model.BaseYear, 1, 1),
                Value = FactorsAffectingTurnoverOfWorkingCapital.Money.BaseYear
            });
            items.Add(new ChartDateTimeItem
            {
                Date = new DateTime(model.CurrentYear, 12, 31),
                Value = FactorsAffectingTurnoverOfWorkingCapital.Money.CurrentYear
            });
            return items;
        }
        public List<ChartDateTimeItem> GetReceivables()
        {
            List<ChartDateTimeItem> items = new();
            items.Add(new ChartDateTimeItem
            {
                Date = new DateTime(model.BaseYear, 1, 1),
                Value = FactorsAffectingTurnoverOfWorkingCapital.Receivables.BaseYear
            });
            items.Add(new ChartDateTimeItem
            {
                Date = new DateTime(model.CurrentYear, 12, 31),
                Value = FactorsAffectingTurnoverOfWorkingCapital.Receivables.CurrentYear
            });
            return items;
        }
        public List<ChartDateTimeItem> GetMaterialValues()
        {
            List<ChartDateTimeItem> items = new();
            items.Add(new ChartDateTimeItem
            {
                Date = new DateTime(model.BaseYear, 1, 1),
                Value = FactorsAffectingTurnoverOfWorkingCapital.MaterialValues.BaseYear
            });
            items.Add(new ChartDateTimeItem
            {
                Date = new DateTime(model.CurrentYear, 12, 31),
                Value = FactorsAffectingTurnoverOfWorkingCapital.MaterialValues.CurrentYear
            });
            return items;
        }
    }
}
