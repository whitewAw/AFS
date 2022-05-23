namespace AFS.Core.Model
{
    public class Form2
    {
        public event Action? OnChange;

        public CurrentPrevious F2000 { get; set; } = new();
        public CurrentPrevious F2050 { get; set; } = new();
        public CurrentPrevious F2120 { get; set; } = new();
        public CurrentPrevious F2130 { get; set; } = new();
        public CurrentPrevious F2150 { get; set; } = new();
        public CurrentPrevious F2180 { get; set; } = new();
        public CurrentPrevious F2200 { get; set; } = new();
        public CurrentPrevious F2220 { get; set; } = new();
        public CurrentPrevious F2240 { get; set; } = new();
        public CurrentPrevious F2250 { get; set; } = new();
        public CurrentPrevious F2255 { get; set; } = new();
        public CurrentPrevious F2270 { get; set; } = new();
        public CurrentPrevious F2300 { get; set; } = new();
        public CurrentPrevious F2305 { get; set; } = new();
        public CurrentPrevious F2400 { get; set; } = new();
        public CurrentPrevious F2405 { get; set; } = new();
        public CurrentPrevious F2410 { get; set; } = new();
        public CurrentPrevious F2415 { get; set; } = new();
        public CurrentPrevious F2445 { get; set; } = new();
        public CurrentPrevious F2455 { get; set; } = new();
        public CurrentPrevious F2500 { get; set; } = new();
        public CurrentPrevious F2505 { get; set; } = new();
        public CurrentPrevious F2510 { get; set; } = new();
        public CurrentPrevious F2515 { get; set; } = new();
        public CurrentPrevious F2520 { get; set; } = new();
        public CurrentPrevious F2600 { get; set; } = new();
        public CurrentPrevious F2605 { get; set; } = new();
        public CurrentPrevious F2610 { get; set; } = new();
        public CurrentPrevious F2615 { get; set; } = new();
        public CurrentPrevious F2650 { get; set; } = new();

        private void NotifyStateChanged() => OnChange?.Invoke();

        internal void Init(Form2 form2)
        {
            F2000.Init(form2.F2000);
            F2050.Init(form2.F2050);
            F2120.Init(form2.F2120);
            F2130.Init(form2.F2130);
            F2150.Init(form2.F2150);
            F2180.Init(form2.F2180);
            F2200.Init(form2.F2200);
            F2220.Init(form2.F2220);
            F2240.Init(form2.F2240);
            F2250.Init(form2.F2250);
            F2255.Init(form2.F2255);
            F2270.Init(form2.F2270);
            F2300.Init(form2.F2300);
            F2305.Init(form2.F2305);
            F2400.Init(form2.F2400);
            F2405.Init(form2.F2405);
            F2410.Init(form2.F2410);
            F2415.Init(form2.F2415);
            F2445.Init(form2.F2445);
            F2455.Init(form2.F2455);
            F2500.Init(form2.F2500);
            F2505.Init(form2.F2505);
            F2510.Init(form2.F2510);
            F2515.Init(form2.F2515);
            F2520.Init(form2.F2520);
            F2600.Init(form2.F2600);
            F2605.Init(form2.F2605);
            F2610.Init(form2.F2610);
            F2615.Init(form2.F2615);
            F2650.Init(form2.F2650);

            NotifyStateChanged();
        }

        internal void SubscribeOnChange(Action onChange)
        {
            F2000.OnChange += onChange;
            F2050.OnChange += onChange;
            F2120.OnChange += onChange;
            F2130.OnChange += onChange;
            F2150.OnChange += onChange;
            F2180.OnChange += onChange;
            F2200.OnChange += onChange;
            F2220.OnChange += onChange;
            F2240.OnChange += onChange;
            F2250.OnChange += onChange;
            F2255.OnChange += onChange;
            F2270.OnChange += onChange;
            F2300.OnChange += onChange;
            F2305.OnChange += onChange;
            F2400.OnChange += onChange;
            F2405.OnChange += onChange;
            F2410.OnChange += onChange;
            F2415.OnChange += onChange;
            F2445.OnChange += onChange;
            F2455.OnChange += onChange;
            F2500.OnChange += onChange;
            F2505.OnChange += onChange;
            F2510.OnChange += onChange;
            F2515.OnChange += onChange;
            F2520.OnChange += onChange;
            F2600.OnChange += onChange;
            F2605.OnChange += onChange;
            F2610.OnChange += onChange;
            F2615.OnChange += onChange;
            F2650.OnChange += onChange;
        }

        internal void UnSubscribeOnChange(Action onChange)
        {
            F2000.OnChange -= onChange;
            F2050.OnChange -= onChange;
            F2120.OnChange -= onChange;
            F2130.OnChange -= onChange;
            F2150.OnChange -= onChange;
            F2180.OnChange -= onChange;
            F2200.OnChange -= onChange;
            F2220.OnChange -= onChange;
            F2240.OnChange -= onChange;
            F2250.OnChange -= onChange;
            F2255.OnChange -= onChange;
            F2270.OnChange -= onChange;
            F2300.OnChange -= onChange;
            F2305.OnChange -= onChange;
            F2400.OnChange -= onChange;
            F2405.OnChange -= onChange;
            F2410.OnChange -= onChange;
            F2415.OnChange -= onChange;
            F2445.OnChange -= onChange;
            F2455.OnChange -= onChange;
            F2500.OnChange -= onChange;
            F2505.OnChange -= onChange;
            F2510.OnChange -= onChange;
            F2515.OnChange -= onChange;
            F2520.OnChange -= onChange;
            F2600.OnChange -= onChange;
            F2605.OnChange -= onChange;
            F2610.OnChange -= onChange;
            F2615.OnChange -= onChange;
            F2650.OnChange -= onChange;

        }

        public double GetF2090Current() => F2000.Current > F2050.Current ? F2000.Current - F2050.Current : 0;
        public double GetF2090Previous() => F2000.Previous > F2050.Previous ? F2000.Previous - F2050.Previous : 0;
        public double GetF2095Current() => F2000.Current < F2050.Current ? F2000.Current - F2050.Current : 0;
        public double GetF2095Previous() => F2000.Previous < F2050.Previous ? F2000.Previous - F2050.Previous : 0;

        public double GetF2190Current()
        {
            double res = FinancialResultFromOperatingActivities(true);
            return res > 0 ? res : 0;
        }
        public double GetF2190Previous()
        {
            double res = FinancialResultFromOperatingActivities(false);
            return res > 0 ? res : 0;
        }
        public double GetF2195Current()
        {

            double res = FinancialResultFromOperatingActivities(true);
            return res < 0 ? res : 0;
        }
        public double GetF2195Previous()
        {

            double res = FinancialResultFromOperatingActivities(false);
            return res < 0 ? res : 0;
        }
        public double GetF2290Current()
        {
            double res = FinancialResultBeforeTax(true);
            return res > 0 ? res : 0;
        }
        public double GetF2290Previous()
        {
            double res = FinancialResultBeforeTax(false);
            return res > 0 ? res : 0;
        }
        public double GetF2295Current()
        {
            double res = FinancialResultBeforeTax(true);
            return res < 0 ? res : 0;
        }
        public double GetF2295Previous()
        {
            double res = FinancialResultBeforeTax(false);
            return res < 0 ? res : 0;
        }
        public double GetF2350Current()
        {
            double res = NetFinancialResult(true);
            return res > 0 ? res : 0;
        }
        public double GetF2350Previous()
        {
            double res = NetFinancialResult(false);
            return res > 0 ? res : 0;
        }
        public double GetF2355Current()
        {
            double res = NetFinancialResult(true);
            return res < 0 ? res : 0;
        }
        public double GetF2355Previous()
        {
            double res = NetFinancialResult(false);
            return res < 0 ? res : 0;
        }
        public double GetF2450Current() => OtherAggregatePreTaxIncome(true);
        public double GetF2450Previous() => OtherAggregatePreTaxIncome(false);
        public double GetF2460Current() => GetF2450Current() - F2455.Current;
        public double GetF2460Previous() => GetF2450Previous() - F2455.Previous;
        public double GetF2465Current() => GetF2350Current() + GetF2355Current() + GetF2460Current();
        public double GetF2465Previous() => GetF2350Previous() + GetF2355Previous() + GetF2460Previous();
        public double GetF2550Current() => F2500.Current + F2505.Current + F2510.Current + F2515.Current + F2520.Current;
        public double GetF2550Previous() => F2500.Previous + F2505.Previous + F2510.Previous + F2515.Previous + F2520.Previous;

        private double FinancialResultFromOperatingActivities(bool Current)
        {
            if (Current)
            {
                return GetF2090Current() + GetF2095Current() + F2120.Current - F2130.Current - F2150.Current - F2180.Current;
            }
            return GetF2090Previous() + GetF2095Previous() + F2120.Previous - F2130.Previous - F2150.Previous - F2180.Previous;
        }

        private double FinancialResultBeforeTax(bool Current)
        {
            if (Current)
            {
                return GetF2190Current() + GetF2195Current() + F2200.Current + F2220.Current + F2240.Current - F2250.Current - F2255.Current - F2270.Current;
            }
            return GetF2190Previous() + GetF2195Previous() + F2200.Previous + F2220.Previous + F2240.Previous - F2250.Previous - F2255.Previous - F2270.Previous;
        }

        private double NetFinancialResult(bool Current)
        {
            if (Current)
            {
                return GetF2290Current() + GetF2295Current() - F2300.Current + F2305.Current;
            }
            return GetF2290Previous() + GetF2295Previous() - F2300.Previous + F2305.Previous;
        }
        private double OtherAggregatePreTaxIncome(bool Current)
        {
            if (Current)
            {
                return F2400.Current + F2405.Current + F2410.Current + F2415.Current + F2445.Current;
            }
            return F2400.Previous + F2405.Previous + F2410.Previous + F2415.Previous + F2445.Previous;
        }
    }
}