

CREATE TABLE [dbo].[StageImpApGenSheet](
	[StageImpApGenSheetID] [int] IDENTITY(1,1) NOT NULL,
	[PONumberKey] [nvarchar](255) NULL,
	[PurchOrdLineItmKey] [nvarchar](255) NULL,
	[ReferenceKey] [nvarchar](255) NULL,
	[VendorKey] [nvarchar](255) NULL,
	[VendorText] [nvarchar](255) NULL,
	[FundKey] [nvarchar](255) NULL,
	[FundedProgramKey] [nvarchar](255) NULL,
	[WBSElementKey] [nvarchar](255) NULL,
	[WBSElementText] [nvarchar](255) NULL,
	[BudgetObjectClassKey] [nvarchar](255) NULL,
	[DebitAmount] [float] NULL,
	[CreditAmount] [float] NULL,
	[DebitCreditTotal] [float] NULL,
 CONSTRAINT [PK_StageImpApGenSheet_StageImpApGenSheetID] PRIMARY KEY CLUSTERED 
(
	[StageImpApGenSheetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

