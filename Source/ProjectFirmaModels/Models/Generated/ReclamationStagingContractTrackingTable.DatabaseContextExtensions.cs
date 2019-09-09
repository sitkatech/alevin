//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingContractTrackingTable]
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
        public static ReclamationStagingContractTrackingTable GetReclamationStagingContractTrackingTable(this IQueryable<ReclamationStagingContractTrackingTable> reclamationStagingContractTrackingTables, int reclamationStagingContractTrackingTableID)
        {
            var reclamationStagingContractTrackingTable = reclamationStagingContractTrackingTables.SingleOrDefault(x => x.ReclamationStagingContractTrackingTableID == reclamationStagingContractTrackingTableID);
            Check.RequireNotNullThrowNotFound(reclamationStagingContractTrackingTable, "ReclamationStagingContractTrackingTable", reclamationStagingContractTrackingTableID);
            return reclamationStagingContractTrackingTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingContractTrackingTable(this IQueryable<ReclamationStagingContractTrackingTable> reclamationStagingContractTrackingTables, List<int> reclamationStagingContractTrackingTableIDList)
        {
            if(reclamationStagingContractTrackingTableIDList.Any())
            {
                reclamationStagingContractTrackingTables.Where(x => reclamationStagingContractTrackingTableIDList.Contains(x.ReclamationStagingContractTrackingTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingContractTrackingTable(this IQueryable<ReclamationStagingContractTrackingTable> reclamationStagingContractTrackingTables, ICollection<ReclamationStagingContractTrackingTable> reclamationStagingContractTrackingTablesToDelete)
        {
            if(reclamationStagingContractTrackingTablesToDelete.Any())
            {
                var reclamationStagingContractTrackingTableIDList = reclamationStagingContractTrackingTablesToDelete.Select(x => x.ReclamationStagingContractTrackingTableID).ToList();
                reclamationStagingContractTrackingTables.Where(x => reclamationStagingContractTrackingTableIDList.Contains(x.ReclamationStagingContractTrackingTableID)).Delete();
            }
        }

        public static void DeleteReclamationStagingContractTrackingTable(this IQueryable<ReclamationStagingContractTrackingTable> reclamationStagingContractTrackingTables, int reclamationStagingContractTrackingTableID)
        {
            DeleteReclamationStagingContractTrackingTable(reclamationStagingContractTrackingTables, new List<int> { reclamationStagingContractTrackingTableID });
        }

        public static void DeleteReclamationStagingContractTrackingTable(this IQueryable<ReclamationStagingContractTrackingTable> reclamationStagingContractTrackingTables, ReclamationStagingContractTrackingTable reclamationStagingContractTrackingTableToDelete)
        {
            DeleteReclamationStagingContractTrackingTable(reclamationStagingContractTrackingTables, new List<ReclamationStagingContractTrackingTable> { reclamationStagingContractTrackingTableToDelete });
        }
    }
}