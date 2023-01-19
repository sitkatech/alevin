using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ActionItem;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.SubprojectActionItem
{
    public class IndexViewData : FirmaViewData
    {
        public string GridDataUrl { get; }
        public SubprojectActionItemsAdminGridSpec GridSpec { get; }
        public string GridName { get; }

        public string ActionItemStateToBeSelectedOnLoad { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, string gridDataUrl) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.SubprojectActionItem.ToType().GetFieldDefinitionLabelPluralized()}";
            GridDataUrl = gridDataUrl;
            GridSpec = new SubprojectActionItemsAdminGridSpec(currentFirmaSession);
            GridName = "actionItemsIndexGrid";

            ActionItemStateToBeSelectedOnLoad = ActionItemState.Incomplete.ActionItemStateDisplayName;
        }

    }
}