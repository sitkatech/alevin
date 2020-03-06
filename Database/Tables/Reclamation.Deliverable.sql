SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[Deliverable](
	[DeliverableID] [int] IDENTITY(1,1) NOT NULL,
	[DeliverableTypeID] [int] NULL,
	[Description] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DueDate] [datetime] NULL,
	[DateDelivered] [datetime] NULL,
	[IsTaskCompleted] [bit] NOT NULL,
	[IsTaskCanceled] [bit] NOT NULL,
	[CostAuthorityAgreementID] [int] NULL,
	[ReclamationStagingAgreementStatusTableID] [int] NULL,
	[PersonID] [int] NULL,
 CONSTRAINT [PK_Deliverable_ReclamationDeliverableID] PRIMARY KEY CLUSTERED 
(
	[DeliverableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[Deliverable]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_DeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID] FOREIGN KEY([DeliverableTypeID])
REFERENCES [Reclamation].[DeliverableType] ([DeliverableTypeID])
GO
ALTER TABLE [Reclamation].[Deliverable] CHECK CONSTRAINT [FK_Deliverable_DeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID]
GO
ALTER TABLE [Reclamation].[Deliverable]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[Deliverable] CHECK CONSTRAINT [FK_Deliverable_Person_PersonID]
GO
ALTER TABLE [Reclamation].[Deliverable]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_ReclamationStagingAgreementStatusTable_ReclamationStagingAgreementStatusTableID] FOREIGN KEY([ReclamationStagingAgreementStatusTableID])
REFERENCES [Reclamation].[ReclamationStagingAgreementStatusTable] ([ReclamationStagingAgreementStatusTableID])
GO
ALTER TABLE [Reclamation].[Deliverable] CHECK CONSTRAINT [FK_Deliverable_ReclamationStagingAgreementStatusTable_ReclamationStagingAgreementStatusTableID]
GO
ALTER TABLE [Reclamation].[Deliverable]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgreementID] FOREIGN KEY([CostAuthorityAgreementID])
REFERENCES [Reclamation].[ReclamationStagingCostAuthorityAgreement] ([ReclamationStagingCostAuthorityAgreementID])
GO
ALTER TABLE [Reclamation].[Deliverable] CHECK CONSTRAINT [FK_Deliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgreementID]