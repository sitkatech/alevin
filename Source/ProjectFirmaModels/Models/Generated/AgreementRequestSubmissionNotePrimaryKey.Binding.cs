//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AgreementRequestSubmissionNote
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AgreementRequestSubmissionNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AgreementRequestSubmissionNote>
    {
        public AgreementRequestSubmissionNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AgreementRequestSubmissionNotePrimaryKey(AgreementRequestSubmissionNote agreementRequestSubmissionNote) : base(agreementRequestSubmissionNote){}

        public static implicit operator AgreementRequestSubmissionNotePrimaryKey(int primaryKeyValue)
        {
            return new AgreementRequestSubmissionNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator AgreementRequestSubmissionNotePrimaryKey(AgreementRequestSubmissionNote agreementRequestSubmissionNote)
        {
            return new AgreementRequestSubmissionNotePrimaryKey(agreementRequestSubmissionNote);
        }
    }
}