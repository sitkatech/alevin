//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementCostAuthority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementCostAuthorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementCostAuthority>
    {
        public AgreementCostAuthorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementCostAuthorityPrimaryKey(AgreementCostAuthority agreementCostAuthority) : base(agreementCostAuthority){}

        public static implicit operator AgreementCostAuthorityPrimaryKey(int primaryKeyValue)
        {
            return new AgreementCostAuthorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementCostAuthorityPrimaryKey(AgreementCostAuthority agreementCostAuthority)
        {
            return new AgreementCostAuthorityPrimaryKey(agreementCostAuthority);
        }
    }
}