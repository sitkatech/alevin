SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationStagingPostedObligation](
	[ReclamationStagingPostedObligationID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalPostedObligationsID] [int] NULL,
	[OriginalReclamationCostAuthorityAgreementID] [int] NULL,
	[OriginalAgreementStatusID] [int] NULL,
	[Fund] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Program] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JobNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BOC] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FiscalYear] [int] NULL,
	[AgreementNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContractorName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mods] [float] NULL,
	[Line] [float] NULL,
	[BeginDate] [datetime] NULL,
	[LastOfMonthEnding] [datetime] NULL,
	[LastOfAmount] [money] NULL,
	[Amount] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationStagingPostedObligation_ReclamationStagingPostedObligationID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingPostedObligationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
