using ProjectFirmaModels.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Project
{
    public class FundingSourceBudgetAmount : IFundingSourceBudgetAmount
    {
        public ProjectFirmaModels.Models.FundingSource FundingSource { get; }
        public int FundingSourceID => FundingSource?.FundingSourceID ?? ModelObjectHelpers.NotYetAssignedID;

        public decimal? ProjectedAmount { get; set;  }
        public string DisplayCssClass;


        public FundingSourceBudgetAmount(ProjectFirmaModels.Models.FundingSource fundingSource, decimal? targetedAmount, string displayCssClass)
        {
            FundingSource = fundingSource;
            ProjectedAmount = targetedAmount;
            DisplayCssClass = displayCssClass;
        }

        public FundingSourceBudgetAmount(IFundingSourceBudgetAmount fundingSourceBudgetAmount)
        {
            FundingSource = fundingSourceBudgetAmount.FundingSource;
            ProjectedAmount = fundingSourceBudgetAmount.ProjectedAmount;
        }

        public static FundingSourceBudgetAmount Clone(IFundingSourceBudgetAmount fundingSourceBudgetAmountToDiff, string displayCssClass)
        {
            return new FundingSourceBudgetAmount(fundingSourceBudgetAmountToDiff.FundingSource,
                fundingSourceBudgetAmountToDiff.ProjectedAmount,
                displayCssClass);
        }
    }
}