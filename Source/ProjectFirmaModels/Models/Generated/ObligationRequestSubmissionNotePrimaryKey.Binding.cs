//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ObligationRequestSubmissionNote
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ObligationRequestSubmissionNotePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ObligationRequestSubmissionNote>
    {
        public ObligationRequestSubmissionNotePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ObligationRequestSubmissionNotePrimaryKey(ObligationRequestSubmissionNote obligationRequestSubmissionNote) : base(obligationRequestSubmissionNote){}

        public static implicit operator ObligationRequestSubmissionNotePrimaryKey(int primaryKeyValue)
        {
            return new ObligationRequestSubmissionNotePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ObligationRequestSubmissionNotePrimaryKey(ObligationRequestSubmissionNote obligationRequestSubmissionNote)
        {
            return new ObligationRequestSubmissionNotePrimaryKey(obligationRequestSubmissionNote);
        }
    }
}