﻿/*-----------------------------------------------------------------------
<copyright file="EditAttachmentTypeViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using System.Linq;
using System.Web.Mvc;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.AttachmentType
{
    public class EditAttachmentTypeViewData : FirmaUserControlViewData
    {
        public List<FileResourceMimeType> AllFileResourceMimeTypes { get; }
        public List<TaxonomyTrunkSimple> AllTaxonomyTrunks { get; }
        public bool HasTaxonomyTrunks { get; }
        public List<SelectListItem> MaxFileSizes { get; }

        public EditAttachmentTypeViewData(List<FileResourceMimeType> fileResourceMimeTypes, List<ProjectFirmaModels.Models.TaxonomyTrunk> allTaxonomyTrunks, bool hasTaxonomyTrunks)
        {
            AllFileResourceMimeTypes = fileResourceMimeTypes;
            AllTaxonomyTrunks = allTaxonomyTrunks.Select(x => new TaxonomyTrunkSimple(x)).ToList();
            // 8/7/2019 TK - AttachmentTypeTaxonomyTrunk is configured to only be FK'ed to the TaxonomyTrunk table.
            // If we want to support clients applying attachment types to branches or leaves, we will need to add FK's to those tables as well.
            // Then update the AttachmentTypeTaxonomyTrunk class to return the correct list of taxonomy objects based on the clients set taxonomy level.
            HasTaxonomyTrunks = hasTaxonomyTrunks;
            MaxFileSizes = new List<SelectListItem>();
            for (var i = 10; i <= 50; i += 10)
            {
                SelectListItem thisSelectListItem = new SelectListItem()
                {
                    Text = $"≤ {i}MB",
                    Value = (i * 1024 * 1000).ToString() // calculate byte value based on displayed MB
                };
                MaxFileSizes.Add(thisSelectListItem);
            }
        }
    }
}
