//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementRequest
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementRequestPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementRequest>
    {
        public ReclamationAgreementRequestPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementRequestPrimaryKey(ReclamationAgreementRequest reclamationAgreementRequest) : base(reclamationAgreementRequest){}

        public static implicit operator ReclamationAgreementRequestPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementRequestPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementRequestPrimaryKey(ReclamationAgreementRequest reclamationAgreementRequest)
        {
            return new ReclamationAgreementRequestPrimaryKey(reclamationAgreementRequest);
        }
    }
}