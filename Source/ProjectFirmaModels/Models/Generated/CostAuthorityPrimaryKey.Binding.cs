//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthority>
    {
        public CostAuthorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityPrimaryKey(CostAuthority costAuthority) : base(costAuthority){}

        public static implicit operator CostAuthorityPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityPrimaryKey(CostAuthority costAuthority)
        {
            return new CostAuthorityPrimaryKey(costAuthority);
        }
    }
}