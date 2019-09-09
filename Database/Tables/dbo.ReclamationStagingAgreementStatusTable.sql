SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationStagingAgreementStatusTable](
	[ReclamationStagingAgreementStatusTableID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalAgreementStatusID] [int] NULL,
	[OriginalReclamationCostAuthorityAgreementID] [int] NULL,
	[RequisitionNumber] [int] NULL,
	[Mods] [int] NULL,
	[Line] [int] NULL,
	[Fund] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[FiscalYear] [float] NULL,
	[OriginalObligation] [money] NULL,
	[Notes] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModDeObligationOrClosed] [bit] NOT NULL,
 CONSTRAINT [PK_ReclamationStagingAgreementStatusTable_ReclamationStagingAgreementStatusTableID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingAgreementStatusTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
