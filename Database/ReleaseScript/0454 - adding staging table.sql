

CREATE TABLE [dbo].[StageImpPayRecV3](
	[StageImpPayRecV3ID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessAreaKey] [nvarchar](255) NULL,
	[FABudgetActivityKey] [nvarchar](255) NULL,
	[FunctionalAreaText] [nvarchar](255) NULL,
	[ObligationNumberKey] [nvarchar](255) NULL,
	[ObligationItemKey] [nvarchar](255) NULL,
	[FundKey] [nvarchar](255) NULL,
	[FundedProgramKeyNotCompounded] [nvarchar](255) NULL,
	[WBSElementKey] [nvarchar](255) NULL,
	[WBSElementText] [nvarchar](255) NULL,
	[BudgetObjectClassKey] [nvarchar](255) NULL,
	[VendorKey] [nvarchar](255) NULL,
	[VendorText] [nvarchar](255) NULL,
	[Obligation] [float] NULL,
	[GoodsReceipt] [nvarchar](255) NULL,
	[Invoiced] [float] NULL,
	[Disbursed] [float] NULL,
	[UnexpendedBalance] [float] NULL,
 CONSTRAINT [PK_StageImpPayRecV3_StageImpPayRecV3ID] PRIMARY KEY CLUSTERED 
(
	[StageImpPayRecV3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

