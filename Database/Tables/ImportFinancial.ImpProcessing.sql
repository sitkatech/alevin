SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[ImpProcessing](
	[ImpProcessingID] [int] IDENTITY(1,1) NOT NULL,
	[ImpProcessingTableTypeID] [int] NOT NULL,
	[UploadDate] [datetime] NULL,
	[LastProcessedDate] [datetime] NULL,
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