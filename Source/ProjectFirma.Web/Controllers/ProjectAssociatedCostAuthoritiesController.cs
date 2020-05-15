﻿using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ProjectAssociatedCostAuthorities;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ProjectAssociatedCostAuthoritiesController : FirmaBaseController
    {
        
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult EditProjectAssociatedCostAuthorities(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditProjectAssociatedCostAuthoritiesViewModel(project, CurrentPerson);
            return ViewProjectAssociatedCostAuthoritiesEditor(viewModel, project);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult EditProjectAssociatedCostAuthorities(ProjectPrimaryKey projectPrimaryKey, EditProjectAssociatedCostAuthoritiesViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewProjectAssociatedCostAuthoritiesEditor(viewModel, project);
            }

            viewModel.UpdateModel(project, HttpRequestStorage.DatabaseEntities.CostAuthorityProjects, CurrentPerson);

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewProjectAssociatedCostAuthoritiesEditor(EditProjectAssociatedCostAuthoritiesViewModel viewModel, Project project)
        {
            var allReclamationAgreements = HttpRequestStorage.DatabaseEntities.Agreements.ToList();
            var allCostAuthorities = HttpRequestStorage.DatabaseEntities.CostAuthorities.ToList();

            var viewData = new EditProjectAssociatedCostAuthoritiesViewData(allReclamationAgreements, allCostAuthorities);
            return RazorPartialView<EditProjectAssociatedCostAuthorities, EditProjectAssociatedCostAuthoritiesViewData, EditProjectAssociatedCostAuthoritiesViewModel>(viewData, viewModel);
        }

    }
}