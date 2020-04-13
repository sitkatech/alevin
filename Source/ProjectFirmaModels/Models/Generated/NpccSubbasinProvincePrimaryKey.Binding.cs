//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.NpccSubbasinProvince
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class NpccSubbasinProvincePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<NpccSubbasinProvince>
    {
        public NpccSubbasinProvincePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public NpccSubbasinProvincePrimaryKey(NpccSubbasinProvince npccSubbasinProvince) : base(npccSubbasinProvince){}

        public static implicit operator NpccSubbasinProvincePrimaryKey(int primaryKeyValue)
        {
            return new NpccSubbasinProvincePrimaryKey(primaryKeyValue);
        }

        public static implicit operator NpccSubbasinProvincePrimaryKey(NpccSubbasinProvince npccSubbasinProvince)
        {
            return new NpccSubbasinProvincePrimaryKey(npccSubbasinProvince);
        }
    }
}