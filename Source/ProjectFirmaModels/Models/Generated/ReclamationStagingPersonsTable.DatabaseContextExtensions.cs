//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingPersonsTable]
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
        public static ReclamationStagingPersonsTable GetReclamationStagingPersonsTable(this IQueryable<ReclamationStagingPersonsTable> reclamationStagingPersonsTables, int reclamationStagingPersonsTableID)
        {
            var reclamationStagingPersonsTable = reclamationStagingPersonsTables.SingleOrDefault(x => x.ReclamationStagingPersonsTableID == reclamationStagingPersonsTableID);
            Check.RequireNotNullThrowNotFound(reclamationStagingPersonsTable, "ReclamationStagingPersonsTable", reclamationStagingPersonsTableID);
            return reclamationStagingPersonsTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingPersonsTable(this IQueryable<ReclamationStagingPersonsTable> reclamationStagingPersonsTables, List<int> reclamationStagingPersonsTableIDList)
        {
            if(reclamationStagingPersonsTableIDList.Any())
            {
                reclamationStagingPersonsTables.Where(x => reclamationStagingPersonsTableIDList.Contains(x.ReclamationStagingPersonsTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingPersonsTable(this IQueryable<ReclamationStagingPersonsTable> reclamationStagingPersonsTables, ICollection<ReclamationStagingPersonsTable> reclamationStagingPersonsTablesToDelete)
        {
            if(reclamationStagingPersonsTablesToDelete.Any())
            {
                var reclamationStagingPersonsTableIDList = reclamationStagingPersonsTablesToDelete.Select(x => x.ReclamationStagingPersonsTableID).ToList();
                reclamationStagingPersonsTables.Where(x => reclamationStagingPersonsTableIDList.Contains(x.ReclamationStagingPersonsTableID)).Delete();
            }
        }

        public static void DeleteReclamationStagingPersonsTable(this IQueryable<ReclamationStagingPersonsTable> reclamationStagingPersonsTables, int reclamationStagingPersonsTableID)
        {
            DeleteReclamationStagingPersonsTable(reclamationStagingPersonsTables, new List<int> { reclamationStagingPersonsTableID });
        }

        public static void DeleteReclamationStagingPersonsTable(this IQueryable<ReclamationStagingPersonsTable> reclamationStagingPersonsTables, ReclamationStagingPersonsTable reclamationStagingPersonsTableToDelete)
        {
            DeleteReclamationStagingPersonsTable(reclamationStagingPersonsTables, new List<ReclamationStagingPersonsTable> { reclamationStagingPersonsTableToDelete });
        }
    }
}