SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[FiscalQuarter](
	[FiscalQuarterID] [int] NOT NULL,
	[FiscalQuarterNumber] [int] NOT NULL,
	[FiscalQuarterName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FiscalQuarterDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FiscalQuarterStartCalendarMonth] [int] NOT NULL,
	[FiscalQuarterStartCalendarDay] [int] NOT NULL,
 CONSTRAINT [PK_FiscalQuarter_FiscalQuarterID] PRIMARY KEY CLUSTERED 
(
	[FiscalQuarterID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
