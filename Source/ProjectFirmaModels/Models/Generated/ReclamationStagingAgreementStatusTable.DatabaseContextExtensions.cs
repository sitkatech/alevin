//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingAgreementStatusTable]
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
        public static ReclamationStagingAgreementStatusTable GetReclamationStagingAgreementStatusTable(this IQueryable<ReclamationStagingAgreementStatusTable> reclamationStagingAgreementStatusTables, int reclamationStagingAgreementStatusTableID)
        {
            var reclamationStagingAgreementStatusTable = reclamationStagingAgreementStatusTables.SingleOrDefault(x => x.ReclamationStagingAgreementStatusTableID == reclamationStagingAgreementStatusTableID);
            Check.RequireNotNullThrowNotFound(reclamationStagingAgreementStatusTable, "ReclamationStagingAgreementStatusTable", reclamationStagingAgreementStatusTableID);
            return reclamationStagingAgreementStatusTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingAgreementStatusTable(this IQueryable<ReclamationStagingAgreementStatusTable> reclamationStagingAgreementStatusTables, List<int> reclamationStagingAgreementStatusTableIDList)
        {
            if(reclamationStagingAgreementStatusTableIDList.Any())
            {
                reclamationStagingAgreementStatusTables.Where(x => reclamationStagingAgreementStatusTableIDList.Contains(x.ReclamationStagingAgreementStatusTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingAgreementStatusTable(this IQueryable<ReclamationStagingAgreementStatusTable> reclamationStagingAgreementStatusTables, ICollection<ReclamationStagingAgreementStatusTable> reclamationStagingAgreementStatusTablesToDelete)
        {
            if(reclamationStagingAgreementStatusTablesToDelete.Any())
            {
                var reclamationStagingAgreementStatusTableIDList = reclamationStagingAgreementStatusTablesToDelete.Select(x => x.ReclamationStagingAgreementStatusTableID).ToList();
                reclamationStagingAgreementStatusTables.Where(x => reclamationStagingAgreementStatusTableIDList.Contains(x.ReclamationStagingAgreementStatusTableID)).Delete();
            }
        }

        public static void DeleteReclamationStagingAgreementStatusTable(this IQueryable<ReclamationStagingAgreementStatusTable> reclamationStagingAgreementStatusTables, int reclamationStagingAgreementStatusTableID)
        {
            DeleteReclamationStagingAgreementStatusTable(reclamationStagingAgreementStatusTables, new List<int> { reclamationStagingAgreementStatusTableID });
        }

        public static void DeleteReclamationStagingAgreementStatusTable(this IQueryable<ReclamationStagingAgreementStatusTable> reclamationStagingAgreementStatusTables, ReclamationStagingAgreementStatusTable reclamationStagingAgreementStatusTableToDelete)
        {
            DeleteReclamationStagingAgreementStatusTable(reclamationStagingAgreementStatusTables, new List<ReclamationStagingAgreementStatusTable> { reclamationStagingAgreementStatusTableToDelete });
        }
    }
}