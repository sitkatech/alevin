SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpFishProject2PopulationDissolve](
	[OBJECTID] [int] NULL,
	[DPS] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[POPULATION] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[STATUS] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RUN_TIMING] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SHAPE_Length] [float] NULL,
	[SHAPE_Area] [float] NULL,
	[GEOM] [geometry] NULL,
	[tmpFishProject2PopulationDissolveID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tmpFishProject2PopulationDissolve_tmpFishProject2PopulationDissolveID] PRIMARY KEY CLUSTERED 
(
	[tmpFishProject2PopulationDissolveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
