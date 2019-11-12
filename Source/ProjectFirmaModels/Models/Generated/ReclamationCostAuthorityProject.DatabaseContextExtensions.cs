//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationCostAuthorityProject]
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
        public static ReclamationCostAuthorityProject GetReclamationCostAuthorityProject(this IQueryable<ReclamationCostAuthorityProject> reclamationCostAuthorityProjects, int reclamationCostAuthorityProjectID)
        {
            var reclamationCostAuthorityProject = reclamationCostAuthorityProjects.SingleOrDefault(x => x.ReclamationCostAuthorityProjectID == reclamationCostAuthorityProjectID);
            Check.RequireNotNullThrowNotFound(reclamationCostAuthorityProject, "ReclamationCostAuthorityProject", reclamationCostAuthorityProjectID);
            return reclamationCostAuthorityProject;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationCostAuthorityProject(this IQueryable<ReclamationCostAuthorityProject> reclamationCostAuthorityProjects, List<int> reclamationCostAuthorityProjectIDList)
        {
            if(reclamationCostAuthorityProjectIDList.Any())
            {
                reclamationCostAuthorityProjects.Where(x => reclamationCostAuthorityProjectIDList.Contains(x.ReclamationCostAuthorityProjectID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationCostAuthorityProject(this IQueryable<ReclamationCostAuthorityProject> reclamationCostAuthorityProjects, ICollection<ReclamationCostAuthorityProject> reclamationCostAuthorityProjectsToDelete)
        {
            if(reclamationCostAuthorityProjectsToDelete.Any())
            {
                var reclamationCostAuthorityProjectIDList = reclamationCostAuthorityProjectsToDelete.Select(x => x.ReclamationCostAuthorityProjectID).ToList();
                reclamationCostAuthorityProjects.Where(x => reclamationCostAuthorityProjectIDList.Contains(x.ReclamationCostAuthorityProjectID)).Delete();
            }
        }

        public static void DeleteReclamationCostAuthorityProject(this IQueryable<ReclamationCostAuthorityProject> reclamationCostAuthorityProjects, int reclamationCostAuthorityProjectID)
        {
            DeleteReclamationCostAuthorityProject(reclamationCostAuthorityProjects, new List<int> { reclamationCostAuthorityProjectID });
        }

        public static void DeleteReclamationCostAuthorityProject(this IQueryable<ReclamationCostAuthorityProject> reclamationCostAuthorityProjects, ReclamationCostAuthorityProject reclamationCostAuthorityProjectToDelete)
        {
            DeleteReclamationCostAuthorityProject(reclamationCostAuthorityProjects, new List<ReclamationCostAuthorityProject> { reclamationCostAuthorityProjectToDelete });
        }
    }
}