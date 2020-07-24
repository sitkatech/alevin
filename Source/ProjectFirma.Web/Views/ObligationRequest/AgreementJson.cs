namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class AgreementJson
    {
        public int ReclamationAgreementID { get; set; }
        public int? TechnicalRepresentativeID { get; set; }
        public int? OrganizationID { get; set; }


        public AgreementJson(ProjectFirmaModels.Models.Agreement agreement)
        {
            TechnicalRepresentativeID = null;
            TechnicalRepresentativeID = agreement.TechnicalRepresentative.HasValue ? (int)agreement.TechnicalRepresentative.Value : TechnicalRepresentativeID;
            OrganizationID = agreement.OrganizationID;
            ReclamationAgreementID = agreement.AgreementID;
        }
    }
}