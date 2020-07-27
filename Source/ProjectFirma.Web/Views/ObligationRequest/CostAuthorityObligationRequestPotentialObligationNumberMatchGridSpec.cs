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
            Add(string.Empty, x => ModalDialogFormHelper.MakeInfoIconLink(x.GetPotentialMatchDetailUrl(), "View Details of Potential Match", true), 30, DhtmlxGridColumnFilterType.None);

            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), pm => UrlTemplate.MakeHrefString(pm.ObligationNumber.GetDetailUrl(), pm.ObligationNumber.ObligationNumberKey), 100, DhtmlxGridColumnFilterType.Text);
            Add("Total of All Obligation Item Budgets", pm => pm.ObligationNumber.GetWbsElementObligationItemBudgets().Sum(y => y.UnexpendedBalance).ToStringCurrency(), 100, DhtmlxGridColumnFilterType.Numeric);
            Add("Obligation Item Budget Count", pm => pm.ObligationNumber.GetWbsElementObligationItemBudgets().Count.ToString(), 60, DhtmlxGridColumnFilterType.Numeric);
            Add("WBS", pm => pm.CostAuthorityObligationRequest.CostAuthority.CostAuthorityWorkBreakdownStructure, 200, DhtmlxGridColumnFilterType.Numeric);

            Add(string.Empty, x => ModalDialogFormHelper.MakeConfirmDialogLink("Confirm this match", x.GetPotentialMatchConfirmUrl(), "Confirm Match", null, true), 50, DhtmlxGridColumnFilterType.None);
        }


    }
}