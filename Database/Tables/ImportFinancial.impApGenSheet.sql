SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[impApGenSheet](
	[impApGenSheetID] [int] IDENTITY(1,1) NOT NULL,
	[PO Number - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Purch Ord Line Itm - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Reference - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Vendor - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Vendor - Text] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fund - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Funded Program - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBS Element - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBS Element - Text] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Budget Object Class - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Debit Amount] [float] NULL,
	[Credit Amount] [float] NULL,
	[Debit/Credit Total] [float] NULL,
	[CreatedOnKey] [datetime] NULL,
	[PostingDateKey] [datetime] NULL,
 CONSTRAINT [PK_impApGenSheet_impApGenSheetID] PRIMARY KEY CLUSTERED 
(
	[impApGenSheetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
