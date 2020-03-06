//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementReclamationCostAuthority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementReclamationCostAuthorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementReclamationCostAuthority>
    {
        public AgreementReclamationCostAuthorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementReclamationCostAuthorityPrimaryKey(AgreementReclamationCostAuthority agreementReclamationCostAuthority) : base(agreementReclamationCostAuthority){}

        public static implicit operator AgreementReclamationCostAuthorityPrimaryKey(int primaryKeyValue)
        {
            return new AgreementReclamationCostAuthorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementReclamationCostAuthorityPrimaryKey(AgreementReclamationCostAuthority agreementReclamationCostAuthority)
        {
            return new AgreementReclamationCostAuthorityPrimaryKey(agreementReclamationCostAuthority);
        }
    }
}