﻿/*-----------------------------------------------------------------------
<copyright file="FundingSourceCustomAttributesController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Web.Mvc;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using EditFundingSourceCustomAttributes = ProjectFirma.Web.Views.FundingSourceCustomAttributes.EditFundingSourceCustomAttributes;
using EditFundingSourceCustomAttributesViewData = ProjectFirma.Web.Views.FundingSourceCustomAttributes.EditFundingSourceCustomAttributesViewData;
using EditFundingSourceCustomAttributesViewModel = ProjectFirma.Web.Views.FundingSourceCustomAttributes.EditFundingSourceCustomAttributesViewModel;

namespace ProjectFirma.Web.Controllers
{
    public class FundingSourceCustomAttributesController : FirmaBaseController
    {
        [HttpGet]
        [FundingSourceCustomAttributeEditFeature]
        public PartialViewResult EditFundingSourceCustomAttributesForFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            var viewModel = new EditFundingSourceCustomAttributesViewModel(fundingSource);
            return ViewEditFundingSourceCustomAttributes(fundingSource, viewModel);
        }

        [HttpPost]
        [FundingSourceCustomAttributeEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditFundingSourceCustomAttributesForFundingSource(FundingSourcePrimaryKey fundingSourcePrimaryKey, EditFundingSourceCustomAttributesViewModel viewModel)
        {
            var fundingSource = fundingSourcePrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEditFundingSourceCustomAttributes(fundingSource, viewModel);
            }

            return UpdateFundingSourceCustomAttributes(viewModel, fundingSource);
        }

        private ActionResult UpdateFundingSourceCustomAttributes(EditFundingSourceCustomAttributesViewModel viewModel, FundingSource fundingSource)
        {
            viewModel.UpdateModel(fundingSource, CurrentFirmaSession);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewEditFundingSourceCustomAttributes(FundingSource fundingSource, EditFundingSourceCustomAttributesViewModel viewModel)
        {

            var fundingSourceCustomAttributeTypes = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.ToList().Where(x => x.HasEditPermission(CurrentFirmaSession));

            var viewData = new EditFundingSourceCustomAttributesViewData(
                fundingSourceCustomAttributeTypes,
                new List<FundingSourceCustomAttribute>(fundingSource.FundingSourceCustomAttributes.ToList()));

            return RazorPartialView<EditFundingSourceCustomAttributes, EditFundingSourceCustomAttributesViewData, EditFundingSourceCustomAttributesViewModel>(viewData, viewModel);
        }
    }
}