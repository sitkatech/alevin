CREATE TABLE dbo.Subproject(
	SubprojectID int identity(1,1) not null,
	TenantID int not null,
	ProjectID int not null, 
	Constraint [FK_Subproject_Tenant_TenantID] Foreign KEY(TenantID) references dbo.Tenant(TenantID),
	Constraint [FK_Subproject_Project_ProjectID] Foreign KEY(ProjectID) references dbo.Project(ProjectID),
	Constraint [PK_Subproject_SubprojectID] Primary Key(SubprojectID),
	ProjectStageID int not null,
	Constraint [FK_Subproject_ProjectStage_ProjectStageID] Foreign KEY(ProjectStageID) references dbo.ProjectStage(ProjectStageID),
	ImplementationStartYear int null,
	CompleteionYear int null,
	Notes html null,
	CONSTRAINT [AK_Subproject_SubprojectID_TenantID] UNIQUE NONCLUSTERED 
	(
		[SubprojectID] ASC,
		[TenantID] ASC
	),
	constraint FK_Subproject_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
)

create table dbo.SubprojectPerformanceMeasureActual(
	[SubprojectPerformanceMeasureActualID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ActualValue] [float] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID]) REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID] FOREIGN KEY([PerformanceMeasureReportingPeriodID], [TenantID]) REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID] FOREIGN KEY([SubprojectID]) REFERENCES [dbo].[Subproject] ([SubprojectID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID]) REFERENCES dbo.Subproject([SubprojectID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Tenant_TenantID] FOREIGN KEY([TenantID]) REFERENCES [dbo].[Tenant] ([TenantID]),
	CONSTRAINT [PK_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID] PRIMARY KEY CLUSTERED 
	(
		[SubprojectPerformanceMeasureActualID] ASC
	),
	 CONSTRAINT [AK_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
	(
		[SubprojectPerformanceMeasureActualID] ASC,
		[PerformanceMeasureID] ASC
	),
	 CONSTRAINT [AK_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_TenantID] UNIQUE NONCLUSTERED 
	(
		[SubprojectPerformanceMeasureActualID] ASC,
		[TenantID] ASC
	)
)

create table dbo.SubprojectPerformanceMeasureExpected(
	[SubprojectPerformanceMeasureExpectedID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
	CONSTRAINT [PK_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpectedID] PRIMARY KEY CLUSTERED 
	(
		[SubprojectPerformanceMeasureExpectedID] ASC
	),
	 CONSTRAINT [AK_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpectedID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
	(
		[SubprojectPerformanceMeasureExpectedID] ASC,
		[PerformanceMeasureID] ASC
	),
	 CONSTRAINT [AK_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpectedID_TenantID] UNIQUE NONCLUSTERED 
	(
		[SubprojectPerformanceMeasureExpectedID] ASC,
		[TenantID] ASC
	),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID] FOREIGN KEY([SubprojectID]) REFERENCES [dbo].[Subproject] ([SubprojectID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID]) REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Tenant_TenantID] FOREIGN KEY([TenantID]) REFERENCES [dbo].[Tenant] ([TenantID]),
)

CREATE TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption](
	[SubprojectPerformanceMeasureActualSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectPerformanceMeasureActualID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	CONSTRAINT [PK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActualSubcategoryOptionID] PRIMARY KEY CLUSTERED 
	(
		[SubprojectPerformanceMeasureActualSubcategoryOptionID] ASC
	),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_Performanc1] FOREIGN KEY([SubprojectPerformanceMeasureActualID]) REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_Performanc2] FOREIGN KEY([SubprojectPerformanceMeasureActualID], [PerformanceMeasureID]) REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID], [PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_TenantID_Pe] FOREIGN KEY([SubprojectPerformanceMeasureActualID], [TenantID]) REFERENCES [dbo].[PerformanceMeasureActual] ([PerformanceMeasureActualID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID]) REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_Performance] FOREIGN KEY([PerformanceMeasureSubcategoryID], [PerformanceMeasureID]) REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [TenantID]) REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI1] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID]) REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI2] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID]) REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI3] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [TenantID]) REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID]) REFERENCES [dbo].[Tenant] ([TenantID])
)

CREATE TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption](
	[SubprojectPerformanceMeasureExpectedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectPerformanceMeasureExpectedID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
	 CONSTRAINT [PK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpectedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
	(
		[SubprojectPerformanceMeasureExpectedSubcategoryOptionID] ASC
	),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID]) REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec1] FOREIGN KEY([SubprojectPerformanceMeasureExpectedID]) REFERENCES[dbo].[SubprojectPerformanceMeasureExpected] ([SubprojectPerformanceMeasureExpectedID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec2] FOREIGN KEY([SubprojectPerformanceMeasureExpectedID], [PerformanceMeasureID]) REFERENCES[dbo].[SubprojectPerformanceMeasureExpected] ([SubprojectPerformanceMeasureExpectedID], [PerformanceMeasureID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec3] FOREIGN KEY([SubprojectPerformanceMeasureExpectedID], [TenantID]) REFERENCES[dbo].[SubprojectPerformanceMeasureExpected] ([SubprojectPerformanceMeasureExpectedID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID]) REFERENCES[dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [TenantID]) REFERENCES[dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptio1] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID]) REFERENCES[dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptio2] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [TenantID]) REFERENCES[dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [TenantID]),
	CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID]) REFERENCES[dbo].[Tenant] ([TenantID])
)