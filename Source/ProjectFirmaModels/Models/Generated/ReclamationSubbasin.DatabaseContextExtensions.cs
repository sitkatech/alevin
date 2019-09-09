//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationSubbasin]
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
        public static ReclamationSubbasin GetReclamationSubbasin(this IQueryable<ReclamationSubbasin> reclamationSubbasins, int reclamationSubbasinID)
        {
            var reclamationSubbasin = reclamationSubbasins.SingleOrDefault(x => x.ReclamationSubbasinID == reclamationSubbasinID);
            Check.RequireNotNullThrowNotFound(reclamationSubbasin, "ReclamationSubbasin", reclamationSubbasinID);
            return reclamationSubbasin;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationSubbasin(this IQueryable<ReclamationSubbasin> reclamationSubbasins, List<int> reclamationSubbasinIDList)
        {
            if(reclamationSubbasinIDList.Any())
            {
                reclamationSubbasins.Where(x => reclamationSubbasinIDList.Contains(x.ReclamationSubbasinID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationSubbasin(this IQueryable<ReclamationSubbasin> reclamationSubbasins, ICollection<ReclamationSubbasin> reclamationSubbasinsToDelete)
        {
            if(reclamationSubbasinsToDelete.Any())
            {
                var reclamationSubbasinIDList = reclamationSubbasinsToDelete.Select(x => x.ReclamationSubbasinID).ToList();
                reclamationSubbasins.Where(x => reclamationSubbasinIDList.Contains(x.ReclamationSubbasinID)).Delete();
            }
        }

        public static void DeleteReclamationSubbasin(this IQueryable<ReclamationSubbasin> reclamationSubbasins, int reclamationSubbasinID)
        {
            DeleteReclamationSubbasin(reclamationSubbasins, new List<int> { reclamationSubbasinID });
        }

        public static void DeleteReclamationSubbasin(this IQueryable<ReclamationSubbasin> reclamationSubbasins, ReclamationSubbasin reclamationSubbasinToDelete)
        {
            DeleteReclamationSubbasin(reclamationSubbasins, new List<ReclamationSubbasin> { reclamationSubbasinToDelete });
        }
    }
}