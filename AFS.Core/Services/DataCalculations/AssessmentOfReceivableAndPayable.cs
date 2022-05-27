using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class AssessmentOfReceivableAndPayable
    {
        public AssessmentOfReceivableAndPayableRow WithBuyersOrSuppliers { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithLongTermLiabilities { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow ForBills { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow FromInsurance { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithBudgetAndExtraBudgetaryFunds { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithAccruedIncome { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithPayroll { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithAdvances { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithParticipants { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithInternalCashSettlements { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow WithOther { get; private set; } = new();
        public AssessmentOfReceivableAndPayableRow Total { get; private set; } = new();

        public AssessmentOfReceivableAndPayable(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            WithBuyersOrSuppliersInit(model);
            WithLongTermLiabilitiesInit(model);
            ForBillsInit(model);
            FromInsuranceInit(model);
            WithBudgetAndExtraBudgetaryFundsInit(model);
            WithAccruedIncomeInit(model);
            WithPayrollInit(model);
            WithAdvancesInit(model);
            WithParticipantsInit(model);
            WithInternalCashSettlementsInit(model);
            WithOtherInit(model);
            TotalInit();
        }
        private void WithBuyersOrSuppliersInit(AFSModel model)
        {
            WithBuyersOrSuppliers.Number = "1.";
            WithBuyersOrSuppliers.ReceivableBase = model.F1Base.F1125.Begin;
            WithBuyersOrSuppliers.ReceivableCurrent = model.F1Current.F1125.Begin;

            WithBuyersOrSuppliers.PayableBase = model.F1Base.F1615.Begin;
            WithBuyersOrSuppliers.PayableCurrent = model.F1Current.F1615.Begin;
        }
        private void WithLongTermLiabilitiesInit(AFSModel model)
        {
            WithLongTermLiabilities.Number = "2.";

            WithLongTermLiabilities.PayableBase = model.F1Base.F1610.Begin;
            WithLongTermLiabilities.PayableCurrent = model.F1Current.F1610.Begin;
        }

        private void ForBillsInit(AFSModel model)
        {
            ForBills.Number = "3.";
            ForBills.ReceivableBase = model.F1Base.F1120.Begin;
            ForBills.ReceivableCurrent = model.F1Current.F1120.Begin;

            ForBills.PayableBase = model.F1Base.F1605.Begin;
            ForBills.PayableCurrent = model.F1Current.F1605.Begin;
        }
        private void FromInsuranceInit(AFSModel model)
        {
            FromInsurance.Number = "4.";

            FromInsurance.PayableBase = model.F1Base.F1625.Begin;
            FromInsurance.PayableCurrent = model.F1Current.F1625.Begin;
        }
        private void WithBudgetAndExtraBudgetaryFundsInit(AFSModel model)
        {
            WithBudgetAndExtraBudgetaryFunds.Number = "5.";
            WithBudgetAndExtraBudgetaryFunds.ReceivableBase = model.F1Base.F1135.Begin;
            WithBudgetAndExtraBudgetaryFunds.ReceivableCurrent = model.F1Current.F1135.Begin;

            WithBudgetAndExtraBudgetaryFunds.PayableBase = model.F1Base.F1620.Begin;
            WithBudgetAndExtraBudgetaryFunds.PayableCurrent = model.F1Current.F1620.Begin;
        }
        private void WithAccruedIncomeInit(AFSModel model)
        {
            WithAccruedIncome.Number = "6.";
            WithAccruedIncome.ReceivableBase = model.F1Base.F1140.Begin;
            WithAccruedIncome.ReceivableCurrent = model.F1Current.F1140.Begin;
        }
        private void WithPayrollInit(AFSModel model)
        {
            WithPayroll.Number = "7.";
            WithPayroll.PayableBase = model.F1Base.F1630.Begin;
            WithPayroll.PayableCurrent = model.F1Current.F1630.Begin;
        }
        private void WithAdvancesInit(AFSModel model)
        {
            WithAdvances.Number = "8.";
            WithAdvances.ReceivableBase = model.F1Base.F1130.Begin;
            WithAdvances.ReceivableCurrent = model.F1Current.F1130.Begin;

            WithAdvances.PayableBase = model.F1Base.F1635.Begin;
            WithAdvances.PayableCurrent = model.F1Current.F1635.Begin;
        }
        private void WithParticipantsInit(AFSModel model)
        {
            WithParticipants.Number = "9.";

            WithParticipants.PayableBase = model.F1Base.F1640.Begin;
            WithParticipants.PayableCurrent = model.F1Current.F1640.Begin;
        }
        private void WithInternalCashSettlementsInit(AFSModel model)
        {
            WithInternalCashSettlements.Number = "10.";
            WithInternalCashSettlements.ReceivableBase = model.F1Base.F1145.Begin;
            WithInternalCashSettlements.ReceivableCurrent = model.F1Current.F1145.Begin;

            WithInternalCashSettlements.PayableBase = model.F1Base.F1645.Begin;
            WithInternalCashSettlements.PayableCurrent = model.F1Current.F1645.Begin;
        }
        private void WithOtherInit(AFSModel model)
        {
            WithOther.Number = "11.";
            WithOther.ReceivableBase = model.F1Base.F1155.Begin;
            WithOther.ReceivableCurrent = model.F1Current.F1155.Begin;

            WithOther.PayableBase = model.F1Base.F1690.Begin;
            WithOther.PayableCurrent = model.F1Current.F1690.Begin;
        }
        private void TotalInit()
        {
            Total.ReceivableBase = WithBuyersOrSuppliers.ReceivableBase + WithLongTermLiabilities.ReceivableBase + ForBills.ReceivableBase + FromInsurance.ReceivableBase + WithBudgetAndExtraBudgetaryFunds.ReceivableBase + WithAccruedIncome.ReceivableBase + WithPayroll.ReceivableBase + WithAdvances.ReceivableBase + WithParticipants.ReceivableBase + WithInternalCashSettlements.ReceivableBase + WithOther.ReceivableBase;
            Total.ReceivableCurrent = WithBuyersOrSuppliers.ReceivableCurrent + WithLongTermLiabilities.ReceivableCurrent + ForBills.ReceivableCurrent + FromInsurance.ReceivableCurrent + WithBudgetAndExtraBudgetaryFunds.ReceivableCurrent + WithAccruedIncome.ReceivableCurrent + WithPayroll.ReceivableCurrent + WithAdvances.ReceivableCurrent + WithParticipants.ReceivableCurrent + WithInternalCashSettlements.ReceivableCurrent + WithOther.ReceivableCurrent;

            Total.PayableBase = WithBuyersOrSuppliers.PayableBase + WithLongTermLiabilities.PayableBase + ForBills.PayableBase + FromInsurance.PayableBase + WithBudgetAndExtraBudgetaryFunds.PayableBase + WithAccruedIncome.PayableBase + WithPayroll.PayableBase + WithAdvances.PayableBase + WithParticipants.PayableBase + WithInternalCashSettlements.PayableBase + WithOther.PayableBase;
            Total.PayableCurrent = WithBuyersOrSuppliers.PayableCurrent + WithLongTermLiabilities.PayableCurrent + ForBills.PayableCurrent + FromInsurance.PayableCurrent + WithBudgetAndExtraBudgetaryFunds.PayableCurrent + WithAccruedIncome.PayableCurrent + WithPayroll.PayableCurrent + WithAdvances.PayableCurrent + WithParticipants.PayableCurrent + WithInternalCashSettlements.PayableCurrent + WithOther.PayableCurrent;
        }
    }
}
