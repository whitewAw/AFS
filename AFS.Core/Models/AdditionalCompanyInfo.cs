using AFS.Core.Model;

namespace AFS.Core.Models
{
    public class AdditionalCompanyInfo
    {

        private int averageNumberOfEmployeesBase;
        private int averageNumberOfEmployeesCurrent;

        public event Action? OnChange;

        public FixedAssetsInfo FixedAssetsInfoBase { get; set; } = new();
        public FixedAssetsInfo FixedAssetsInfoCurrent { get; set; } = new();

        public int AverageNumberOfEmployeesBase
        {
            get => averageNumberOfEmployeesBase;
            set
            {
                averageNumberOfEmployeesBase = value;
                NotifyStateChanged();
            }
        }
        public int AverageNumberOfEmployeesCurrent
        {
            get => averageNumberOfEmployeesCurrent;
            set
            {
                averageNumberOfEmployeesCurrent = value;
                NotifyStateChanged();
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        internal void Init(AdditionalCompanyInfo info)
        {
            averageNumberOfEmployeesBase = info.AverageNumberOfEmployeesBase;
            averageNumberOfEmployeesCurrent = info.AverageNumberOfEmployeesCurrent;
            FixedAssetsInfoBase.Init(info.FixedAssetsInfoBase);
            FixedAssetsInfoCurrent.Init(info.FixedAssetsInfoCurrent);

            NotifyStateChanged();
        }

        public void SubscribeOnChange(Action onChange)
        {
            OnChange += onChange;
            FixedAssetsInfoBase.OnChange += onChange;
            FixedAssetsInfoCurrent.OnChange += onChange;
        }
        public void UnSubscribeOnChange(Action? onChange)
        {
            if (onChange != null)
            {
                OnChange -= onChange;
                FixedAssetsInfoBase.OnChange -= onChange;
                FixedAssetsInfoCurrent.OnChange -= onChange;
            }
        }
    }

    public class FixedAssetsInfo
    {
        private double receivedFixedAssets;
        private double receivedNewFixedAssets;
        private double withdrawnFixedAssets;
        private double liquidatedFixedAssets;

        public event Action? OnChange;
        public double ReceivedFixedAssets
        {
            get => receivedFixedAssets;
            set
            {
                receivedFixedAssets = AFSConstraints.RoundStat(value);
                NotifyStateChanged();
            }
        }
        public double ReceivedNewFixedAssets
        {
            get => receivedNewFixedAssets;
            set
            {
                receivedNewFixedAssets = AFSConstraints.RoundStat(value);
                NotifyStateChanged();
            }
        }
        public double LeftFixedAssets
        {
            get => withdrawnFixedAssets;
            set
            {
                withdrawnFixedAssets = AFSConstraints.RoundStat(value);
                NotifyStateChanged();
            }
        }
        public double LiquidatedFixedAssets
        {
            get => liquidatedFixedAssets;
            set
            {
                liquidatedFixedAssets = AFSConstraints.RoundStat(value);
                NotifyStateChanged();
            }
        }

        internal void Init(FixedAssetsInfo info)
        {
            receivedFixedAssets = info.ReceivedFixedAssets;
            receivedNewFixedAssets = info.ReceivedNewFixedAssets;
            withdrawnFixedAssets = info.LeftFixedAssets;
            liquidatedFixedAssets = info.LiquidatedFixedAssets;

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}