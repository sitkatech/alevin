using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
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
            Add("Info", x => ModalDialogFormHelper.MakeInfoIconLink(x.GetPotentialMatchDetailUrl(), "View Details of Potential Match", true), 30, AgGridColumnFilterType.None);

            Add(FieldDefinitionEnum.Obligation.ToType().ToGridHeaderString(), pm => UrlTemplate.MakeHrefString(pm.ObligationNumber.GetDetailUrl(), pm.ObligationNumber.ObligationNumberKey), 100, AgGridColumnFilterType.Text);
            Add("Total of All Obligation Item Budgets", pm => pm.ObligationNumber.GetWbsElementObligationItemBudgets().Sum(y => y.UnexpendedBalance).ToStringCurrency(), 100, AgGridColumnFilterType.Numeric);
            Add("Obligation Item Budget Count", pm => pm.ObligationNumber.GetWbsElementObligationItemBudgets().Count.ToString(), 60, AgGridColumnFilterType.Numeric);
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString(), a => a.CostAuthorityObligationRequest.CostAuthority.GetDetailLinkUsingCostAuthorityWorkBreakdownStructure(), 200, AgGridColumnFilterType.Text);
            Add("Confirm Match", x => ModalDialogFormHelper.MakeConfirmDialogLink("Confirm this match", x.GetPotentialMatchConfirmUrl(), "Confirm Match", null, true), 120, AgGridColumnFilterType.None);
        }


    }
}