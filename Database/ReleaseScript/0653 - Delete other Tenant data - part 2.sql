

delete from dbo.ProjectStatus where TenantID != 12
delete from dbo.FirmaPageImage where TenantID != 12
delete from dbo.DocumentLibraryDocumentRole where TenantID != 12
delete from dbo.FirmaPage where TenantID != 12
delete from dbo.AssessmentSubGoal where TenantID != 12
delete from dbo.FieldDefinitionDataImage where TenantID != 12
delete from dbo.ProjectRelevantCostTypeUpdate where TenantID != 12
delete from dbo.ProjectCustomAttributeTypeRole where TenantID != 12
delete from dbo.ProjectOrganizationUpdate where TenantID != 12
delete from dbo.ProjectNoteUpdate where TenantID != 12
delete from dbo.FileResourceData where TenantID != 12
delete from dbo.PerformanceMeasureSubcategoryOption where TenantID != 12
delete from dbo.ProjectCustomAttributeValue where TenantID != 12

delete from dbo.FundingSourceCustomAttributeValue where TenantID != 12
delete from dbo.FundingSourceCustomAttribute where TenantID != 12
delete from dbo.FundingSourceCustomAttributeType where TenantID != 12

-- NO, don't delete the Tenant itself.
--delete from dbo.Tenant where TenantID != 12
delete from dbo.OrganizationBoundaryStaging where TenantID != 12
delete from dbo.ProjectUpdateSetting where TenantID != 12
delete from dbo.TaxonomyLeafPerformanceMeasure where TenantID != 12
delete from dbo.TaxonomyLeaf where TenantID != 12
delete from dbo.AssessmentQuestion where TenantID != 12
delete from dbo.ProjectUpdateHistory where TenantID != 12
delete from dbo.ProjectProjectStatus where TenantID != 12
delete from dbo.TrainingVideo where TenantID != 12
delete from dbo.ProjectContact where TenantID != 12


delete from dbo.ProjectImageUpdate where TenantID != 12
delete from dbo.ProjectCustomAttributeGroupProjectCategory where TenantID != 12
delete from dbo.TaxonomyBranch where TenantID != 12
delete from dbo.ReportTemplate where TenantID != 12
delete from dbo.PerformanceMeasureSubcategory where TenantID != 12
delete from dbo.ProjectContactUpdate where TenantID != 12
delete from dbo.ProjectFundingSourceExpenditureUpdate where TenantID != 12
delete from dbo.PerformanceMeasureNote where TenantID != 12

delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID != 12
delete from dbo.TaxonomyTrunk where TenantID != 12
delete from dbo.NpccProvince where TenantID != 12
delete from dbo.Classification where TenantID != 12
delete from Reclamation.ProjectFundingSourceBudget where TenantID != 12
delete from dbo.OrganizationImage where TenantID != 12
delete from dbo.ProjectCustomGridConfiguration where TenantID != 12
delete from dbo.ProjectCustomAttributeType where TenantID != 12

delete from dbo.NpccSubbasinProvince where TenantID != 12
delete from dbo.ProjectNoFundingSourceIdentified where TenantID != 12
delete from dbo.Evaluation where TenantID != 12
delete from dbo.PerformanceMeasureImage where TenantID != 12
delete from dbo.PerformanceMeasure where TenantID != 12
delete from dbo.PerformanceMeasureActualUpdate where TenantID != 12
delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where TenantID != 12
delete from Reclamation.ProjectFundingSourceBudgetUpdate where TenantID != 12
delete from dbo.ProjectGeospatialArea where TenantID != 12
delete from dbo.ProjectCustomAttribute where TenantID != 12
delete from dbo.PerformanceMeasureImage where TenantID != 12





delete from dbo.PersonStewardOrganization where TenantID != 12
delete from dbo.PersonStewardTaxonomyBranch where TenantID != 12
-- There's two-way bindings here between Person and Organziation that make things difficult
update dbo.Organization set PrimaryContactPersonID = null where TenantID != 12
alter table dbo.Person alter column OrganizationID int null
update dbo.Person set OrganizationID = null where TenantID != 12
delete from dbo.Notification where TenantID != 12


