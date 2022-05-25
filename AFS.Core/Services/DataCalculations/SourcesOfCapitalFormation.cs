using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class SourcesOfCapitalFormation
    {
        public TotalSourcesOfCapital TotalSourcesOfCapital { get; set; } = new();
        public Equity Equity { get; set; } = new();
        public OwnCurrentAssets OwnCurrentAssets { get; set; } = new();
        public RaisedCapital RaisedCapital { get; set; } = new();
        public LongTermLiabilities LongTermLiabilities { get; private set; } = new();
        public ShortTermLoans ShortTermLoans { get; private set; } = new();
        public AccountsPayable AccountsPayable { get; private set; } = new();
        public OtherCurrentLiabilities OtherCurrentLiabilities { get; private set; } = new();
        public LiabilitiesRelatedNonCurrentAssetsHeldForSale LiabilitiesRelatedNonCurrentAssetsHeldForSale { get; set; } = new();
        public FutureIncome FutureIncome { get; private set; } = new();

        public SourcesOfCapitalFormation(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            TotalSourcesOfCapital.Init(model);
            Equity.Init(model);
            OwnCurrentAssets.Init(model, Equity);
            RaisedCapital.Init(model);
            LongTermLiabilities.Init(model, RaisedCapital);
            ShortTermLoans.Init(model, RaisedCapital);
            AccountsPayable.Init(model, RaisedCapital);
            OtherCurrentLiabilities.Init(model, RaisedCapital);
            LiabilitiesRelatedNonCurrentAssetsHeldForSale.Init(model, RaisedCapital);
            FutureIncome.Init(model);
        }
    }

    public class TotalSourcesOfCapital
    {
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1900Begin();
            Base.EndOfYear = model.F1Base.GetF1900End();

            Current.BeginningOfyear = model.F1Current.GetF1900Begin();
            Current.EndOfYear = model.F1Current.GetF1900End();
        }
    }
    public class Equity
    {
        public string Number { get; private set; } = "1.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1495Begin() + model.F1Base.GetProvisionOfNextCostsAndPayments(true) + model.F1Base.F1660.Begin;
            Base.EndOfYear = model.F1Base.GetF1495End() + model.F1Base.GetProvisionOfNextCostsAndPayments(false) + model.F1Base.F1660.End;

            Current.BeginningOfyear = model.F1Current.GetF1495Begin() + model.F1Current.GetProvisionOfNextCostsAndPayments(true) + model.F1Current.F1660.Begin;
            Current.EndOfYear = model.F1Current.GetF1495End() + model.F1Current.GetProvisionOfNextCostsAndPayments(false) + model.F1Current.F1660.End;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.GetF1900Begin() * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.GetF1900End() * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.GetF1900Begin() * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.GetF1900End() * 100;
        }
    }
    public class OwnCurrentAssets
    {
        public string Number { get; private set; } = "1.1";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfEquityBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfEquityCurrent { get; private set; } = new();

        public void Init(AFSModel model, Equity equity)
        {
            Base.BeginningOfyear = equity.Base.BeginningOfyear - model.F1Base.GetF1095Begin();
            Base.EndOfYear = equity.Current.EndOfYear - model.F1Base.GetF1095End();

            Current.BeginningOfyear = equity.Current.BeginningOfyear - model.F1Current.GetF1095Begin();
            Current.EndOfYear = equity.Current.EndOfYear - model.F1Current.GetF1095End();

            InPercentageOfEquityBase.BeginningOfyear = Base.BeginningOfyear / equity.Base.BeginningOfyear * 100;
            InPercentageOfEquityBase.EndOfYear = Base.EndOfYear / equity.Base.EndOfYear * 100;

            InPercentageOfEquityCurrent.BeginningOfyear = Current.BeginningOfyear / equity.Current.BeginningOfyear * 100;
            InPercentageOfEquityCurrent.EndOfYear = Current.EndOfYear / equity.Current.EndOfYear * 100;
        }
    }
    public class RaisedCapital
    {
        public string Number { get; private set; } = "2.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1695Begin() + model.F1Base.GetF1595Begin() - model.F1Base.GetProvisionOfNextCostsAndPayments(true) - model.F1Base.F1660.Begin - model.F1Base.F1665.Begin + model.F1Base.F1700.Begin;
            Base.EndOfYear = model.F1Base.GetF1695End() + model.F1Base.GetF1595End() - model.F1Base.GetProvisionOfNextCostsAndPayments(false) - model.F1Base.F1660.End - model.F1Base.F1665.End + model.F1Base.F1700.End;

            Current.BeginningOfyear = model.F1Current.GetF1695Begin() + model.F1Current.GetF1595Begin() - model.F1Current.GetProvisionOfNextCostsAndPayments(true) - model.F1Current.F1660.Begin - model.F1Current.F1665.Begin + model.F1Current.F1700.Begin;
            Current.EndOfYear = model.F1Current.GetF1695End() + model.F1Current.GetF1595End() - model.F1Current.GetProvisionOfNextCostsAndPayments(false) - model.F1Current.F1660.End - model.F1Current.F1665.End + model.F1Current.F1700.End;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.GetF1900Begin() * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.GetF1900End() * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.GetF1900Begin() * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.GetF1900End() * 100;
        }
    }
    public class LongTermLiabilities
    {
        public string Number { get; private set; } = "2.1.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalCurrent { get; private set; } = new();

        public void Init(AFSModel model, RaisedCapital raisedCapital)
        {
            Base.BeginningOfyear = model.F1Base.GetF1595Begin() - model.F1Base.GetProvisionOfNextCostsAndPayments(true);
            Base.EndOfYear = model.F1Base.GetF1595End() - model.F1Base.GetProvisionOfNextCostsAndPayments(false);

            Current.BeginningOfyear = model.F1Current.GetF1595Begin() - model.F1Current.GetProvisionOfNextCostsAndPayments(true);
            Current.EndOfYear = model.F1Current.GetF1595End() - model.F1Current.GetProvisionOfNextCostsAndPayments(false);

            InPercentageOfBorrowedCapitalBase.BeginningOfyear = Base.BeginningOfyear / raisedCapital.Base.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalBase.EndOfYear = Base.EndOfYear / raisedCapital.Base.EndOfYear * 100;

            InPercentageOfBorrowedCapitalCurrent.BeginningOfyear = Current.BeginningOfyear / raisedCapital.Current.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalCurrent.EndOfYear = Current.EndOfYear / raisedCapital.Current.EndOfYear * 100;
        }
    }
    public class ShortTermLoans
    {
        public string Number { get; private set; } = "2.2.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalCurrent { get; private set; } = new();

        public void Init(AFSModel model, RaisedCapital raisedCapital)
        {
            Base.BeginningOfyear = model.F1Base.F1600.Begin + model.F1Base.F1610.Begin;
            Base.EndOfYear = model.F1Base.F1600.End + model.F1Base.F1610.End;

            Current.BeginningOfyear = model.F1Current.F1600.Begin + model.F1Current.F1610.Begin;
            Current.EndOfYear = model.F1Current.F1600.End + model.F1Current.F1610.End;

            InPercentageOfBorrowedCapitalBase.BeginningOfyear = Base.BeginningOfyear / raisedCapital.Base.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalBase.EndOfYear = Base.EndOfYear / raisedCapital.Base.EndOfYear * 100;

            InPercentageOfBorrowedCapitalCurrent.BeginningOfyear = Current.BeginningOfyear / raisedCapital.Current.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalCurrent.EndOfYear = Current.EndOfYear / raisedCapital.Current.EndOfYear * 100;
        }
    }
    public class AccountsPayable
    {
        public string Number { get; private set; } = "2.3.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalCurrent { get; private set; } = new();

        public void Init(AFSModel model, RaisedCapital raisedCapital)
        {
            Base.BeginningOfyear = model.F1Base.GetAccountsPayable(true);
            Base.EndOfYear = model.F1Base.GetAccountsPayable(false);

            Current.BeginningOfyear = model.F1Current.GetAccountsPayable(true);
            Current.EndOfYear = model.F1Current.GetAccountsPayable(false);

            InPercentageOfBorrowedCapitalBase.BeginningOfyear = Base.BeginningOfyear / raisedCapital.Base.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalBase.EndOfYear = Base.EndOfYear / raisedCapital.Base.EndOfYear * 100;

            InPercentageOfBorrowedCapitalCurrent.BeginningOfyear = Current.BeginningOfyear / raisedCapital.Current.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalCurrent.EndOfYear = Current.EndOfYear / raisedCapital.Current.EndOfYear * 100;
        }
    }
    public class OtherCurrentLiabilities
    {
        public string Number { get; private set; } = "2.4.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalCurrent { get; private set; } = new();

        public void Init(AFSModel model, RaisedCapital raisedCapital)
        {
            Base.BeginningOfyear = model.F1Base.F1690.Begin;
            Base.EndOfYear = model.F1Base.F1690.End;

            Current.BeginningOfyear = model.F1Current.F1690.Begin;
            Current.EndOfYear = model.F1Current.F1690.End;

            InPercentageOfBorrowedCapitalBase.BeginningOfyear = Base.BeginningOfyear / raisedCapital.Base.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalBase.EndOfYear = Base.EndOfYear / raisedCapital.Base.EndOfYear * 100;

            InPercentageOfBorrowedCapitalCurrent.BeginningOfyear = Current.BeginningOfyear / raisedCapital.Current.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalCurrent.EndOfYear = Current.EndOfYear / raisedCapital.Current.EndOfYear * 100;
        }
    }
    public class LiabilitiesRelatedNonCurrentAssetsHeldForSale
    {
        public string Number { get; private set; } = "2.5.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfBorrowedCapitalCurrent { get; private set; } = new();


        public void Init(AFSModel model, RaisedCapital raisedCapital)
        {
            Base.BeginningOfyear = model.F1Base.F1700.Begin;
            Base.EndOfYear = model.F1Base.F1700.End;

            Current.BeginningOfyear = model.F1Current.F1700.Begin;
            Current.EndOfYear = model.F1Current.F1700.End;

            InPercentageOfBorrowedCapitalBase.BeginningOfyear = Base.BeginningOfyear / raisedCapital.Base.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalBase.EndOfYear = Base.EndOfYear / raisedCapital.Base.EndOfYear * 100;

            InPercentageOfBorrowedCapitalCurrent.BeginningOfyear = Current.BeginningOfyear / raisedCapital.Current.BeginningOfyear * 100;
            InPercentageOfBorrowedCapitalCurrent.EndOfYear = Current.EndOfYear / raisedCapital.Current.EndOfYear * 100;
        }
    }

    public class FutureIncome
    {
        public string Number { get; private set; } = "3.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsBase { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow InPercentageOfAssetsCurrent { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.F1665.Begin;
            Base.EndOfYear = model.F1Base.F1665.End;

            Current.BeginningOfyear = model.F1Current.F1665.Begin;
            Current.EndOfYear = model.F1Current.F1665.End;

            InPercentageOfAssetsBase.BeginningOfyear = Base.BeginningOfyear / model.F1Base.GetF1900Begin() * 100;
            InPercentageOfAssetsBase.EndOfYear = Base.EndOfYear / model.F1Base.GetF1900End() * 100;

            InPercentageOfAssetsCurrent.BeginningOfyear = Current.BeginningOfyear / model.F1Current.GetF1900Begin() * 100;
            InPercentageOfAssetsCurrent.EndOfYear = Current.EndOfYear / model.F1Current.GetF1900End() * 100;
        }
    }
}