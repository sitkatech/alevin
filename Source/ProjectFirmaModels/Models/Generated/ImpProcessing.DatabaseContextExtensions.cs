//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpProcessing]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ImpProcessing GetImpProcessing(this IQueryable<ImpProcessing> impProcessings, int impProcessingID)
        {
            var impProcessing = impProcessings.SingleOrDefault(x => x.ImpProcessingID == impProcessingID);
            Check.RequireNotNullThrowNotFound(impProcessing, "ImpProcessing", impProcessingID);
            return impProcessing;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteImpProcessing(this IQueryable<ImpProcessing> impProcessings, List<int> impProcessingIDList)
        {
            if(impProcessingIDList.Any())
            {
                impProcessings.Where(x => impProcessingIDList.Contains(x.ImpProcessingID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteImpProcessing(this IQueryable<ImpProcessing> impProcessings, ICollection<ImpProcessing> impProcessingsToDelete)
        {
            if(impProcessingsToDelete.Any())
            {
                var impProcessingIDList = impProcessingsToDelete.Select(x => x.ImpProcessingID).ToList();
                impProcessings.Where(x => impProcessingIDList.Contains(x.ImpProcessingID)).Delete();
            }
        }

        public static void DeleteImpProcessing(this IQueryable<ImpProcessing> impProcessings, int impProcessingID)
        {
            DeleteImpProcessing(impProcessings, new List<int> { impProcessingID });
        }

        public static void DeleteImpProcessing(this IQueryable<ImpProcessing> impProcessings, ImpProcessing impProcessingToDelete)
        {
            DeleteImpProcessing(impProcessings, new List<ImpProcessing> { impProcessingToDelete });
        }
    }
}