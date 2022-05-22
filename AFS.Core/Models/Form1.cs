namespace AFS.Core.Model
{
    public class Form1
    {
        public event Action? OnChange;

        public BeginEnd F1001 { get; set; } = new();
        public BeginEnd F1002 { get; set; } = new();
        public BeginEnd F1005 { get; set; } = new();
        public BeginEnd F1011 { get; set; } = new();
        public BeginEnd F1012 { get; set; } = new();
        public BeginEnd F1015 { get; set; } = new();
        public BeginEnd F1020 { get; set; } = new();
        public BeginEnd F1030 { get; set; } = new();
        public BeginEnd F1035 { get; set; } = new();
        public BeginEnd F1040 { get; set; } = new();
        public BeginEnd F1045 { get; set; } = new();
        public BeginEnd F1090 { get; set; } = new();
        public BeginEnd F1101 { get; set; } = new();
        public BeginEnd F1102 { get; set; } = new();
        public BeginEnd F1103 { get; set; } = new();
        public BeginEnd F1104 { get; set; } = new();
        public BeginEnd F1110 { get; set; } = new();
        public BeginEnd F1120 { get; set; } = new();
        public BeginEnd F1125 { get; set; } = new();
        public BeginEnd F1130 { get; set; } = new();
        public BeginEnd F1135 { get; set; } = new();
        public BeginEnd F1136 { get; set; } = new();
        public BeginEnd F1140 { get; set; } = new();
        public BeginEnd F1145 { get; set; } = new();
        public BeginEnd F1155 { get; set; } = new();
        public BeginEnd F1160 { get; set; } = new();
        public BeginEnd F1165 { get; set; } = new();
        public BeginEnd F1170 { get; set; } = new();
        public BeginEnd F1190 { get; set; } = new();
        public BeginEnd F1200 { get; set; } = new();
        public BeginEnd F1400 { get; set; } = new();
        public BeginEnd F1405 { get; set; } = new();
        public BeginEnd F1410 { get; set; } = new();
        public BeginEnd F1415 { get; set; } = new();
        public BeginEnd F1420 { get; set; } = new();
        public BeginEnd F1425 { get; set; } = new();
        public BeginEnd F1430 { get; set; } = new();
        public BeginEnd F1500 { get; set; } = new();
        public BeginEnd F1510 { get; set; } = new();
        public BeginEnd F1515 { get; set; } = new();
        public BeginEnd F1520 { get; set; } = new();
        public BeginEnd F1525 { get; set; } = new();
        public BeginEnd F1600 { get; set; } = new();
        public BeginEnd F1605 { get; set; } = new();
        public BeginEnd F1610 { get; set; } = new();
        public BeginEnd F1615 { get; set; } = new();
        public BeginEnd F1620 { get; set; } = new();
        public BeginEnd F1621 { get; set; } = new();
        public BeginEnd F1625 { get; set; } = new();
        public BeginEnd F1630 { get; set; } = new();
        public BeginEnd F1635 { get; set; } = new();
        public BeginEnd F1640 { get; set; } = new();
        public BeginEnd F1645 { get; set; } = new();
        public BeginEnd F1660 { get; set; } = new();
        public BeginEnd F1665 { get; set; } = new();
        public BeginEnd F1690 { get; set; } = new();
        public BeginEnd F1700 { get; set; } = new();

        private void NotifyStateChanged() => OnChange?.Invoke();

        internal void Init(Form1 form1)
        {
            F1001.Init(form1.F1001);
            F1002.Init(form1.F1002);
            F1005.Init(form1.F1005);
            F1011.Init(form1.F1011);
            F1012.Init(form1.F1012);
            F1015.Init(form1.F1015);
            F1020.Init(form1.F1020);
            F1030.Init(form1.F1030);
            F1035.Init(form1.F1035);
            F1040.Init(form1.F1040);
            F1045.Init(form1.F1045);
            F1090.Init(form1.F1090);
            F1101.Init(form1.F1101);
            F1102.Init(form1.F1102);
            F1103.Init(form1.F1103);
            F1104.Init(form1.F1104);
            F1110.Init(form1.F1110);
            F1120.Init(form1.F1120);
            F1125.Init(form1.F1125);
            F1130.Init(form1.F1130);
            F1135.Init(form1.F1135);
            F1136.Init(form1.F1136);
            F1140.Init(form1.F1140);
            F1145.Init(form1.F1145);
            F1155.Init(form1.F1155);
            F1160.Init(form1.F1160);
            F1165.Init(form1.F1165);
            F1170.Init(form1.F1170);
            F1190.Init(form1.F1190);
            F1200.Init(form1.F1200);
            F1400.Init(form1.F1400);
            F1405.Init(form1.F1405);
            F1410.Init(form1.F1410);
            F1415.Init(form1.F1415);
            F1420.Init(form1.F1420);
            F1425.Init(form1.F1425);
            F1430.Init(form1.F1430);
            F1500.Init(form1.F1500);
            F1510.Init(form1.F1510);
            F1515.Init(form1.F1515);
            F1520.Init(form1.F1520);
            F1525.Init(form1.F1525);
            F1600.Init(form1.F1600);
            F1605.Init(form1.F1605);
            F1610.Init(form1.F1610);
            F1615.Init(form1.F1615);
            F1620.Init(form1.F1620);
            F1621.Init(form1.F1621);
            F1625.Init(form1.F1625);
            F1630.Init(form1.F1630);
            F1635.Init(form1.F1635);
            F1640.Init(form1.F1640);
            F1645.Init(form1.F1645);
            F1660.Init(form1.F1660);
            F1665.Init(form1.F1665);
            F1690.Init(form1.F1690);
            F1700.Init(form1.F1700);

            NotifyStateChanged();
        }

        internal void SubscribeOnChange(Action onChange)
        {
            F1001.OnChange += onChange;
            F1002.OnChange += onChange;
            F1005.OnChange += onChange;
            F1011.OnChange += onChange;
            F1012.OnChange += onChange;
            F1015.OnChange += onChange;
            F1020.OnChange += onChange;
            F1030.OnChange += onChange;
            F1035.OnChange += onChange;
            F1040.OnChange += onChange;
            F1045.OnChange += onChange;
            F1090.OnChange += onChange;
            F1101.OnChange += onChange;
            F1102.OnChange += onChange;
            F1103.OnChange += onChange;
            F1104.OnChange += onChange;
            F1110.OnChange += onChange;
            F1120.OnChange += onChange;
            F1125.OnChange += onChange;
            F1130.OnChange += onChange;
            F1135.OnChange += onChange;
            F1136.OnChange += onChange;
            F1140.OnChange += onChange;
            F1145.OnChange += onChange;
            F1155.OnChange += onChange;
            F1160.OnChange += onChange;
            F1165.OnChange += onChange;
            F1170.OnChange += onChange;
            F1190.OnChange += onChange;
            F1200.OnChange += onChange;
            F1400.OnChange += onChange;
            F1405.OnChange += onChange;
            F1410.OnChange += onChange;
            F1415.OnChange += onChange;
            F1420.OnChange += onChange;
            F1425.OnChange += onChange;
            F1430.OnChange += onChange;
            F1500.OnChange += onChange;
            F1510.OnChange += onChange;
            F1515.OnChange += onChange;
            F1520.OnChange += onChange;
            F1525.OnChange += onChange;
            F1600.OnChange += onChange;
            F1605.OnChange += onChange;
            F1610.OnChange += onChange;
            F1615.OnChange += onChange;
            F1620.OnChange += onChange;
            F1621.OnChange += onChange;
            F1625.OnChange += onChange;
            F1630.OnChange += onChange;
            F1635.OnChange += onChange;
            F1640.OnChange += onChange;
            F1645.OnChange += onChange;
            F1660.OnChange += onChange;
            F1665.OnChange += onChange;
            F1690.OnChange += onChange;
            F1700.OnChange += onChange;
        }

        internal void UnSubscribeOnChange(Action onChange)
        {
            F1001.OnChange -= onChange;
            F1002.OnChange -= onChange;
            F1005.OnChange -= onChange;
            F1011.OnChange -= onChange;
            F1012.OnChange -= onChange;
            F1015.OnChange -= onChange;
            F1020.OnChange -= onChange;
            F1030.OnChange -= onChange;
            F1035.OnChange -= onChange;
            F1040.OnChange -= onChange;
            F1045.OnChange -= onChange;
            F1090.OnChange -= onChange;
            F1101.OnChange -= onChange;
            F1102.OnChange -= onChange;
            F1103.OnChange -= onChange;
            F1104.OnChange -= onChange;
            F1110.OnChange -= onChange;
            F1120.OnChange -= onChange;
            F1125.OnChange -= onChange;
            F1130.OnChange -= onChange;
            F1135.OnChange -= onChange;
            F1136.OnChange -= onChange;
            F1140.OnChange -= onChange;
            F1145.OnChange -= onChange;
            F1155.OnChange -= onChange;
            F1160.OnChange -= onChange;
            F1165.OnChange -= onChange;
            F1170.OnChange -= onChange;
            F1190.OnChange -= onChange;
            F1200.OnChange -= onChange;
            F1400.OnChange -= onChange;
            F1405.OnChange -= onChange;
            F1410.OnChange -= onChange;
            F1415.OnChange -= onChange;
            F1420.OnChange -= onChange;
            F1425.OnChange -= onChange;
            F1430.OnChange -= onChange;
            F1500.OnChange -= onChange;
            F1510.OnChange -= onChange;
            F1515.OnChange -= onChange;
            F1520.OnChange -= onChange;
            F1525.OnChange -= onChange;
            F1600.OnChange -= onChange;
            F1605.OnChange -= onChange;
            F1610.OnChange -= onChange;
            F1615.OnChange -= onChange;
            F1620.OnChange -= onChange;
            F1621.OnChange -= onChange;
            F1625.OnChange -= onChange;
            F1630.OnChange -= onChange;
            F1635.OnChange -= onChange;
            F1640.OnChange -= onChange;
            F1645.OnChange -= onChange;
            F1660.OnChange -= onChange;
            F1665.OnChange -= onChange;
            F1690.OnChange -= onChange;
            F1700.OnChange -= onChange;
        }

        public double GetF1000Begin() => F1001.Begin - F1002.Begin;
        public double GetF1000End() => F1001.End - F1002.End;
        public double GetF1010Begin() => F1011.Begin - F1012.Begin;
        public double GetF1010End() => F1011.End - F1012.End;
        public double GetF1095Begin() => GetF1000Begin() + F1005.Begin + GetF1010Begin() + F1015.Begin + F1020.Begin + F1030.Begin + F1035.Begin + F1040.Begin + F1045.Begin + F1090.Begin;
        public double GetF1095End() => GetF1000End() + F1005.End + GetF1010End() + F1015.End + F1020.End + F1030.End + F1035.End + F1040.End + F1045.End + F1090.End;
        public double GetF1100Begin() => F1101.Begin + F1102.Begin + F1103.Begin + F1104.Begin;
        public double GetF1100End() => F1101.End + F1102.End + F1103.End + F1104.End;
        public double GetF1195Begin() => GetF1100Begin() + F1110.Begin + F1120.Begin + F1125.Begin + F1130.Begin + F1135.Begin + F1140.Begin + F1145.Begin + F1155.Begin + F1160.Begin + F1165.Begin + F1170.Begin + F1190.Begin;
        public double GetF1195End() => GetF1100End() + F1110.End + F1120.End + F1125.End + F1130.End + F1135.End + F1140.End + F1145.End + F1155.End + F1160.End + F1165.End + F1170.End + F1190.End;
        public double GetF1300Begin() => GetF1095Begin() + GetF1195Begin() + F1200.Begin;
        public double GetF1300End() => GetF1095End() + GetF1195End() + F1200.End;
        public double GetF1495Begin() => F1400.Begin + F1405.Begin + F1410.Begin + F1415.Begin + F1420.Begin - F1425.Begin - F1430.Begin;
        public double GetF1495End() => F1400.End + F1405.End + F1410.End + F1415.End + F1420.End - F1425.End - F1430.End;
        public double GetF1595Begin() => F1500.Begin + F1510.Begin + F1515.Begin + F1520.Begin + F1525.Begin;
        public double GetF1595End() => F1500.End + F1510.End + F1515.End + F1520.End + F1525.End;
        public double GetF1695Begin() => F1600.Begin + F1605.Begin + F1610.Begin + F1615.Begin + F1620.Begin + F1625.Begin + F1630.Begin + F1635.Begin + F1640.Begin + F1645.Begin + F1660.Begin + F1665.Begin + F1690.Begin;
        public double GetF1695End() => F1600.End + F1605.End + F1610.End + F1615.End + F1620.End + F1625.End + F1630.End + F1635.End + F1640.End + F1645.End + F1660.End + F1665.End + F1690.End;
        public double GetF1900Begin() => GetF1495Begin() + GetF1595Begin() + GetF1695Begin() + F1700.Begin;
        public double GetF1900End() => GetF1495End() + GetF1595End() + GetF1695End() + F1700.End;

        internal double GetAccountsTangibleAssets(bool begin)
        {
            if (begin)
            {
                return GetF1100Begin() + F1110.Begin;
            }
            return GetF1100End() + F1110.End;
        }
        internal double GetAccountsReceivable(bool begin)
        {
            if (begin)
            {
                return F1120.Begin + F1125.Begin + F1130.Begin + F1135.Begin + F1140.Begin + F1145.Begin + F1155.Begin;
            }
            return F1120.End + F1125.End + F1130.End + F1135.End + F1140.End + F1145.End + F1155.End;
        }
        internal double GetAccountsMoney(bool begin)
        {
            if (begin)
            {
                return F1160.Begin + F1165.Begin;
            }
            return F1160.End + F1165.End;
        }
    }
}