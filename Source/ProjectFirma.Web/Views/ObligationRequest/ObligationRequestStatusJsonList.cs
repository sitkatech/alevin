using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class ObligationRequestStatusJsonList
    {
        public Dictionary<int, ObligationRequestStatusJson> ObligationRequestJsons { get; set; }

        public ObligationRequestStatusJsonList(List<ObligationRequestStatusJson> obligationRequestJsons)
        {
            ObligationRequestJsons = obligationRequestJsons.ToDictionary(x => x.ReclamationObligationRequestStatusID, x=> x);
        }
    }
}