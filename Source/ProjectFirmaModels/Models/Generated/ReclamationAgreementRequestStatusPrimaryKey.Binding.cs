//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementRequestStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementRequestStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementRequestStatus>
    {
        public ReclamationAgreementRequestStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementRequestStatusPrimaryKey(ReclamationAgreementRequestStatus reclamationAgreementRequestStatus) : base(reclamationAgreementRequestStatus){}

        public static implicit operator ReclamationAgreementRequestStatusPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementRequestStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementRequestStatusPrimaryKey(ReclamationAgreementRequestStatus reclamationAgreementRequestStatus)
        {
            return new ReclamationAgreementRequestStatusPrimaryKey(reclamationAgreementRequestStatus);
        }
    }
}