//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.impPayRecV3
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class impPayRecV3PrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<impPayRecV3>
    {
        public impPayRecV3PrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public impPayRecV3PrimaryKey(impPayRecV3 impPayRecV3) : base(impPayRecV3){}

        public static implicit operator impPayRecV3PrimaryKey(int primaryKeyValue)
        {
            return new impPayRecV3PrimaryKey(primaryKeyValue);
        }

        public static implicit operator impPayRecV3PrimaryKey(impPayRecV3 impPayRecV3)
        {
            return new impPayRecV3PrimaryKey(impPayRecV3);
        }
    }
}