SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[ImpPayrecV3](
	[ImpPayrecV3ID] [int] IDENTITY(1,1) NOT NULL,
	[BusinessAreaKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FABudgetActivityKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FunctionalAreaText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObligationNumberKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ObligationItemKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundedProgramKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BudgetObjectClassKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Obligation] [float] NULL,
	[GoodsReceipt] [float] NULL,
	[Invoiced] [float] NULL,
	[Disbursed] [float] NULL,
	[UnexpendedBalance] [float] NULL,
	[CreatedOnKey] [datetime] NULL,
	[DateOfUpdateKey] [datetime] NULL,
	[PostingDateKey] [datetime] NULL,
	[PostingDatePerSplKey] [datetime] NULL,
	[DocumentDateOfBlKey] [datetime] NULL,
 CONSTRAINT [PK_impPayRecV3_impPayRecV3ID] PRIMARY KEY CLUSTERED 
(
	[ImpPayrecV3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]