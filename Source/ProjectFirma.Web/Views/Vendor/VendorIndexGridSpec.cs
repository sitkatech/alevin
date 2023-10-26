﻿/*-----------------------------------------------------------------------
<copyright file="IndexGridSpec.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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

using System.Web;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.AgGridWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Vendor
{
    public class VendorIndexGridSpec : GridSpec<ProjectFirmaModels.Models.Vendor>
    {
        public VendorIndexGridSpec(FirmaSession currentFirmaSession)
        {
            Add(FieldDefinitionEnum.Vendor.ToType().ToGridHeaderString(), MakeVendorDetailHrefString, 400, AgGridColumnFilterType.Html);
            //Add("Vendor Name", v => v.VendorText, 100);
            //Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), a => a.OrganizationType?.OrganizationTypeName, 100, AgGridColumnFilterType.SelectFilterStrict);
            //Add(FieldDefinitionEnum.OrganizationPrimaryContact.ToType().ToGridHeaderString(), a => userViewFeature.HasPermission(currentFirmaSession, a.PrimaryContactPerson).HasPermission ? a.GetPrimaryContactPersonAsUrl() : new HtmlString(a.GetPrimaryContactPersonAsString()), 120);
            //Add($"# of {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", a => a.GetAllActiveProjects(currentFirmaSession.Person).Count, 90);
            //if (currentFirmaSession.Person.CanViewProposals())
            //{
            //    Add($"# of {FieldDefinitionEnum.Proposal.ToType().GetFieldDefinitionLabelPluralized()} associated with this {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()}", a => a.GetProposalsVisibleToUser(currentFirmaSession).Count, 90);
            //}
            //Add($"# of {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabelPluralized()}", a => a.FundingSources.Count, 90);
            //Add("# of Users", a => a.People.Count, 90);
            //Add("Is Active", a => a.IsActive.ToYesNo(), 80, AgGridColumnFilterType.SelectFilterStrict);
            //Add("Has Spatial Boundary", x => (x.OrganizationBoundary != null).ToCheckboxImageOrEmpty(), 70);
        }

        private static HtmlString MakeVendorDetailHrefString(ProjectFirmaModels.Models.Vendor vendor)
        {
            string vendorDetailUrl = vendor.GetDetailUrl();
            return UrlTemplate.MakeHrefString(vendorDetailUrl, vendor.VendorText);
        }
    }
}
