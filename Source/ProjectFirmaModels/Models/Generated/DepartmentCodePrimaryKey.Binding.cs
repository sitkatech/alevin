//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.DepartmentCode
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class DepartmentCodePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<DepartmentCode>
    {
        public DepartmentCodePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public DepartmentCodePrimaryKey(DepartmentCode departmentCode) : base(departmentCode){}

        public static implicit operator DepartmentCodePrimaryKey(int primaryKeyValue)
        {
            return new DepartmentCodePrimaryKey(primaryKeyValue);
        }

        public static implicit operator DepartmentCodePrimaryKey(DepartmentCode departmentCode)
        {
            return new DepartmentCodePrimaryKey(departmentCode);
        }
    }
}