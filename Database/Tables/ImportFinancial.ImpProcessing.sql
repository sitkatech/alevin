SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[ImpProcessing](
	[ImpProcessingID] [int] IDENTITY(1,1) NOT NULL,
	[ImpProcessingTableTypeID] [int] NOT NULL,
	[UploadDate] [datetime] NULL,
	[UploadPersonID] [int] NULL,
	[UploadedFiscalYears] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastProcessedDate] [datetime] NULL,
	[LastProcessedPersonID] [int] NULL,
 CONSTRAINT [PK_ImpProcessing_ImpProcessingID] PRIMARY KEY CLUSTERED 
(
	[ImpProcessingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ImportFinancial].[ImpProcessing]  WITH CHECK ADD  CONSTRAINT [FK_ImpProcessing_ImpProcessingTableType_ImpProcessingTableTypeID] FOREIGN KEY([ImpProcessingTableTypeID])
REFERENCES [ImportFinancial].[ImpProcessingTableType] ([ImpProcessingTableTypeID])
GO
ALTER TABLE [ImportFinancial].[ImpProcessing] CHECK CONSTRAINT [FK_ImpProcessing_ImpProcessingTableType_ImpProcessingTableTypeID]
GO
ALTER TABLE [ImportFinancial].[ImpProcessing]  WITH CHECK ADD  CONSTRAINT [FK_ImpProcessing_Person_LastProcessedPersonID_PersonID] FOREIGN KEY([LastProcessedPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [ImportFinancial].[ImpProcessing] CHECK CONSTRAINT [FK_ImpProcessing_Person_LastProcessedPersonID_PersonID]
GO
ALTER TABLE [ImportFinancial].[ImpProcessing]  WITH CHECK ADD  CONSTRAINT [FK_ImpProcessing_Person_UploadPersonID_PersonID] FOREIGN KEY([UploadPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [ImportFinancial].[ImpProcessing] CHECK CONSTRAINT [FK_ImpProcessing_Person_UploadPersonID_PersonID]