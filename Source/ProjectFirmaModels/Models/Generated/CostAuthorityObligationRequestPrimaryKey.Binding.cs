//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthorityObligationRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityObligationRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthorityObligationRequest>
    {
        public CostAuthorityObligationRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityObligationRequestPrimaryKey(CostAuthorityObligationRequest costAuthorityObligationRequest) : base(costAuthorityObligationRequest){}

        public static implicit operator CostAuthorityObligationRequestPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityObligationRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityObligationRequestPrimaryKey(CostAuthorityObligationRequest costAuthorityObligationRequest)
        {
            return new CostAuthorityObligationRequestPrimaryKey(costAuthorityObligationRequest);
        }
    }
}