//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ObligationRequest
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ObligationRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ObligationRequest>
    {
        public ObligationRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ObligationRequestPrimaryKey(ObligationRequest obligationRequest) : base(obligationRequest){}

        public static implicit operator ObligationRequestPrimaryKey(int primaryKeyValue)
        {
            return new ObligationRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ObligationRequestPrimaryKey(ObligationRequest obligationRequest)
        {
            return new ObligationRequestPrimaryKey(obligationRequest);
        }
    }
}