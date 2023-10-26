using System.Web;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SubprojectActionItemModelExtensions
    {
        public static string GetDeleteUrl(this SubprojectActionItem actionItem)
        {
            return SitkaRoute<SubprojectActionItemController>.BuildUrlFromExpression(c => c.Delete(actionItem.SubprojectActionItemID));
        }

        public static string GetEditUrl(this SubprojectActionItem actionItem)
        {
            return SitkaRoute<SubprojectActionItemController>.BuildUrlFromExpression(c => c.Edit(actionItem.SubprojectActionItemID));
        }

        public static HtmlString GetDisplayHeaderHtmlString(this SubprojectActionItem actionItem, bool userHasEditPermissions)
        {
            var editButtonString = actionItem.GetEditButtonHtmlString(userHasEditPermissions);
            var returnString = $"{editButtonString} {actionItem.SubprojectActionItemText.Truncate(75, "...")}".Trim();
            return new HtmlString(returnString);
        }

        public static HtmlString GetDisplayFooterHtmlString(this SubprojectActionItem actionItem)
        {
            return new HtmlString($"{actionItem.GetStatusWithIconHtmlString()} {actionItem.GetAssignedToPersonWithIconHtmlString()} {actionItem.GetDueDateWithIconHtmlString()}");
        }

        public static HtmlString GetAssignedToPersonWithIconHtmlString(this SubprojectActionItem actionItem)
        {
            return new HtmlString($"<span title=\"{FieldDefinitionEnum.SubprojectActionItemAssignedToPerson.ToType().FieldDefinitionDisplayName}\"><span class=\"glyphicon glyphicon-user\" aria-hidden=\"true\"></span> {actionItem.AssignedToPerson.GetFullNameFirstLast()}</span>");
        }

        public static HtmlString GetDueDateWithIconHtmlString(this SubprojectActionItem actionItem)
        {
            return new HtmlString($"<span title=\"{FieldDefinitionEnum.SubprojectActionItemDueByDate.ToType().FieldDefinitionDisplayName}\"><span class=\"glyphicon glyphicon-calendar\" aria-hidden=\"true\"></span> {actionItem.DueByDate.ToShortDateString()}</span>");
        }

        public static HtmlString GetEditButtonHtmlString(this SubprojectActionItem actionItem, bool userHasEditPermissions)
        {
            var buttonString = userHasEditPermissions 
                ? $"{AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(actionItem.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, $"Edit {FieldDefinitionEnum.SubprojectActionItem.ToType().FieldDefinitionDisplayName}"))}" 
                : string.Empty;
            return new HtmlString(buttonString);
        }

        public static HtmlString GetStatusWithIconHtmlString(this SubprojectActionItem actionItem)
        {
            var glyphiconClass = actionItem.ActionItemState.ToEnum == ActionItemStateEnum.Complete
                ? "glyphicon-ok text-success"
                : "glyphicon-remove text-danger";
            return new HtmlString($"<span title=\"{FieldDefinitionEnum.ActionItemState.ToType().FieldDefinitionDisplayName}\"><span class=\"glyphicon {glyphiconClass}\" aria-hidden=\"true\"></span> {actionItem.ActionItemState.ActionItemStateDisplayName}</span>");
        }

        public static HtmlString CreateNotificationMailToLink(this SubprojectActionItem actionItem)
        {
            var subjectText = HttpUtility.UrlPathEncode($"Action required on: {actionItem.Subproject.SubprojectName}");
            var mailTo = HttpUtility.UrlPathEncode(actionItem.AssignedToPerson.Email);
            var body = $"Hi {actionItem.AssignedToPerson.GetFullNameFirstLast()}, \r\n\r\n";
            body += $"{actionItem.SubprojectActionItemText}\r\n";
            body += $"Due by Date: {actionItem.DueByDate.ToShortDateString()}\r\n\r\n";
            var projectDetailLink = SitkaRoute<SubprojectController>.BuildAbsoluteUrlFromExpression(x => x.Detail(actionItem.Subproject.PrimaryKey));
            body += $"Subproject: {actionItem.Subproject.SubprojectName}\r\n";
            body += $"Link to Project: {projectDetailLink}\r\n\r\n";
            body += $"Action Item State: {actionItem.ActionItemState.ActionItemStateDisplayName}\r\n";
            body += $"Assigned On Date: {actionItem.AssignedOnDate.ToShortDateString()}\r\n";
            body += $"Related Habitat Coordination Call Update: {actionItem.SubprojectProjectStatus.GetDropdownDisplayName()}\r\n\r\n";
            body += $"Thank You, \r\n\r\n";
            var mailToLink = new HtmlString($"<a href=\"mailto:{mailTo}?subject={subjectText}&body={HttpUtility.UrlPathEncode(body)}\">{AgGridHtmlHelpers.EmailIconBootstrap}</a>");

            return mailToLink;
        }

    }
}