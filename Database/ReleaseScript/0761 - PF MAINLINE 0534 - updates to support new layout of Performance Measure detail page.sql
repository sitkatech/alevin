alter table dbo.PerformanceMeasure drop column Importance

alter table dbo.TenantAttribute add SetTargetsByGeospatialArea bit null
go
update dbo.TenantAttribute set SetTargetsByGeospatialArea = 1
alter table dbo.TenantAttribute alter column SetTargetsByGeospatialArea bit not null


INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(380, N'SetTargetsByGeospatialArea', N'Set Targets By Geospatial Area?')

insert into FieldDefinitionDefault ([FieldDefinitionID], DefaultDefinition)
values
(380, 'If set to ''Yes'', then the Targets tab is visible on the Performance Measure detail page')


insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(88, 'PerformanceMeasureExpectedAccomplishments', 'Performance Measure Expected Accomplishments', 2),
(89, 'PerformanceMeasureReportedAccomplishments', 'Performance Measure Reported Accomplishments', 2),
(90, 'PerformanceMeasureTargetsTabIntro', 'Performance Measure Targets Tab Intro', 1)


insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(12, 88, ''),
(12, 89, ''),
(12, 90, '')
