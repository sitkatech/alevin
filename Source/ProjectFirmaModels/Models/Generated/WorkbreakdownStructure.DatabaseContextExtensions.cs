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
        public static WorkbreakdownStructure GetWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, int workbreakdownStructureID)
        {
            var workbreakdownStructure = workbreakdownStructures.SingleOrDefault(x => x.WorkbreakdownStructureID == workbreakdownStructureID);
            Check.RequireNotNullThrowNotFound(workbreakdownStructure, "WorkbreakdownStructure", workbreakdownStructureID);
            return workbreakdownStructure;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, List<int> workbreakdownStructureIDList)
        {
            if(workbreakdownStructureIDList.Any())
            {
                workbreakdownStructures.Where(x => workbreakdownStructureIDList.Contains(x.WorkbreakdownStructureID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, ICollection<WorkbreakdownStructure> workbreakdownStructuresToDelete)
        {
            if(workbreakdownStructuresToDelete.Any())
            {
                var workbreakdownStructureIDList = workbreakdownStructuresToDelete.Select(x => x.WorkbreakdownStructureID).ToList();
                workbreakdownStructures.Where(x => workbreakdownStructureIDList.Contains(x.WorkbreakdownStructureID)).Delete();
            }
        }

        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, int workbreakdownStructureID)
        {
            DeleteWorkbreakdownStructure(workbreakdownStructures, new List<int> { workbreakdownStructureID });
        }

        public static void DeleteWorkbreakdownStructure(this IQueryable<WorkbreakdownStructure> workbreakdownStructures, WorkbreakdownStructure workbreakdownStructureToDelete)
        {
            DeleteWorkbreakdownStructure(workbreakdownStructures, new List<WorkbreakdownStructure> { workbreakdownStructureToDelete });
        }
    }
}