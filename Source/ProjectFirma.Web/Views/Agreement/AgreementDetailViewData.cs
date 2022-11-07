/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
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
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.Agreement Agreement { get; }

        public bool IsAdmin { get; }

        public string EditAgreementBasicsUrl { get; }

        public string IndexUrl { get; }
        public string CostAuthorityIndexUrl { get; }

        public bool UserHasAgreementManagePermissions { get; }

        public string BasicProjectInfoProjectGridName { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoProjectGridDataUrl { get; }

        public string BasicCostAuthorityGridName { get; }
        public BasicCostAuthorityGridSpec BasicCostAuthorityGridSpec { get; }
        public string BasicCostAuthorityGridDataUrl { get; }

        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForAgreement { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostAuthorityWorkBreakdownStructure { get; }

        public AgreementDetailViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.Agreement agreement) : base(currentFirmaSession)
        {
            PageTitle = $"Agreement Number: {agreement.AgreementNumber}";
            EntityName = "Agreement Detail";

            Agreement = agreement;
            UserHasAgreementManagePermissions = new AgreementManageFeature().HasPermissionByPerson(CurrentPerson);
            IsAdmin = new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson);

            EditAgreementBasicsUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.EditBasics(agreement));

            /*
            EditPerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            EditSubcategoriesAndOptionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditSubcategoriesAndOptions(performanceMeasure));
                
            EditCriticalDefinitionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions));
            EditProjectReportingUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting));
            */

            IndexUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.AgreementIndex());
            CostAuthorityIndexUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.CostAuthorityIndex());

            FieldDefinitionForAgreement = FieldDefinitionEnum.Agreement.ToType();
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            FieldDefinitionForCostAuthorityWorkBreakdownStructure = FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType();


            /* Basic Project Info */
            BasicProjectInfoProjectGridName = "agreementProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(currentFirmaSession, true, agreement)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} associated with Agreement Number {agreement.AgreementNumber}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with Agreement Number {agreement.AgreementNumber}",
                SaveFiltersInCookie = true
            };
            BasicProjectInfoProjectGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(tc => tc.AgreementProjectsGridJsonData(agreement));

            /* Cost Authority */
            BasicCostAuthorityGridName = "costAuthorityAgreementListGrid";
            BasicCostAuthorityGridSpec = new BasicCostAuthorityGridSpec(CurrentPerson)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} associated with {FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabel()} {agreement.AgreementNumber}",
                ObjectNamePlural = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabelPluralized()} associated with {FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabel()} {agreement.AgreementNumber}",
                SaveFiltersInCookie = true
            };
            BasicCostAuthorityGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(ac => ac.AgreementCostAuthorityGridJsonData(agreement));

        }


    }
}
