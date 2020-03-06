//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[DepartmentCode]
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
        public static DepartmentCode GetDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, int reclamationDepartmentCodeID)
        {
            var departmentCode = departmentCodes.SingleOrDefault(x => x.ReclamationDepartmentCodeID == reclamationDepartmentCodeID);
            Check.RequireNotNullThrowNotFound(departmentCode, "DepartmentCode", reclamationDepartmentCodeID);
            return departmentCode;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, List<int> reclamationDepartmentCodeIDList)
        {
            if(reclamationDepartmentCodeIDList.Any())
            {
                departmentCodes.Where(x => reclamationDepartmentCodeIDList.Contains(x.ReclamationDepartmentCodeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, ICollection<DepartmentCode> departmentCodesToDelete)
        {
            if(departmentCodesToDelete.Any())
            {
                var reclamationDepartmentCodeIDList = departmentCodesToDelete.Select(x => x.ReclamationDepartmentCodeID).ToList();
                departmentCodes.Where(x => reclamationDepartmentCodeIDList.Contains(x.ReclamationDepartmentCodeID)).Delete();
            }
        }

        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, int reclamationDepartmentCodeID)
        {
            DeleteDepartmentCode(departmentCodes, new List<int> { reclamationDepartmentCodeID });
        }

        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, DepartmentCode departmentCodeToDelete)
        {
            DeleteDepartmentCode(departmentCodes, new List<DepartmentCode> { departmentCodeToDelete });
        }
    }
}