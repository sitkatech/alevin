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

using System;
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
    public class EditCostAuthorityObligationRequestViewData : FirmaViewData
    {

        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        public ProjectFirmaModels.Models.ObligationRequest ObligationRequest { get; set; }
        public IEnumerable<SelectListItem> Organizations { get; }
        public IEnumerable<SelectListItem> People { get; }
        public IEnumerable<SelectListItem> BudgetObjectCodes { get; }

        public EditCostAuthorityObligationRequestViewData(
             ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , ProjectFirmaModels.Models.ObligationRequest obligationRequest
             , List<ProjectFirmaModels.Models.Organization> allOrganizations
             , List<Person> allPeople
             , List<ProjectFirmaModels.Models.BudgetObjectCode> allBudgetObjectCodes
            ) : base(currentFirmaSession)
        {
            ProjectStatusFirmaPage = new ViewPageContentViewData(projectStatusFirmaPage, currentFirmaSession);
            ObligationRequest = obligationRequest;
            Organizations = allOrganizations.OrderBy(x => x.GetDisplayName()).ToSelectListWithEmptyFirstRow(x => x.OrganizationID.ToString(), x => x.GetDisplayName());
            People = allPeople.OrderBy(x => x.GetFullNameFirstLast()).ToSelectListWithEmptyFirstRow(x => x.PersonID.ToString(), x => x.GetFullNameFirstLast());
            BudgetObjectCodes = allBudgetObjectCodes.OrderBy(x => x.GetDisplayName()).ToSelectListWithEmptyFirstRow(x => x.BudgetObjectCodeID.ToString(), x => x.GetDisplayName());
        }
    }
}
