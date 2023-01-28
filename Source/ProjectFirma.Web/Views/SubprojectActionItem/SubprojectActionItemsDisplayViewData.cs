
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.SubprojectActionItem
{
    public class SubprojectActionItemsDisplayViewData : FirmaUserControlViewData
    {
        public ProjectFirmaModels.Models.Subproject Subproject { get; set; }
        public SubprojectActionItemsGridSpec ActionItemsGridSpec { get; }
        public string ActionItemsGridName { get; }
        public string ActionItemsGridDataUrl { get; }
        public PermissionCheckResult UserCanViewActionItems { get; }
        public PermissionCheckResult UserCanCreateActionItems { get; }
        public string AddNewActionItemUrl { get; }

        public SubprojectActionItemsDisplayViewData(ProjectFirmaModels.Models.Subproject project, SubprojectActionItemsGridSpec actionItemsGridSpec, string actionItemsGridName, string actionItemsGridDataUrl, PermissionCheckResult userCanViewActionItems, PermissionCheckResult userCanCreateActionItems, string addNewActionItemUrl)
        {
            Subproject = project;
            ActionItemsGridSpec = actionItemsGridSpec;
            ActionItemsGridName = actionItemsGridName;
            ActionItemsGridDataUrl = actionItemsGridDataUrl;
            UserCanViewActionItems = userCanViewActionItems;
            UserCanCreateActionItems = userCanCreateActionItems;
            AddNewActionItemUrl = addNewActionItemUrl;
        }
    }
}