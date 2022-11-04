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

using System.Linq;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.TaxonomyBranch
{
    public class IndexViewData : FirmaViewData
    {        
        public IndexGridSpec GridSpec{ get; }
        public string GridName{ get; }
        public string GridDataUrl{ get; }
        public string EditSortOrderUrl { get; }
        public string EditSortOrderInGroupUrl { get; }
        public bool OfferEditSortOrder { get; }
        public bool OfferEditSortOrderInGroup { get; }
        public bool HasTaxonomyBranchManagePermissions { get; }
        public string NewUrl { get; }
        public string TaxonomyBranchDisplayName { get; }
        public bool IsNotTaxonomyLevelLeaf { get; }

        public IndexViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage firmaPage) : base(currentFirmaSession, firmaPage)
        {
            var taxonomyBranchDisplayNamePluralized = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabelPluralized();
            PageTitle = taxonomyBranchDisplayNamePluralized;

            // if branch is the highest level, let them sort without groups
            OfferEditSortOrder = MultiTenantHelpers.IsTaxonomyLevelBranch();
            // if it is a three tier taxonomy, let them sort grouped by taxonomy trunks
            OfferEditSortOrderInGroup = MultiTenantHelpers.IsTaxonomyLevelTrunk();

            HasTaxonomyBranchManagePermissions = new TaxonomyBranchManageFeature().HasPermissionByFirmaSession(currentFirmaSession);
            IsNotTaxonomyLevelLeaf = !MultiTenantHelpers.IsTaxonomyLevelLeaf();

            var taxonomyBranchDisplayName = FieldDefinitionEnum.TaxonomyBranch.ToType().GetFieldDefinitionLabel();
            GridSpec = new IndexGridSpec(currentFirmaSession)
            {
                ObjectNameSingular = taxonomyBranchDisplayName,
                ObjectNamePlural = taxonomyBranchDisplayNamePluralized,
                SaveFiltersInCookie = true
            };

            GridName = "taxonomyBranchesGrid";
            GridDataUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());
            NewUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(t => t.New());
            EditSortOrderUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.EditSortOrder());
            EditSortOrderInGroupUrl = SitkaRoute<TaxonomyBranchController>.BuildUrlFromExpression(tc => tc.EditSortOrderInGroup());
            TaxonomyBranchDisplayName = taxonomyBranchDisplayName;
        }
    }
}
