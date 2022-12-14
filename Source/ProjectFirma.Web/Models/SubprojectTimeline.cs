using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.BootstrapWrappers;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using static LtInfo.Common.DateUtilities;

namespace ProjectFirma.Web.Models
{
    public class SubprojectTimeline
    {
        public Subproject Subproject { get; }

        private List<ITimelineEvent> TimelineEvents { get; }
        public const string DisplayClass = "open";
        public bool UsesFiscalYears { get; }

        public SubprojectTimeline(Subproject subproject, bool canEditSubprojectProjectStatus, bool canEditFinalStatusReport)
        {
            Subproject = subproject;
            TimelineEvents = new List<ITimelineEvent>();
            TimelineEvents.AddRange(GetTimelineProjectStatusChangeEvents(Subproject, canEditSubprojectProjectStatus, canEditFinalStatusReport));
            UsesFiscalYears = MultiTenantHelpers.UseFiscalYears();
        }


        private List<SubprojectTimelineProjectStatusChangeEvent> GetTimelineProjectStatusChangeEvents(Subproject subproject, bool canEditSubprojectProjectStatus, bool canEditFinalStatusReport)
        {
            var projectStatusChangeEvents = subproject.SubprojectProjectStatuses
                .Select(x => new SubprojectTimelineProjectStatusChangeEvent(x, canEditSubprojectProjectStatus, canEditFinalStatusReport))
                .OrderByDescending(y => y.SubprojectProjectStatus.SubprojectProjectStatusID)
                .ToList();
            return projectStatusChangeEvents;
        }

        // this hopefully return some sort of grouped list for display
        public List<IGrouping<YearGroup, IGrouping<QuarterGroup, IGrouping<DayGroup, ITimelineEvent>>>> GetGroupedTimelineEvents()
        {
            var startDate = MultiTenantHelpers.GetStartDayOfFiscalYear();
            var startMonth = startDate.Month;
            var timelineEvents = TimelineEvents;
            if (!MultiTenantHelpers.GetTenantAttributeFromCache().EnableStatusUpdates)
            {
                // do not show the right side (Status Update) events
                timelineEvents = timelineEvents.Where(x => x.ProjectTimelineSide != TimelineSide.Right).ToList();
            }
            var timelineEventsGrouped = timelineEvents
                .OrderByDescending(a => a.Date)
                .GroupBy(x => new DayGroup
                {
                    Day = x.Date.Day, 
                    Month = x.Date.Month, 
                    Quarter = x.Quarter, 
                    Year = UsesFiscalYears ? x.Date.GetFiscalYearFromStartMonth((DateUtilities.Month)startMonth) : x.Date.Year
                }).ToList()
                .GroupBy(y => new QuarterGroup{ Quarter = y.Key.Quarter, Year = y.Key.Year }).ToList()
                .GroupBy(z => new YearGroup {Year = z.Key.Year })
                .ToList();

            return timelineEventsGrouped;
        }

        public struct DayGroup
        {
            public int Day;
            public DateUtilities.Quarter Quarter;
            public int Month;
            public int Year;
        }

        public struct QuarterGroup
        {
            public DateUtilities.Quarter Quarter;
            public int Year;
        }

        public struct YearGroup
        {
            public int Year;
        }

        

        public static HtmlString MakeProjectStatusEditLinkButton(SubprojectProjectStatus subprojectProjectStatus, bool canEditProjectStatus, bool canEditFinalStatusReport)
        {
            var editIconAsModalDialogLinkBootstrap = new HtmlString(string.Empty);
            if ((canEditProjectStatus && !subprojectProjectStatus.IsFinalStatusUpdate) || (canEditFinalStatusReport && subprojectProjectStatus.IsFinalStatusUpdate))
            {
                //editIconAsModalDialogLinkBootstrap = DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(
                //    subprojectProjectStatus.GetEditSubprojectProjectStatusUrl()
                //    , $"Add {FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel()} Details:");
            }
            return editIconAsModalDialogLinkBootstrap;
        }
        public static HtmlString MakeProjectStatusDeleteLinkButton(SubprojectProjectStatus subprojectProjectStatus, bool canEditProjectStatus, bool canEditFinalStatusReport)
        {
            var deleteIconAsModalDialogLinkBootstrap = new HtmlString(string.Empty);
            if ((canEditProjectStatus && !subprojectProjectStatus.IsFinalStatusUpdate) || (canEditFinalStatusReport && subprojectProjectStatus.IsFinalStatusUpdate))
            {
                //deleteIconAsModalDialogLinkBootstrap = ModalDialogFormHelper.MakeDeleteLink(
                //    BootstrapHtmlHelpers.MakeGlyphIconWithScreenReaderOnlyText("glyphicon-trash",
                //        "Delete status report").ToString(),
                //    subprojectProjectStatus.GetDeleteSubprojectProjectStatusUrl(), new List<string> { }, true);
            }
            return deleteIconAsModalDialogLinkBootstrap;
        }

