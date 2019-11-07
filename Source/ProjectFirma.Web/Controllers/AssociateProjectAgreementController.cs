using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.AssociateProjectAgreement;
using ProjectFirma.Web.Views.Shared.ProjectContact;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class AssociateProjectAgreementController : FirmaBaseController
    {
        
        [HttpGet]
        [ProjectEditAsAdminFeature]
        public PartialViewResult AddAssociatedAgreementToProjectEditor(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new AddAssociatedAgreementToProjectViewModel(project, CurrentPerson);
            return ViewAddAssociatedAgreementToProjectEditor(viewModel, project);
        }

        [HttpPost]
        [ProjectEditAsAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult AddAssociatedAgreementToProjectEditor(ProjectPrimaryKey projectPrimaryKey, AddAssociatedAgreementToProjectViewModel viewModel)
        {
            var project = projectPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewAddAssociatedAgreementToProjectEditor(viewModel, project);
            }

            viewModel.UpdateModel(project, HttpRequestStorage.DatabaseEntities.ReclamationCostAuthorityProjects, CurrentPerson);
            //HttpRequestStorage.DatabaseEntities.SaveChanges();

            return new ModalDialogFormJsonResult();
        }

        private PartialViewResult ViewAddAssociatedAgreementToProjectEditor(AddAssociatedAgreementToProjectViewModel viewModel, Project project)
        {

            var allReclamationAgreements = HttpRequestStorage.DatabaseEntities.ReclamationAgreements.ToList();
            var allReclamationCostAuthorities = HttpRequestStorage.DatabaseEntities.ReclamationCostAuthorities.ToList();

            var viewData = new AddAssociatedAgreementToProjectViewData(allReclamationAgreements, allReclamationCostAuthorities);
            return RazorPartialView<AddAssociatedAgreementToProject, AddAssociatedAgreementToProjectViewData, AddAssociatedAgreementToProjectViewModel>(viewData, viewModel);
        }

    }
}