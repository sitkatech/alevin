//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.SubprojectNote
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<SubprojectNote>
    {
        public SubprojectNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectNotePrimaryKey(SubprojectNote subprojectNote) : base(subprojectNote){}

        public static implicit operator SubprojectNotePrimaryKey(int primaryKeyValue)
        {
            return new SubprojectNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectNotePrimaryKey(SubprojectNote subprojectNote)
        {
            return new SubprojectNotePrimaryKey(subprojectNote);
        }
    }
}