using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.ActionItem;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Controllers
{
    public class ActionItemController : FirmaBaseController
    {
        [ActionItemEditFeature]
        public GridJsonNetJObjectResult<ActionItem> ActionItemsGridJsonData(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var gridSpec = new ActionItemsGridSpec();
            var actionItems = project.ActionItems.OrderByDescending(x => x.DueByDate).ToList();
            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<ActionItem>(actionItems, gridSpec);
            return gridJsonNetJObjectResult;
        }

        [HttpGet]
        [ActionItemEditFeature]
        public PartialViewResult New(ProjectPrimaryKey projectPrimaryKey)
        {
            var project = projectPrimaryKey.EntityObject;
            var viewModel = new EditViewModel()
            {
                ActionItemStateEnum = ActionItemStateEnum.Incomplete,
                ProjectID = project.ProjectID
            };
            
            return ViewEdit(viewModel);
        }

        [HttpGet]
        [ActionItemEditFeature]
        public PartialViewResult Edit(ActionItemPrimaryKey actionItemPrimaryKey)
        {
            var actionItem = actionItemPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(actionItem);
            return ViewEdit(viewModel);
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel)
        {
            var firmaPage = FirmaPageTypeEnum.ActionItemEditDialog.GetFirmaPage();
            var viewData = new EditViewData(CurrentFirmaSession, firmaPage);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [HttpPost]
        [ActionItemEditFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Edit(ActionItemPrimaryKey actionItemPrimaryKey, EditViewModel viewModel)
        {
            var actionItem = actionItemPrimaryKey.EntityObject;
            if (!ModelState.IsValid)
            {
                return ViewEdit(viewModel);
            }
            
            viewModel.UpdateModel(actionItem, CurrentFirmaSession);
            SetMessageForDisplay("Action Item successfully updated.");
            return new ModalDialogFormJsonResult();
        }


    }
}