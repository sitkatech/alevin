﻿/*-----------------------------------------------------------------------
<copyright file="IndexViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyLeaf
{
    public class IndexViewData : FirmaViewData
    {
        public IndexGridSpec GridSpec { get; }
        public string GridName { get; }
        public string GridDataUrl { get; }
        public string EditSortOrderUrl { get; }
        public string EditSortOrderInGroupUrl { get; }
        public bool OfferEditSortOrder { get; }
        public bool OfferEditSortOrderInGroup { get; }
        public bool HasTaxonomyLeafManagePermissions { get; }
        public string NewUrl { get; }
        public string TaxonomyLeafDisplayName { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            var taxonomyLeafDisplayNamePluralized = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabelPluralized();
            PageTitle = taxonomyLeafDisplayNamePluralized;

            // if leaf is the highest level, let them sort without groups
            OfferEditSortOrder = MultiTenantHelpers.IsTaxonomyLevelLeaf();
            // if it is a two or three tier taxonomy, let them sort grouped by taxonomy branches
            OfferEditSortOrderInGroup = !MultiTenantHelpers.IsTaxonomyLevelLeaf();

            var hasTaxonomyLeafManagePermissions = new TaxonomyLeafManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            var taxonomyLeafDisplayName = FieldDefinitionEnum.TaxonomyLeaf.ToType().GetFieldDefinitionLabel();
            GridSpec = new IndexGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = taxonomyLeafDisplayName,
                ObjectNamePlural = taxonomyLeafDisplayNamePluralized,
                SaveFiltersInCookie = true
            };

            GridName = "taxonomyLeafsGrid";
            GridDataUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            EditSortOrderUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(tc => tc.EditSortOrder());
            EditSortOrderInGroupUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(tc => tc.EditSortOrderInGroup());
            HasTaxonomyLeafManagePermissions = hasTaxonomyLeafManagePermissions;
            NewUrl = SitkaRoute<TaxonomyLeafController>.BuildUrlFromExpression(t => t.New());
            TaxonomyLeafDisplayName = taxonomyLeafDisplayName;
        }
    }
}
