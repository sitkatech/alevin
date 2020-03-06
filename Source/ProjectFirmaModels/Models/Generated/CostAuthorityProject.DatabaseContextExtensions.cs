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
        public static CostAuthorityProject GetCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, int costAuthorityProjectID)
        {
            var costAuthorityProject = costAuthorityProjects.SingleOrDefault(x => x.CostAuthorityProjectID == costAuthorityProjectID);
            Check.RequireNotNullThrowNotFound(costAuthorityProject, "CostAuthorityProject", costAuthorityProjectID);
            return costAuthorityProject;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, List<int> costAuthorityProjectIDList)
        {
            if(costAuthorityProjectIDList.Any())
            {
                costAuthorityProjects.Where(x => costAuthorityProjectIDList.Contains(x.CostAuthorityProjectID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, ICollection<CostAuthorityProject> costAuthorityProjectsToDelete)
        {
            if(costAuthorityProjectsToDelete.Any())
            {
                var costAuthorityProjectIDList = costAuthorityProjectsToDelete.Select(x => x.CostAuthorityProjectID).ToList();
                costAuthorityProjects.Where(x => costAuthorityProjectIDList.Contains(x.CostAuthorityProjectID)).Delete();
            }
        }

        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, int costAuthorityProjectID)
        {
            DeleteCostAuthorityProject(costAuthorityProjects, new List<int> { costAuthorityProjectID });
        }

        public static void DeleteCostAuthorityProject(this IQueryable<CostAuthorityProject> costAuthorityProjects, CostAuthorityProject costAuthorityProjectToDelete)
        {
            DeleteCostAuthorityProject(costAuthorityProjects, new List<CostAuthorityProject> { costAuthorityProjectToDelete });
        }
    }
}