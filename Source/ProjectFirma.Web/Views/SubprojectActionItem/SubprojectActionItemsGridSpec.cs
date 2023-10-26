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

using ProjectFirmaModels.Models;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.SubprojectActionItem
{
    public class SubprojectActionItemsAdminGridSpec : GridSpec<ProjectFirmaModels.Models.SubprojectActionItem>
    {
        public int IndexOfActionItemStateColumn = 7;
        public SubprojectActionItemsAdminGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => x.CreateNotificationMailToLink(), 30, AgGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.SubprojectActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.SubprojectActionItemText, 200, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()}", x => x.Subproject.GetDisplayNameAsUrl(), 150, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.SubprojectActionItemAssignedToPerson.ToType().GetFieldDefinitionLabel()}", x => x.AssignedToPerson.GetFullNameFirstLastAsUrl(currentFirmaSession), 150, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"{FieldDefinitionEnum.SubprojectActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.SubprojectActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.SubprojectActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.SubprojectActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()}", x => x.SubprojectProjectStatus?.GetDropdownDisplayName() ?? "", 200, AgGridColumnFilterType.Text);
        }
    }

    public class SubprojectActionItemsUserGridSpec : GridSpec<ProjectFirmaModels.Models.SubprojectActionItem>
    {
        public SubprojectActionItemsUserGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), new SubprojectActionItemManageFeature().HasPermissionByFirmaSession(currentFirmaSession)), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(x.GetEditUrl(), $"Edit {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()}", true, new SubprojectActionItemManageFeature().HasPermissionByFirmaSession(currentFirmaSession)), 30, AgGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.SubprojectActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.SubprojectActionItemText, 200, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.Subproject.ToType().GetFieldDefinitionLabel()}", x => x.Subproject.GetDisplayNameAsUrl(), 200, AgGridColumnFilterType.Html);
            Add($"{FieldDefinitionEnum.SubprojectActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.SubprojectActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.SubprojectActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.SubprojectActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()}", x => x.SubprojectProjectStatus?.GetDropdownDisplayName() ?? "", 200, AgGridColumnFilterType.Text);
        }
    }

    public class SubprojectActionItemsGridSpec : GridSpec<ProjectFirmaModels.Models.SubprojectActionItem>
    {
        public SubprojectActionItemsGridSpec(FirmaSession currentFirmaSession)
        {
            Add(string.Empty, x => AgGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, AgGridColumnFilterType.None);
            Add(string.Empty, x => AgGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, AgGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.SubprojectActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.SubprojectActionItemText, 200, AgGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.SubprojectActionItemAssignedToPerson.ToType().GetFieldDefinitionLabel()}", x => x.AssignedToPerson.GetFullNameFirstLastAsUrl(currentFirmaSession), 150, AgGridColumnFilterType.SelectFilterHtmlStrict);
            Add($"{FieldDefinitionEnum.SubprojectActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, AgGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.SubprojectActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.SubprojectActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.SubprojectActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.Status.ToType().GetFieldDefinitionLabel()}", x => x.SubprojectProjectStatus?.GetDropdownDisplayName() ?? "", 200, AgGridColumnFilterType.Text);
        }
    }

}
