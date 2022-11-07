/*-----------------------------------------------------------------------
<copyright file="EditNoteViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ObligationRequest
{
    public class EditCostAuthorityObligationRequestsViewData : FirmaViewData
    {
        public IEnumerable<SelectListItem> CostAuthorities { get; }
        public CostAuthorityJsonList CostAuthorityJsonList { get; }
        public ViewPageContentViewData EditCostAuthorityObligationRequestsFirmaPage { get; }
        public IEnumerable<SelectListItem> Organizations { get; }
        public IEnumerable<SelectListItem> People { get; }
        public IEnumerable<SelectListItem> BudgetObjectCodes { get; }

        public EditCostAuthorityObligationRequestsViewData(
             ProjectFirmaModels.Models.FirmaPage editCostAuthorityObligationRequestsFirmaPage
            , FirmaSession currentFirmaSession
            , List<ProjectFirmaModels.Models.CostAuthority> allCostAuthorities
            , ProjectFirmaModels.Models.ObligationRequest obligationRequest
             , List<ProjectFirmaModels.Models.Organization> allOrganizations
             , List<Person> allPeople
             , List<ProjectFirmaModels.Models.BudgetObjectCode> allBudgetObjectCodes
            ) : base(currentFirmaSession, editCostAuthorityObligationRequestsFirmaPage)
        {
            var costAuthoritiesToOmit =
                obligationRequest.CostAuthorityObligationRequests.Select(x => x.CostAuthorityID);
            var reclamationCostAuthoritiesToUse = allCostAuthorities
                .Where(x => !costAuthoritiesToOmit.Contains(x.CostAuthorityID)).ToList();
            CostAuthorities = reclamationCostAuthoritiesToUse
                .OrderBy(x => x.CostAuthorityWorkBreakdownStructure)
                .ToSelectListWithEmptyFirstRow(x => x.CostAuthorityID.ToString(), x => x.CostAuthorityWorkBreakdownStructure, "Select CAWBS");
            CostAuthorityJsonList = new CostAuthorityJsonList(reclamationCostAuthoritiesToUse.Select(x => new CostAuthorityJson(x)).ToList());
            EditCostAuthorityObligationRequestsFirmaPage = new ViewPageContentViewData(editCostAuthorityObligationRequestsFirmaPage, currentFirmaSession);
            Organizations = allOrganizations.OrderBy(x => x.GetDisplayName()).ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(), x => x.GetDisplayName());
            People = allPeople.OrderBy(x => x.GetFullNameFirstLast()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(), x => x.GetFullNameFirstLast());
            BudgetObjectCodes = allBudgetObjectCodes.OrderBy(x => x.GetDisplayName()).ToSelectListWithEmptyFirstRow(x => x.BudgetObjectCodeID.ToString(), x => x.GetDisplayName());
        }
    }
}
