//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationDepartmentCode]
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
        public static ReclamationDepartmentCode GetReclamationDepartmentCode(this IQueryable<ReclamationDepartmentCode> reclamationDepartmentCodes, int reclamationDepartmentCodeID)
        {
            var reclamationDepartmentCode = reclamationDepartmentCodes.SingleOrDefault(x => x.ReclamationDepartmentCodeID == reclamationDepartmentCodeID);
            Check.RequireNotNullThrowNotFound(reclamationDepartmentCode, "ReclamationDepartmentCode", reclamationDepartmentCodeID);
            return reclamationDepartmentCode;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationDepartmentCode(this IQueryable<ReclamationDepartmentCode> reclamationDepartmentCodes, List<int> reclamationDepartmentCodeIDList)
        {
            if(reclamationDepartmentCodeIDList.Any())
            {
                reclamationDepartmentCodes.Where(x => reclamationDepartmentCodeIDList.Contains(x.ReclamationDepartmentCodeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationDepartmentCode(this IQueryable<ReclamationDepartmentCode> reclamationDepartmentCodes, ICollection<ReclamationDepartmentCode> reclamationDepartmentCodesToDelete)
        {
            if(reclamationDepartmentCodesToDelete.Any())
            {
                var reclamationDepartmentCodeIDList = reclamationDepartmentCodesToDelete.Select(x => x.ReclamationDepartmentCodeID).ToList();
                reclamationDepartmentCodes.Where(x => reclamationDepartmentCodeIDList.Contains(x.ReclamationDepartmentCodeID)).Delete();
            }
        }

        public static void DeleteReclamationDepartmentCode(this IQueryable<ReclamationDepartmentCode> reclamationDepartmentCodes, int reclamationDepartmentCodeID)
        {
            DeleteReclamationDepartmentCode(reclamationDepartmentCodes, new List<int> { reclamationDepartmentCodeID });
        }

        public static void DeleteReclamationDepartmentCode(this IQueryable<ReclamationDepartmentCode> reclamationDepartmentCodes, ReclamationDepartmentCode reclamationDepartmentCodeToDelete)
        {
            DeleteReclamationDepartmentCode(reclamationDepartmentCodes, new List<ReclamationDepartmentCode> { reclamationDepartmentCodeToDelete });
        }
    }
}