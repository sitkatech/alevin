//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Subproject
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Subproject>
    {
        public SubprojectPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public SubprojectPrimaryKey(Subproject subproject) : base(subproject){}

        public static implicit operator SubprojectPrimaryKey(int primaryKeyValue)
        {
            return new SubprojectPrimaryKey(primaryKeyValue);
        }

        public static implicit operator SubprojectPrimaryKey(Subproject subproject)
        {
            return new SubprojectPrimaryKey(subproject);
        }
    }
}