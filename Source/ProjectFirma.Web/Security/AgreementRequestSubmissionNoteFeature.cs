using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can create, read, edit and delete notes for an agreement request")]
    public class AgreementRequestSubmissionNoteFeature : FirmaFeature
    {
        public AgreementRequestSubmissionNoteFeature()
            : base(new List<Role> { Role.SitkaAdmin, Role.Admin })
        {
        }
    }
}