//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingObligationsTable]
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
        public static ReclamationStagingObligationsTable GetReclamationStagingObligationsTable(this IQueryable<ReclamationStagingObligationsTable> reclamationStagingObligationsTables, int reclamationStagingObligationsTableID)
        {
            var reclamationStagingObligationsTable = reclamationStagingObligationsTables.SingleOrDefault(x => x.ReclamationStagingObligationsTableID == reclamationStagingObligationsTableID);
            Check.RequireNotNullThrowNotFound(reclamationStagingObligationsTable, "ReclamationStagingObligationsTable", reclamationStagingObligationsTableID);
            return reclamationStagingObligationsTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingObligationsTable(this IQueryable<ReclamationStagingObligationsTable> reclamationStagingObligationsTables, List<int> reclamationStagingObligationsTableIDList)
        {
            if(reclamationStagingObligationsTableIDList.Any())
            {
                reclamationStagingObligationsTables.Where(x => reclamationStagingObligationsTableIDList.Contains(x.ReclamationStagingObligationsTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingObligationsTable(this IQueryable<ReclamationStagingObligationsTable> reclamationStagingObligationsTables, ICollection<ReclamationStagingObligationsTable> reclamationStagingObligationsTablesToDelete)
        {
            if(reclamationStagingObligationsTablesToDelete.Any())
            {
                var reclamationStagingObligationsTableIDList = reclamationStagingObligationsTablesToDelete.Select(x => x.ReclamationStagingObligationsTableID).ToList();
                reclamationStagingObligationsTables.Where(x => reclamationStagingObligationsTableIDList.Contains(x.ReclamationStagingObligationsTableID)).Delete();
            }
        }

        public static void DeleteReclamationStagingObligationsTable(this IQueryable<ReclamationStagingObligationsTable> reclamationStagingObligationsTables, int reclamationStagingObligationsTableID)
        {
            DeleteReclamationStagingObligationsTable(reclamationStagingObligationsTables, new List<int> { reclamationStagingObligationsTableID });
        }

        public static void DeleteReclamationStagingObligationsTable(this IQueryable<ReclamationStagingObligationsTable> reclamationStagingObligationsTables, ReclamationStagingObligationsTable reclamationStagingObligationsTableToDelete)
        {
            DeleteReclamationStagingObligationsTable(reclamationStagingObligationsTables, new List<ReclamationStagingObligationsTable> { reclamationStagingObligationsTableToDelete });
        }
    }
}