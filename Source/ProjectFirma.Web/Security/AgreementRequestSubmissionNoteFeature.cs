using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Security
{
    [SecurityFeatureDescription("Can create, read, edit and delete notes for an obligation request")]
    public class ObligationRequestSubmissionNoteFeature : FirmaFeature
    {
        public ObligationRequestSubmissionNoteFeature()
            : base(new List<Role> { Role.ESAAdmin, Role.Admin })
        {
        }
    }
}