﻿/*-----------------------------------------------------------------------
<copyright file="DetailViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.ModalDialog;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Security;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Views.Shared.TextControls;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.CostAuthority;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirma.Web.Views.Project;

//using ProjectFirma.Web.Views.Project;

namespace ProjectFirma.Web.Views.Agreement
{
    public class AgreementDetailViewData : FirmaViewData
    {
        public ProjectFirmaModels.Models.ReclamationAgreement ReclamationAgreement { get; }

        public bool IsAdmin { get; }

        //public string EditPerformanceMeasureUrl { get; }
        //public string EditSubcategoriesAndOptionsUrl { get; }
        //public string EditCriticalDefinitionsUrl { get; }
        //public string EditProjectReportingUrl { get; }

        public string IndexUrl { get; }
        public string CostAuthorityIndexUrl { get; }

        //public string EditTaxonomyTiersUrl { get; }
        //public bool UserHasTaxonomyTierPerformanceMeasureManagePermissions { get; }
        public bool UserHasAgreementManagePermissions { get; }
        //public PerformanceMeasureReportedValuesGridSpec PerformanceMeasureReportedValuesGridSpec { get; }
        //public string PerformanceMeasureReportedValuesGridName { get; }
        //public string PerformanceMeasureReportedValuesGridDataUrl { get; }

        /*
        public Project.IndexGridSpec ProjectIndexGridSpec { get; }
        public string ProjectIndexGridName { get;}
        public string ProjectIndexGridDataUrl { get; }
        */

        public string BasicProjectInfoProjectGridName { get; }
        public BasicProjectInfoGridSpec BasicProjectInfoGridSpec { get; }
        public string BasicProjectInfoProjectGridDataUrl { get; }

        public string BasicCostAuthorityGridName { get; }
        public BasicCostAuthorityGridSpec BasicCostAuthorityGridSpec { get; }
        public string BasicCostAuthorityGridDataUrl { get; }

        //public string PerformanceMeasureExpectedsGridName { get; }
        //public string PerformanceMeasureExpectedsGridDataUrl { get; }

        //public string TaxonomyTierDisplayNamePluralized { get; }

        /*
        public RelatedTaxonomyTiersViewData RelatedTaxonomyTiersViewData { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasure { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasureSubcategory { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForPerformanceMeasureSubcategoryOption { get; }
        */

        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForAgreement { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostAuthorityWorkBreakdownStructure { get; }
        

        public AgreementDetailViewData(Person currentPerson,
                                       ProjectFirmaModels.Models.ReclamationAgreement reclamationAgreement
                                       //PerformanceMeasureChartViewData performanceMeasureChartViewData,
                                       //EntityNotesViewData entityNotesViewData,
                                       //bool userHasAgreementManagePermissions, 
                                       /*bool isAdmin*/) : base(currentPerson)
        {
            

            PageTitle = $"Agreement Number: {reclamationAgreement.AgreementNumber}";
            EntityName = "Agreement Detail";

            ReclamationAgreement = reclamationAgreement;
            //PerformanceMeasureChartViewData = performanceMeasureChartViewData;
            //EntityNotesViewData = entityNotesViewData;
            UserHasAgreementManagePermissions = new AgreementManageFeature().HasPermissionByPerson(CurrentPerson);
            IsAdmin = new FirmaAdminFeature().HasPermissionByPerson(CurrentPerson);

            /*
            EditPerformanceMeasureUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            EditSubcategoriesAndOptionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditSubcategoriesAndOptions(performanceMeasure));
                
            EditCriticalDefinitionsUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.CriticalDefinitions));
            EditProjectReportingUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(c => c.EditPerformanceMeasureRichText(performanceMeasure, EditRtfContent.PerformanceMeasureRichTextType.ProjectReporting));
            */

            IndexUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(c => c.AgreementIndex());
            CostAuthorityIndexUrl = SitkaRoute<CostAuthorityController>.BuildUrlFromExpression(cac => cac.CostAuthorityIndex());

        //public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForAgreement { get; }
        //public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForProject { get; }
        //public ProjectFirmaModels.Models.FieldDefinition FieldDefinitionForCostAuthorityWorkBreakdownStructure { get; }

        FieldDefinitionForAgreement = FieldDefinitionEnum.Agreement.ToType();
        FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
        FieldDefinitionForCostAuthorityWorkBreakdownStructure = FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType();

            /*
        public Project.IndexGridSpec ProjectIndexGridSpec { get; }
        public string ProjectIndexGridName { get;}
        public string ProjectIndexGridDataUrl { get; }
               
             *
             */


            /* Basic Project Info */
            BasicProjectInfoProjectGridName = "agreementProjectListGrid";
            BasicProjectInfoGridSpec = new BasicProjectInfoGridSpec(CurrentPerson, true)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()} associated with Agreement Number {reclamationAgreement.AgreementNumber}",
                ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()} associated with Agreement Number {reclamationAgreement.AgreementNumber}",
                SaveFiltersInCookie = true
            };
            BasicProjectInfoProjectGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(tc => tc.AgreementProjectsGridJsonData(reclamationAgreement));

            /* Cost Authority */
            BasicCostAuthorityGridName = "costAuthorityAgreementListGrid";
            BasicCostAuthorityGridSpec = new BasicCostAuthorityGridSpec(CurrentPerson)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabel()} associated with {FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabel()} {reclamationAgreement.AgreementNumber}",
                ObjectNamePlural = $"{FieldDefinitionEnum.CostAuthorityWorkBreakdownStructure.ToType().GetFieldDefinitionLabelPluralized()} associated with {FieldDefinitionEnum.Agreement.ToType().GetFieldDefinitionLabel()} {reclamationAgreement.AgreementNumber}",
                SaveFiltersInCookie = true
            };
            BasicCostAuthorityGridDataUrl = SitkaRoute<AgreementController>.BuildUrlFromExpression(ac => ac.AgreementCostAuthorityGridJsonData(reclamationAgreement));

            
            //GridSpec = new IndexGridSpec(currentPerson, new Dictionary<int, FundingType>(), geospatialAreaTypes, projectCustomAttributeTypes) { ObjectNameSingular = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}", ObjectNamePlural = $"{FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}", SaveFiltersInCookie = true };

            //if (new ProjectCreateFeature().HasPermissionByPerson(CurrentPerson))
            //{
            //    GridSpec<>.CustomExcelDownloadUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexExcelDownload());
            //}
            //else if (currentPerson.RoleID == ProjectFirmaModels.Models.Role.ProjectSteward.RoleID)
            //{
            //    GridSpec.CreateEntityModalDialogForm = new ModalDialogForm(SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.DenyCreateProject()), $"New {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}");
            //}

            //GridName = "projectsGrid";
            //GridDataUrl = SitkaRoute<ProjectController>.BuildUrlFromExpression(tc => tc.IndexGridJsonData());











            //var associatePerformanceMeasureTaxonomyLevel = MultiTenantHelpers.GetAssociatePerformanceMeasureTaxonomyLevel();
            //TaxonomyTierDisplayNamePluralized = associatePerformanceMeasureTaxonomyLevel.GetFieldDefinition().GetFieldDefinitionLabelPluralized();
            //UserHasTaxonomyTierPerformanceMeasureManagePermissions = new TaxonomyTierPerformanceMeasureManageFeature().HasPermission(currentPerson, performanceMeasure).HasPermission;
            //EditTaxonomyTiersUrl = SitkaRoute<TaxonomyTierPerformanceMeasureController>.BuildUrlFromExpression(c => c.Edit(performanceMeasure));
            //RelatedTaxonomyTiersViewData = new RelatedTaxonomyTiersViewData(performanceMeasure, associatePerformanceMeasureTaxonomyLevel, true);

            /*
            PerformanceMeasureReportedValuesGridSpec = new PerformanceMeasureReportedValuesGridSpec(performanceMeasure)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.ReportedValue.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.ReportedValue.ToType().GetFieldDefinitionLabelPluralized()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureReportedValuesGridName = "performanceMeasuresReportedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureReportedValuesGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureReportedValuesGridJsonData(performanceMeasure));

            PerformanceMeasureExpectedGridSpec = new PerformanceMeasureExpectedGridSpec(performanceMeasure)
            {
                ObjectNameSingular = $"{FieldDefinitionEnum.ExpectedValue.ToType().GetFieldDefinitionLabel()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabel()}",
                ObjectNamePlural = $"{FieldDefinitionEnum.ExpectedValue.ToType().GetFieldDefinitionLabelPluralized()} for {FieldDefinitionEnum.Project.ToType().GetFieldDefinitionLabelPluralized()}",
                SaveFiltersInCookie = true
            };

            PerformanceMeasureExpectedsGridName = "performanceMeasuresExpectedValuesFromPerformanceMeasureGrid";
            PerformanceMeasureExpectedsGridDataUrl = SitkaRoute<PerformanceMeasureController>.BuildUrlFromExpression(tc => tc.PerformanceMeasureExpectedsGridJsonData(performanceMeasure));

            FieldDefinitionForPerformanceMeasure = FieldDefinitionEnum.PerformanceMeasureSubcategoryOption.ToType();
            FieldDefinitionForPerformanceMeasureSubcategory = FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType();
            FieldDefinitionForPerformanceMeasureSubcategoryOption = FieldDefinitionEnum.PerformanceMeasureSubcategoryOption.ToType();
            FieldDefinitionForProject = FieldDefinitionEnum.Project.ToType();
            */
        }


    }
}