SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Staging].[StageImpUnexpendedBalancePayRecV3](
	[StageImpUnexpendedBalancePayRecV3ID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessArea] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FABudgetActivity] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FunctionalArea] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObligationNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObligationItem] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fund] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundedProgram] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElement] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementDescription] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BudgetObjectClass] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Vendor] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostingDatePerSpl] [datetime] NULL,
	[UnexpendedBalance] [float] NULL,
 CONSTRAINT [PK_StageImpUnexpendedBalancePayRecV3_StageImpUnexpendedBalancePayRecV3ID] PRIMARY KEY CLUSTERED 
(
	[StageImpUnexpendedBalancePayRecV3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
