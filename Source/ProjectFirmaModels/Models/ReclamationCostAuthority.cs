using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ReclamationCostAuthority : IAuditableEntity
    {
        public string GetAuditDescriptionString()
        {
            return $"ReclamationCostAuthority: {this.ReclamationCostAuthorityID} - {this.CostAuthorityWorkBreakdownStructure}";
        }
    }
}