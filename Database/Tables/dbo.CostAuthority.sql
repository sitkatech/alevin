SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostAuthority](
	[CostAuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostAuthority] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountStructureDescription] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BasinNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Subbasin] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HCategory] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostCenter] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgencyProjectType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JobNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authority] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSStatus] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HCategoryLU] [float] NULL,
	[WBSNoDot] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_CostAuthority_CostAuthorityID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
