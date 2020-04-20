namespace ProjectFirmaModels.Models
{
    public interface IFundingSourceBudgetAmount
    {
        FundingSource FundingSource { get; }
        decimal? ProjectedAmount { get; }
    }

    public interface ICostTypeFundingSourceBudgetAmount : IFundingSourceBudgetAmount
    {
        CostType CostType { get; }
        int? CostTypeID { get; }
        int? CalendarYear { get; }
        decimal? GetProjectedAmount();
    }
}