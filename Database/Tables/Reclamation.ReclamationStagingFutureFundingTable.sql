SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationStagingFutureFundingTable](
	[ReclamationStagingFutureFundingTableID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalContractTrackingID] [int] NULL,
	[OriginalReclamationCostAuthorityAgreementID] [int] NULL,
	[PlannedFundingYear] [int] NULL,
	[ExpectedAmt] [money] NULL,
	[AwardAmt] [money] NULL,
	[AwardYear] [float] NULL,
	[IsFunded] [bit] NOT NULL,
	[ContingencyYear] [int] NULL,
	[Notes] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationStagingFutureFundingTable_ReclamationStagingFutureFundingTableID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingFutureFundingTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
