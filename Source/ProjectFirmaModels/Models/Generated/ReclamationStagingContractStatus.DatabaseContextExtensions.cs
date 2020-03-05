//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingContractStatus]
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
        public static ReclamationStagingContractStatus GetReclamationStagingContractStatus(this IQueryable<ReclamationStagingContractStatus> reclamationStagingContractStatuses, int reclamationStagingContractStatusID)
        {
            var reclamationStagingContractStatus = reclamationStagingContractStatuses.SingleOrDefault(x => x.ReclamationStagingContractStatusID == reclamationStagingContractStatusID);
            Check.RequireNotNullThrowNotFound(reclamationStagingContractStatus, "ReclamationStagingContractStatus", reclamationStagingContractStatusID);
            return reclamationStagingContractStatus;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingContractStatus(this IQueryable<ReclamationStagingContractStatus> reclamationStagingContractStatuses, List<int> reclamationStagingContractStatusIDList)
        {
            if(reclamationStagingContractStatusIDList.Any())
            {
                reclamationStagingContractStatuses.Where(x => reclamationStagingContractStatusIDList.Contains(x.ReclamationStagingContractStatusID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingContractStatus(this IQueryable<ReclamationStagingContractStatus> reclamationStagingContractStatuses, ICollection<ReclamationStagingContractStatus> reclamationStagingContractStatusesToDelete)
        {
            if(reclamationStagingContractStatusesToDelete.Any())
            {
                var reclamationStagingContractStatusIDList = reclamationStagingContractStatusesToDelete.Select(x => x.ReclamationStagingContractStatusID).ToList();
                reclamationStagingContractStatuses.Where(x => reclamationStagingContractStatusIDList.Contains(x.ReclamationStagingContractStatusID)).Delete();
            }
        }

        public static void DeleteReclamationStagingContractStatus(this IQueryable<ReclamationStagingContractStatus> reclamationStagingContractStatuses, int reclamationStagingContractStatusID)
        {
            DeleteReclamationStagingContractStatus(reclamationStagingContractStatuses, new List<int> { reclamationStagingContractStatusID });
        }

        public static void DeleteReclamationStagingContractStatus(this IQueryable<ReclamationStagingContractStatus> reclamationStagingContractStatuses, ReclamationStagingContractStatus reclamationStagingContractStatusToDelete)
        {
            DeleteReclamationStagingContractStatus(reclamationStagingContractStatuses, new List<ReclamationStagingContractStatus> { reclamationStagingContractStatusToDelete });
        }
    }
}