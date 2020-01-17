/*-----------------------------------------------------------------------
<copyright file="BasicProjectInfoGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.AgreementRequest
{
    public class CostAuthorityAgreementRequestGridSpec : GridSpec<ProjectFirmaModels.Models.ReclamationCostAuthorityAgreementRequest>
    {
        public CostAuthorityAgreementRequestGridSpec(FirmaSession currentFirmaSession)
        {
            //var userHasTagManagePermissions = new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession);
            //if (userHasTagManagePermissions && allowTaggingFunctionality)
            //{
            //    BulkTagModalDialogForm = new BulkTagModalDialogForm(SitkaRoute<TagController>.BuildUrlFromExpression(x => x.BulkTagProjects(null)), $"Tag Checked {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", $"Tag {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}");
            //    AddCheckBoxColumn();
            //    Add("ProjectID", x => x.ProjectID, 0);
            //}

            //Add(string.Empty, x => UrlTemplate.MakeHrefString(x.GetFactSheetUrl(), FirmaDhtmlxGridHtmlHelpers.FactSheetIcon.ToString()), 30, DhtmlxGridColumnFilterType.None);
            //Add(FieldDefinitionEnum.ProjectName.ToType().ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            //if (MultiTenantHelpers.HasCanStewardProjectsOrganizationRelationship())
            //{
            //    Add(FieldDefinitionEnum.ProjectsStewardOrganizationRelationshipToProject.ToType().ToGridHeaderString(), x => x.GetCanStewardProjectsOrganization().GetShortNameAsUrl(), 150,
            //        DhtmlxGridColumnFilterType.Html);
            //}
            Add(FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().ToGridHeaderString("CAWBS"), x => x.CostAuthority.CostAuthorityWorkBreakdownStructure, 150, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.AccountStructureDescription.ToType().ToGridHeaderString(), x => x.CostAuthority.AccountStructureDescription, 300, DhtmlxGridColumnFilterType.Html);
            Add(FieldDefinitionEnum.ProjectedObligation.ToType().ToGridHeaderString(), x => x.ProjectedObligation, 150, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(FieldDefinitionEnum.CostAuthorityAgreementRequestNote.ToType().ToGridHeaderString("Notes"), x => x.ReclamationCostAuthorityAgreementRequestNote, 150, DhtmlxGridColumnFilterType.Text);
            
        }
    }
}
