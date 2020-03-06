//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementRequestStatus
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementRequestStatusPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementRequestStatus>
    {
        public AgreementRequestStatusPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementRequestStatusPrimaryKey(AgreementRequestStatus agreementRequestStatus) : base(agreementRequestStatus){}

        public static implicit operator AgreementRequestStatusPrimaryKey(int primaryKeyValue)
        {
            return new AgreementRequestStatusPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementRequestStatusPrimaryKey(AgreementRequestStatus agreementRequestStatus)
        {
            return new AgreementRequestStatusPrimaryKey(agreementRequestStatus);
        }
    }
}