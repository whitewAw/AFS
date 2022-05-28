using AFS.Core.Model;
using AFS.Core.Models.TablsModels;

namespace AFS.Core.Services.DataCalculations
{
    public class IndicatorsOfFinancialStability
    {
        public TwoYearsCalculationData TotalReturnOnAssets { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfIndependence { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfFinancialDependence { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfFinancialStability { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfManeuverabilityOfEquity { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfConcentrationOfBorrowedCapital { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfStructureOfLongTermInvestments { get; private set; } = new();
        public TwoYearsCalculationData CoefficientOfLongevityOfBorrowedFunds { get; private set; } = new();
        public TwoYearsCalculationData RatedCapitalStructureRatio { get; private set; } = new();
        public TwoYearsCalculationData RatioOfBorrowedCapitalAndEquity { get; private set; } = new();
        public TwoYearsCalculationData RatioOfOwnAndLongTermBorrowedFundsInInventories { get; private set; } = new();
        public TwoYearsCalculationData RatioOfMobileToImmobilized { get; private set; } = new();
        public TwoYearsCalculationData TotalCoverageRatio { get; private set; } = new();

        public IndicatorsOfFinancialStability(AFSModel model) => Init(model);
        private void Init(AFSModel model)
        {
            SourcesOfCapitalFormation sOCF = new(model);

            TotalReturnOnAssetsInit(model);
            CoefficientOfIndependenceInit(model);
            CoefficientOfFinancialDependenceInit();
            CoefficientOfFinancialStabilityInit(model, sOCF);
            CoefficientOfManeuverabilityOfEquityInit(model, sOCF);
            CoefficientOfConcentrationOfBorrowedCapitalInit(model, sOCF);
            CoefficientOfStructureOfLongTermInvestmentsInit(model, sOCF);
            CoefficientOfLongevityOfBorrowedFundsInit(model, sOCF);
            RatedCapitalStructureRatioInit(sOCF);
            RatioOfBorrowedCapitalAndEquityInit(model, sOCF);
            RatioOfOwnAndLongTermBorrowedFundsInInventoriesInit(model, sOCF);
            RatioOfMobileToImmobilizedInit(model, sOCF);
            TotalCoverageRatioInit(model, sOCF);
        }
        private void TotalReturnOnAssetsInit(AFSModel model)
        {
            TotalReturnOnAssets.Number = "1.";
            TotalReturnOnAssets.BaseYear = model.F2Base.F2000.Current / ((model.F1Base.GetF1300Begin() + model.F1Base.GetF1300End()) / 2);
            TotalReturnOnAssets.CurrentYear = model.F2Current.F2000.Current / ((model.F1Current.GetF1300Begin() + model.F1Current.GetF1300End()) / 2);
        }
        private void CoefficientOfIndependenceInit(AFSModel model)
        {
            CoefficientOfIndependence.Number = "2.";
            CoefficientOfIndependence.BaseYear = model.F1Base.GetF1495End() / model.F1Base.GetF1900End();
            CoefficientOfIndependence.CurrentYear = model.F1Current.GetF1495End() / model.F1Current.GetF1900End();
        }
        private void CoefficientOfFinancialDependenceInit()
        {
            CoefficientOfFinancialDependence.Number = "3.";
            CoefficientOfFinancialDependence.BaseYear = 1 / CoefficientOfIndependence.BaseYear;
            CoefficientOfFinancialDependence.CurrentYear = 1 / CoefficientOfIndependence.CurrentYear;
        }
        private void CoefficientOfFinancialStabilityInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            CoefficientOfFinancialStability.Number = "4.";
            CoefficientOfFinancialStability.BaseYear = sOCF.Equity.Base.EndOfYear / model.F1Base.GetF1900End();
            CoefficientOfFinancialStability.CurrentYear = sOCF.Equity.Current.EndOfYear / model.F1Current.GetF1900End();
        }
        private void CoefficientOfManeuverabilityOfEquityInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            CoefficientOfManeuverabilityOfEquity.Number = "5.";
            CoefficientOfManeuverabilityOfEquity.BaseYear = sOCF.OwnCurrentAssets.Base.EndOfYear / model.F1Base.GetF1495End();
            CoefficientOfManeuverabilityOfEquity.CurrentYear = sOCF.OwnCurrentAssets.Current.EndOfYear / model.F1Current.GetF1495End();
        }
        private void CoefficientOfConcentrationOfBorrowedCapitalInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            CoefficientOfConcentrationOfBorrowedCapital.Number = "6.";
            CoefficientOfConcentrationOfBorrowedCapital.BaseYear = sOCF.RaisedCapital.Base.EndOfYear / model.F1Base.GetF1900End();
            CoefficientOfConcentrationOfBorrowedCapital.CurrentYear = sOCF.RaisedCapital.Current.EndOfYear / model.F1Current.GetF1900End();
        }
        private void CoefficientOfStructureOfLongTermInvestmentsInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            CoefficientOfStructureOfLongTermInvestments.Number = "7.";
            CoefficientOfStructureOfLongTermInvestments.BaseYear = sOCF.LongTermLiabilities.Base.EndOfYear / model.F1Base.GetF1095End();
            CoefficientOfStructureOfLongTermInvestments.CurrentYear = sOCF.LongTermLiabilities.Current.EndOfYear / model.F1Current.GetF1095End();
        }
        private void CoefficientOfLongevityOfBorrowedFundsInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            CoefficientOfLongevityOfBorrowedFunds.Number = "8.";
            CoefficientOfLongevityOfBorrowedFunds.BaseYear = sOCF.LongTermLiabilities.Base.EndOfYear / (sOCF.LongTermLiabilities.Base.EndOfYear + model.F1Base.GetF1495End());
            CoefficientOfLongevityOfBorrowedFunds.CurrentYear = sOCF.LongTermLiabilities.Current.EndOfYear / (sOCF.LongTermLiabilities.Current.EndOfYear + model.F1Current.GetF1495End());
        }
        private void RatedCapitalStructureRatioInit(SourcesOfCapitalFormation sOCF)
        {
            RatedCapitalStructureRatio.Number = "9.";
            RatedCapitalStructureRatio.BaseYear = sOCF.LongTermLiabilities.Base.EndOfYear / sOCF.RaisedCapital.Base.EndOfYear;
            RatedCapitalStructureRatio.CurrentYear = sOCF.LongTermLiabilities.Current.EndOfYear / sOCF.RaisedCapital.Current.EndOfYear;
        }
        private void RatioOfBorrowedCapitalAndEquityInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            RatioOfBorrowedCapitalAndEquity.Number = "10.";
            RatioOfBorrowedCapitalAndEquity.BaseYear = sOCF.RaisedCapital.Base.EndOfYear / model.F1Base.GetF1495End();
            RatioOfBorrowedCapitalAndEquity.CurrentYear = sOCF.RaisedCapital.Current.EndOfYear / model.F1Current.GetF1495End();
        }
        private void RatioOfOwnAndLongTermBorrowedFundsInInventoriesInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            RatioOfOwnAndLongTermBorrowedFundsInInventories.Number = "11.";
            RatioOfOwnAndLongTermBorrowedFundsInInventories.BaseYear = sOCF.Equity.Base.EndOfYear / model.F1Base.GetAccountsTangibleAssets(false);
            RatioOfOwnAndLongTermBorrowedFundsInInventories.CurrentYear = sOCF.Equity.Current.EndOfYear / model.F1Current.GetAccountsTangibleAssets(false);
        }
        private void RatioOfMobileToImmobilizedInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            RatioOfMobileToImmobilized.Number = "12.";
            RatioOfMobileToImmobilized.BaseYear = (model.F1Base.GetF1195End() + model.F1Base.F1200.End - model.F1Base.F1170.End) / model.F1Base.GetF1095End();
            RatioOfMobileToImmobilized.CurrentYear = (model.F1Current.GetF1195End() + model.F1Current.F1200.End - model.F1Current.F1170.End) / model.F1Current.GetF1095End();
        }
        private void TotalCoverageRatioInit(AFSModel model, SourcesOfCapitalFormation sOCF)
        {
            TotalCoverageRatio.Number = "13.";
            TotalCoverageRatio.BaseYear = (model.F1Base.GetF1300End() - model.F1Base.GetF1095End()) / (model.F1Base.GetF1695End() - model.F1Base.F1660.End - model.F1Base.F1665.End + model.F1Base.F1700.End);
            TotalCoverageRatio.CurrentYear = (model.F1Current.GetF1300End() - model.F1Current.GetF1095End()) / (model.F1Current.GetF1695End() - model.F1Current.F1660.End - model.F1Current.F1665.End + model.F1Current.F1700.End);
        }
    }
}