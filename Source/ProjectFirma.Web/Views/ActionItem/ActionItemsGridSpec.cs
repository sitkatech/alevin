/*-----------------------------------------------------------------------
<copyright file="ProjectUpdateBatchGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Views;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ActionItem
{
    public class ActionItemsGridSpec : GridSpec<ProjectFirmaModels.Models.ActionItem>
    {
        public ActionItemsGridSpec()
        {
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsModalDialogLinkBootstrap(new ModalDialogForm(x.GetEditUrl(), ModalDialogFormHelper.DefaultDialogWidth, "Edit Status")), 30, DhtmlxGridColumnFilterType.None);
            Add($"{FieldDefinitionEnum.ActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemText, 200, DhtmlxGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ActionItemAssignedToPerson.ToType().GetFieldDefinitionLabel()}", x => x.AssignedToPerson.GetFullNameFirstLast(), 150, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.ActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 120, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.ActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"Related {FieldDefinitionEnum.ProjectStatus.ToType().GetFieldDefinitionLabel()}", x => x.ProjectProjectStatus?.GetDropdownDisplayName() ?? "", 200, DhtmlxGridColumnFilterType.Text);
        }
    }
}
