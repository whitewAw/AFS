namespace AFS.Core.Models
{
    public class AdditionalCompanyInfo : TrackedEntity
    {
        private double averageNumberOfEmployeesBase;
        private double averageNumberOfEmployeesCurrent;

        public FixedAssetsInfo FixedAssetsInfoBase { get; set; } = new();
        public FixedAssetsInfo FixedAssetsInfoCurrent { get; set; } = new();

        public double AverageNumberOfEmployeesBase
        {
            get => averageNumberOfEmployeesBase;
            set => SetProperty(ref averageNumberOfEmployeesBase, AFSConstraints.RoundStat(value));
        }
        public double AverageNumberOfEmployeesCurrent
        {
            get => averageNumberOfEmployeesCurrent;
            set => SetProperty(ref averageNumberOfEmployeesCurrent, AFSConstraints.RoundStat(value));
        }

        internal void Init(AdditionalCompanyInfo info)
        {
            averageNumberOfEmployeesBase = info.AverageNumberOfEmployeesBase;
            averageNumberOfEmployeesCurrent = info.AverageNumberOfEmployeesCurrent;
            FixedAssetsInfoBase.Init(info.FixedAssetsInfoBase);
            FixedAssetsInfoCurrent.Init(info.FixedAssetsInfoCurrent);
        }

        public void SubscribeOnChange(Action propertyChanged)
        {
            PropertyChanged += propertyChanged;
            FixedAssetsInfoBase.PropertyChanged += propertyChanged;
            FixedAssetsInfoCurrent.PropertyChanged += propertyChanged;
        }
        public void UnSubscribeOnChange(Action? propertyChanged)
        {
            if (propertyChanged != null)
            {
                PropertyChanged -= propertyChanged;
                FixedAssetsInfoBase.PropertyChanged -= propertyChanged;
                FixedAssetsInfoCurrent.PropertyChanged -= propertyChanged;
            }
        }
    }

    public class FixedAssetsInfo : TrackedEntity
    {
        private double receivedFixedAssets;
        private double receivedNewFixedAssets;
        private double withdrawnFixedAssets;
        private double liquidatedFixedAssets;
        public double ReceivedFixedAssets
        {
            get => receivedFixedAssets;
            set => SetProperty(ref receivedFixedAssets, AFSConstraints.RoundStat(value));
        }
        public double ReceivedNewFixedAssets
        {
            get => receivedNewFixedAssets;
            set => SetProperty(ref receivedNewFixedAssets, AFSConstraints.RoundStat(value));
        }
        public double LeftFixedAssets
        {
            get => withdrawnFixedAssets;
            set => SetProperty(ref withdrawnFixedAssets, AFSConstraints.RoundStat(value));
        }
        public double LiquidatedFixedAssets
        {
            get => liquidatedFixedAssets;
            set => SetProperty(ref liquidatedFixedAssets, AFSConstraints.RoundStat(value));
        }

        internal void Init(FixedAssetsInfo info)
        {
            receivedFixedAssets = info.ReceivedFixedAssets;
            receivedNewFixedAssets = info.ReceivedNewFixedAssets;
            withdrawnFixedAssets = info.LeftFixedAssets;
            liquidatedFixedAssets = info.LiquidatedFixedAssets;
        }
    }
}