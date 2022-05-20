namespace AFS.Core.Model
{
    public class Form2
    {
        private double f2000curent;
        private double f2050curent;
        private double f2120curent;
        private double f2130curent;
        private double f2150curent;
        private double f2180curent;
        private double f2200curent;
        private double f2220curent;
        private double f2240curent;
        private double f2250curent;
        private double f2255curent;
        private double f2270curent;
        private double f2300curent;
        private double f2305curent;
        private double f2400curent;
        private double f2405curent;
        private double f2410curent;
        private double f2415curent;
        private double f2445curent;
        private double f2455curent;
        private double f2500curent;
        private double f2505curent;
        private double f2510curent;
        private double f2515curent;
        private double f2520curent;
        private double f2600curent;
        private double f2605curent;
        private double f2610curent;
        private double f2615curent;
        private double f2650curent;

        private double f2000previous;
        private double f2050previous;
        private double f2120previous;
        private double f2130previous;
        private double f2150previous;
        private double f2180previous;
        private double f2200previous;
        private double f2220previous;
        private double f2240previous;
        private double f2250previous;
        private double f2255previous;
        private double f2270previous;
        private double f2300previous;
        private double f2305previous;
        private double f2400previous;
        private double f2405previous;
        private double f2410previous;
        private double f2415previous;
        private double f2445previous;
        private double f2455previous;
        private double f2500previous;
        private double f2505previous;
        private double f2510previous;
        private double f2515previous;
        private double f2520previous;
        private double f2600previous;
        private double f2605previous;
        private double f2610previous;
        private double f2615previous;
        private double f2650previous;

        public event Action? OnChange;
        public double F2000curent
        {
            get => f2000curent;
            set
            {
                f2000curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2050curent
        {
            get => f2050curent;
            set
            {
                f2050curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2090curent => F2000curent > f2050curent ? F2000curent - f2050curent : 0;
        public double F2095curent => F2000curent < f2050curent ? F2000curent - f2050curent : 0;
        public double F2120curent
        {
            get => f2120curent;
            set
            {
                f2120curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2130curent
        {
            get => f2130curent;
            set
            {
                f2130curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2150curent
        {
            get => f2150curent;
            set
            {
                f2150curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2180curent
        {
            get => f2180curent;
            set
            {
                f2180curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2190curent
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(true);
                return res > 0 ? res : 0;
            }
        }

        public double F2195curent
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(true);
                return res < 0 ? res : 0;
            }
        }
        public double F2200curent
        {
            get => f2200curent;
            set
            {
                f2200curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2220curent
        {
            get => f2220curent;
            set
            {
                f2220curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2240curent
        {
            get => f2240curent;
            set
            {
                f2240curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2250curent
        {
            get => f2250curent;
            set
            {
                f2250curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2255curent
        {
            get => f2255curent;
            set
            {
                f2255curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2270curent
        {
            get => f2270curent;
            set
            {
                f2270curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2290curent
        {
            get
            {
                double res = FinancialResultBeforeTax(true);
                return res > 0 ? res : 0;
            }
        }
        public double F2295curent
        {
            get
            {
                double res = FinancialResultBeforeTax(true);
                return res < 0 ? res : 0;
            }
        }
        public double F2300curent
        {
            get => f2300curent;
            set
            {
                f2300curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2305curent
        {
            get => f2305curent;
            set
            {
                f2305curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2350curent
        {
            get
            {
                double res = NetFinancialResult(true);
                return res > 0 ? res : 0;
            }

        }

        public double F2355curent
        {
            get
            {
                var res = NetFinancialResult(true);
                return res < 0 ? res : 0;
            }
        }
        public double F2400curent
        {
            get => f2400curent;
            set
            {
                f2400curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2405curent
        {
            get => f2405curent;
            set
            {
                f2405curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2410curent
        {
            get => f2410curent;
            set
            {
                f2410curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2415curent
        {
            get => f2415curent;
            set
            {
                f2415curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2445curent
        {
            get => f2445curent;
            set
            {
                f2445curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2450curent => OtherAggregatePreTaxIncome(true);

       public double F2455curent
        {
            get => f2455curent;
            set
            {
                f2455curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2460curent => F2450curent - F2455curent;
        public double F2465curent => F2350curent + F2355curent + F2460curent;
        public double F2500curent
        {
            get => f2500curent;
            set
            {
                f2500curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2505curent
        {
            get => f2505curent;
            set
            {
                f2505curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2510curent
        {
            get => f2510curent;
            set
            {
                f2510curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2515curent
        {
            get => f2515curent;
            set
            {
                f2515curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2520curent
        {
            get => f2520curent;
            set
            {
                f2520curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2550curent
        {
            get
            {
                return F2500curent + F2505curent + F2510curent + F2515curent + F2520curent;
            }
        }
        public double F2600curent
        {
            get => f2600curent;
            set
            {
                f2600curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2605curent
        {
            get => f2605curent;
            set
            {
                f2605curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2610curent
        {
            get => f2610curent;
            set
            {
                f2610curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2615curent
        {
            get => f2615curent;
            set
            {
                f2615curent = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2650curent
        {
            get => f2650curent;
            set
            {
                f2650curent = Round(value);
                NotifyStateChanged();
            }
        }

        public double F2000previous
        {
            get => f2000previous;
            set
            {
                f2000previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2050previous
        {
            get => f2050previous;
            set
            {
                f2050previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2090previous => F2000previous > f2050previous ? F2000previous - f2050previous : 0;
        public double F2095previous => F2000previous < f2050previous ? F2000previous - f2050previous : 0;
        public double F2120previous
        {
            get => f2120previous;
            set
            {
                f2120previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2130previous
        {
            get => f2130previous;
            set
            {
                f2130previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2150previous
        {
            get => f2150previous;
            set
            {
                f2150previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2180previous
        {
            get => f2180previous;
            set
            {
                f2180previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2190previous
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(false);
                return res > 0 ? res : 0;
            }
        }

        public double F2195previous
        {
            get
            {
                double res = FinancialResultFromOperatingActivities(false);
                return res < 0 ? res : 0;
            }
        }
        public double F2200previous
        {
            get => f2200previous;
            set
            {
                f2200previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2220previous
        {
            get => f2220previous;
            set
            {
                f2220previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2240previous
        {
            get => f2240previous;
            set
            {
                f2240previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2250previous
        {
            get => f2250previous;
            set
            {
                f2250previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2255previous
        {
            get => f2255previous;
            set
            {
                f2255previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2270previous
        {
            get => f2270previous;
            set
            {
                f2270previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2290previous
        {
            get
            {
                double res = FinancialResultBeforeTax(false);
                return res > 0 ? res : 0;
            }
        }
        public double F2295previous
        {
            get
            {
                double res = FinancialResultBeforeTax(false);
                return res < 0 ? res : 0;
            }
        }
        public double F2300previous
        {
            get => f2300previous;
            set
            {
                f2300previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2305previous
        {
            get => f2305previous;
            set
            {
                f2305previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2350previous
        {
            get
            {
                double res = NetFinancialResult(false);
                return res > 0 ? res : 0;
            }

        }

        public double F2355previous
        {
            get
            {
                var res = NetFinancialResult(false);
                return res < 0 ? res : 0;
            }
        }
        public double F2400previous
        {
            get => f2400previous;
            set
            {
                f2400previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2405previous
        {
            get => f2405previous;
            set
            {
                f2405previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2410previous
        {
            get => f2410previous;
            set
            {
                f2410previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2415previous
        {
            get => f2415previous;
            set
            {
                f2415previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2445previous
        {
            get => f2445previous;
            set
            {
                f2445previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2450previous => OtherAggregatePreTaxIncome(false); 
        public double F2455previous
        {
            get => f2455previous;
            set
            {
                f2455previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2460previous => F2450previous - F2455previous;
        public double F2465previous => F2350previous + F2355previous + F2460previous;
        public double F2500previous
        {
            get => f2500previous;
            set
            {
                f2500previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2505previous
        {
            get => f2505previous;
            set
            {
                f2505previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2510previous
        {
            get => f2510previous;
            set
            {
                f2510previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2515previous
        {
            get => f2515previous;
            set
            {
                f2515previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2520previous
        {
            get => f2520previous;
            set
            {
                f2520previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2550previous
        {
            get
            {
                return F2500previous + F2505previous + F2510previous + F2515previous + F2520previous;
            }
        }
        public double F2600previous
        {
            get => f2600previous;
            set
            {
                f2600previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2605previous
        {
            get => f2605previous;
            set
            {
                f2605previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2610previous
        {
            get => f2610previous;
            set
            {
                f2610previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2615previous
        {
            get => f2615previous;
            set
            {
                f2615previous = Round(value);
                NotifyStateChanged();
            }
        }
        public double F2650previous
        {
            get => f2650previous;
            set
            {
                f2650previous = Round(value);
                NotifyStateChanged();
            }
        }
        private static double Round(double value)
        {
            return AFSConstraints.RoundStat(value);
        }
        private void NotifyStateChanged() => OnChange?.Invoke();

        private double FinancialResultFromOperatingActivities(bool curent)
        {
            if (curent)
            {
                return F2090curent + F2095curent + F2120curent - F2130curent - F2150curent - F2180curent;
            }
            return F2090previous + F2095previous + F2120previous - F2130previous - F2150previous - F2180previous;
        }

        private double FinancialResultBeforeTax(bool curent)
        {
            if (curent)
            {
                return F2190curent + F2195curent + F2200curent + F2220curent + F2240curent - F2250curent - F2255curent - F2270curent;
            }
            return F2190previous + F2195previous + F2200previous + F2220previous + F2240previous - F2250previous - F2255previous - F2270previous;
        }

        private double NetFinancialResult(bool curent)
        {
            if (curent)
            {
                return F2290curent + F2295curent - F2300curent + F2305curent;
            }
            return F2290previous + F2295previous - F2300previous + F2305previous;
        }
        private double OtherAggregatePreTaxIncome(bool curent)
        {
            if (curent)
            {
                return F2400curent + F2405curent + F2410curent + F2415curent + F2445curent;
            }
            return F2400previous + F2405previous + F2410previous + F2415previous + F2445previous;
        }

        internal void Init(Form2 form2)
        {
            f2000curent = form2.F2000curent;
            f2050curent = form2.F2050curent;
            f2120curent = form2.F2120curent;
            f2130curent = form2.F2130curent;
            f2150curent = form2.F2150curent;
            f2180curent = form2.F2180curent;
            f2200curent = form2.F2200curent;
            f2220curent = form2.F2220curent;
            f2240curent = form2.F2240curent;
            f2250curent = form2.F2250curent;
            f2255curent = form2.F2255curent;
            f2270curent = form2.F2270curent;
            f2300curent = form2.F2300curent;
            f2305curent = form2.F2305curent;
            f2400curent = form2.F2400curent;
            f2405curent = form2.F2405curent;
            f2410curent = form2.F2410curent;
            f2415curent = form2.F2415curent;
            f2445curent = form2.F2445curent;
            f2455curent = form2.F2455curent;
            f2500curent = form2.F2500curent;
            f2505curent = form2.F2505curent;
            f2510curent = form2.F2510curent;
            f2515curent = form2.F2515curent;
            f2520curent = form2.F2520curent;
            f2600curent = form2.F2600curent;
            f2605curent = form2.F2605curent;
            f2610curent = form2.F2610curent;
            f2615curent = form2.F2615curent;
            f2650curent = form2.F2650curent;
            f2000previous = form2.F2000previous;
            f2050previous = form2.F2050previous;
            f2120previous = form2.F2120previous;
            f2130previous = form2.F2130previous;
            f2150previous = form2.F2150previous;
            f2180previous = form2.F2180previous;
            f2200previous = form2.F2200previous;
            f2220previous = form2.F2220previous;
            f2240previous = form2.F2240previous;
            f2250previous = form2.F2250previous;
            f2255previous = form2.F2255previous;
            f2270previous = form2.F2270previous;
            f2300previous = form2.F2300previous;
            f2305previous = form2.F2305previous;
            f2400previous = form2.F2400previous;
            f2405previous = form2.F2405previous;
            f2410previous = form2.F2410previous;
            f2415previous = form2.F2415previous;
            f2445previous = form2.F2445previous;
            f2455previous = form2.F2455previous;
            f2500previous = form2.F2500previous;
            f2505previous = form2.F2505previous;
            f2510previous = form2.F2510previous;
            f2515previous = form2.F2515previous;
            f2520previous = form2.F2520previous;
            f2600previous = form2.F2600previous;
            f2605previous = form2.F2605previous;
            f2610previous = form2.F2610previous;
            f2615previous = form2.F2615previous;
            f2650previous = form2.F2650previous;

            NotifyStateChanged();
        }
    }
}
