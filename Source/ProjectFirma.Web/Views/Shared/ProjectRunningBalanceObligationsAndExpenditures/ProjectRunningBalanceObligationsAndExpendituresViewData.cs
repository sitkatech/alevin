using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectRunningBalanceObligationsAndExpenditures
{

    // Opting for a specific type for clarity. It isn't strictly needed.
    public class BudgetObjectCodeQuarterGroup
    {
        public int FiscalYear;
        public string FiscalQuarterDisplayName;
        public string BudgetObjectCodeName;

        //public ProjectFirmaModels.Models.BudgetObjectCode BudgetObjectCode;

        public BudgetObjectCodeQuarterGroup(int fiscalYear, 
                                            FiscalQuarter fiscalQuarter, 
                                            ProjectFirmaModels.Models.BudgetObjectCode budgetObjectCode)
        {
            this.FiscalYear = fiscalYear;
            this.FiscalQuarterDisplayName = fiscalQuarter.FiscalQuarterDisplayName;
            this.BudgetObjectCodeName = budgetObjectCode != null ? budgetObjectCode.BudgetObjectCodeName : string.Empty;
            //this.BudgetObjectCode = budgetObjectCode;
        }
    }

    public class ProjectRunningBalanceObligationsAndExpendituresViewData : FirmaUserControlViewData
    {
        public List<ProjectRunningBalanceObligationsAndExpendituresRecord> ProjectRunningBalanceObligationsAndExpendituresRecords { get; set; }
        //public List<IGrouping<BudgetObjectCodeQuarterGroup, ProjectRunningBalanceObligationsAndExpendituresRecord>> ProjectRunningBalanceObligationsAndExpendituresRecordsGrouped { get; set; }

        public ProjectRunningBalanceObligationsAndExpendituresViewData(List<ProjectRunningBalanceObligationsAndExpendituresRecord> projectRunningBalanceObligationsAndExpendituresRecords)
        {
            this.ProjectRunningBalanceObligationsAndExpendituresRecords =  projectRunningBalanceObligationsAndExpendituresRecords;

            //ProjectRunningBalanceObligationsAndExpendituresRecordsGrouped = 
            //    projectRunningBalanceObligationsAndExpendituresRecords.
            //        GroupBy(prb => new BudgetObjectCodeQuarterGroup(prb.FiscalYear, prb.FiscalQuarter, prb.BudgetObjectCode)).ToList();
            

            var blah =
                projectRunningBalanceObligationsAndExpendituresRecords.GroupBy(prb =>
                    new {prb.FiscalYear, prb.FiscalQuarter.FiscalQuarterDisplayName, BudgetObjectCodeName = bleef(prb)}).ToList();

            int yes = blah.Count;

            /*
            ProjectRunningBalanceObligationsAndExpendituresRecordsGrouped = 
                ProjectRunningBalanceObligationsAndExpendituresRecordsGrouped.
                    OrderBy(g => g.Key.FiscalYear)
                    .ThenBy(g => g.Key.FiscalQuarter)
                    .ThenBy(g => g.Key.BudgetObjectCode)
                    .ToList();
            */
        }

        private static string bleef(ProjectRunningBalanceObligationsAndExpendituresRecord prb)
        {
            return prb.BudgetObjectCode != null ? prb.BudgetObjectCode.BudgetObjectCodeName : string.Empty;
        }
    }
}