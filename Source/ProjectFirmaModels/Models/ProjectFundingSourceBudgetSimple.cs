namespace ProjectFirmaModels.Models
{
    public class ProjectFundingSourceBudgetSimple
    {

        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public ProjectFundingSourceBudgetSimple()
        {
        }

        public ProjectFundingSourceBudgetSimple(ProjectFundingSourceBudget projectFundingSourceBudget)
            : this()
        {
            ProjectID = projectFundingSourceBudget.ProjectID;
            FundingSourceID = projectFundingSourceBudget.FundingSourceID;
            ProjectedAmount = projectFundingSourceBudget.ProjectedAmount;
        }

        public ProjectFundingSourceBudgetSimple(ProjectFundingSourceBudgetUpdate projectFundingSourceBudgetUpdate)
        {
            ProjectUpdateBatchID = projectFundingSourceBudgetUpdate.ProjectUpdateBatchID;
            FundingSourceID = projectFundingSourceBudgetUpdate.FundingSourceID;
            ProjectedAmount = projectFundingSourceBudgetUpdate.ProjectedAmount;
        }

        public ProjectFundingSourceBudget ToProjectFundingSourceBudget()
        {
            return new ProjectFundingSourceBudget(ProjectID, FundingSourceID) { ProjectedAmount = ProjectedAmount };
        }

        public int ProjectID { get; set; }
        public int ProjectUpdateBatchID { get; set; }
        public int FundingSourceID { get; set; }
        public decimal? ProjectedAmount { get; set; }

        public ProjectFundingSourceBudgetUpdate ToProjectFundingSourceBudgetUpdate()
        {
            return new ProjectFundingSourceBudgetUpdate(ProjectUpdateBatchID, FundingSourceID) { ProjectedAmount = ProjectedAmount };
        }



        public bool IsProjectedAmountValueNull()
        {
            return ProjectedAmount == null;
        }
    }
}