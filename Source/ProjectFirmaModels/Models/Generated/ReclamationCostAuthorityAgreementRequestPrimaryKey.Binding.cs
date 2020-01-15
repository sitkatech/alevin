//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationCostAuthorityAgreementRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationCostAuthorityAgreementRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationCostAuthorityAgreementRequest>
    {
        public ReclamationCostAuthorityAgreementRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationCostAuthorityAgreementRequestPrimaryKey(ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequest) : base(reclamationCostAuthorityAgreementRequest){}

        public static implicit operator ReclamationCostAuthorityAgreementRequestPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationCostAuthorityAgreementRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationCostAuthorityAgreementRequestPrimaryKey(ReclamationCostAuthorityAgreementRequest reclamationCostAuthorityAgreementRequest)
        {
            return new ReclamationCostAuthorityAgreementRequestPrimaryKey(reclamationCostAuthorityAgreementRequest);
        }
    }
}