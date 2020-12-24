using System.Linq;

namespace ProjectFirmaModels.Models
{
    public partial class ObligationRequest : IAuditableEntity
    {

        public string GetAuditDescriptionString()
        {
            return $"ObligationRequest: {this.ObligationRequestID}";
        }

        public decimal? TotalProjectedObligation
        {
            get
            {
                return this.CostAuthorityObligationRequests.Sum(o => o.ProjectedObligation);
            }
        }
    }
}