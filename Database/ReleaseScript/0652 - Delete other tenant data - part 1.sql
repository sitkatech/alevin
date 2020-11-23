

--select * from dbo.Tenant


--begin tran


delete from dbo.ProjectOrganization
where TenantID != 12
GO

delete from dbo.ProjectExternalLink
where TenantID != 12
GO

delete from dbo.PerformanceMeasureExpectedSubcategoryOption
where TenantID != 12
GO

delete from dbo.PerformanceMeasureExpected
where TenantID != 12
GO

delete from dbo.ProjectImageUpdate
where TenantID != 12
GO

delete from dbo.ProjectImage
where TenantID != 12
GO

delete from dbo.ProjectLocation
where TenantID != 12
GO

delete from dbo.ProjectClassification
where TenantID != 12
GO

delete from Reclamation.ProjectFundingSourceBudget
where TenantID != 12
GO

delete from dbo.ProjectNote
where TenantID != 12
GO

delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate
where TenantID != 12
GO

delete from dbo.PerformanceMeasureActualSubcategoryOption
where TenantID != 12
GO

delete from dbo.PerformanceMeasureActualUpdate
where TenantID != 12
GO

delete from dbo.PerformanceMeasureActual
where TenantID != 12
GO

delete from dbo.ProjectGeospatialArea
where TenantID != 12
GO

delete from dbo.ProjectUpdate
where TenantID != 12
GO

delete from dbo.ProjectUpdateHistory
where TenantID != 12
GO

delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate
where TenantID != 12


delete from dbo.ProjectFundingSourceExpenditureUpdate
where TenantID != 12
GO

delete from Reclamation.ProjectFundingSourceBudgetUpdate
where TenantID != 12
GO

delete from dbo.ProjectGeospatialAreaUpdate
where TenantID != 12

delete from dbo.ProjectExternalLinkUpdate
where TenantID != 12

delete from dbo.ProjectOrganizationUpdate
where TenantID != 12

delete from dbo.ProjectGeospatialAreaTypeNoteUpdate
where TenantID != 12

delete from dbo.ProjectExemptReportingYearUpdate
where TenantID != 12

delete from dbo.ProjectAttachmentUpdate
where TenantID != 12

delete from dbo.ProjectLocationStagingUpdate
where TenantID != 12

delete from dbo.ProjectLocationUpdate
where TenantID != 12

delete from dbo.ProjectNoteUpdate
where TenantID != 12

delete from dbo.TechnicalAssistanceRequestUpdate
where TenantID != 12

delete from dbo.PerformanceMeasureExpectedUpdate
where TenantID != 12

delete from dbo.ProjectCustomAttributeUpdateValue
where TenantID != 12

delete from dbo.ProjectCustomAttributeUpdate
where TenantID != 12

delete from dbo.ProjectRelevantCostTypeUpdate
where TenantID != 12

delete from dbo.ProjectContactUpdate
where TenantID != 12

delete from dbo.ProjectUpdateBatch
where TenantID != 12
GO

delete from dbo.PerformanceMeasureActualUpdate
where TenantID != 12
GO

delete from dbo.ProjectLocationStaging
where TenantID != 12
GO

delete from dbo.ProjectTag
where TenantID != 12
GO

delete from dbo.NotificationProject
where TenantID != 12
GO

delete from dbo.ProjectGeospatialAreaTypeNote
where TenantID != 12
GO

delete from dbo.ProjectExemptReportingYear
where TenantID != 12
GO

delete from dbo.ProjectAttachment
where TenantID != 12
GO

delete from dbo.ProjectCustomAttributeValue
where TenantID != 12
GO

delete from dbo.ProjectCustomAttribute
where TenantID != 12
GO

delete from dbo.TechnicalAssistanceRequest
where TenantID != 12
GO

delete from dbo.ProjectInternalNote
where TenantID != 12
GO

delete from dbo.ProjectContact
where TenantID != 12
GO

delete from dbo.ProjectRelevantCostType
where TenantID != 12
GO

delete from dbo.SecondaryProjectTaxonomyLeaf
where TenantID != 12
GO

delete from dbo.Project
where TenantID != 12
GO

--rollback tran
