
INSERT INTO [dbo].[TenantAttribute]
           ([TenantID]
           ,[DefaultBoundingBox]
           ,[MinimumYear]
           ,[PrimaryContactPersonID]
           ,[TenantSquareLogoFileResourceInfoID]
           ,[TenantBannerLogoFileResourceInfoID]
           ,[TenantStyleSheetFileResourceInfoID]
           ,[TenantShortDisplayName]
           ,[ToolDisplayName]
           ,[ShowProposalsToThePublic]
           ,[TaxonomyLevelID]
           ,[AssociatePerfomanceMeasureTaxonomyLevelID]
           ,[IsActive]
           ,[ProjectExternalDataSourceEnabled]
           ,[AccomplishmentsDashboardFundingDisplayTypeID]
           ,[AccomplishmentsDashboardAccomplishmentsButtonText]
           ,[AccomplishmentsDashboardExpendituresButtonText]
           ,[AccomplishmentsDashboardOrganizationsButtonText]
           ,[AccomplishmentsDashboardIncludeReportingOrganizationType]
           ,[ShowLeadImplementerLogoOnFactSheet]
           ,[EnableAccomplishmentsDashboard]
           ,[ProjectStewardshipAreaTypeID]
           ,[EnableSecondaryProjectTaxonomyLeaf]
           ,[KeystoneOpenIDClientIdentifier]
           ,[KeystoneOpenIDClientSecret]
           ,[BudgetTypeID]
           ,[CanManageCustomAttributes]
           ,[ExcludeTargetedFundingOrganizations]
           ,[GoogleAnalyticsTrackingCode]
           ,[UseProjectTimeline]
           ,[GeoServerNamespace]
           ,[EnableEvaluations]
           ,[EnableProjectCategories]
           ,[EnableReports]
           ,[TenantFactSheetLogoFileResourceInfoID]
           ,[EnableMatchmaker]
           ,[MatchmakerAlgorithmIncludesProjectGeospatialAreas]
           ,[AreGeospatialAreasExternallySourced]
           ,[ShowPhotoCreditOnFactSheet]
           ,[TrackAccomplishments])
     VALUES
           (1,0xE61000000104050000000100000040285FC06911DAA3DB1C47400100000040285FC08D97B8A52102454001000000B0415DC08D97B8A52102454001000000B0415DC06911DAA3DB1C47400100000040285FC06911DAA3DB1C474001000000020000000001000000FFFFFFFF0000000003,2017,NULL,NULL,NULL,NULL,'ProjectFirma','ProjectFirma',1,2,2,1,0,1,NULL,NULL,NULL,1,0,1,NULL,0,'SitkaProjectFirma','6C0D5ACB-EF45-4081-AFDA-754DA37A87BD',2,0,0,NULL,1,'ProjectFirma',0,0,0,NULL,0,0,0,0,1)
GO



USE [AlevinDB]
GO

INSERT INTO [dbo].[ProjectUpdateSetting]
           ([TenantID]
           ,[ProjectUpdateKickOffDate]
           ,[ProjectUpdateCloseOutDate]
           ,[ProjectUpdateReminderInterval]
           ,[EnableProjectUpdateReminders]
           ,[SendPeriodicReminders]
           ,[SendCloseOutNotification]
           ,[ProjectUpdateKickOffIntroContent]
           ,[ProjectUpdateReminderIntroContent]
           ,[ProjectUpdateCloseOutIntroContent]
           ,[DaysBeforeCloseOutDateForReminder])
     VALUES
           (1
           ,null
           ,null
           ,null
           ,0
           ,0
           ,0
           ,null
           ,null
           ,null
           ,null)
GO






