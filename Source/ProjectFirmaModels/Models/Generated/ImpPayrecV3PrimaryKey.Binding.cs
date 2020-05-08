//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImpPayrecV3
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ImpPayrecV3PrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImpPayrecV3>
    {
        public ImpPayrecV3PrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImpPayrecV3PrimaryKey(ImpPayrecV3 impPayrecV3) : base(impPayrecV3){}

        public static implicit operator ImpPayrecV3PrimaryKey(int primaryKeyValue)
        {
            return new ImpPayrecV3PrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImpPayrecV3PrimaryKey(ImpPayrecV3 impPayrecV3)
        {
            return new ImpPayrecV3PrimaryKey(impPayrecV3);
        }
    }
}