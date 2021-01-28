SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GeospatialAreaType](
	[GeospatialAreaTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaTypeName] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeospatialAreaTypeNamePluralized] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeospatialAreaIntroContent] [dbo].[html] NULL,
	[GeospatialAreaTypeDefinition] [dbo].[html] NULL,
	[GeospatialAreaLayerName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DisplayOnAllProjectMaps] [bit] NOT NULL,
	[OnByDefaultOnProjectMap] [bit] NOT NULL,
	[IsPopulation] [bit] NOT NULL,
	[EsuDpsGeospatialAreaTypeID] [int] NULL,
	[MPGGeospatialAreaTypeID] [int] NULL,
	[PopulationGeospatialAreaTypeID] [int] NULL,
	[IncludeInBiOpAnnualReport] [bit] NOT NULL,
	[OnByDefaultOnOtherMaps] [bit] NOT NULL,
 CONSTRAINT [PK_GeospatialAreaType_GeospatialAreaTypeID] PRIMARY KEY CLUSTERED 
(
	[GeospatialAreaTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaType_GeospatialAreaTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaType_GeospatialAreaTypeName_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_GeospatialAreaType_GeospatialAreaTypeNamePluralized_TenantID] UNIQUE NONCLUSTERED 
(
	[GeospatialAreaTypeNamePluralized] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID_GeospatialAreaTypeID] FOREIGN KEY([EsuDpsGeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID_TenantID_GeospatialAreaTypeID_TenantID] FOREIGN KEY([EsuDpsGeospatialAreaTypeID], [TenantID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID_TenantID_GeospatialAreaTypeID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID_GeospatialAreaTypeID] FOREIGN KEY([MPGGeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID_TenantID_GeospatialAreaTypeID_TenantID] FOREIGN KEY([MPGGeospatialAreaTypeID], [TenantID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID_TenantID_GeospatialAreaTypeID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID_GeospatialAreaTypeID] FOREIGN KEY([PopulationGeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID_TenantID_GeospatialAreaTypeID_TenantID] FOREIGN KEY([PopulationGeospatialAreaTypeID], [TenantID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID], [TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID_TenantID_GeospatialAreaTypeID_TenantID]
GO
ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_Tenant_TenantID]