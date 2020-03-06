//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[WorkbreakdownStructure]
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
        public static WorkbreakdownStructure GetWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, int reclamationWorkBreakdownStructureID)
        {
            var workbreakdownStructure = workbreakdownStructures.SingleOrDefault(x => x.ReclamationWorkBreakdownStructureID == reclamationWorkBreakdownStructureID);
            Check.RequireNotNullThrowNotFound(workbreakdownStructure, "WorkbreakdownStructure", reclamationWorkBreakdownStructureID);
            return workbreakdownStructure;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, List<int> reclamationWorkBreakdownStructureIDList)
        {
            if(reclamationWorkBreakdownStructureIDList.Any())
            {
                workbreakdownStructures.Where(x => reclamationWorkBreakdownStructureIDList.Contains(x.ReclamationWorkBreakdownStructureID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, ICollection<WorkbreakdownStructure> workbreakdownStructuresToDelete)
        {
            if(workbreakdownStructuresToDelete.Any())
            {
                var reclamationWorkBreakdownStructureIDList = workbreakdownStructuresToDelete.Select(x => x.ReclamationWorkBreakdownStructureID).ToList();
                workbreakdownStructures.Where(x => reclamationWorkBreakdownStructureIDList.Contains(x.ReclamationWorkBreakdownStructureID)).Delete();
            }
        }

        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, int reclamationWorkBreakdownStructureID)
        {
            DeleteWorkbreakdownStructure(workbreakdownStructures, new List<int> { reclamationWorkBreakdownStructureID });
        }

        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, WorkbreakdownStructure workbreakdownStructureToDelete)
        {
            DeleteWorkbreakdownStructure(workbreakdownStructures, new List<WorkbreakdownStructure> { workbreakdownStructureToDelete });
        }
    }
}