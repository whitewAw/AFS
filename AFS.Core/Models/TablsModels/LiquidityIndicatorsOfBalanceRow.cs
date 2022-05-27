namespace AFS.Core.Models.TablsModels
{
    public class LiquidityIndicatorsOfBalanceRow
    {
        public double ABegin { get; set; }
        public double AEnd { get; set; }
        public double PBegin { get; set; }
        public double PEnd { get; set; }
        public double PaymentBalanceBegin => ABegin - PBegin;
        public double PaymentBalanceEnd => AEnd - PEnd;
    }
}
