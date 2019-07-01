//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[WorkBreakdownStructure]
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
        public static WorkBreakdownStructure GetWorkBreakdownStructure(this IQueryable<WorkBreakdownStructure> workBreakdownStructures, int workBreakdownStructureID)
        {
            var workBreakdownStructure = workBreakdownStructures.SingleOrDefault(x => x.WorkBreakdownStructureID == workBreakdownStructureID);
            Check.RequireNotNullThrowNotFound(workBreakdownStructure, "WorkBreakdownStructure", workBreakdownStructureID);
            return workBreakdownStructure;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWorkBreakdownStructure(this IQueryable<WorkBreakdownStructure> workBreakdownStructures, List<int> workBreakdownStructureIDList)
        {
            if(workBreakdownStructureIDList.Any())
            {
                workBreakdownStructures.Where(x => workBreakdownStructureIDList.Contains(x.WorkBreakdownStructureID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWorkBreakdownStructure(this IQueryable<WorkBreakdownStructure> workBreakdownStructures, ICollection<WorkBreakdownStructure> workBreakdownStructuresToDelete)
        {
            if(workBreakdownStructuresToDelete.Any())
            {
                var workBreakdownStructureIDList = workBreakdownStructuresToDelete.Select(x => x.WorkBreakdownStructureID).ToList();
                workBreakdownStructures.Where(x => workBreakdownStructureIDList.Contains(x.WorkBreakdownStructureID)).Delete();
            }
        }

        public static void DeleteWorkBreakdownStructure(this IQueryable<WorkBreakdownStructure> workBreakdownStructures, int workBreakdownStructureID)
        {
            DeleteWorkBreakdownStructure(workBreakdownStructures, new List<int> { workBreakdownStructureID });
        }

        public static void DeleteWorkBreakdownStructure(this IQueryable<WorkBreakdownStructure> workBreakdownStructures, WorkBreakdownStructure workBreakdownStructureToDelete)
        {
            DeleteWorkBreakdownStructure(workBreakdownStructures, new List<WorkBreakdownStructure> { workBreakdownStructureToDelete });
        }
    }
}