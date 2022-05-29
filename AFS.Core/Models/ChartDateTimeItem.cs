using AFS.Core.Model;

namespace AFS.Core.Models
{
    public class ChartDateTimeItem
    {
        private double? value;
        public DateTime Date { get; set; }
        public string? Item { get; set; }
        public double? Value
        {
            get => AFSConstraints.RoundStat(value.GetValueOrDefault(0));
            set => this.value = value;
        }
    }
}