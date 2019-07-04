//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationPersonsTable]
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
        public static ReclamationPersonsTable GetReclamationPersonsTable(this IQueryable<ReclamationPersonsTable> reclamationPersonsTables, int reclamationPersonsTableID)
        {
            var reclamationPersonsTable = reclamationPersonsTables.SingleOrDefault(x => x.ReclamationPersonsTableID == reclamationPersonsTableID);
            Check.RequireNotNullThrowNotFound(reclamationPersonsTable, "ReclamationPersonsTable", reclamationPersonsTableID);
            return reclamationPersonsTable;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationPersonsTable(this IQueryable<ReclamationPersonsTable> reclamationPersonsTables, List<int> reclamationPersonsTableIDList)
        {
            if(reclamationPersonsTableIDList.Any())
            {
                reclamationPersonsTables.Where(x => reclamationPersonsTableIDList.Contains(x.ReclamationPersonsTableID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationPersonsTable(this IQueryable<ReclamationPersonsTable> reclamationPersonsTables, ICollection<ReclamationPersonsTable> reclamationPersonsTablesToDelete)
        {
            if(reclamationPersonsTablesToDelete.Any())
            {
                var reclamationPersonsTableIDList = reclamationPersonsTablesToDelete.Select(x => x.ReclamationPersonsTableID).ToList();
                reclamationPersonsTables.Where(x => reclamationPersonsTableIDList.Contains(x.ReclamationPersonsTableID)).Delete();
            }
        }

        public static void DeleteReclamationPersonsTable(this IQueryable<ReclamationPersonsTable> reclamationPersonsTables, int reclamationPersonsTableID)
        {
            DeleteReclamationPersonsTable(reclamationPersonsTables, new List<int> { reclamationPersonsTableID });
        }

        public static void DeleteReclamationPersonsTable(this IQueryable<ReclamationPersonsTable> reclamationPersonsTables, ReclamationPersonsTable reclamationPersonsTableToDelete)
        {
            DeleteReclamationPersonsTable(reclamationPersonsTables, new List<ReclamationPersonsTable> { reclamationPersonsTableToDelete });
        }
    }
}