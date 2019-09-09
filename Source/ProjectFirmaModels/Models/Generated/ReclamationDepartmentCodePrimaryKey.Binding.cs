//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationDepartmentCode
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationDepartmentCodePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationDepartmentCode>
    {
        public ReclamationDepartmentCodePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationDepartmentCodePrimaryKey(ReclamationDepartmentCode reclamationDepartmentCode) : base(reclamationDepartmentCode){}

        public static implicit operator ReclamationDepartmentCodePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationDepartmentCodePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationDepartmentCodePrimaryKey(ReclamationDepartmentCode reclamationDepartmentCode)
        {
            return new ReclamationDepartmentCodePrimaryKey(reclamationDepartmentCode);
        }
    }
}