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
        public static DepartmentCode GetDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, int departmentCodeID)
        {
            var departmentCode = departmentCodes.SingleOrDefault(x => x.DepartmentCodeID == departmentCodeID);
            Check.RequireNotNullThrowNotFound(departmentCode, "DepartmentCode", departmentCodeID);
            return departmentCode;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, List<int> departmentCodeIDList)
        {
            if(departmentCodeIDList.Any())
            {
                departmentCodes.Where(x => departmentCodeIDList.Contains(x.DepartmentCodeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, ICollection<DepartmentCode> departmentCodesToDelete)
        {
            if(departmentCodesToDelete.Any())
            {
                var departmentCodeIDList = departmentCodesToDelete.Select(x => x.DepartmentCodeID).ToList();
                departmentCodes.Where(x => departmentCodeIDList.Contains(x.DepartmentCodeID)).Delete();
            }
        }

        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, int departmentCodeID)
        {
            DeleteDepartmentCode(departmentCodes, new List<int> { departmentCodeID });
        }

        public static void DeleteDepartmentCode(this IQueryable<DepartmentCode> departmentCodes, DepartmentCode departmentCodeToDelete)
        {
            DeleteDepartmentCode(departmentCodes, new List<DepartmentCode> { departmentCodeToDelete });
        }
    }
}