namespace AFS.Core.Model
{
    public class Form2
    {
        private double f2000begin;
        private double f2050begin;
        private double f2120begin;
        private double f2130begin;
        private double f2150begin;
        private double f2180begin;
        private double f2200begin;
        private double f2220begin;
        private double f2240begin;
        private double f2250begin;
        private double f2255begin;
        private double f2270begin;
        private double f2300begin;
        private double f2305begin;
        private double f2400begin;
        private double f2405begin;
        private double f2410begin;
        private double f2415begin;
        private double f2445begin;
        private double f2455begin;
        private double f2500begin;
        private double f2505begin;
        private double f2510begin;
        private double f2515begin;
        private double f2520begin;
        private double f2600begin;
        private double f2605begin;
        private double f2610begin;
        private double f2615begin;
        private double f2650begin;

        private double f2000end;
        private double f2050end;
        private double f2120end;
        private double f2130end;
        private double f2150end;
        private double f2180end;
        private double f2200end;
        private double f2220end;
        private double f2240end;
        private double f2250end;
        private double f2255end;
        private double f2270end;
        private double f2300end;
        private double f2305end;
        private double f2400end;
        private double f2405end;
        private double f2410end;
        private double f2415end;
        private double f2445end;
        private double f2455end;
        private double f2500end;
        private double f2505end;
        private double f2510end;
        private double f2515end;
        private double f2520end;
        private double f2600end;
        private double f2605end;
        private double f2610end;
        private double f2615end;
        private double f2650end;

