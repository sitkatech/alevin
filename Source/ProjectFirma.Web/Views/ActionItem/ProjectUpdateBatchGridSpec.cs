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
using System;
using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.ActionItem
{
    public class ActionItemsGridSpec : GridSpec<ProjectFirmaModels.Models.ActionItem>
    {
        public ActionItemsGridSpec()
        {
            Add($"{FieldDefinitionEnum.ActionItemAssignedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.AssignedOnDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemDueByDate.ToType().GetFieldDefinitionLabel()}", x => x.DueByDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemCompletedOnDate.ToType().GetFieldDefinitionLabel()}", x => x.CompletedOnDate, 120);
            Add($"{FieldDefinitionEnum.ActionItemState.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemState.ActionItemStateDisplayName, 170, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add($"{FieldDefinitionEnum.ActionItemAssignedToPerson.ToType().GetFieldDefinitionLabel()}", x => x.AssignedToPerson.GetFullNameFirstLast(), 170, DhtmlxGridColumnFilterType.Text);
            Add($"{FieldDefinitionEnum.ActionItemText.ToType().GetFieldDefinitionLabel()}", x => x.ActionItemText, 170, DhtmlxGridColumnFilterType.Text);
        }
    }
}
