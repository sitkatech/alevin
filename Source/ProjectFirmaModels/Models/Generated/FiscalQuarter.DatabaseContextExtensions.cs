//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[FiscalQuarter]
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
        public static FiscalQuarter GetFiscalQuarter(this IQueryable<FiscalQuarter> fiscalQuarters, int fiscalQuarterID)
        {
            var fiscalQuarter = fiscalQuarters.SingleOrDefault(x => x.FiscalQuarterID == fiscalQuarterID);
            Check.RequireNotNullThrowNotFound(fiscalQuarter, "FiscalQuarter", fiscalQuarterID);
            return fiscalQuarter;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteFiscalQuarter(this IQueryable<FiscalQuarter> fiscalQuarters, List<int> fiscalQuarterIDList)
        {
            if(fiscalQuarterIDList.Any())
            {
                fiscalQuarters.Where(x => fiscalQuarterIDList.Contains(x.FiscalQuarterID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteFiscalQuarter(this IQueryable<FiscalQuarter> fiscalQuarters, ICollection<FiscalQuarter> fiscalQuartersToDelete)
        {
            if(fiscalQuartersToDelete.Any())
            {
                var fiscalQuarterIDList = fiscalQuartersToDelete.Select(x => x.FiscalQuarterID).ToList();
                fiscalQuarters.Where(x => fiscalQuarterIDList.Contains(x.FiscalQuarterID)).Delete();
            }
        }

        public static void DeleteFiscalQuarter(this IQueryable<FiscalQuarter> fiscalQuarters, int fiscalQuarterID)
        {
            DeleteFiscalQuarter(fiscalQuarters, new List<int> { fiscalQuarterID });
        }

        public static void DeleteFiscalQuarter(this IQueryable<FiscalQuarter> fiscalQuarters, FiscalQuarter fiscalQuarterToDelete)
        {
            DeleteFiscalQuarter(fiscalQuarters, new List<FiscalQuarter> { fiscalQuarterToDelete });
        }
    }
}