//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingFutureFundingTable]
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
        public static ReclamationStagingFutureFundingTable GetReclamationStagingFutureFundingTable(this IQueryable<ReclamationStagingFutureFundingTable> reclamationStagingFutureFundingTables, int reclamationStagingFutureFundingTableID)
        {
            var reclamationStagingFutureFundingTable = reclamationStagingFutureFundingTables.SingleOrDefault(x => x.ReclamationStagingFutureFundingTableID == reclamationStagingFutureFundingTableID);
            Check.RequireNotNullThrowNotFound(reclamationStagingFutureFundingTable, "ReclamationStagingFutureFundingTable", reclamationStagingFutureFundingTableID);
            return reclamationStagingFutureFundingTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingFutureFundingTable(this IQueryable<ReclamationStagingFutureFundingTable> reclamationStagingFutureFundingTables, List<int> reclamationStagingFutureFundingTableIDList)
        {
            if(reclamationStagingFutureFundingTableIDList.Any())
            {
                reclamationStagingFutureFundingTables.Where(x => reclamationStagingFutureFundingTableIDList.Contains(x.ReclamationStagingFutureFundingTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingFutureFundingTable(this IQueryable<ReclamationStagingFutureFundingTable> reclamationStagingFutureFundingTables, ICollection<ReclamationStagingFutureFundingTable> reclamationStagingFutureFundingTablesToDelete)
        {
            if(reclamationStagingFutureFundingTablesToDelete.Any())
            {
                var reclamationStagingFutureFundingTableIDList = reclamationStagingFutureFundingTablesToDelete.Select(x => x.ReclamationStagingFutureFundingTableID).ToList();
                reclamationStagingFutureFundingTables.Where(x => reclamationStagingFutureFundingTableIDList.Contains(x.ReclamationStagingFutureFundingTableID)).Delete();
            }
        }

        public static void DeleteReclamationStagingFutureFundingTable(this IQueryable<ReclamationStagingFutureFundingTable> reclamationStagingFutureFundingTables, int reclamationStagingFutureFundingTableID)
        {
            DeleteReclamationStagingFutureFundingTable(reclamationStagingFutureFundingTables, new List<int> { reclamationStagingFutureFundingTableID });
        }

        public static void DeleteReclamationStagingFutureFundingTable(this IQueryable<ReclamationStagingFutureFundingTable> reclamationStagingFutureFundingTables, ReclamationStagingFutureFundingTable reclamationStagingFutureFundingTableToDelete)
        {
            DeleteReclamationStagingFutureFundingTable(reclamationStagingFutureFundingTables, new List<ReclamationStagingFutureFundingTable> { reclamationStagingFutureFundingTableToDelete });
        }
    }
}