//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementRequestFundingPriority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementRequestFundingPriorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementRequestFundingPriority>
    {
        public AgreementRequestFundingPriorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementRequestFundingPriorityPrimaryKey(AgreementRequestFundingPriority agreementRequestFundingPriority) : base(agreementRequestFundingPriority){}

        public static implicit operator AgreementRequestFundingPriorityPrimaryKey(int primaryKeyValue)
        {
            return new AgreementRequestFundingPriorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementRequestFundingPriorityPrimaryKey(AgreementRequestFundingPriority agreementRequestFundingPriority)
        {
            return new AgreementRequestFundingPriorityPrimaryKey(agreementRequestFundingPriority);
        }
    }
}