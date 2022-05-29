using AFS.Core.Model;
using AFS.Core.Models;

namespace AFS.Core.Services.DataCalculations
{
    public class StructureOfAccountsPayableChart
    {
        AssessmentOfReceivableAndPayable? AssessmentOfReceivableAndPayable { get; set; }

        public StructureOfAccountsPayableChart(AFSModel model) => Init(model);
        private void Init(AFSModel model) => AssessmentOfReceivableAndPayable = new(model);
        public List<ChartDataItem> GetDataItem(bool baseYear)
        {
            List<ChartDataItem> assets = new();

            var withBuyersOrSuppliersValue = GetWithBuyersOrSuppliers(baseYear).GetValueOrDefault(0);
            if (withBuyersOrSuppliersValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithBuyersOrSuppliers",
                    Value = withBuyersOrSuppliersValue
                });
            }
            var withLongTermLiabilitiesValue = GetWithLongTermLiabilities(baseYear).GetValueOrDefault(0);
            if (withLongTermLiabilitiesValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithLongTermLiabilities",
                    Value = withLongTermLiabilitiesValue
                });
            }
            var forBillsValue = GetForBills(baseYear).GetValueOrDefault(0);
            if (forBillsValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "ForBills",
                    Value = forBillsValue
                });
            }
            var fromInsuranceValue = GetFromInsurance(baseYear).GetValueOrDefault(0);
            if (fromInsuranceValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "FromInsurance",
                    Value = fromInsuranceValue
                });
            }
            var withBudgetAndExtraBudgetaryFundsValue = GetWithBudgetAndExtraBudgetaryFunds(baseYear).GetValueOrDefault(0);
            if (withBudgetAndExtraBudgetaryFundsValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithBudgetAndExtraBudgetaryFunds",
                    Value = withBudgetAndExtraBudgetaryFundsValue
                });
            }
            var withAccruedIncomeValue = GetWithAccruedIncome(baseYear).GetValueOrDefault(0);
            if (withAccruedIncomeValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithAccruedIncome",
                    Value = withAccruedIncomeValue
                });
            }
            var withPayrollValue = GetWithPayroll(baseYear).GetValueOrDefault(0);
            if (withPayrollValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithPayroll",
                    Value = withPayrollValue
                });
            }
            var withAdvancesValue = GetWithAdvances(baseYear).GetValueOrDefault(0);
            if (withAdvancesValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithAdvances",
                    Value = withAdvancesValue
                });
            }
            var withParticipantsValue = GetWithParticipants(baseYear).GetValueOrDefault(0);
            if (withParticipantsValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithParticipants",
                    Value = withParticipantsValue
                });
            }
            var withInternalCashSettlementsValue = GetWithInternalCashSettlements(baseYear).GetValueOrDefault(0);
            if (withInternalCashSettlementsValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithInternalCashSettlements",
                    Value = withInternalCashSettlementsValue
                });
            }
            var withOtherValue = GetWithOther(baseYear).GetValueOrDefault(0);
            if (withOtherValue != 0)
            {
                assets.Add(new ChartDataItem
                {
                    Item = "WithOther",
                    Value = withOtherValue
                });
            }

            return assets.OrderByDescending(item => item.Value).ToList();
        }
        private double? GetWithBuyersOrSuppliers(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithBuyersOrSuppliers.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithBuyersOrSuppliers.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithLongTermLiabilities(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithLongTermLiabilities.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithLongTermLiabilities.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetForBills(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.ForBills.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.ForBills.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetFromInsurance(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.FromInsurance.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.FromInsurance.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithBudgetAndExtraBudgetaryFunds(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithBudgetAndExtraBudgetaryFunds.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithBudgetAndExtraBudgetaryFunds.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithAccruedIncome(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithAccruedIncome.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithAccruedIncome.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithPayroll(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithPayroll.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithPayroll.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithAdvances(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithAdvances.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithAdvances.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithParticipants(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithParticipants.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithParticipants.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithInternalCashSettlements(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithInternalCashSettlements.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithInternalCashSettlements.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
        private double? GetWithOther(bool baseYear)
        {
            if (baseYear == true && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithOther.PayableBase / AssessmentOfReceivableAndPayable.Total.PayableBase * 100;
            }
            else if (baseYear == false && AssessmentOfReceivableAndPayable != null)
            {
                return AssessmentOfReceivableAndPayable.WithOther.PayableCurrent / AssessmentOfReceivableAndPayable.Total.PayableCurrent * 100;
            }
            return 0;
        }
    }
}
