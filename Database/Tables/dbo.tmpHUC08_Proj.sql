SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpHUC08_Proj](
	[OBJECTID_1] [int] NULL,
	[OBJECTID] [float] NULL,
	[TNMID] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MetaSource] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SourceData] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SourceOrig] [varchar](130) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SourceFeat] [varchar](40) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoadDate] [varchar](24) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AreaSqKm] [float] NULL,
	[AreaAcres] [float] NULL,
	[GNIS_ID] [int] NULL,
	[Name] [varchar](120) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[States] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HUC8] [varchar](8) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Shape_Leng] [float] NULL,
	[Shape_Length] [float] NULL,
	[Shape_Area] [float] NULL,
	[GEOM] [geometry] NULL,
	[tmpHUC08_ProjID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tmpHUC08_Proj_tmpHUC08_ProjID] PRIMARY KEY CLUSTERED 
(
	[tmpHUC08_ProjID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
