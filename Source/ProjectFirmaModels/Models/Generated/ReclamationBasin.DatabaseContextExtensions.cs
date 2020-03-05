//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationBasin]
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
        public static ReclamationBasin GetReclamationBasin(this IQueryable<ReclamationBasin> reclamationBasins, int reclamationBasinID)
        {
            var reclamationBasin = reclamationBasins.SingleOrDefault(x => x.ReclamationBasinID == reclamationBasinID);
            Check.RequireNotNullThrowNotFound(reclamationBasin, "ReclamationBasin", reclamationBasinID);
            return reclamationBasin;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationBasin(this IQueryable<ReclamationBasin> reclamationBasins, List<int> reclamationBasinIDList)
        {
            if(reclamationBasinIDList.Any())
            {
                reclamationBasins.Where(x => reclamationBasinIDList.Contains(x.ReclamationBasinID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationBasin(this IQueryable<ReclamationBasin> reclamationBasins, ICollection<ReclamationBasin> reclamationBasinsToDelete)
        {
            if(reclamationBasinsToDelete.Any())
            {
                var reclamationBasinIDList = reclamationBasinsToDelete.Select(x => x.ReclamationBasinID).ToList();
                reclamationBasins.Where(x => reclamationBasinIDList.Contains(x.ReclamationBasinID)).Delete();
            }
        }

        public static void DeleteReclamationBasin(this IQueryable<ReclamationBasin> reclamationBasins, int reclamationBasinID)
        {
            DeleteReclamationBasin(reclamationBasins, new List<int> { reclamationBasinID });
        }

        public static void DeleteReclamationBasin(this IQueryable<ReclamationBasin> reclamationBasins, ReclamationBasin reclamationBasinToDelete)
        {
            DeleteReclamationBasin(reclamationBasins, new List<ReclamationBasin> { reclamationBasinToDelete });
        }
    }
}