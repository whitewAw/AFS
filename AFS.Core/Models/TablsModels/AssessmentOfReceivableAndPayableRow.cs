namespace AFS.Core.Models.TablsModels
{
    public class AssessmentOfReceivableAndPayableRow
    {
        public string? Number { get; set; }
        public double ReceivableBase { get; set; }
        public double ReceivableCurrent { get; set; }
        public double PayableBase { get; set; }
        public double PayableCurrent { get; set; }
        public double ExceedingReceivableBase => ReceivableBase > PayableBase ? ReceivableBase - PayableBase : 0;
        public double ExceedingReceivableCurrent => ReceivableCurrent > PayableCurrent ? ReceivableCurrent - PayableCurrent : 0;
        public double ExceedingPayableBase => PayableBase > ReceivableBase ? PayableBase - ReceivableBase : 0;
        public double ExceedingPayableCurrent => PayableCurrent > ReceivableCurrent ? PayableCurrent - ReceivableCurrent : 0;
    }
}
