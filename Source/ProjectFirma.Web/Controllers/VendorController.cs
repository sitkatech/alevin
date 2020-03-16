/*-----------------------------------------------------------------------
<copyright file="OrganizationController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common.Models;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Detail = ProjectFirma.Web.Views.Organization.Detail;
using DetailViewData = ProjectFirma.Web.Views.Organization.DetailViewData;
using Index = ProjectFirma.Web.Views.Organization.Index;
using IndexGridSpec = ProjectFirma.Web.Views.Organization.IndexGridSpec;
using IndexViewData = ProjectFirma.Web.Views.Organization.IndexViewData;
using Organization = ProjectFirmaModels.Models.Organization;

namespace ProjectFirma.Web.Controllers
{
    /// <summary>
    /// UNDER CONSTRUCTION - DOES NOT WORK YET. Copied from Organization...
    /// </summary>
    public class VendorController : FirmaBaseController
    {
        [OrganizationViewFeature]
        public ViewResult Index()
        {
            var firmaPage = FirmaPageTypeEnum.OrganizationsList.GetFirmaPage();
            var hasManageOrganizationPermission = new OrganizationManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridDataUrl = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.IndexGridJsonData(IndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations));
            var activeOrAllOrganizationsSelectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "Active Organizations Only", Value = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.IndexGridJsonData(IndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations))},
                new SelectListItem() {Text = "All Organizations", Value = SitkaRoute<OrganizationController>.BuildUrlFromExpression(x => x.IndexGridJsonData(IndexGridSpec.OrganizationStatusFilterTypeEnum.AllOrganizations))}
            };

            var viewData = new IndexViewData(CurrentFirmaSession, firmaPage, gridDataUrl, activeOrAllOrganizationsSelectListItems, hasManageOrganizationPermission);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [OrganizationViewFeature]
        public GridJsonNetJObjectResult<Organization> IndexGridJsonData(IndexGridSpec.OrganizationStatusFilterTypeEnum organizationStatusFilterType)
        {
            var hasDeleteOrganizationPermission = new OrganizationManageFeature().HasPermissionByFirmaSession(CurrentFirmaSession);
            var gridSpec = new IndexGridSpec(CurrentFirmaSession, hasDeleteOrganizationPermission);
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList();

            switch (organizationStatusFilterType)
            {
                case IndexGridSpec.OrganizationStatusFilterTypeEnum.ActiveOrganizations:
                    organizations = organizations.Where(x => x.IsActive).ToList();
                    break;
                case IndexGridSpec.OrganizationStatusFilterTypeEnum.AllOrganizations:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("organizationStatusFilterType", organizationStatusFilterType,
                        null);
            }

            var gridJsonNetJObjectResult = new GridJsonNetJObjectResult<Organization>(organizations.OrderBy(x => x.GetDisplayName()).ToList(), gridSpec);
            return gridJsonNetJObjectResult;
        }


        //[OrganizationViewFeature]
        //public ViewResult Detail(OrganizationPrimaryKey organizationPrimaryKey)
        //{
        //    var organization = organizationPrimaryKey.EntityObject;
        //    var expendituresDirectlyFromOrganizationViewGoogleChartViewData = GetCalendarYearExpendituresFromOrganizationFundingSourcesLineChartViewData(organization);
        //    var expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData = GetCalendarYearExpendituresFromProjectFundingSourcesLineChartViewData(organization, CurrentFirmaSession);

        //    var mapInitJson = GetMapInitJson(organization, out var hasSpatialData, CurrentPerson);

        //    var performanceMeasures = organization.GetAllActiveProjectsAndProposals(CurrentPerson).ToList()
        //        .SelectMany(x => x.PerformanceMeasureActuals)
        //        .Select(x => x.PerformanceMeasure).Distinct(new HavePrimaryKeyComparer<PerformanceMeasure>())
        //        .OrderBy(x => x.PerformanceMeasureDisplayName)
        //        .ToList();

        //    var viewData = new DetailViewData(CurrentFirmaSession, organization, mapInitJson, hasSpatialData, performanceMeasures, expendituresDirectlyFromOrganizationViewGoogleChartViewData, expendituresReceivedFromOtherOrganizationsViewGoogleChartViewData);
        //    return RazorView<Detail, DetailViewData>(viewData);
        //}


    }
}
