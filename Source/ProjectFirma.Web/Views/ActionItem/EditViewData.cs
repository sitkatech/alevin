/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.ActionItem
{
    public class EditViewData : FirmaViewData
    {
        public ViewPageContentViewData PageContentViewData { get; }
        public IEnumerable<SelectListItem> ProjectProjectStatusSelectListItems { get; }
        public IEnumerable<SelectListItem> PeopleSelectListItems { get; }
        public HtmlString DeleteButton { get; }

        public EditViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, IEnumerable<SelectListItem> peopleSelectListItems, IEnumerable<SelectListItem> projectProjectStatusSelectListItems, string deleteUrl) : base(currentFirmaSession, firmaPage)
        {
            PageContentViewData = new ViewPageContentViewData(firmaPage, true);
            ProjectProjectStatusSelectListItems = projectProjectStatusSelectListItems;
            PeopleSelectListItems = peopleSelectListItems;
            DeleteButton = string.IsNullOrEmpty(deleteUrl) ? new HtmlString(string.Empty) : ModalDialogFormHelper.MakeDeleteIconButton(deleteUrl, $"Delete {FieldDefinitionEnum.ActionItem.ToType().GetFieldDefinitionLabel()}", true);
        }
    }
}
