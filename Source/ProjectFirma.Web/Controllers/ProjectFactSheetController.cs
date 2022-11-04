﻿/*-----------------------------------------------------------------------
<copyright file="ProjectFactSheetController.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectFactSheet;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectFactSheetController : FirmaBaseController
    {
        [ProjectFactSheetAdminFeature]
        public ViewResult Manage()
        {
            var firmaPage = FirmaPageTypeEnum.ManageProjectFactSheet.GetFirmaPage();
            var factSheetCustomTextFirmaPage = FirmaPageTypeEnum.FactSheetCustomText.GetFirmaPage();
            var factSheetCustomTextViewData = new ViewPageContentViewData(factSheetCustomTextFirmaPage, false);
            var editCustomFactSheetTextUrl =  SitkaRoute<FirmaPageController>.BuildUrlFromExpression(t => t.EditInDialog(factSheetCustomTextFirmaPage));
            var deleteFactSheetLogoFileResourceUrl = new SitkaRoute<ProjectFactSheetController>(c => c.DeleteTenantFactSheetLogoFileResource()).BuildUrlFromExpression();
            var editFactSheetLogoUrl = new SitkaRoute<ProjectFactSheetController>(c => c.EditFactSheetLogo()).BuildUrlFromExpression();
            var editBasicsUrl = new SitkaRoute<ProjectFactSheetController>(c => c.EditBasics()).BuildUrlFromExpression();
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewData = new ManageViewData(CurrentFirmaSession, firmaPage, factSheetCustomTextViewData, editCustomFactSheetTextUrl, deleteFactSheetLogoFileResourceUrl, editFactSheetLogoUrl, editBasicsUrl, tenantAttribute);
            return RazorView<Manage, ManageViewData>(viewData);
        }


        [HttpGet]
        [ProjectFactSheetAdminFeature]
        public PartialViewResult EditFactSheetLogo()
        {
            var tenant = HttpRequestStorage.Tenant;
            var viewModel = new EditFactSheetLogoViewModel(tenant);
            return ViewEditFactSheetLogo(viewModel);
        }

        [HttpPost]
        [ProjectFactSheetAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditFactSheetLogo(EditFactSheetLogoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditFactSheetLogo(viewModel);
            }

            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == viewModel.TenantID);

            viewModel.UpdateModel(tenantAttribute, CurrentFirmaSession, HttpRequestStorage.DatabaseEntities);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult(new SitkaRoute<ProjectFactSheetController>(c => c.Manage()).BuildUrlFromExpression());
        }

        private PartialViewResult ViewEditFactSheetLogo(EditFactSheetLogoViewModel viewModel)
        {
            var viewData = new EditFactSheetLogoViewData(CurrentFirmaSession);
            return RazorPartialView<EditFactSheetLogo, EditFactSheetLogoViewData, EditFactSheetLogoViewModel>(viewData, viewModel);
        }

        [HttpGet]
        [ProjectFactSheetAdminFeature]
        public PartialViewResult DeleteTenantFactSheetLogoFileResource()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new ConfirmDialogFormViewModel(tenant.TenantID);
            return ViewDeleteTenantFactSheetLogoFileResource(viewModel, tenantAttribute);
        }

        [HttpPost]
        [ProjectFactSheetAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult DeleteTenantFactSheetLogoFileResource(ConfirmDialogFormViewModel viewModel)
        {
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == HttpRequestStorage.DatabaseEntities.TenantID);
            if (!ModelState.IsValid)
            {
                return ViewDeleteTenantFactSheetLogoFileResource(viewModel, tenantAttribute);
            }

            var tenantAttributeTenantFactSheetLogoFileResource = tenantAttribute.TenantFactSheetLogoFileResourceInfo;
            var fileResourceDatas = tenantAttribute.TenantFactSheetLogoFileResourceInfo.FileResourceDatas;
            tenantAttribute.TenantFactSheetLogoFileResourceInfo.FileResourceDatas = null;
            tenantAttribute.TenantFactSheetLogoFileResourceInfo = null;
            foreach (var fileResourceData in fileResourceDatas)
            {
                fileResourceData.Delete(HttpRequestStorage.DatabaseEntities);
            }
            tenantAttributeTenantFactSheetLogoFileResource.Delete(HttpRequestStorage.DatabaseEntities);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewDeleteTenantFactSheetLogoFileResource(ConfirmDialogFormViewModel viewModel, TenantAttribute tenantAttribute)
        {
            var confirmMessage = $"Are you sure you want to delete the Fact Sheet Logo for {tenantAttribute.TenantShortDisplayName}?";
            var viewData = new ConfirmDialogFormViewData(confirmMessage);
            return RazorPartialView<ConfirmDialogForm, ConfirmDialogFormViewData, ConfirmDialogFormViewModel>(viewData, viewModel);
        }
        [HttpGet]
        [ProjectFactSheetAdminFeature]
        public PartialViewResult EditBasics()
        {
            var tenant = HttpRequestStorage.Tenant;
            var tenantAttribute = MultiTenantHelpers.GetTenantAttributeFromCache();
            var viewModel = new EditBasicsViewModel(tenant, tenantAttribute);
            return ViewEditBasics(viewModel);
        }

        [HttpPost]
        [ProjectFactSheetAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditBasics(EditBasicsViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewEditBasics(viewModel);
            }

            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == viewModel.TenantID);
            viewModel.UpdateModel(tenantAttribute, CurrentFirmaSession);
            MultiTenantHelpers.ClearTenantAttributeCacheForAllTenants();
            return new ModalDialogFormJsonResult(new SitkaRoute<ProjectFactSheetController>(c => c.Manage()).BuildUrlFromExpression());
        }

        private PartialViewResult ViewEditBasics(EditBasicsViewModel viewModel)
        {
            var adminFeature = new FirmaAdminFeature();
            var viewData = new EditBasicsViewData(CurrentFirmaSession);
            return RazorPartialView<EditBasics, EditBasicsViewData, EditBasicsViewModel>(viewData, viewModel);
        }

    }
}