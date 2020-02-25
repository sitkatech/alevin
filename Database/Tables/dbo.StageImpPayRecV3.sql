SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StageImpPayRecV3](
	[StageImpPayRecV3ID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessAreaKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FABudgetActivityKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FunctionalAreaText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObligationNumberKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObligationItemKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundedProgramKeyNotCompounded] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BudgetObjectClassKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Obligation] [float] NULL,
	[GoodsReceipt] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Invoiced] [float] NULL,
	[Disbursed] [float] NULL,
	[UnexpendedBalance] [float] NULL,
 CONSTRAINT [PK_StageImpPayRecV3_StageImpPayRecV3ID] PRIMARY KEY CLUSTERED 
(
	[StageImpPayRecV3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