        public event Action? OnChange;
        public double F2000begin
        {
            get => f2000begin;
            set
            {
                f2000begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2050begin
        {
            get => f2050begin;
            set
            {
                f2050begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2090begin => F2000begin > f2050begin ? F2000begin - f2050begin : 0;
        public double F2095begin => F2000begin < f2050begin ? F2000begin - f2050begin : 0;
        public double F2120begin
        {
            get => f2120begin;
            set
            {
                f2120begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2130begin
        {
            get => f2130begin;
            set
            {
                f2130begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2150begin
        {
            get => f2150begin;
            set
            {
                f2150begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2180begin
        {
            get => f2180begin;
            set
            {
                f2180begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2190begin
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(true);
                return res > 0 ? res : 0;
            }
        }

        public double F2195begin
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(true);
                return res < 0 ? res : 0;
            }
        }
        public double F2200begin
        {
            get => f2200begin;
            set
            {
                f2200begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2220begin
        {
            get => f2220begin;
            set
            {
                f2220begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2240begin
        {
            get => f2240begin;
            set
            {
                f2240begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2250begin
        {
            get => f2250begin;
            set
            {
                f2250begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2255begin
        {
            get => f2255begin;
            set
            {
                f2255begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2270begin
        {
            get => f2270begin;
            set
            {
                f2270begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2290begin
        {
            get
            {
                double res = FinancialResultBeforeTax(true);
                return res > 0 ? res : 0;
            }
        }
        public double F2295begin
        {
            get
            {
                double res = FinancialResultBeforeTax(true);
                return res < 0 ? res : 0;
            }
        }
        public double F2300begin
        {
            get => f2300begin;
            set
            {
                f2300begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2305begin
        {
            get => f2305begin;
            set
            {
                f2305begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2350begin
        {
            get
            {
                double res = NetFinancialResult(true);
                return res > 0 ? res : 0;
            }

        }

        public double F2355begin
        {
            get
            {
                var res = NetFinancialResult(true);
                return res < 0 ? res : 0;
            }
        }
        public double F2400begin
        {
            get => f2400begin;
            set
            {
                f2400begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2405begin
        {
            get => f2405begin;
            set
            {
                f2405begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2410begin
        {
            get => f2410begin;
            set
            {
                f2410begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2415begin
        {
            get => f2415begin;
            set
            {
                f2415begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2445begin
        {
            get => f2445begin;
            set
            {
                f2445begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2450begin => OtherAggregatePreTaxIncome(true);

       public double F2455begin
        {
            get => f2455begin;
            set
            {
                f2455begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2460begin => F2450begin - F2455begin;
        public double F2465begin => F2350begin + F2355begin + F2460begin;
        public double F2500begin
        {
            get => f2500begin;
            set
            {
                f2500begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2505begin
        {
            get => f2505begin;
            set
            {
                f2505begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2510begin
        {
            get => f2510begin;
            set
            {
                f2510begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2515begin
        {
            get => f2515begin;
            set
            {
                f2515begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2520begin
        {
            get => f2520begin;
            set
            {
                f2520begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2550begin
        {
            get
            {
                return F2500begin + F2505begin + F2510begin + F2515begin + F2520begin;
            }
        }
        public double F2600begin
        {
            get => f2600begin;
            set
            {
                f2600begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2605begin
        {
            get => f2605begin;
            set
            {
                f2605begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2610begin
        {
            get => f2610begin;
            set
            {
                f2610begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2615begin
        {
            get => f2615begin;
            set
            {
                f2615begin = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2650begin
        {
            get => f2650begin;
            set
            {
                f2650begin = Round(value);
                NotifyStateChanged();
            }
        }

        public double F2000end
        {
            get => f2000end;
            set
            {
                f2000end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2050end
        {
            get => f2050end;
            set
            {
                f2050end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2090end => F2000end > f2050end ? F2000end - f2050end : 0;
        public double F2095end => F2000end < f2050end ? F2000end - f2050end : 0;
        public double F2120end
        {
            get => f2120end;
            set
            {
                f2120end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2130end
        {
            get => f2130end;
            set
            {
                f2130end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2150end
        {
            get => f2150end;
            set
            {
                f2150end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2180end
        {
            get => f2180end;
            set
            {
                f2180end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2190end
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(false);
                return res > 0 ? res : 0;
            }
        }

        public double F2195end
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(false);
                return res < 0 ? res : 0;
            }
        }
        public double F2200end
        {
            get => f2200end;
            set
            {
                f2200end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2220end
        {
            get => f2220end;
            set
            {
                f2220end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2240end
        {
            get => f2240end;
            set
            {
                f2240end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2250end
        {
            get => f2250end;
            set
            {
                f2250end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2255end
        {
            get => f2255end;
            set
            {
                f2255end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2270end
        {
            get => f2270end;
            set
            {
                f2270end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2290end
        {
            get
            {
                double res = FinancialResultBeforeTax(false);
                return res > 0 ? res : 0;
            }
        }
        public double F2295end
        {
            get
            {
                double res = FinancialResultBeforeTax(false);
                return res < 0 ? res : 0;
            }
        }
        public double F2300end
        {
            get => f2300end;
            set
            {
                f2300end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2305end
        {
            get => f2305end;
            set
            {
                f2305end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2350end
        {
            get
            {
                double res = NetFinancialResult(false);
                return res > 0 ? res : 0;
            }

        }

        public double F2355end
        {
            get
            {
                var res = NetFinancialResult(false);
                return res < 0 ? res : 0;
            }
        }
        public double F2400end
        {
            get => f2400end;
            set
            {
                f2400end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2405end
        {
            get => f2405end;
            set
            {
                f2405end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2410end
        {
            get => f2410end;
            set
            {
                f2410end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2415end
        {
            get => f2415end;
            set
            {
                f2415end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2445end
        {
            get => f2445end;
            set
            {
                f2445end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2450end => OtherAggregatePreTaxIncome(false); 
        public double F2455end
        {
            get => f2455end;
            set
            {
                f2455end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2460end => F2450end - F2455end;
        public double F2465end => F2350end + F2355end + F2460end;
        public double F2500end
        {
            get => f2500end;
            set
            {
                f2500end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2505end
        {
            get => f2505end;
            set
            {
                f2505end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2510end
        {
            get => f2510end;
            set
            {
                f2510end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2515end
        {
            get => f2515end;
            set
            {
                f2515end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2520end
        {
            get => f2520end;
            set
            {
                f2520end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2550end
        {
            get
            {
                return F2500end + F2505end + F2510end + F2515end + F2520end;
            }
        }
        public double F2600end
        {
            get => f2600end;
            set
            {
                f2600end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2605end
        {
            get => f2605end;
            set
            {
                f2605end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2610end
        {
            get => f2610end;
            set
            {
                f2610end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2615end
        {
            get => f2615end;
            set
            {
                f2615end = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2650end
        {
            get => f2650end;
            set
            {
                f2650end = Round(value);
                NotifyStateChanged();
            }
        }
        private static double Round(double value)
        {
            return Math.Round(value, 1, MidpointRounding.AwayFromZero);
        }
        private void NotifyStateChanged() => OnChange?.Invoke();

        private double FinancialResultFromOperatingActivities(bool begin)
        {
            if (begin)
            {
                return F2090begin + F2095begin + F2120begin - F2130begin - F2150begin - F2180begin;
            }
            return F2090end + F2095end + F2120end - F2130end - F2150end - F2180end;
        }

        private double FinancialResultBeforeTax(bool begin)
        {
            if (begin)
            {
                return F2190begin + F2195begin + F2200begin + F2220begin + F2240begin - F2250begin - F2255begin - F2270begin;
            }
            return F2190end + F2195end + F2200end + F2220end + F2240end - F2250end - F2255end - F2270end;
        }

        private double NetFinancialResult(bool begin)
        {
            if (begin)
            {
                return F2290begin + F2295begin + F2300begin + F2305begin;
            }
            return F2290end + F2295end + F2300end + F2305end;
        }
        private double OtherAggregatePreTaxIncome(bool begin)
        {
            if (begin)
            {
                return F2400begin + F2405begin + F2410begin + F2415begin + F2445begin;
            }
            return F2400end + F2405end + F2410end + F2415end + F2445end;
        }

        internal void Init(Form2 form2)
        {
            f2000begin = form2.F2000begin;
            f2050begin = form2.F2050begin;
            f2120begin = form2.F2120begin;
            f2130begin = form2.F2130begin;
            f2150begin = form2.F2150begin;
            f2180begin = form2.F2180begin;
            f2200begin = form2.F2200begin;
            f2220begin = form2.F2220begin;
            f2240begin = form2.F2240begin;
            f2250begin = form2.F2250begin;
            f2255begin = form2.F2255begin;
            f2270begin = form2.F2270begin;
            f2300begin = form2.F2300begin;
            f2305begin = form2.F2305begin;
            f2400begin = form2.F2400begin;
            f2405begin = form2.F2405begin;
            f2410begin = form2.F2410begin;
            f2415begin = form2.F2415begin;
            f2445begin = form2.F2445begin;
            f2455begin = form2.F2455begin;
            f2500begin = form2.F2500begin;
            f2505begin = form2.F2505begin;
            f2510begin = form2.F2510begin;
            f2515begin = form2.F2515begin;
            f2520begin = form2.F2520begin;
            f2600begin = form2.F2600begin;
            f2605begin = form2.F2605begin;
            f2610begin = form2.F2610begin;
            f2615begin = form2.F2615begin;
            f2650begin = form2.F2650begin;
            f2000end = form2.F2000end;
            f2050end = form2.F2050end;
            f2120end = form2.F2120end;
            f2130end = form2.F2130end;
            f2150end = form2.F2150end;
            f2180end = form2.F2180end;
            f2200end = form2.F2200end;
            f2220end = form2.F2220end;
            f2240end = form2.F2240end;
            f2250end = form2.F2250end;
            f2255end = form2.F2255end;
            f2270end = form2.F2270end;
            f2300end = form2.F2300end;
            f2305end = form2.F2305end;
            f2400end = form2.F2400end;
            f2405end = form2.F2405end;
            f2410end = form2.F2410end;
            f2415end = form2.F2415end;
            f2445end = form2.F2445end;
            f2455end = form2.F2455end;
            f2500end = form2.F2500end;
            f2505end = form2.F2505end;
            f2510end = form2.F2510end;
            f2515end = form2.F2515end;
            f2520end = form2.F2520end;
            f2600end = form2.F2600end;
            f2605end = form2.F2605end;
            f2610end = form2.F2610end;
            f2615end = form2.F2615end;
            f2650end = form2.F2650end;

            NotifyStateChanged();
        }
    }
}
