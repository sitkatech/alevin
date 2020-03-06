using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class CostAuthority : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"CostAuthority: {this.CostAuthorityID} - {this.CostAuthorityWorkBreakdownStructure}";
        }
    }
}