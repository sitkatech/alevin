//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImportFinancialImpPayRecUnexpendedV3]
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
        public static ImportFinancialImpPayRecUnexpendedV3 GetImportFinancialImpPayRecUnexpendedV3(this IQueryable<ImportFinancialImpPayRecUnexpendedV3> importFinancialImpPayRecUnexpendedV3s, int importFinancialImpPayRecUnexpendedV3ID)
        {
            var importFinancialImpPayRecUnexpendedV3 = importFinancialImpPayRecUnexpendedV3s.SingleOrDefault(x => x.ImportFinancialImpPayRecUnexpendedV3ID == importFinancialImpPayRecUnexpendedV3ID);
            Check.RequireNotNullThrowNotFound(importFinancialImpPayRecUnexpendedV3, "ImportFinancialImpPayRecUnexpendedV3", importFinancialImpPayRecUnexpendedV3ID);
            return importFinancialImpPayRecUnexpendedV3;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteImportFinancialImpPayRecUnexpendedV3(this IQueryable<ImportFinancialImpPayRecUnexpendedV3> importFinancialImpPayRecUnexpendedV3s, List<int> importFinancialImpPayRecUnexpendedV3IDList)
        {
            if(importFinancialImpPayRecUnexpendedV3IDList.Any())
            {
                importFinancialImpPayRecUnexpendedV3s.Where(x => importFinancialImpPayRecUnexpendedV3IDList.Contains(x.ImportFinancialImpPayRecUnexpendedV3ID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteImportFinancialImpPayRecUnexpendedV3(this IQueryable<ImportFinancialImpPayRecUnexpendedV3> importFinancialImpPayRecUnexpendedV3s, ICollection<ImportFinancialImpPayRecUnexpendedV3> importFinancialImpPayRecUnexpendedV3sToDelete)
        {
            if(importFinancialImpPayRecUnexpendedV3sToDelete.Any())
            {
                var importFinancialImpPayRecUnexpendedV3IDList = importFinancialImpPayRecUnexpendedV3sToDelete.Select(x => x.ImportFinancialImpPayRecUnexpendedV3ID).ToList();
                importFinancialImpPayRecUnexpendedV3s.Where(x => importFinancialImpPayRecUnexpendedV3IDList.Contains(x.ImportFinancialImpPayRecUnexpendedV3ID)).Delete();
            }
        }

        public static void DeleteImportFinancialImpPayRecUnexpendedV3(this IQueryable<ImportFinancialImpPayRecUnexpendedV3> importFinancialImpPayRecUnexpendedV3s, int importFinancialImpPayRecUnexpendedV3ID)
        {
            DeleteImportFinancialImpPayRecUnexpendedV3(importFinancialImpPayRecUnexpendedV3s, new List<int> { importFinancialImpPayRecUnexpendedV3ID });
        }

        public static void DeleteImportFinancialImpPayRecUnexpendedV3(this IQueryable<ImportFinancialImpPayRecUnexpendedV3> importFinancialImpPayRecUnexpendedV3s, ImportFinancialImpPayRecUnexpendedV3 importFinancialImpPayRecUnexpendedV3ToDelete)
        {
            DeleteImportFinancialImpPayRecUnexpendedV3(importFinancialImpPayRecUnexpendedV3s, new List<ImportFinancialImpPayRecUnexpendedV3> { importFinancialImpPayRecUnexpendedV3ToDelete });
        }
    }
}