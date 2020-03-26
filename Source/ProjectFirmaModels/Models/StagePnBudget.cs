using ProjectFirmaModels.Models.ExcelUpload;

namespace ProjectFirmaModels.Models
{
    /*
     *         public readonly string FundedProgram;
public readonly string FundType;
public readonly string FundsCenter;
public readonly string FiscalYearPeriod;
public readonly string CommitmentItem;
public readonly string FiDocNumber;
public readonly double? Recoveries;
public readonly double? CommittedButNotObligated;
public readonly double? TotalObligations;
public readonly double? TotalExpenditures;
public readonly double? UndeliveredOrders;
     */

    public partial class StagePnBudget : IAuditableEntity
    {
        public StagePnBudget(PnBudgetsStageImport pnBudgetsStageImport)
        {
            this.FundedProgram = pnBudgetsStageImport.FundedProgram;
            this.FundType = pnBudgetsStageImport.FundType;
            this.Fund = pnBudgetsStageImport.Fund;
            this.FundsCenter = pnBudgetsStageImport.FundsCenter;
            this.FiscalYearPeriod = pnBudgetsStageImport.FiscalYearPeriod;
            this.CommitmentItem = pnBudgetsStageImport.CommitmentItem;
            this.FiDocNumber = pnBudgetsStageImport.FiDocNumber;
            this.Recoveries = pnBudgetsStageImport.Recoveries;
            this.CommittedButNotObligated = pnBudgetsStageImport.CommittedButNotObligated;
            this.TotalObligations = pnBudgetsStageImport.TotalObligations;
            this.TotalExpenditures = pnBudgetsStageImport.TotalExpenditures;
            this.UndeliveredOrders = pnBudgetsStageImport.UndeliveredOrders;
        }

        public string GetAuditDescriptionString()
        {
            return this.StagePnBudgetID.ToString();
        }
    }
}
