using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class CostAuthorityObligationRequestPotentialObligationNumberMatchGridSpec : GridSpec<CostAuthorityObligationRequestPotentialObligationNumberMatch>
    {
        public CostAuthorityObligationRequestPotentialObligationNumberMatchGridSpec(FirmaSession currentFirmaSession)
        {
            // Yes, we will need editor links of some kind here eventually...

            //Add(string.Empty
            //    , x => !isInDraft ? new HtmlString("<span style='cursor: not-allowed;' class='glyphicon glyphicon-trash blue disabled' title='You cannot delete this because it is in draft'><span class='sr-only'>You cannot delete this because it is in draft</span></span>")
            //        : costAuthorityIDListOnObligation.Contains(x.CostAuthorityID) ? new HtmlString("<span style='cursor: not-allowed;' class='glyphicon glyphicon-trash blue disabled' title='You cannot delete this because it is on the Obligation'><span class='sr-only'>You cannot delete this because it is on the Obligation</span></span>")
            //        : ModalDialogFormHelper.MakeDeleteIconLink(x.GetDeleteUrl(), "Delete This Projected Obligation", true)
            //    , 30
            //    , DhtmlxGridColumnFilterType.None);

            ;


            // Like what we want, but we want info icon
            Add(string.Empty, x => ModalDialogFormHelper.MakeInfoIconLink(x.GetPotentialMatchDetailUrl(), "View Details of Potential Match", true), 30, DhtmlxGridColumnFilterType.None);

            //Add(string.Empty,
            //    x => UrlTemplate.MakeHrefString(x.GetPotentialMatchDetailUrl(),
            //        FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString() +
            //        $"<span class=\"sr-only\">View details of potential match</span>"), 30,
            //    DhtmlxGridColumnFilterType.None);

            //Add(string.Empty,
            //    x => ModalDialogFormHelper.ModalDialogFormLink(FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString() + "<span class=\"sr-only\">View details of potential match</span>",
            //        x.GetPotentialMatchDetailUrl(), "details of potential match", 900, "Save", "Cancel",
            //        new List<string> { "btn-firma btn-xs" }, null, null), 30,
            //    DhtmlxGridColumnFilterType.None);

            //Add(string.Empty,
            //    x => ModalDialogFormHelper.ModalDialogFormLink(FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString() + "<span class=\"sr-only\">View details of potential match</span>",
            //        x.GetPotentialMatchDetailUrl(), "details of potential match", 900, "Save", "Cancel",
            //        new List<string> { "btn-firma btn-xs" }, null, null), 30,
            //    DhtmlxGridColumnFilterType.None);



            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), pm => UrlTemplate.MakeHrefString(pm.ObligationNumber.GetDetailUrl(), pm.ObligationNumber.ObligationNumberKey), 100, DhtmlxGridColumnFilterType.Text);

            Add("Total of All Obligation Item Budgets", pm => pm.ObligationNumber.ObligationItems.SelectMany(x => x.WbsElementObligationItemBudgets).Sum(y => y.UnexpendedBalance).ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);

            Add("Obligation Item Budget Count", pm => pm.ObligationNumber.ObligationItems.SelectMany(x => x.WbsElementObligationItemBudgets).Count().ToString(), 100, DhtmlxGridColumnFilterType.Numeric);

            Add("WBS", pm => pm.CostAuthorityObligationRequest.CostAuthority.CostAuthorityWorkBreakdownStructure, 250, DhtmlxGridColumnFilterType.Numeric);

            /*
            // Agreement (AgreementNumber)
            Add(FieldDefinitionEnum.AgreementNumber.ToType().ToGridHeaderString(), ra => UrlTemplate.MakeHrefString(ra.ReclamationAgreement?.GetDetailUrl(), ra.ReclamationAgreement?.GetDisplayName()), 100, DhtmlxGridColumnFilterType.Html);
            // Organization for Agreement
            Add("Agreement Organization", ra => UrlTemplate.MakeHrefString(ra.ReclamationAgreement?.Organization?.GetDetailUrl(), ra.ReclamationAgreement?.Organization?.GetDisplayName()), 300, DhtmlxGridColumnFilterType.SelectFilterHtmlStrict);


            //Add(string.Empty, x => ModalDialogFormHelper.MakeEditIconLink(x.GetEditUrl(), "Edit Projected Obligation", true), 30, DhtmlxGridColumnFilterType.None);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString("CAWBS"), x => x.CostAuthority.CostAuthorityWorkBreakdownStructure, 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.AccountStructureDescription.ToType().ToGridHeaderString(), x => x.CostAuthority.AccountStructureDescription, 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectedObligation.ToType().ToGridHeaderString(), x => x.ProjectedObligation, 300, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.BudgetObjectCode.ToType().ToGridHeaderString(), a => a.BudgetObjectCode?.GetDisplayName(), 120, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.RecipientOrganization.ToType().ToGridHeaderString(), a => a.RecipientOrganization?.GetDisplayName(), 120, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.TechnicalRepresentative.ToType().ToGridHeaderString(), a => a.TechnicalRepresentativePerson?.GetFullNameFirstLast(), 120, DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.CostAuthorityObligationRequestNote.ToType().ToGridHeaderString("Notes"), x => x.CostAuthorityObligationRequestNote, 300, DhtmlxGridColumnFilterType.Text);
            */
        }


    }
}