delete from dbo.SupportRequestLog where TenantID != 12
delete from dbo.CustomPageImage where TenantID != 12
delete from dbo.FirmaHomePageImage where TenantID != 12

-- Problems start here?
delete from dbo.TenantAttribute where TenantID != 12
delete from dbo.FundingSource where TenantID != 12
delete from dbo.Organization where TenantID != 12
delete from dbo.FileResourceInfo where TenantID != 12

delete from dbo.ReleaseNote where UpdatePersonID in (select p.PersonID from dbo.Person as p where TenantID != 12)
delete from dbo.ImportExternalProjectStaging where CreatePersonID in (select p.PersonID from dbo.Person as p where TenantID != 12)
delete from dbo.PersonStewardGeospatialArea where PersonID in (select p.PersonID from dbo.Person as p where TenantID != 12)

delete from dbo.Person where TenantID != 12
alter table dbo.Person alter column OrganizationID int not null

--delete from dbo.FileResourceInfo where TenantID != 12
delete from dbo.EvaluationCriteria where TenantID != 12

delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate where TenantID != 12
delete from dbo.AttachmentTypeFileResourceMimeType where TenantID != 12
delete from dbo.AttachmentType where TenantID != 12
delete from dbo.ClassificationSystem where TenantID != 12
delete from dbo.ProjectCustomAttributeUpdate where TenantID != 12
delete from dbo.EvaluationCriteriaValue where TenantID != 12
delete from dbo.Tag where TenantID != 12

delete from dbo.ProjectGeospatialAreaUpdate where TenantID != 12
delete from dbo.PerformanceMeasureReportingPeriodTarget where TenantID != 12

delete from dbo.CostType where TenantID != 12
delete from dbo.ImportExternalProjectStaging where TenantID != 12
delete from dbo.ProjectTag where TenantID != 12
delete from dbo.ProjectEvaluation where TenantID != 12
delete from dbo.MatchmakerOrganizationTaxonomyBranch where TenantID != 12

delete from dbo.AttachmentTypeTaxonomyTrunk where TenantID != 12
delete from dbo.ProjectExemptReportingYearUpdate where TenantID != 12
delete from dbo.PersonStewardGeospatialArea where TenantID != 12
delete from dbo.ProjectEvaluationSelectedValue where TenantID != 12
delete from dbo.ProjectCustomAttributeUpdateValue where TenantID != 12
delete from dbo.GeospatialAreaPerformanceMeasureReportingPeriodTarget where TenantID != 12
delete from dbo.ProjectClassification where TenantID != 12
delete from dbo.SupportRequestLog where TenantID != 12
delete from dbo.MatchmakerOrganizationTaxonomyTrunk where TenantID != 12
delete from dbo.ProjectLocationUpdate where TenantID != 12
delete from dbo.ProjectAttachment where TenantID != 12

delete from dbo.CustomPageImage where TenantID != 12
delete from dbo.CustomPageRole where TenantID != 12
delete from dbo.CustomPage where TenantID != 12

delete from dbo.FundingSource where TenantID != 12
delete from dbo.ProjectExemptReportingYear where TenantID != 12
delete from dbo.MatchmakerOrganizationTaxonomyLeaf where TenantID != 12
delete from dbo.ClassificationPerformanceMeasure where TenantID != 12

delete from dbo.AuditLog where TenantID != 12
delete from dbo.MatchMakerAreaOfInterestLocation where TenantID != 12
delete from dbo.ProjectAttachmentUpdate where TenantID != 12
delete from dbo.FundingSourceCustomAttributeTypeRole where TenantID != 12
delete from dbo.GeospatialAreaPerformanceMeasureNoTarget where TenantID != 12
delete from dbo.ProjectInternalNote where TenantID != 12
delete from dbo.ProjectLocation where TenantID != 12
delete from dbo.ProjectFundingSourceExpenditure where TenantID != 12
delete from dbo.FieldDefinitionData where TenantID != 12
delete from dbo.TechnicalAssistanceRequest where TenantID != 12
delete from dbo.MatchmakerOrganizationPerformanceMeasure where TenantID != 12

