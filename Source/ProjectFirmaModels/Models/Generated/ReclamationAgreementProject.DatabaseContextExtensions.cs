//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationAgreementProject]
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
        public static ReclamationAgreementProject GetReclamationAgreementProject(this IQueryable<ReclamationAgreementProject> reclamationAgreementProjects, int reclamationAgreementProjectID)
        {
            var reclamationAgreementProject = reclamationAgreementProjects.SingleOrDefault(x => x.ReclamationAgreementProjectID == reclamationAgreementProjectID);
            Check.RequireNotNullThrowNotFound(reclamationAgreementProject, "ReclamationAgreementProject", reclamationAgreementProjectID);
            return reclamationAgreementProject;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationAgreementProject(this IQueryable<ReclamationAgreementProject> reclamationAgreementProjects, List<int> reclamationAgreementProjectIDList)
        {
            if(reclamationAgreementProjectIDList.Any())
            {
                reclamationAgreementProjects.Where(x => reclamationAgreementProjectIDList.Contains(x.ReclamationAgreementProjectID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationAgreementProject(this IQueryable<ReclamationAgreementProject> reclamationAgreementProjects, ICollection<ReclamationAgreementProject> reclamationAgreementProjectsToDelete)
        {
            if(reclamationAgreementProjectsToDelete.Any())
            {
                var reclamationAgreementProjectIDList = reclamationAgreementProjectsToDelete.Select(x => x.ReclamationAgreementProjectID).ToList();
                reclamationAgreementProjects.Where(x => reclamationAgreementProjectIDList.Contains(x.ReclamationAgreementProjectID)).Delete();
            }
        }

        public static void DeleteReclamationAgreementProject(this IQueryable<ReclamationAgreementProject> reclamationAgreementProjects, int reclamationAgreementProjectID)
        {
            DeleteReclamationAgreementProject(reclamationAgreementProjects, new List<int> { reclamationAgreementProjectID });
        }

        public static void DeleteReclamationAgreementProject(this IQueryable<ReclamationAgreementProject> reclamationAgreementProjects, ReclamationAgreementProject reclamationAgreementProjectToDelete)
        {
            DeleteReclamationAgreementProject(reclamationAgreementProjects, new List<ReclamationAgreementProject> { reclamationAgreementProjectToDelete });
        }
    }
}