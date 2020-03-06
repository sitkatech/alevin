//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthorityAgreementRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityAgreementRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthorityAgreementRequest>
    {
        public CostAuthorityAgreementRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityAgreementRequestPrimaryKey(CostAuthorityAgreementRequest costAuthorityAgreementRequest) : base(costAuthorityAgreementRequest){}

        public static implicit operator CostAuthorityAgreementRequestPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityAgreementRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityAgreementRequestPrimaryKey(CostAuthorityAgreementRequest costAuthorityAgreementRequest)
        {
            return new CostAuthorityAgreementRequestPrimaryKey(costAuthorityAgreementRequest);
        }
    }
}