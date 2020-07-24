using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class CostAuthorityJsonList
    {
        public Dictionary<int, CostAuthorityJson> CostAuthorityJsons { get; set; }

        public CostAuthorityJsonList(List<CostAuthorityJson> costAuthorityJson)
        {
            CostAuthorityJsons = costAuthorityJson.ToDictionary(x => x.CostAuthorityID, x => x);
        }
    }
}