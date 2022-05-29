using AFS.Core.Model;
using AFS.Core.Models;

namespace AFS.Core.Services.DataCalculations
{
    public class CompositionOfAssets
    {
        CharacteristicsOfCapital? CharacteristicsOfCapital { get; set; }

        public CompositionOfAssets(AFSModel model) => Init(model);

        private void Init(AFSModel model)
        {
            CharacteristicsOfCapital = new(model);
        }

        public List<ChartDataItem> GetDataItem(bool baseYear, bool begin)
        {
            List<ChartDataItem> assets = new();
            assets.Add(new ChartDataItem
            {
                Item = "NonCurrentImmobilizedAssets",
                Value = GetNonCurrentImmobilizedFunds(baseYear, begin)
            });
            assets.Add(new ChartDataItem
            {
                Item = "TangibleCurrentAssets",
                Value = GetTangibleCurrentAssets(baseYear, begin)
            });
            assets.Add(new ChartDataItem
            {
                Item = "AccountsReceivable",
                Value = GetAccountsReceivable(baseYear, begin)
            });
            assets.Add(new ChartDataItem
            {
                Item = "CashCurrentFinancialInvestments",
                Value = GetCashCurrentFinancialInvestments(baseYear, begin)
            });
            assets.Add(new ChartDataItem
            {
                Item = "OtherCurrentAssets",
                Value = GetOtherCurrentAssets(baseYear, begin)
            });
            assets.Add(new ChartDataItem
            {
                Item = "NonCurrentAssetsHeldForSale",
                Value = GetNonCurrentAssetsHeldForSale(baseYear, begin)
            });
            assets.Add(new ChartDataItem
            {
                Item = "FutureExpenses",
                Value = GetFutureExpenses(baseYear, begin)
            });
            return assets.OrderByDescending(item => item.Value).ToList();
        }


        public double? GetNonCurrentImmobilizedFunds(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.NonCurrentImmobilizedFunds.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.NonCurrentImmobilizedFunds.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.NonCurrentImmobilizedFunds.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.NonCurrentImmobilizedFunds.Current.EndOfYear;
            }
            return 0;
        }

        public double? GetTangibleCurrentAssets(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.TangibleCurrentAssets.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.TangibleCurrentAssets.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.TangibleCurrentAssets.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.TangibleCurrentAssets.Current.EndOfYear;
            }
            return 0;
        }

        public double? GetAccountsReceivable(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.AccountsReceivable.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.AccountsReceivable.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.AccountsReceivable.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.AccountsReceivable.Current.EndOfYear;
            }
            return 0;
        }

        public double? GetCashCurrentFinancialInvestments(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.CashCurrentFinancialInvestments.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.CashCurrentFinancialInvestments.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.CashCurrentFinancialInvestments.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.CashCurrentFinancialInvestments.Current.EndOfYear;
            }
            return 0;
        }

        public double? GetOtherCurrentAssets(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.OtherCurrentAssets.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.OtherCurrentAssets.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.OtherCurrentAssets.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.OtherCurrentAssets.Current.EndOfYear;
            }
            return 0;
        }

        public double? GetNonCurrentAssetsHeldForSale(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.NonCurrentAssetsHeldForSale.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.NonCurrentAssetsHeldForSale.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.NonCurrentAssetsHeldForSale.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.NonCurrentAssetsHeldForSale.Current.EndOfYear;
            }
            return 0;
        }

        public double? GetFutureExpenses(bool baseYear, bool begin)
        {
            if (begin == true && baseYear == true)
            {
                return CharacteristicsOfCapital?.FutureExpenses.Base.BeginningOfyear;
            }
            else if (begin == false && baseYear == true)
            {
                return CharacteristicsOfCapital?.FutureExpenses.Base.EndOfYear;
            }
            else if (begin == true && baseYear == false)
            {
                return CharacteristicsOfCapital?.FutureExpenses.Current.BeginningOfyear;
            }
            else if (begin == false && baseYear == false)
            {
                return CharacteristicsOfCapital?.FutureExpenses.Current.EndOfYear;
            }
            return 0;
        }
    }
}
