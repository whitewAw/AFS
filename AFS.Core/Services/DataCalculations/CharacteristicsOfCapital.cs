using AFS.Core.Model;

namespace AFS.Core.Services.DataCalculations
{
    public class CharacteristicsOfCapital
    {
        public CharacteristicsOfCapital(AFSModel model) => Init(model);
        public TotalAssets TotalAssets { get; set; } = new();
        public NonCurrentImmobilizedFunds NonCurrentImmobilizedFunds { get; set; } = new();
        public CurrentMobileAssets CurrentMobileAssets { get; set; } = new();
        public LiabilitiesRelatedNonCurrentAssetsHeldForSale LiabilitiesRelatedNonCurrentAssetsHeldForSale { get; set; } = new();
        public TangibleCurrentAssets TangibleCurrentAssets { get; set; } = new();
        public FutureExpenses FutureExpenses { get; set; } = new();
        public CashCurrentFinancialInvestments CashCurrentFinancialInvestments { get; set; } = new();
        public OtherCurrentAssets OtherCurrentAssets { get; set; } = new();
        public AccountsReceivable AccountsReceivable { get; set; } = new();

        private void Init(AFSModel model)
        {
            TotalAssets.Init(model);
            NonCurrentImmobilizedFunds.Init(model);
            CurrentMobileAssets.Init(model);
            LiabilitiesRelatedNonCurrentAssetsHeldForSale.Init(model);
            TangibleCurrentAssets.Init(model);
            FutureExpenses.Init(model);
            CashCurrentFinancialInvestments.Init(model);
            OtherCurrentAssets.Init(model);
            AccountsReceivable.Init(model);
        }
    }

    public class TotalAssets
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1300begin;
            Base.EndOfYear = model.F1Base.F1300end;

            Current.BeginningOfyear = model.F1Current.F1300begin;
            Current.EndOfYear = model.F1Current.F1300end;
        }
    }

    public class NonCurrentImmobilizedFunds
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1095begin;
            Base.EndOfYear = model.F1Base.F1095end;

            Current.BeginningOfyear = model.F1Current.F1095begin;
            Current.EndOfYear = model.F1Current.F1095end;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1300begin * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1300end * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1300begin * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1300end * 100;
        }
    }
    public class CurrentMobileAssets
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1195begin;
            Base.EndOfYear = model.F1Base.F1195end;

            Current.BeginningOfyear = model.F1Current.F1195begin;
            Current.EndOfYear = model.F1Current.F1195end;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1300begin * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1300end * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1300begin * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1300end * 100;
        }
    }
    public class LiabilitiesRelatedNonCurrentAssetsHeldForSale
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1200begin;
            Base.EndOfYear = model.F1Base.F1200end;

            Current.BeginningOfyear = model.F1Current.F1200begin;
            Current.EndOfYear = model.F1Current.F1200end;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1300begin * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1300end * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1300begin * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1300end * 100;
        }
    }
    public class TangibleCurrentAssets
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1100begin + model.F1Base.F1110begin;
            Base.EndOfYear = model.F1Base.F1100end + model.F1Base.F1110end;

            Current.BeginningOfyear = model.F1Current.F1100begin + model.F1Current.F1110begin;
            Current.EndOfYear = model.F1Current.F1100end + model.F1Current.F1110end;

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1195begin * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1195end * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1195begin * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1195end * 100;
        }
    }
    public class FutureExpenses
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1170begin;
            Base.EndOfYear = model.F1Base.F1170end;

            Current.BeginningOfyear = model.F1Current.F1170begin;
            Current.EndOfYear = model.F1Current.F1170end;

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1195begin * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1195end * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1195begin * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1195end * 100;
        }
    }
    public class CashCurrentFinancialInvestments
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1160begin + model.F1Base.F1165begin;
            Base.EndOfYear = model.F1Base.F1160end + model.F1Base.F1165end;

            Current.BeginningOfyear = model.F1Current.F1160begin + model.F1Current.F1165begin;
            Current.EndOfYear = model.F1Current.F1160end + model.F1Current.F1165end;

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1195begin * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1195end * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1195begin * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1195end * 100;
        }
    }
    public class OtherCurrentAssets
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1190begin;
            Base.EndOfYear = model.F1Base.F1190end;

            Current.BeginningOfyear = model.F1Current.F1190begin;
            Current.EndOfYear = model.F1Current.F1190end;

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1195begin * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1195end * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1195begin * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1195end * 100;
        }
    }
    public class AccountsReceivable
    {
        public BasicCalculationData Base { get; private set; } = new();
        public BasicCalculationData Current { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public BasicCalculationData InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.AccountsReceivable(true);
            Base.EndOfYear = model.F1Base.AccountsReceivable(false);

            Current.BeginningOfyear = model.F1Current.AccountsReceivable(true);
            Current.EndOfYear = model.F1Current.AccountsReceivable(false);

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.F1195begin * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.F1195end * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.F1195begin * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.F1195end * 100;
        }
    }
}