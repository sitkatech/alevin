SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationStagingContractTrackingTable](
	[ReclamationStagingContractTrackingTableID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalContractTrackingID] [int] NULL,
	[OriginalAgreementStatusID] [int] NULL,
	[StatusDate] [datetime] NULL,
	[ReclamationStagingContractStatusID] [int] NULL,
	[RequisitionNumber] [int] NULL,
 CONSTRAINT [PK_ReclamationStagingContractTrackingTable_ReclamationStagingContractTrackingTableID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingContractTrackingTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
