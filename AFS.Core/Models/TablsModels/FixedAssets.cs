namespace AFS.Core.Models.TablsModels
{
    public class FixedAssets
    {
        public double BalanceAtBeginInitialCost { get; set; }
        public double Received { get; set; }
        public double ReceivedNew { get; set; }
        public double Left { get; set; }
        public double Liquidated { get; set; }
        public double BalanceAtEndInitialCost { get; set; }
        public double BalanceAtEndMinusDepreciation { get; set; }
    }
}