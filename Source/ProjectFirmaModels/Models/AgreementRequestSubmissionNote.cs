using System;

namespace ProjectFirmaModels.Models
{
    public partial class AgreementRequestSubmissionNote : IAuditableEntity, IEntityNote
    {
        public DateTime GetLastUpdated()
        {
            return UpdateDate ?? CreateDate;
        }

        public string GetLastUpdatedBy()
        {
            if (UpdatePersonID.HasValue)
            {
                return UpdatePerson.GetFullNameFirstLast();
            }

            if (CreatePersonID.HasValue)
            {
                return CreatePerson.GetFullNameFirstLast();
            }

            return "System";
        }

        public string GetAuditDescriptionString()
        {
            return $"Reclamation Agreement Request Submission Note: {ReclamationAgreementRequestSubmissionNoteID} Note";
        }
    }
}