//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectInternalNote
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectInternalNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectInternalNote>
    {
        public SubprojectInternalNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectInternalNotePrimaryKey(SubprojectInternalNote subprojectInternalNote) : base(subprojectInternalNote){}

        public static implicit operator SubprojectInternalNotePrimaryKey(int primaryKeyValue)
        {
            return new SubprojectInternalNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectInternalNotePrimaryKey(SubprojectInternalNote subprojectInternalNote)
        {
            return new SubprojectInternalNotePrimaryKey(subprojectInternalNote);
        }
    }
}