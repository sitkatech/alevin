﻿/*-----------------------------------------------------------------------
<copyright file="PersonOrganizationController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.PersonOrganization;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Controllers
{
    public class PersonOrganizationController : FirmaBaseController
    {
        [HttpGet]
        [UserAdminFeature]
        public PartialViewResult EditPersonOrganizationPrimaryContacts(PersonPrimaryKey personPrimaryKey)
        {
            var person = personPrimaryKey.EntityObject;
            var organizationIDs = person.OrganizationsWhereYouAreThePrimaryContactPerson.Select(org => org.OrganizationID).ToList();
            var viewModel = new EditPersonOrganizationsViewModel(organizationIDs);
            return ViewEditPersonOrganizations(viewModel);
        }

        [HttpPost]
        [UserAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditPersonOrganizationPrimaryContacts(PersonPrimaryKey personPrimaryKey, EditPersonOrganizationsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditPersonOrganizations(viewModel);
            }
            var person = personPrimaryKey.EntityObject;
            viewModel.UpdateModel(person, HttpRequestStorage.DatabaseEntities.Organizations.ToList());
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditPersonOrganizations(EditPersonOrganizationsViewModel viewModel)
        {
            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations().Select(x => new OrganizationSimple(x)).ToList();
            var viewData = new EditPersonOrganizationsViewData(allOrganizations);
            return RazorPartialView<EditPersonOrganizations, EditPersonOrganizationsViewData, EditPersonOrganizationsViewModel>(viewData, viewModel);
        }
    }
}
