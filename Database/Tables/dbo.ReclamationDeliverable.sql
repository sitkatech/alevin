SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationDeliverable](
	[ReclamationDeliverableID] [int] IDENTITY(1,1) NOT NULL,
	[Original_ReclamationDeliverableID] [int] NULL,
	[ReclamationAgreementStatusID] [int] NULL,
	[DeliverableTypeID] [int] NULL,
	[Description] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DueDate] [datetime] NULL,
	[DateDelivered] [datetime] NULL,
	[IsTaskCompleted] [bit] NOT NULL,
	[IsTaskCanceled] [bit] NOT NULL,
	[ReclamationPersonsTableID] [int] NULL,
	[CostAuthorityAgreementID] [int] NULL,
 CONSTRAINT [PK_ReclamationDeliverable_ReclamationDeliverableID] PRIMARY KEY CLUSTERED 
(
	[ReclamationDeliverableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReclamationDeliverable]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationDeliverable_ReclamationDeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID] FOREIGN KEY([DeliverableTypeID])
REFERENCES [dbo].[ReclamationDeliverableType] ([ReclamationDeliverableTypeID])
GO
ALTER TABLE [dbo].[ReclamationDeliverable] CHECK CONSTRAINT [FK_ReclamationDeliverable_ReclamationDeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID]
GO
ALTER TABLE [dbo].[ReclamationDeliverable]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationDeliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgree] FOREIGN KEY([CostAuthorityAgreementID])
REFERENCES [dbo].[ReclamationStagingCostAuthorityAgreement] ([ReclamationStagingCostAuthorityAgreementID])
GO
ALTER TABLE [dbo].[ReclamationDeliverable] CHECK CONSTRAINT [FK_ReclamationDeliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgree]