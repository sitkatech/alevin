SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliverable](
	[DeliverableID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationDeliverableID] [int] NULL,
	[ReclamationAgreementStatusID] [int] NULL,
	[DeliverableTypeID] [int] NULL,
	[Description] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DueDate] [datetime] NULL,
	[DateDelivered] [datetime] NULL,
	[IsTaskCompleted] [bit] NOT NULL,
	[IsTaskCanceled] [bit] NOT NULL,
	[ReclamationPersonsTableID] [int] NULL,
	[CostAuthorityAgreementID] [int] NULL,
 CONSTRAINT [PK_Deliverable_DeliverableID] PRIMARY KEY CLUSTERED 
(
	[DeliverableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Deliverable]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_CostAuthorityAgreement_CostAuthorityAgreementID] FOREIGN KEY([CostAuthorityAgreementID])
REFERENCES [dbo].[CostAuthorityAgreement] ([CostAuthorityAgreementID])
GO
ALTER TABLE [dbo].[Deliverable] CHECK CONSTRAINT [FK_Deliverable_CostAuthorityAgreement_CostAuthorityAgreementID]
GO
ALTER TABLE [dbo].[Deliverable]  WITH CHECK ADD  CONSTRAINT [FK_Deliverable_DeliverableType_DeliverableTypeID] FOREIGN KEY([DeliverableTypeID])
REFERENCES [dbo].[DeliverableType] ([DeliverableTypeID])
GO
ALTER TABLE [dbo].[Deliverable] CHECK CONSTRAINT [FK_Deliverable_DeliverableType_DeliverableTypeID]