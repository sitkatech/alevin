using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.ProjectProjectStatus;
using ProjectFirma.Web.Views.Shared;
using ProjectFirma.Web.Views.Shared.ProjectTimeline;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.SubprojectProjectStatus
{
    public class EditSubprojectProjectStatusViewData : FirmaViewData
    {

        public IEnumerable<SelectListItem> ProjectStatuses { get; }
        public ProjectStatusJsonList ProjectStatusJsonList { get; }

        public bool AllowEditUpdateDate { get; }
        public bool AllowEditFinal { get; }
        public string CreatedByPerson { get; }
        public HtmlString DeleteButton { get; }
        public ViewPageContentViewData ProjectStatusFirmaPage { get; }
        public ProjectStatusLegendDisplayViewData ProjectStatusLegendDisplayViewData { get; }
        

        public EditSubprojectProjectStatusViewData(
            ProjectFirmaModels.Models.Subproject subproject
            , bool allowEditUpdateDate
            , string createdByPerson
            , string deleteUrl
            , ProjectFirmaModels.Models.FirmaPage projectStatusFirmaPage
            , FirmaSession currentFirmaSession
            , List<ProjectFirmaModels.Models.ProjectStatus> allProjectStatuses
            , ProjectStatusLegendDisplayViewData projectStatusLegendDisplayViewData
            , bool isFinalStatusReport) : base(currentFirmaSession)
        {
            ProjectStatuses = allProjectStatuses.OrderBy(x => x.ProjectStatusSortOrder)
                .ToSelectListWithEmptyFirstRow(x => x.ProjectStatusID.ToString(), 
                    x => !string.IsNullOrEmpty(x.ProjectStatusDescription) 
                        ? $"{x.ProjectStatusDisplayName} - {x.ProjectStatusDescription}" 
                        : $"{x.ProjectStatusDisplayName}");
            ProjectStatusJsonList = new ProjectStatusJsonList(allProjectStatuses.Select(x => new ProjectStatusJson(x)).ToList());
            AllowEditUpdateDate = allowEditUpdateDate;
            CreatedByPerson = !string.IsNullOrEmpty(createdByPerson)
                ? createdByPerson
                : currentFirmaSession.UserDisplayName;
            DeleteButton = string.IsNullOrEmpty(deleteUrl) ? new HtmlString(string.Empty) : ModalDialogFormHelper.MakeDeleteIconButton(deleteUrl, $"Delete {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()} Update", true);
            ProjectStatusFirmaPage = new ViewPageContentViewData(projectStatusFirmaPage, currentFirmaSession);
            ProjectStatusLegendDisplayViewData = projectStatusLegendDisplayViewData;
            AllowEditFinal = isFinalStatusReport || SubprojectProjectStatusController.AllowUserToSetNewStatusReportToFinal(subproject, currentFirmaSession);
        }
    }
}