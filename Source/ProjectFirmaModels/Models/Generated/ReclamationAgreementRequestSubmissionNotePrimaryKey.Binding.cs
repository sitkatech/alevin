//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationAgreementRequestSubmissionNote
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationAgreementRequestSubmissionNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationAgreementRequestSubmissionNote>
    {
        public ReclamationAgreementRequestSubmissionNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationAgreementRequestSubmissionNotePrimaryKey(ReclamationAgreementRequestSubmissionNote reclamationAgreementRequestSubmissionNote) : base(reclamationAgreementRequestSubmissionNote){}

        public static implicit operator ReclamationAgreementRequestSubmissionNotePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationAgreementRequestSubmissionNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationAgreementRequestSubmissionNotePrimaryKey(ReclamationAgreementRequestSubmissionNote reclamationAgreementRequestSubmissionNote)
        {
            return new ReclamationAgreementRequestSubmissionNotePrimaryKey(reclamationAgreementRequestSubmissionNote);
        }
    }
}