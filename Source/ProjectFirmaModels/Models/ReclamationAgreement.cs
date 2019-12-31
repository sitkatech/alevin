using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ReclamationAgreement : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationAgreement: {this.ReclamationAgreementID} - {this.AgreementNumber}";
        }

        public string GetOrganizationDisplayName()
        {
            if (Organization == null)
            {
                return string.Empty;
            }
            return Organization.GetDisplayName();
        }
    }
}