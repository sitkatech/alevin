using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class Agreement : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"Agreement: {this.AgreementID} - {this.AgreementNumber}";
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