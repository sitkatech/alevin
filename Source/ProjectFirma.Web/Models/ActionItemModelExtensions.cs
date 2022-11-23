using System;
using System.Text;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using System.Web;

namespace ProjectFirma.Web.Models
{
    public static class ActionItemModelExtensions
    {
        public static string GetDeleteUrl(this ActionItem actionItem)
        {
            return SitkaRoute<ActionItemController>.BuildUrlFromExpression(c => c.Delete(actionItem.ActionItemID));
        }

        public static string GetEditUrl(this ActionItem actionItem)
        {
            return SitkaRoute<ActionItemController>.BuildUrlFromExpression(c => c.Edit(actionItem.ActionItemID));
        }

        public static HtmlString GetDisplayHeaderHtmlString(this ActionItem actionItem, bool userHasEditPermissions)
        {
            var editButtonString = actionItem.GetEditButtonHtmlString(userHasEditPermissions);
            var returnString = $"{editButtonString} {actionItem.ActionItemText.Truncate(75, "...")}".Trim();
            return new HtmlString(returnString);
        }

        public static HtmlString GetDisplayFooterHtmlString(this ActionItem actionItem)
        {
            return new HtmlString($"{actionItem.GetStatusWithIconHtmlString()} {actionItem.GetAssignedToPersonWithIconHtmlString()} {actionItem.GetDueDateWithIconHtmlString()}");
        }

        public static HtmlString GetAssignedToPersonWithIconHtmlString(this ActionItem actionItem)
        {
            return new HtmlString($"<span title=\"{FieldDefinitionEnum.ActionItemAssignedToPerson.ToType().FieldDefinitionDisplayName}\"><span class=\"glyphicon glyphicon-user\" aria-hidden=\"true\"></span> {actionItem.AssignedToPerson.GetFullNameFirstLast()}</span>");
        }

        public static HtmlString GetDueDateWithIconHtmlString(this ActionItem actionItem)
        {
            return new HtmlString($"<span title=\"{FieldDefinitionEnum.ActionItemDueByDate.ToType().FieldDefinitionDisplayName}\"><span class=\"glyphicon glyphicon-calendar\" aria-hidden=\"true\"></span> {actionItem.DueByDate.ToShortDateString()}</span>");
        }

        public static HtmlString GetEditButtonHtmlString(this ActionItem actionItem, bool userHasEditPermissions)
        {
            var buttonString = userHasEditPermissions 
                ? $"{DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(actionItem.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, $"Edit {FieldDefinitionEnum.ActionItem.ToType().FieldDefinitionDisplayName}"))}" 
                : string.Empty;
            return new HtmlString(buttonString);
        }

        public static HtmlString GetStatusWithIconHtmlString(this ActionItem actionItem)
        {
            var glyphiconClass = actionItem.ActionItemState.ToEnum == ActionItemStateEnum.Complete
                ? "glyphicon-ok text-success"
                : "glyphicon-remove text-danger";
            return new HtmlString($"<span title=\"{FieldDefinitionEnum.ActionItemState.ToType().FieldDefinitionDisplayName}\"><span class=\"glyphicon {glyphiconClass}\" aria-hidden=\"true\"></span> {actionItem.ActionItemState.ActionItemStateDisplayName}</span>");
        }

        public static HtmlString CreateNotificationMailToLink(this ActionItem actionItem)
        {
            var subjectText = HttpUtility.UrlPathEncode($"Action required on: {actionItem.Project.ProjectName}");
            var mailTo = HttpUtility.UrlPathEncode(actionItem.AssignedToPerson.Email);
            var body = $"Hi {actionItem.AssignedToPerson.GetFullNameFirstLast()}, \r\n\r\n";
            body += $"{actionItem.ActionItemText}\r\n";
            body += $"Due by Date: {actionItem.DueByDate.ToShortDateString()}\r\n\r\n";
            var projectDetailLink = SitkaRoute<ProjectController>.BuildAbsoluteUrlFromExpression(x => x.Detail(actionItem.Project.PrimaryKey));
            body += $"Project: {actionItem.Project.ProjectName}\r\n";
            body += $"Link to Project: {projectDetailLink}\r\n\r\n";
            body += $"Action Item State: {actionItem.ActionItemState.ActionItemStateDisplayName}\r\n";
            body += $"Assigned On Date: {actionItem.AssignedOnDate.ToShortDateString()}\r\n";
            body += $"Related Habitat Coordination Call Update: {actionItem.ProjectProjectStatus.GetDropdownDisplayName()}\r\n\r\n";
            body += $"Thank You, \r\n\r\n";
            var mailToLink = new HtmlString($"<a href=\"mailto:{mailTo}?subject={subjectText}&body={HttpUtility.UrlPathEncode(body)}\">{DhtmlxGridHtmlHelpers.EmailIconBootstrap}</a>");

            return mailToLink;
        }

    }
}