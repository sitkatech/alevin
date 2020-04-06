SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ReclamationOneTimeImport].[BocCleaned](
	[BocCategory] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BocItem] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BocGroup] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2004] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2005] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2006] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2010] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2011] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fbms2016] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fbms2017] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fbms2018] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fbms2019] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Definitions] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Reportable1099] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Explanation1099] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
