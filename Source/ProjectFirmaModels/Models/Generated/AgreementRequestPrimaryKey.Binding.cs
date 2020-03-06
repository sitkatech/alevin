//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementRequest>
    {
        public AgreementRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementRequestPrimaryKey(AgreementRequest agreementRequest) : base(agreementRequest){}

        public static implicit operator AgreementRequestPrimaryKey(int primaryKeyValue)
        {
            return new AgreementRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementRequestPrimaryKey(AgreementRequest agreementRequest)
        {
            return new AgreementRequestPrimaryKey(agreementRequest);
        }
    }
}