//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[WbsElement]
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
        public static WbsElement GetWbsElement(this IQueryable<WbsElement> wbsElements, int wbsElementID)
        {
            var wbsElement = wbsElements.SingleOrDefault(x => x.WbsElementID == wbsElementID);
            Check.RequireNotNullThrowNotFound(wbsElement, "WbsElement", wbsElementID);
            return wbsElement;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteWbsElement(this IQueryable<WbsElement> wbsElements, List<int> wbsElementIDList)
        {
            if(wbsElementIDList.Any())
            {
                wbsElements.Where(x => wbsElementIDList.Contains(x.WbsElementID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteWbsElement(this IQueryable<WbsElement> wbsElements, ICollection<WbsElement> wbsElementsToDelete)
        {
            if(wbsElementsToDelete.Any())
            {
                var wbsElementIDList = wbsElementsToDelete.Select(x => x.WbsElementID).ToList();
                wbsElements.Where(x => wbsElementIDList.Contains(x.WbsElementID)).Delete();
            }
        }

        public static void DeleteWbsElement(this IQueryable<WbsElement> wbsElements, int wbsElementID)
        {
            DeleteWbsElement(wbsElements, new List<int> { wbsElementID });
        }

        public static void DeleteWbsElement(this IQueryable<WbsElement> wbsElements, WbsElement wbsElementToDelete)
        {
            DeleteWbsElement(wbsElements, new List<WbsElement> { wbsElementToDelete });
        }
    }
}