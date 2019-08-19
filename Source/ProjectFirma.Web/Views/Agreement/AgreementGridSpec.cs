/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureGridSpec.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirmaModels.Models;


namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementGridSpec : GridSpec<ProjectFirmaModels.Models.ReclamationAgreement>
    {
        public AgreementGridSpec(Person currentPerson)
        {
            //var hasDeletePermission = new AgreementManageFeature().HasPermissionByPerson(currentPerson);
            //if (hasDeletePermission)
            //{
            //    //Add(string.Empty, x => x.AgreementDataSourceType.IsCustomCalculation ? new HtmlString("") : DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true), 30, DhtmlxGridColumnFilterType.None);
            //}

            /*
            Add(FieldDefinitionEnum.Agreement.ToType().ToGridHeaderString(MultiTenantHelpers.GetAgreementName()),
                a => UrlTemplate.MakeHrefString(a.GetSummaryUrl(), a.AgreementDisplayName),
                300,
                DhtmlxGridColumnFilterType.Text);
            Add(FieldDefinitionEnum.MeasurementUnit.ToType().ToGridHeaderString("Unit"), a => a.MeasurementUnitType.LegendDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add(FieldDefinitionEnum.AgreementType.ToType().ToGridHeaderString("Type"), a => a.AgreementType.AgreementTypeDisplayName, 60, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Description", a => a.AgreementDefinition, 400, DhtmlxGridColumnFilterType.Html);
            Add($"# of {FieldDefinitionEnum.AgreementSubcategory.ToType().GetFieldDefinitionLabelPluralized()}", a => a.GetRealSubcategoryCount(), 110);
            */

            // AgreementNumber
            Add(FieldDefinitionEnum.AgreementNumber.ToType().ToGridHeaderString(), a => a.AgreementNumber, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            // Organization info
            Add(FieldDefinitionEnum.Organization.ToType().ToGridHeaderString(), a => UrlTemplate.MakeHrefString(a.Organization.GetDetailUrl(), a.Organization.GetDisplayName()), 300);
            Add(FieldDefinitionEnum.OrganizationType.ToType().ToGridHeaderString(), a => a.Organization.OrganizationType?.OrganizationTypeName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            // Contract Type
            Add(FieldDefinitionEnum.ContractType.ToType().ToGridHeaderString(), a => a.ContractType.ContractTypeDisplayName, 80, DhtmlxGridColumnFilterType.SelectFilterStrict);


            Add($"# of {FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabelPluralized()}", a => a.ReclamationAgreementReclamationCostAuthorities.Count, 80);
            

            

        }
    }
}