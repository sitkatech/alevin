//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ObligationRequestFundingPriority
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ObligationRequestFundingPriorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ObligationRequestFundingPriority>
    {
        public ObligationRequestFundingPriorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ObligationRequestFundingPriorityPrimaryKey(ObligationRequestFundingPriority obligationRequestFundingPriority) : base(obligationRequestFundingPriority){}

        public static implicit operator ObligationRequestFundingPriorityPrimaryKey(int primaryKeyValue)
        {
            return new ObligationRequestFundingPriorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ObligationRequestFundingPriorityPrimaryKey(ObligationRequestFundingPriority obligationRequestFundingPriority)
        {
            return new ObligationRequestFundingPriorityPrimaryKey(obligationRequestFundingPriority);
        }
    }
}