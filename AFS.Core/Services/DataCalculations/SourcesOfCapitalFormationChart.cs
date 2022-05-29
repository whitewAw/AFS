using AFS.Core.Model;
using AFS.Core.Models;

namespace AFS.Core.Services.DataCalculations
{
    public class SourcesOfCapitalFormationChart
    {
        SourcesOfCapitalFormation? SourcesOfCapitalFormation { get; set; }

        public SourcesOfCapitalFormationChart(AFSModel model) => Init(model);
        private void Init(AFSModel model) => SourcesOfCapitalFormation = new(model);
        public List<ChartDataItem> GetDataItem(bool baseYear)
        {
            List<ChartDataItem> assets = new();
            assets.Add(new ChartDataItem
            {
                Item = "Equity",
                Value = GetEquity(baseYear)
            });
            assets.Add(new ChartDataItem
            {
                Item = "LongTermLiabilities_",
                Value = GetLongTermLiabilities(baseYear)
            });
            assets.Add(new ChartDataItem
            {
                Item = "ShortTermLoans",
                Value = GetShortTermLoans(baseYear)
            });
            assets.Add(new ChartDataItem
            {
                Item = "AccountsPayable",
                Value = GetAccountsPayable(baseYear)
            });
            assets.Add(new ChartDataItem
            {
                Item = "OtherCurrentLiabilities",
                Value = GetOtherCurrentLiabilities(baseYear)
            });
            assets.Add(new ChartDataItem
            {
                Item = "LiabilitiesRelatedToNonCurrentAssetsForSale",
                Value = GetLiabilitiesRelatedNonCurrentAssetsHeldForSale(baseYear)
            });
            assets.Add(new ChartDataItem
            {
                Item = "FutureIncome",
                Value = GetFutureIncome(baseYear)
            });
            return assets.OrderByDescending(item => item.Value).ToList();
        }
        private double? GetEquity(bool baseYear)
        {
            if (baseYear == true)
            {
                return SourcesOfCapitalFormation?.Equity.InPercentageOfAssetsBase.EndOfYear;
            }
            else if (baseYear == false)
            {
                return SourcesOfCapitalFormation?.Equity.InPercentageOfAssetsCurrent.EndOfYear;
            }
            return 0;
        }
        private double? GetLongTermLiabilities(bool baseYear)
        {
            if (baseYear == true && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.LongTermLiabilities.Base.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Base.EndOfYear * 100;
            }
            else if (baseYear == false && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.LongTermLiabilities.Current.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Current.EndOfYear * 100;
            }
            return 0;
        }
        private double? GetShortTermLoans(bool baseYear)
        {
            if (baseYear == true && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.ShortTermLoans.Base.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Base.EndOfYear * 100;
            }
            else if (baseYear == false && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.ShortTermLoans.Current.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Current.EndOfYear * 100;
            }
            return 0;
        }
        private double? GetAccountsPayable(bool baseYear)
        {
            if (baseYear == true && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.AccountsPayable.Base.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Base.EndOfYear * 100;
            }
            else if (baseYear == false && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.AccountsPayable.Current.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Current.EndOfYear * 100;
            }
            return 0;
        }
        private double? GetOtherCurrentLiabilities(bool baseYear)
        {
            if (baseYear == true && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.OtherCurrentLiabilities.Base.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Base.EndOfYear * 100;
            }
            else if (baseYear == false && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.OtherCurrentLiabilities.Current.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Current.EndOfYear * 100;
            }
            return 0;
        }
        private double? GetLiabilitiesRelatedNonCurrentAssetsHeldForSale(bool baseYear)
        {
            if (baseYear == true && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.LiabilitiesRelatedNonCurrentAssetsHeldForSale.Base.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Base.EndOfYear * 100;
            }
            else if (baseYear == false && SourcesOfCapitalFormation != null)
            {
                return SourcesOfCapitalFormation.LiabilitiesRelatedNonCurrentAssetsHeldForSale.Current.EndOfYear / SourcesOfCapitalFormation.TotalSourcesOfCapital.Current.EndOfYear * 100;
            }
            return 0;
        }
        private double? GetFutureIncome(bool baseYear)
        {
            if (baseYear == true)
            {
                return SourcesOfCapitalFormation?.FutureIncome.InPercentageOfAssetsBase.EndOfYear;
            }
            else if (baseYear == false)
            {
                return SourcesOfCapitalFormation?.FutureIncome.InPercentageOfAssetsCurrent.EndOfYear;
            }
            return 0;
        }
    }
}
