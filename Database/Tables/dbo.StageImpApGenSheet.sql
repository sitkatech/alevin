SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StageImpApGenSheet](
	[StageImpApGenSheetID] [int] IDENTITY(1,1) NOT NULL,
	[PONumberKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PurchOrdLineItmKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReferenceKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundedProgramKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSElementText] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BudgetObjectClassKey] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebitAmount] [float] NULL,
	[CreditAmount] [float] NULL,
	[DebitCreditTotal] [float] NULL,
	[CreatedOnKey] [datetime] NULL,
	[PostingDateKey] [datetime] NULL,
 CONSTRAINT [PK_StageImpApGenSheet_StageImpApGenSheetID] PRIMARY KEY CLUSTERED 
(
	[StageImpApGenSheetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
