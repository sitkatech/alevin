SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ReclamationOneTimeImport].[BudgetObjectCodeGroupsOnlySheet_4-7-2020](
	[BOC_Category] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Group] [float] NOT NULL,
	[GroupZeroPadded] [int] NOT NULL,
	[Definitions] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
