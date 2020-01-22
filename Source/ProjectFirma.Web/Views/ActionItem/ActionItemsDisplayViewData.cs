
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ActionItem
{
    public class ActionItemsDisplayViewData : FirmaUserControlViewData
    {
        public ProjectFirmaModels.Models.Project Project { get; set; }
        public ActionItemsGridSpec ActionItemsGridSpec { get; }
        public string ActionItemsGridName { get; }
        public string ActionItemsGridDataUrl { get; }
        public PermissionCheckResult UserCanViewActionItems { get; }
        public PermissionCheckResult UserCanEditActionItems { get; }
        public string AddNewActionItemUrl { get; }

        public ActionItemsDisplayViewData(ProjectFirmaModels.Models.Project project, ActionItemsGridSpec actionItemsGridSpec, string actionItemsGridName, string actionItemsGridDataUrl, PermissionCheckResult userCanViewActionItems, PermissionCheckResult userCanEditActionItems, string addNewActionItemUrl)
        {
            Project = project;
            ActionItemsGridSpec = actionItemsGridSpec;
            ActionItemsGridName = actionItemsGridName;
            ActionItemsGridDataUrl = actionItemsGridDataUrl;
            UserCanViewActionItems = userCanViewActionItems;
            UserCanEditActionItems = userCanEditActionItems;
            AddNewActionItemUrl = addNewActionItemUrl;
        }
    }
}