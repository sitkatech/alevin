using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ActionItem
{
    public class IndexViewData : FirmaViewData
    {
        public string GridDataUrl { get; }
        public ActionItemsAdminGridSpec GridSpec { get; }
        public string GridName { get; }

        public string ActionItemStateToBeSelectedOnLoad { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, string gridDataUrl) : base(currentFirmaSession, firmaPage)
        {
            PageTitle = $"Manage {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabelPluralized()}";
            GridDataUrl = gridDataUrl;
            GridSpec = new ActionItemsAdminGridSpec(currentFirmaSession);
            GridName = "actionItemsIndexGrid";

            ActionItemStateToBeSelectedOnLoad = ActionItemState.Incomplete.ActionItemStateDisplayName;
        }

    }
}