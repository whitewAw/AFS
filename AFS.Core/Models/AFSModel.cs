﻿using AFS.Core.Models;

namespace AFS.Core.Model
{
    public class AFSModel: TrackedEntity
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
            set
            {
                if (!string.Equals(companyName, value))
                {
                    companyName = value;
                    NotifyStateChanged();
                }
            }
        }
        public int BaseYear
        {
            get => baseYear;
            set
            {
                if (!baseYear.Equals(value))
                {
                    baseYear = value;
                    if (baseYear + 1 != CurrentYear)
                    {
                        CurrentYear = baseYear + 1;
                    }
                    NotifyStateChanged();
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
                    currentYear = value;
                    if (currentYear - 1 != BaseYear)
                    {
                        BaseYear = currentYear - 1;
                    }
                    NotifyStateChanged();
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

            NotifyStateChanged();
        }
        public void SubscribeOnChange(Action onChange)
        {
            OnChange += onChange;
            F1Base.SubscribeOnChange(onChange);
            F1Current.SubscribeOnChange(onChange);
            F2Base.SubscribeOnChange(onChange);
            F2Current.SubscribeOnChange(onChange);
            AdditionalInfo.SubscribeOnChange(onChange);

        }
        public void UnSubscribeOnChange(Action? onChange)
        {
            if (onChange != null)
            {
                OnChange -= onChange;
                F1Base.UnSubscribeOnChange(onChange);
                F1Current.UnSubscribeOnChange(onChange);
                F2Base.UnSubscribeOnChange(onChange);
                F2Current.UnSubscribeOnChange(onChange);
                AdditionalInfo.UnSubscribeOnChange(onChange);
            }
        }
    }
}