SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[ImportFinancialImpPayRecUnexpendedV3](
	[ImportFinancialImpPayRecUnexpendedV3ID] [int] IDENTITY(1,1) NOT NULL,
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
	[UnexpendedBalance] [datetime] NULL,
 CONSTRAINT [PK_ImportFinancialImpPayRecUnexpendedV3_ImportFinancialImpPayRecUnexpendedV3ID] PRIMARY KEY CLUSTERED 
(
	[ImportFinancialImpPayRecUnexpendedV3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
