SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpHuc12](
	[OBJECTID_1] [int] NULL,
	[OBJECTID] [float] NULL,
	[TNMID] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MetaSource] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SourceData] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SourceOrig] [varchar](130) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SourceFeat] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoadDate] [varchar](24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NonContrib] [float] NULL,
	[NonContr_1] [float] NULL,
	[AreaSqKm] [float] NULL,
	[AreaAcres] [float] NULL,
	[GNIS_ID] [int] NULL,
	[Name] [varchar](120) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[States] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HUC12] [varchar](12) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HUType] [varchar](254) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HUMod] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ToHUC] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Shape_Leng] [float] NULL,
	[Shape_Length] [float] NULL,
	[Shape_Area] [float] NULL,
	[GEOM] [geometry] NULL,
	[tmpHuc12ID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tmpHuc12_tmpHuc12ID] PRIMARY KEY CLUSTERED 
(
	[tmpHuc12ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
