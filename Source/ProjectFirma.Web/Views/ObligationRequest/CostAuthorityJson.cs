using System;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class CostAuthorityJson
    {
        public int CostAuthorityID { get; set; }
        public int? TechnicalRepresentativePersonID { get; set; }
        public int? RecipientOrganizationID { get; set; }
        public int? BudgetObjectCodeID { get; set; }
        public string CostAuthorityWorkBreakdownStructure { get; set; }
        public string AccountStructureDescription { get; set; }
        public string Note { get; set; }
        public Money? ProjectedObligation { get; set; }

        public bool PreventDelete { get; set; }

        public CostAuthorityJson()
        {
        }

        public CostAuthorityJson(ProjectFirmaModels.Models.CostAuthority costAuthority)
        {
            CostAuthorityID = costAuthority.CostAuthorityID;
            CostAuthorityWorkBreakdownStructure = costAuthority.CostAuthorityWorkBreakdownStructure;
            AccountStructureDescription = costAuthority.AccountStructureDescription;

        }

        public CostAuthorityJson(CostAuthorityObligationRequest costAuthorityObligationRequest)
        {
            CostAuthorityID = costAuthorityObligationRequest.CostAuthority.CostAuthorityID;
            CostAuthorityWorkBreakdownStructure = costAuthorityObligationRequest.CostAuthority.CostAuthorityWorkBreakdownStructure;
            AccountStructureDescription = costAuthorityObligationRequest.CostAuthority.AccountStructureDescription;
            Note = costAuthorityObligationRequest.CostAuthorityObligationRequestNote;
            ProjectedObligation = costAuthorityObligationRequest.ProjectedObligation;
            RecipientOrganizationID = costAuthorityObligationRequest.RecipientOrganizationID;
            TechnicalRepresentativePersonID = costAuthorityObligationRequest.TechnicalRepresentativePersonID;
            BudgetObjectCodeID = costAuthorityObligationRequest.BudgetObjectCodeID;
        }
    }
}