namespace AFS.Core.Models
{
    public class AFSModel : TrackedEntity
    {
        private int baseYear;
        private int currentYear;
        private string? companyName;

        public AFSModel()
        {
            CurrentYear = AFSConstraints.MaxYear;
            BaseYear = AFSConstraints.MaxYear - 1;
        }

        public Form1 F1Base { get; set; } = new();
        public Form1 F1Current { get; set; } = new();
        public Form2 F2Base { get; set; } = new();
        public Form2 F2Current { get; set; } = new();
        public AdditionalCompanyInfo AdditionalInfo { get; set; } = new();

        public string CompanyName
        {
            get => companyName ?? string.Empty;
            set => SetProperty(ref companyName, value);
        }
        public int BaseYear
        {
            get => baseYear;
            set
            {
                if (!baseYear.Equals(value))
                {
                    SetProperty(ref baseYear, value);
                    if (!CurrentYear.Equals(baseYear + 1))
                    {
                        SetProperty(ref currentYear, value + 1);
                    }
                }
            }
        }
        public int CurrentYear
        {
            get => currentYear;
            set
            {
                if (!currentYear.Equals(value))
                {
                    SetProperty(ref currentYear, value);
                    if (!BaseYear.Equals(currentYear - 1))
                    {
                        SetProperty(ref baseYear, value - 1);
                    }
                }
            }
        }
        internal void Init(AFSModel readModel)
        {
            companyName = readModel.CompanyName;
            baseYear = readModel.BaseYear;
            currentYear = readModel.CurrentYear;

            F1Base.Init(readModel.F1Base);
            F1Current.Init(readModel.F1Current);
            F2Base.Init(readModel.F2Base);
            F2Current.Init(readModel.F2Current);
            AdditionalInfo.Init(readModel.AdditionalInfo);

            OnPropertyChanged();
        }
        public void SubscribeOnChange(Action propertyChanged)
        {
            PropertyChanged += propertyChanged;
            F1Base.SubscribeOnChange(propertyChanged);
            F1Current.SubscribeOnChange(propertyChanged);
            F2Base.SubscribeOnChange(propertyChanged);
            F2Current.SubscribeOnChange(propertyChanged);
            AdditionalInfo.SubscribeOnChange(propertyChanged);

        }
        public void UnSubscribeOnChange(Action? propertyChanged)
        {
            if (propertyChanged != null)
            {
                PropertyChanged -= propertyChanged;
                F1Base.UnSubscribeOnChange(propertyChanged);
                F1Current.UnSubscribeOnChange(propertyChanged);
                F2Base.UnSubscribeOnChange(propertyChanged);
                F2Current.UnSubscribeOnChange(propertyChanged);
                AdditionalInfo.UnSubscribeOnChange(propertyChanged);
            }
        }
    }
}