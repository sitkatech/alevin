using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class AgreementJsonList
    {
        public Dictionary<int, AgreementJson> AgreementJsons { get; set; }

        public AgreementJsonList(List<AgreementJson> agreementJsons)
        {
            AgreementJsons = agreementJsons.ToDictionary(x => x.ReclamationAgreementID, x => x);
        }
    }
}