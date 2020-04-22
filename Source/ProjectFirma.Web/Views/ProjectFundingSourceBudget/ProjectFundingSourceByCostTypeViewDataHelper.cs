using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ProjectFundingSourceBudget
{
    public class ProjectFundingSourceByCostTypeViewDataHelper
    {
        public static bool ShowApproveAndReturnButtonForUpdateWorkflow(ProjectUpdateBatch projectUpdateBatch, FirmaSession currentFirmaSession)
        {
             return projectUpdateBatch.IsSubmitted() && new ProjectUpdateAdminFeatureWithProjectContext().HasPermission(currentFirmaSession, projectUpdateBatch.Project).HasPermission;
        }




    }
}