delete from dbo.ProjectAssessmentQuestion where TenantID != 12
delete from dbo.ActionItem where TenantID != 12
delete from dbo.FundingSourceCustomAttribute where TenantID != 12
delete from dbo.PerformanceMeasureExpectedSubcategoryOption where TenantID != 12
delete from dbo.Organization where TenantID != 12
delete from dbo.ProjectImage where TenantID != 12
delete from dbo.GeospatialAreaPerformanceMeasureFixedTarget where TenantID != 12
delete from dbo.GeospatialAreaImage where TenantID != 12

delete from dbo.TechnicalAssistanceRequestUpdate where TenantID != 12
delete from dbo.Notification where TenantID != 12

delete from dbo.PersonSettingGridTable where TenantID != 12
delete from dbo.TechnicalAssistanceParameter where TenantID != 12
delete from dbo.SubbasinLiason where TenantID != 12
delete from dbo.MatchmakerKeyword where TenantID != 12
delete from dbo.FirmaHomePageImage where TenantID != 12
delete from dbo.TenantAttribute where TenantID != 12
delete from dbo.PerformanceMeasureFixedTarget where TenantID != 12
delete from dbo.PerformanceMeasureExpected where TenantID != 12
delete from dbo.PersonSettingGridColumn where TenantID != 12
delete from dbo.NotificationProject where TenantID != 12

-- Order problems here?
delete from dbo.ProjectGeospatialAreaTypeNote where TenantID != 12
delete from dbo.ProjectGeospatialAreaTypeNoteUpdate where TenantID != 12
delete from dbo.GeospatialArea where TenantID != 12
delete from dbo.GeospatialAreaType where TenantID != 12
delete from dbo.OrganizationMatchmakerKeyword where TenantID != 12
delete from dbo.ProjectLocationStaging where TenantID != 12

delete from dbo.StateProvince where TenantID != 12
delete from dbo.PerformanceMeasureExpectedUpdate where TenantID != 12
delete from dbo.FirmaSession where TenantID != 12
delete from dbo.PersonSettingGridColumnSetting where TenantID != 12
delete from dbo.ExternalMapLayer where TenantID != 12
delete from dbo.OrganizationTypeOrganizationRelationshipType where TenantID != 12
delete from dbo.OrganizationType where TenantID != 12
delete from dbo.DocumentLibrary where TenantID != 12
delete from dbo.County where TenantID != 12
delete from dbo.DocumentLibraryDocumentCategory where TenantID != 12
delete from dbo.MatchmakerOrganizationClassification where TenantID != 12
delete from dbo.ProjectLocationStagingUpdate where TenantID != 12


delete from dbo.PersonSettingGridColumnSettingFilter where TenantID != 12
delete from dbo.ContactRelationshipType where TenantID != 12
delete from dbo.PerformanceMeasureActualSubcategoryOption where TenantID != 12
delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate where TenantID != 12
delete from dbo.OrganizationRelationshipType where TenantID != 12
delete from dbo.SecondaryProjectTaxonomyLeaf where TenantID != 12
delete from dbo.PerformanceMeasureReportingPeriod where TenantID != 12
delete from dbo.ProjectExternalLink where TenantID != 12


delete from dbo.ProjectCustomAttributeGroup where TenantID != 12
delete from dbo.ProjectUpdateBatch where TenantID != 12
delete from dbo.DocumentLibraryDocument where TenantID != 12
delete from dbo.Project where TenantID != 12
delete from dbo.ProjectExternalLinkUpdate where TenantID != 12
delete from dbo.TaxonomyLeafPerformanceMeasure where TenantID != 12
delete from dbo.FirmaPageImage where TenantID != 12
delete from dbo.ProjectRelevantCostType where TenantID != 12
delete from dbo.PerformanceMeasureActual where TenantID != 12
delete from dbo.AssessmentGoal where TenantID != 12
delete from dbo.ProjectOrganization where TenantID != 12
delete from dbo.ProjectNote where TenantID != 12
delete from dbo.ProjectUpdate where TenantID != 12
delete from dbo.ProjectCustomGridConfiguration where TenantID != 12

