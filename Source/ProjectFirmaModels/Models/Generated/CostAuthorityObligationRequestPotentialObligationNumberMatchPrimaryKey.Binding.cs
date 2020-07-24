//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.CostAuthorityObligationRequestPotentialObligationNumberMatch
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<CostAuthorityObligationRequestPotentialObligationNumberMatch>
    {
        public CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey(CostAuthorityObligationRequestPotentialObligationNumberMatch costAuthorityObligationRequestPotentialObligationNumberMatch) : base(costAuthorityObligationRequestPotentialObligationNumberMatch){}

        public static implicit operator CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey(int primaryKeyValue)
        {
            return new CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey(primaryKeyValue);
        }

        public static implicit operator CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey(CostAuthorityObligationRequestPotentialObligationNumberMatch costAuthorityObligationRequestPotentialObligationNumberMatch)
        {
            return new CostAuthorityObligationRequestPotentialObligationNumberMatchPrimaryKey(costAuthorityObligationRequestPotentialObligationNumberMatch);
        }
    }
}