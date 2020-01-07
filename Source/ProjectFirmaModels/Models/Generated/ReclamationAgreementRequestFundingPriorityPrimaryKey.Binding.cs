//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementRequestFundingPriority
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementRequestFundingPriorityPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementRequestFundingPriority>
    {
        public ReclamationAgreementRequestFundingPriorityPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementRequestFundingPriorityPrimaryKey(ReclamationAgreementRequestFundingPriority reclamationAgreementRequestFundingPriority) : base(reclamationAgreementRequestFundingPriority){}

        public static implicit operator ReclamationAgreementRequestFundingPriorityPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementRequestFundingPriorityPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementRequestFundingPriorityPrimaryKey(ReclamationAgreementRequestFundingPriority reclamationAgreementRequestFundingPriority)
        {
            return new ReclamationAgreementRequestFundingPriorityPrimaryKey(reclamationAgreementRequestFundingPriority);
        }
    }
}