using AFS.Core.Models;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class CharacteristicsOfCapital
    {
        public TotalAssets TotalAssets { get; private set; } = new();
        public NonCurrentImmobilizedFunds NonCurrentImmobilizedFunds { get; private set; } = new();
        public CurrentMobileAssets CurrentMobileAssets { get; private set; } = new();
        public TangibleCurrentAssets TangibleCurrentAssets { get; private set; } = new();
        public AccountsReceivable AccountsReceivable { get; private set; } = new();
        public CashCurrentFinancialInvestments CashCurrentFinancialInvestments { get; private set; } = new();
        public OtherCurrentAssets OtherCurrentAssets { get; private set; } = new();
        public NonCurrentAssetsHeldForSale NonCurrentAssetsHeldForSale { get; private set; } = new();
        public FutureExpenses FutureExpenses { get; private set; } = new();

        public CharacteristicsOfCapital(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            TotalAssets.Init(model);
            NonCurrentImmobilizedFunds.Init(model);
            CurrentMobileAssets.Init(model);
            TangibleCurrentAssets.Init(model, CurrentMobileAssets);
            AccountsReceivable.Init(model, CurrentMobileAssets);
            CashCurrentFinancialInvestments.Init(model, CurrentMobileAssets);
            OtherCurrentAssets.Init(model, CurrentMobileAssets);
            NonCurrentAssetsHeldForSale.Init(model, CurrentMobileAssets);
            FutureExpenses.Init(model);
        }
    }

    public class TotalAssets
    {
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1300Begin();
            Base.EndOfYear = model.F1Base.GetF1300End();

            Current.BeginningOfyear = model.F1Current.GetF1300Begin();
            Current.EndOfYear = model.F1Current.GetF1300End();
        }
    }

    public class NonCurrentImmobilizedFunds
    {
        public string Number { get; private set; } = "1.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1095Begin();
            Base.EndOfYear = model.F1Base.GetF1095End();

            Current.BeginningOfyear = model.F1Current.GetF1095Begin();
            Current.EndOfYear = model.F1Current.GetF1095End();

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.GetF1300Begin() * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.GetF1300End() * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.GetF1300Begin() * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.GetF1300End() * 100;
        }
    }
    public class CurrentMobileAssets
    {
        public string Number { get; private set; } = "2.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1195Begin() - model.F1Base.F1170.Begin + model.F1Base.F1200.Begin;
            Base.EndOfYear = model.F1Base.GetF1195End() - model.F1Base.F1170.End + model.F1Base.F1200.End;

            Current.BeginningOfyear = model.F1Current.GetF1195Begin() - model.F1Current.F1170.Begin + model.F1Current.F1200.Begin;
            Current.EndOfYear = model.F1Current.GetF1195End() - model.F1Current.F1170.End + model.F1Current.F1200.End;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.GetF1300Begin() * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.GetF1300End() * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.GetF1300Begin() * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.GetF1300End() * 100;
        }
    }
    public class TangibleCurrentAssets
    {
        public string Number { get; private set; } = "2.1.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model, CurrentMobileAssets currentMobileAssets)
        {
            Base.BeginningOfyear = model.F1Base.GetAccountsTangibleAssets(true);
            Base.EndOfYear = model.F1Base.GetAccountsTangibleAssets(false);

            Current.BeginningOfyear = model.F1Current.GetAccountsTangibleAssets(true);
            Current.EndOfYear = model.F1Current.GetAccountsTangibleAssets(false);

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / currentMobileAssets.Base.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / currentMobileAssets.Base.EndOfYear * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / currentMobileAssets.Current.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / currentMobileAssets.Current.EndOfYear * 100;
        }
    }
    public class AccountsReceivable
    {
        public string Number { get; private set; } = "2.2.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model, CurrentMobileAssets currentMobileAssets)
        {
            Base.BeginningOfyear = model.F1Base.GetAccountsReceivable(true);
            Base.EndOfYear = model.F1Base.GetAccountsReceivable(false);

            Current.BeginningOfyear = model.F1Current.GetAccountsReceivable(true);
            Current.EndOfYear = model.F1Current.GetAccountsReceivable(false);

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / currentMobileAssets.Base.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / currentMobileAssets.Base.EndOfYear * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / currentMobileAssets.Current.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / currentMobileAssets.Current.EndOfYear * 100;
        }
    }
    public class CashCurrentFinancialInvestments
    {
        public string Number { get; private set; } = "2.3.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model, CurrentMobileAssets currentMobileAssets)
        {
            Base.BeginningOfyear = model.F1Base.GetAccountsMoney(true);
            Base.EndOfYear = model.F1Base.GetAccountsMoney(false);

            Current.BeginningOfyear = model.F1Current.GetAccountsMoney(true);
            Current.EndOfYear = model.F1Current.GetAccountsMoney(false);

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / currentMobileAssets.Base.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / currentMobileAssets.Base.EndOfYear * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / currentMobileAssets.Current.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / currentMobileAssets.Current.EndOfYear * 100;
        }
    }
    public class OtherCurrentAssets
    {
        public string Number { get; private set; } = "2.4.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model, CurrentMobileAssets currentMobileAssets)
        {
            Base.BeginningOfyear = model.F1Base.F1190.Begin;
            Base.EndOfYear = model.F1Base.F1190.End;

            Current.BeginningOfyear = model.F1Current.F1190.Begin;
            Current.EndOfYear = model.F1Current.F1190.End;

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / currentMobileAssets.Base.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / currentMobileAssets.Base.EndOfYear * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / currentMobileAssets.Current.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / currentMobileAssets.Current.EndOfYear * 100;
        }
    }
    public class NonCurrentAssetsHeldForSale
    {
        public string Number { get; private set; } = "2.5";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfCurrentAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model, CurrentMobileAssets currentMobileAssets)
        {
            Base.BeginningOfyear = model.F1Base.F1200.Begin;
            Base.EndOfYear = model.F1Base.F1200.End;

            Current.BeginningOfyear = model.F1Current.F1200.Begin;
            Current.EndOfYear = model.F1Current.F1200.End;

            InPercentageOfCurrentAssetsBase.BeginningOfyear = Base.BeginningOfyear / currentMobileAssets.Base.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsBase.EndOfYear = Base.EndOfYear / currentMobileAssets.Base.EndOfYear * 100;

            InPercentageOfCurrentAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / currentMobileAssets.Current.BeginningOfyear * 100;
            InPercentageOfCurrentAssetsCurrent.EndOfYear = Current.EndOfYear / currentMobileAssets.Current.EndOfYear * 100;
        }
    }

    public class FutureExpenses
    {
        public string Number { get; private set; } = "3.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1170.Begin;
            Base.EndOfYear = model.F1Base.F1170.End;

            Current.BeginningOfyear = model.F1Current.F1170.Begin;
            Current.EndOfYear = model.F1Current.F1170.End;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.GetF1300Begin() * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.GetF1300End() * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.GetF1300Begin() * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.GetF1300End() * 100;
        }
    }
}