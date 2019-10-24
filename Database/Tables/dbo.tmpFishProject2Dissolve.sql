SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tmpFishProject2Dissolve](
	[OBJECTID] [int] NULL,
	[DPS] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SHAPE_Length] [float] NULL,
	[SHAPE_Area] [float] NULL,
	[GEOM] [geometry] NULL,
	[tmpFishProject2DissolveID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_tmpFishProject2Dissolve_tmpFishProject2DissolveID] PRIMARY KEY CLUSTERED 
(
	[tmpFishProject2DissolveID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
