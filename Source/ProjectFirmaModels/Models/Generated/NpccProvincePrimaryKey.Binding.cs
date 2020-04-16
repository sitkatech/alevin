//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.NpccProvince
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class NpccProvincePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<NpccProvince>
    {
        public NpccProvincePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public NpccProvincePrimaryKey(NpccProvince npccProvince) : base(npccProvince){}

        public static implicit operator NpccProvincePrimaryKey(int primaryKeyValue)
        {
            return new NpccProvincePrimaryKey(primaryKeyValue);
        }

        public static implicit operator NpccProvincePrimaryKey(NpccProvince npccProvince)
        {
            return new NpccProvincePrimaryKey(npccProvince);
        }
    }
}