        public static HtmlString MakeProjectStatusDetailsLinkButton(SubprojectProjectStatus subprojectProjectStatus)
        {
            var dialogTitle = subprojectProjectStatus.IsFinalStatusUpdate
                ? FieldDefinitionEnum.FinalStatusUpdateStatus.ToType().GetFieldDefinitionLabel()
                : FieldDefinitionEnum.StatusUpdate.ToType().GetFieldDefinitionLabel();

            var detailsLink = ModalDialogFormHelper.ModalDialogFormLinkHiddenSave(
                null,
                "Show Details",
                string.Empty //subprojectProjectStatus.GetSubprojectProjectStatusDetailsUrl()
                , $"{dialogTitle} Details"
                , 900
                ,"Close"
                , new List<string>());
            return detailsLink;
        }

        public static HtmlString MakeProjectUpdateDetailsLinkButton(ProjectUpdateBatch projectUpdateBatch)
        {
            var url = SitkaRoute<ProjectUpdateController>.BuildUrlFromExpression(c => c.ProjectUpdateBatchDiff(projectUpdateBatch));
            var detailsLink = ModalDialogFormHelper.ModalDialogFormLinkHiddenSave(
                "diff-link-id",
                "Show Details",
                url
                , $"{FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()} Update Change Log"
                , 1000
                , "Close"
                , new List<string>());
            return detailsLink;
        }


    }




    public class SubprojectTimelineProjectStatusChangeEvent : ITimelineEvent
    {
        public DateTime Date { get; }
        public string DateDisplay { get; }
        public int? FiscalYear { get; }
        public Quarter Quarter { get; }
        public TimelineEventType ProjectTimelineEventType { get; }
        public string TimelineEventTypeDisplayName { get; }
        public HtmlString TimelineEventPersonDisplayName { get; }
        public string TimelineDetailsLink { get; }
        public TimelineSide ProjectTimelineSide { get; }
        public string Color { get; }
        public HtmlString EditButton { get; }
        public HtmlString DeleteButton { get; }
        public HtmlString ShowDetailsLinkHtmlString { get; }
        public SubprojectProjectStatus SubprojectProjectStatus { get; }
        public List<ActionItem> ActionItems { get; }
        public HtmlString AddActionItemLinkHtmlString { get; }

        public SubprojectTimelineProjectStatusChangeEvent(SubprojectProjectStatus subprojectProjectStatus, bool canEditProjectProjectStatus, bool canEditFinalStatusReport)
        {
            Date = subprojectProjectStatus.SubprojectProjectStatusUpdateDate;
            DateDisplay = Date.ToString("MMM dd, yyyy");
            FiscalYear = FirmaDateUtilities.CalculateFiscalYearForTenant(Date);
            Quarter = (Quarter)FirmaDateUtilities.CalculateQuarterForTenant(Date);
            ProjectTimelineEventType = TimelineEventType.ProjectStatusChange;
            TimelineEventTypeDisplayName = subprojectProjectStatus.IsFinalStatusUpdate ? "Final Status Update" : "Status Updated";
            TimelineEventPersonDisplayName = new HtmlString(subprojectProjectStatus.SubprojectProjectStatusCreatePerson.GetFullNameFirstLast());
            ProjectTimelineSide = TimelineSide.Right;
            EditButton = SubprojectTimeline.MakeProjectStatusEditLinkButton(subprojectProjectStatus, canEditProjectProjectStatus, canEditFinalStatusReport);
            DeleteButton = SubprojectTimeline.MakeProjectStatusDeleteLinkButton(subprojectProjectStatus, canEditProjectProjectStatus, canEditFinalStatusReport);
            Color = subprojectProjectStatus.ProjectStatus.ProjectStatusColor;
            ShowDetailsLinkHtmlString = SubprojectTimeline.MakeProjectStatusDetailsLinkButton(subprojectProjectStatus);
            SubprojectProjectStatus = subprojectProjectStatus;
            //SubprojectActionItems = subprojectProjectStatus.SubprojectActionItems.ToList();
            //AddActionItemLinkHtmlString = ModalDialogFormHelper.ModalDialogFormLink(string.Format("<span class='glyphicon glyphicon-plus' style='margin-right: 3px'></span>Add {0}", FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()), SitkaRoute<ActionItemController>.BuildUrlFromExpression(c => c.NewForSubprojectStatus(subprojectProjectStatus.Subproject, subprojectProjectStatus)), string.Format("Add New {0}", FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()), 700, "Add", "Cancel", new List<string> { }, null, null);
        }
    }



}