//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationCostAuthority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationCostAuthorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationCostAuthority>
    {
        public ReclamationCostAuthorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationCostAuthorityPrimaryKey(ReclamationCostAuthority reclamationCostAuthority) : base(reclamationCostAuthority){}

        public static implicit operator ReclamationCostAuthorityPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationCostAuthorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationCostAuthorityPrimaryKey(ReclamationCostAuthority reclamationCostAuthority)
        {
            return new ReclamationCostAuthorityPrimaryKey(reclamationCostAuthority);
        }
    }
}