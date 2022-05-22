namespace AFS.Core.Model
{
    public class Form2
    {
        public event Action? OnChange;

        public CurentPrevious F2000 { get; set; } = new();
        public CurentPrevious F2050 { get; set; } = new();
        public CurentPrevious F2120 { get; set; } = new();
        public CurentPrevious F2130 { get; set; } = new();
        public CurentPrevious F2150 { get; set; } = new();
        public CurentPrevious F2180 { get; set; } = new();
        public CurentPrevious F2200 { get; set; } = new();
        public CurentPrevious F2220 { get; set; } = new();
        public CurentPrevious F2240 { get; set; } = new();
        public CurentPrevious F2250 { get; set; } = new();
        public CurentPrevious F2255 { get; set; } = new();
        public CurentPrevious F2270 { get; set; } = new();
        public CurentPrevious F2300 { get; set; } = new();
        public CurentPrevious F2305 { get; set; } = new();
        public CurentPrevious F2400 { get; set; } = new();
        public CurentPrevious F2405 { get; set; } = new();
        public CurentPrevious F2410 { get; set; } = new();
        public CurentPrevious F2415 { get; set; } = new();
        public CurentPrevious F2445 { get; set; } = new();
        public CurentPrevious F2455 { get; set; } = new();
        public CurentPrevious F2500 { get; set; } = new();
        public CurentPrevious F2505 { get; set; } = new();
        public CurentPrevious F2510 { get; set; } = new();
        public CurentPrevious F2515 { get; set; } = new();
        public CurentPrevious F2520 { get; set; } = new();
        public CurentPrevious F2600 { get; set; } = new();
        public CurentPrevious F2605 { get; set; } = new();
        public CurentPrevious F2610 { get; set; } = new();
        public CurentPrevious F2615 { get; set; } = new();
        public CurentPrevious F2650 { get; set; } = new();

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

        public double GetF2090Curent() => F2000.Curent > F2050.Curent ? F2000.Curent - F2050.Curent : 0;
        public double GetF2090Previous() => F2000.Previous > F2050.Previous ? F2000.Previous - F2050.Previous : 0;
        public double GetF2095Curent() => F2000.Curent < F2050.Curent ? F2000.Curent - F2050.Curent : 0;
        public double GetF2095Previous() => F2000.Previous < F2050.Previous ? F2000.Previous - F2050.Previous : 0;

        public double GetF2190Curent()
        {
            double res = FinancialResultFromOperatingActivities(true);
            return res > 0 ? res : 0;
        }
        public double GetF2190Previous()
        {
            double res = FinancialResultFromOperatingActivities(false);
            return res > 0 ? res : 0;
        }
        public double GetF2195Curent()
        {

            double res = FinancialResultFromOperatingActivities(true);
            return res < 0 ? res : 0;
        }
        public double GetF2195Previous()
        {

            double res = FinancialResultFromOperatingActivities(false);
            return res < 0 ? res : 0;
        }
        public double GetF2290Curent()
        {
            double res = FinancialResultBeforeTax(true);
            return res > 0 ? res : 0;
        }
        public double GetF2290Previous()
        {
            double res = FinancialResultBeforeTax(false);
            return res > 0 ? res : 0;
        }
        public double GetF2295Curent()
        {
            double res = FinancialResultBeforeTax(true);
            return res < 0 ? res : 0;
        }
        public double GetF2295Previous()
        {
            double res = FinancialResultBeforeTax(false);
            return res < 0 ? res : 0;
        }
        public double GetF2350Curent()
        {
            double res = NetFinancialResult(true);
            return res > 0 ? res : 0;
        }
        public double GetF2350Previous()
        {
            double res = NetFinancialResult(false);
            return res > 0 ? res : 0;
        }
        public double GetF2355Curent()
        {
            double res = NetFinancialResult(true);
            return res < 0 ? res : 0;
        }
        public double GetF2355Previous()
        {
            double res = NetFinancialResult(false);
            return res < 0 ? res : 0;
        }
        public double GetF2450Curent() => OtherAggregatePreTaxIncome(true);
        public double GetF2450Previous() => OtherAggregatePreTaxIncome(false);
        public double GetF2460Curent() => GetF2450Curent() - F2455.Curent;
        public double GetF2460Previous() => GetF2450Previous() - F2455.Previous;
        public double GetF2465Curent() => GetF2350Curent() + GetF2355Curent() + GetF2460Curent();
        public double GetF2465Previous() => GetF2350Previous() + GetF2355Previous() + GetF2460Previous();
        public double GetF2550Curent() => F2500.Curent + F2505.Curent + F2510.Curent + F2515.Curent + F2520.Curent;
        public double GetF2550Previous() => F2500.Previous + F2505.Previous + F2510.Previous + F2515.Previous + F2520.Previous;

        private double FinancialResultFromOperatingActivities(bool Curent)
        {
            if (Curent)
            {
                return GetF2090Curent() + GetF2095Curent() + F2120.Curent - F2130.Curent - F2150.Curent - F2180.Curent;
            }
            return GetF2090Previous() + GetF2095Previous() + F2120.Previous - F2130.Previous - F2150.Previous - F2180.Previous;
        }

        private double FinancialResultBeforeTax(bool Curent)
        {
            if (Curent)
            {
                return GetF2190Curent() + GetF2195Curent() + F2200.Curent + F2220.Curent + F2240.Curent - F2250.Curent - F2255.Curent - F2270.Curent;
            }
            return GetF2190Previous() + GetF2195Previous() + F2200.Previous + F2220.Previous + F2240.Previous - F2250.Previous - F2255.Previous - F2270.Previous;
        }

        private double NetFinancialResult(bool Curent)
        {
            if (Curent)
            {
                return GetF2290Curent() + GetF2295Curent() - F2300.Curent + F2305.Curent;
            }
            return GetF2290Previous() + GetF2295Previous() - F2300.Previous + F2305.Previous;
        }
        private double OtherAggregatePreTaxIncome(bool Curent)
        {
            if (Curent)
            {
                return F2400.Curent + F2405.Curent + F2410.Curent + F2415.Curent + F2445.Curent;
            }
            return F2400.Previous + F2405.Previous + F2410.Previous + F2415.Previous + F2445.Previous;
        }
    }
}