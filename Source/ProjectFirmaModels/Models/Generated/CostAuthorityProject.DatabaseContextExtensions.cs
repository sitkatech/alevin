//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthorityProject]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static CostAuthorityProject GetCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, int reclamationCostAuthorityProjectID)
        {
            var costAuthorityProject = costAuthorityProjects.SingleOrDefault(x => x.ReclamationCostAuthorityProjectID == reclamationCostAuthorityProjectID);
            Check.RequireNotNullThrowNotFound(costAuthorityProject, "CostAuthorityProject", reclamationCostAuthorityProjectID);
            return costAuthorityProject;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, List<int> reclamationCostAuthorityProjectIDList)
        {
            if(reclamationCostAuthorityProjectIDList.Any())
            {
                costAuthorityProjects.Where(x => reclamationCostAuthorityProjectIDList.Contains(x.ReclamationCostAuthorityProjectID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, ICollection<CostAuthorityProject> costAuthorityProjectsToDelete)
        {
            if(costAuthorityProjectsToDelete.Any())
            {
                var reclamationCostAuthorityProjectIDList = costAuthorityProjectsToDelete.Select(x => x.ReclamationCostAuthorityProjectID).ToList();
                costAuthorityProjects.Where(x => reclamationCostAuthorityProjectIDList.Contains(x.ReclamationCostAuthorityProjectID)).Delete();
            }
        }

        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, int reclamationCostAuthorityProjectID)
        {
            DeleteCostAuthorityProject(costAuthorityProjects, new List<int> { reclamationCostAuthorityProjectID });
        }

        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, CostAuthorityProject costAuthorityProjectToDelete)
        {
            DeleteCostAuthorityProject(costAuthorityProjects, new List<CostAuthorityProject> { costAuthorityProjectToDelete });
        }
    }
}