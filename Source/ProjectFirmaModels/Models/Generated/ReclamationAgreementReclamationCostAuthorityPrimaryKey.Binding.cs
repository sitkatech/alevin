//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementReclamationCostAuthority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementReclamationCostAuthorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementReclamationCostAuthority>
    {
        public ReclamationAgreementReclamationCostAuthorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementReclamationCostAuthorityPrimaryKey(ReclamationAgreementReclamationCostAuthority reclamationAgreementReclamationCostAuthority) : base(reclamationAgreementReclamationCostAuthority){}

        public static implicit operator ReclamationAgreementReclamationCostAuthorityPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementReclamationCostAuthorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementReclamationCostAuthorityPrimaryKey(ReclamationAgreementReclamationCostAuthority reclamationAgreementReclamationCostAuthority)
        {
            return new ReclamationAgreementReclamationCostAuthorityPrimaryKey(reclamationAgreementReclamationCostAuthority);
        }
    }
}