SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[impPayRecV3](
	[impPayRecV3ID] [int] IDENTITY(1,1) NOT NULL,
	[Business area - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FA Budget Activity - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Functional area - Text] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Obligation Number - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Obligation Item - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fund - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Funded Program - Key (Not Compounded)] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBS Element - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBS Element - Text] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Budget Object Class - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Vendor - Key] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Vendor - Text] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Obligation] [float] NULL,
	[Goods Receipt] [float] NULL,
	[Invoiced] [float] NULL,
	[Disbursed] [float] NULL,
	[Unexpended Balance] [float] NULL,
	[CreatedOnKey] [datetime] NULL,
	[DateOfUpdateKey] [datetime] NULL,
	[PostingDateKey] [datetime] NULL,
	[PostingDatePerSplKey] [datetime] NULL,
	[DocumentDateOfBlKey] [datetime] NULL,
 CONSTRAINT [PK_impPayRecV3_impPayRecV3ID] PRIMARY KEY CLUSTERED 
(
	[impPayRecV3ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
