SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationStagingObligationsTable](
	[ReclamationStagingObligationsTableID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalObligationsID] [int] NULL,
	[OriginalAgreementStatusID] [int] NULL,
	[MonthEnding] [datetime] NULL,
	[Amount] [money] NULL,
 CONSTRAINT [PK_ReclamationStagingObligationsTable_ReclamationStagingObligationsTableID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingObligationsTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
