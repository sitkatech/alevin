﻿/*-----------------------------------------------------------------------
<copyright file="EditViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.SubprojectActionItem
{
    public class EditViewData : FirmaViewData
    {
        public ViewPageContentViewData PageContentViewData { get; }
        public IEnumerable<SelectListItem> SubprojectProjectStatusSelectListItems { get; }
        public IEnumerable<SelectListItem> PeopleSelectListItems { get; }

        public EditViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage, IEnumerable<SelectListItem> peopleSelectListItems, IEnumerable<SelectListItem> subprojectProjectStatusSelectListItems) : base(currentFirmaSession, firmaPage)
        {
            PageContentViewData = new ViewPageContentViewData(firmaPage, true);
            SubprojectProjectStatusSelectListItems = subprojectProjectStatusSelectListItems;
            PeopleSelectListItems = peopleSelectListItems;
        }
    }
}