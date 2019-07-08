//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationWorkBreakdownStructure]
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
        public static ReclamationWorkBreakdownStructure GetReclamationWorkBreakdownStructure(this IQueryable<ReclamationWorkBreakdownStructure> reclamationWorkBreakdownStructures, int reclamationWorkBreakdownStructureID)
        {
            var reclamationWorkBreakdownStructure = reclamationWorkBreakdownStructures.SingleOrDefault(x => x.ReclamationWorkBreakdownStructureID == reclamationWorkBreakdownStructureID);
            Check.RequireNotNullThrowNotFound(reclamationWorkBreakdownStructure, "ReclamationWorkBreakdownStructure", reclamationWorkBreakdownStructureID);
            return reclamationWorkBreakdownStructure;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationWorkBreakdownStructure(this IQueryable<ReclamationWorkBreakdownStructure> reclamationWorkBreakdownStructures, List<int> reclamationWorkBreakdownStructureIDList)
        {
            if(reclamationWorkBreakdownStructureIDList.Any())
            {
                reclamationWorkBreakdownStructures.Where(x => reclamationWorkBreakdownStructureIDList.Contains(x.ReclamationWorkBreakdownStructureID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationWorkBreakdownStructure(this IQueryable<ReclamationWorkBreakdownStructure> reclamationWorkBreakdownStructures, ICollection<ReclamationWorkBreakdownStructure> reclamationWorkBreakdownStructuresToDelete)
        {
            if(reclamationWorkBreakdownStructuresToDelete.Any())
            {
                var reclamationWorkBreakdownStructureIDList = reclamationWorkBreakdownStructuresToDelete.Select(x => x.ReclamationWorkBreakdownStructureID).ToList();
                reclamationWorkBreakdownStructures.Where(x => reclamationWorkBreakdownStructureIDList.Contains(x.ReclamationWorkBreakdownStructureID)).Delete();
            }
        }

        public static void DeleteReclamationWorkBreakdownStructure(this IQueryable<ReclamationWorkBreakdownStructure> reclamationWorkBreakdownStructures, int reclamationWorkBreakdownStructureID)
        {
            DeleteReclamationWorkBreakdownStructure(reclamationWorkBreakdownStructures, new List<int> { reclamationWorkBreakdownStructureID });
        }

        public static void DeleteReclamationWorkBreakdownStructure(this IQueryable<ReclamationWorkBreakdownStructure> reclamationWorkBreakdownStructures, ReclamationWorkBreakdownStructure reclamationWorkBreakdownStructureToDelete)
        {
            DeleteReclamationWorkBreakdownStructure(reclamationWorkBreakdownStructures, new List<ReclamationWorkBreakdownStructure> { reclamationWorkBreakdownStructureToDelete });
        }
    }
}