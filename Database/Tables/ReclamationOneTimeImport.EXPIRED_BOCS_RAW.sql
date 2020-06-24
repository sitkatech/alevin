SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW](
	[BudgetObjectCodeName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BOC_Category] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BOC_Item] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Group] [float] NULL,
	[2004] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2005] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2006] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2010] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[2011] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FBMS_2014] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FBMS_2015] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FBMS_2016] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FBMS_2017] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Definitions] [nvarchar](450) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[1099_Reportable] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[1099_Explanation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Expired] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Closed] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Column1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
