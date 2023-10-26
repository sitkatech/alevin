/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatchGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using LtInfo.Common.AgGridWrappers;
using ProjectFirmaModels.Models;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ActionItem
{
    public class ActionItemsAdminGridSpec : GridSpec<ProjectFirmaModels.Models.ActionItem>
    {
        public int IndexOfActionItemStateColumn = 7;
        public ActionItemsAdminGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => x.CreateNotificationMailToLink(), 30, AgGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.ActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemText, 200, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", x => x.Project.GetDisplayNameAsUrl(), 150, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ActionItemAssignedToPerson.ToType().GetFieldDefinitionLabel()}", x => x.AssignedToPerson.GetFullNameFirstLastAsUrl(currentFirmaSession), 150, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"{FieldDefinitionEnum.ActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.ActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()}", x => x.ProjectProjectStatus?.GetDropdownDisplayName() ?? "", 200, AgGridColumnFilterType.Text);
        }
    }

    public class ActionItemsUserGridSpec : GridSpec<ProjectFirmaModels.Models.ActionItem>
    {
        public ActionItemsUserGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), new ActionItemManageFeature().HasPermission(currentFirmaSession, x).HasPermission), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditUrl(), $"Edit {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()}", new ActionItemManageFeature().HasPermission(currentFirmaSession, x).HasPermission), 30, AgGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.ActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemText, 200, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", x => x.Project.GetDisplayNameAsUrl(), 200, AgGridColumnFilterType.Html);
            Add($"{FieldDefinitionEnum.ActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.ActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()}", x => x.ProjectProjectStatus?.GetDropdownDisplayName() ?? "", 200, AgGridColumnFilterType.Text);
        }
    }

    public class ActionItemsGridSpec : GridSpec<ProjectFirmaModels.Models.ActionItem>
    {
        public ActionItemsGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, AgGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.ActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemText, 200, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ActionItemAssignedToPerson.ToType().GetFieldDefinitionLabel()}", x => x.AssignedToPerson.GetFullNameFirstLastAsUrl(currentFirmaSession), 150, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"{FieldDefinitionEnum.ActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.ActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()}", x => x.ProjectProjectStatus?.GetDropdownDisplayName() ?? "", 200, AgGridColumnFilterType.Text);
        }
    }

}
