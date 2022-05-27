
using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class GeneralIndicatorsOfFinancialStability
    {
        public AvailabilityOfWorkingCapitalForFormationOfStocks AvailabilityOfWorkingCapitalForFormationOfStocks { get; private set; } = new();
        public AvailabilityOfOwnCurrentAndLongTermBorrowedForStocks AvailabilityOfOwnCurrentAndLongTermBorrowedForStocks { get; private set; } = new();
        public AvailabilityForStockFormation AvailabilityForStockFormation { get; private set; } = new();
        public Stocks Stocks { get; private set; } = new();
        public ExcessLackOfWorkingCapitalForStocks ExcessLackOfWorkingCapitalForStocks { get; private set; } = new();
        public ExcessLackOfWorkingCapitalAndLongTermForStocks ExcessLackOfWorkingCapitalAndLongTermForStocks { get; private set; } = new();
        public ExcessLackOfWorkingCapitalAndLongTermAndShortTermForStocks ExcessLackOfWorkingCapitalAndLongTermAndShortTermForStocks { get; private set; } = new();

        public GeneralIndicatorsOfFinancialStability(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            SourcesOfCapitalFormation sOCF = new(model);

            AvailabilityOfWorkingCapitalForFormationOfStocks.Init(sOCF);
            AvailabilityOfOwnCurrentAndLongTermBorrowedForStocks.Init(model);
            AvailabilityForStockFormation.Init(model);
            Stocks.Init(model);
            ExcessLackOfWorkingCapitalForStocks.Init(Stocks, AvailabilityOfWorkingCapitalForFormationOfStocks);
            ExcessLackOfWorkingCapitalAndLongTermForStocks.Init(Stocks, AvailabilityOfOwnCurrentAndLongTermBorrowedForStocks);
            ExcessLackOfWorkingCapitalAndLongTermAndShortTermForStocks.Init(Stocks, AvailabilityForStockFormation);
        }
    }
    public class AvailabilityOfWorkingCapitalForFormationOfStocks
    {
        public string Number { get; private set; } = "1.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        public void Init(SourcesOfCapitalFormation sOCF)
        {
            Base.BeginningOfyear = sOCF.OwnCurrentAssets.Base.BeginningOfyear;
            Base.EndOfYear = sOCF.OwnCurrentAssets.Base.EndOfYear;

            Current.BeginningOfyear = sOCF.OwnCurrentAssets.Current.BeginningOfyear;
            Current.EndOfYear = sOCF.OwnCurrentAssets.Current.EndOfYear;
        }
    }
    public class AvailabilityOfOwnCurrentAndLongTermBorrowedForStocks
    {
        public string Number { get; private set; } = "2.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1495Begin() + model.F1Base.GetF1595Begin() - model.F1Base.GetF1095Begin();
            Base.EndOfYear = model.F1Base.GetF1495End() + model.F1Base.GetF1595End() - model.F1Base.GetF1095End();

            Current.BeginningOfyear = model.F1Current.GetF1495Begin() + model.F1Current.GetF1595Begin() - model.F1Current.GetF1095Begin();
            Current.EndOfYear = model.F1Current.GetF1495End() + model.F1Current.GetF1595End() - model.F1Current.GetF1095End();
        }
    }
    public class AvailabilityForStockFormation
    {
        public string Number { get; private set; } = "3.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetF1495Begin() + model.F1Base.GetF1595Begin() - model.F1Base.GetF1095Begin() + model.F1Base.F1600.Begin + model.F1Base.F1610.Begin + model.F1Base.F1660.Begin;
            Base.EndOfYear = model.F1Base.GetF1495End() + model.F1Base.GetF1595End() - model.F1Base.GetF1095End() + model.F1Base.F1600.End + model.F1Base.F1610.End + model.F1Base.F1660.End;

            Current.BeginningOfyear = model.F1Current.GetF1495Begin() + model.F1Current.GetF1595Begin() - model.F1Current.GetF1095Begin() + model.F1Current.F1600.Begin + model.F1Current.F1610.Begin + model.F1Current.F1660.Begin;
            Current.EndOfYear = model.F1Current.GetF1495End() + model.F1Current.GetF1595End() - model.F1Current.GetF1095End() + model.F1Current.F1600.End + model.F1Current.F1610.End + model.F1Current.F1660.End;
        }
    }
    public class Stocks
    {
        public string Number { get; private set; } = "4.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        public void Init(AFSModel model)
        {
            Base.BeginningOfyear = model.F1Base.GetAccountsTangibleAssets(true);
            Base.EndOfYear = model.F1Base.GetAccountsTangibleAssets(false);

            Current.BeginningOfyear = model.F1Current.GetAccountsTangibleAssets(true);
            Current.EndOfYear = model.F1Current.GetAccountsTangibleAssets(false);
        }
    }
    public class ExcessLackOfWorkingCapitalForStocks
    {
        public string Number { get; private set; } = "5.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        internal void Init(Stocks stocks, AvailabilityOfWorkingCapitalForFormationOfStocks availabilityOfWorkingCapitalForFormationOfStocks)
        {
            Base.BeginningOfyear = availabilityOfWorkingCapitalForFormationOfStocks.Base.BeginningOfyear - stocks.Base.BeginningOfyear;
            Base.EndOfYear = availabilityOfWorkingCapitalForFormationOfStocks.Base.EndOfYear - stocks.Base.EndOfYear;

            Current.BeginningOfyear = availabilityOfWorkingCapitalForFormationOfStocks.Current.BeginningOfyear - stocks.Current.BeginningOfyear;
            Current.EndOfYear = availabilityOfWorkingCapitalForFormationOfStocks.Current.EndOfYear - stocks.Current.EndOfYear;
        }
    }
    public class ExcessLackOfWorkingCapitalAndLongTermForStocks
    {
        public string Number { get; private set; } = "6.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        internal void Init(Stocks stocks, AvailabilityOfOwnCurrentAndLongTermBorrowedForStocks availabilityOfOwnCurrentAndLongTermBorrowedForStocks)
        {
            Base.BeginningOfyear = availabilityOfOwnCurrentAndLongTermBorrowedForStocks.Base.BeginningOfyear - stocks.Base.BeginningOfyear;
            Base.EndOfYear = availabilityOfOwnCurrentAndLongTermBorrowedForStocks.Base.EndOfYear - stocks.Base.EndOfYear;

            Current.BeginningOfyear = availabilityOfOwnCurrentAndLongTermBorrowedForStocks.Current.BeginningOfyear - stocks.Current.BeginningOfyear;
            Current.EndOfYear = availabilityOfOwnCurrentAndLongTermBorrowedForStocks.Current.EndOfYear - stocks.Current.EndOfYear;
        }
    }
    public class ExcessLackOfWorkingCapitalAndLongTermAndShortTermForStocks
    {
        public string Number { get; private set; } = "7.";
        public CharacteristicsOfCapitalCalculationRow Base { get; private set; } = new();
        public CharacteristicsOfCapitalCalculationRow Current { get; private set; } = new();

        internal void Init(Stocks stocks, AvailabilityForStockFormation availabilityForStockFormation)
        {
            Base.BeginningOfyear = availabilityForStockFormation.Base.BeginningOfyear - stocks.Base.BeginningOfyear;
            Base.EndOfYear = availabilityForStockFormation.Base.EndOfYear - stocks.Base.EndOfYear;

            Current.BeginningOfyear = availabilityForStockFormation.Current.BeginningOfyear - stocks.Current.BeginningOfyear;
            Current.EndOfYear = availabilityForStockFormation.Current.EndOfYear - stocks.Current.EndOfYear;
        }
    }
}