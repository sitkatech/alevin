SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationAgreementPacificNorthActivity](
	[ReclamationAgreementPacificNorthActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NOT NULL,
	[ReclamationPacificNorthActivityListID] [int] NOT NULL,
 CONSTRAINT [PK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementPacificNorthActivityID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementPacificNorthActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementID_ReclamationPacificNorthActivityListID] UNIQUE NONCLUSTERED 
(
	[ReclamationAgreementID] ASC,
	[ReclamationPacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ReclamationAgreementPacificNorthActivity]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [Reclamation].[ReclamationAgreement] ([ReclamationAgreementID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreementPacificNorthActivity] CHECK CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationAgreement_ReclamationAgreementID]
GO
ALTER TABLE [Reclamation].[ReclamationAgreementPacificNorthActivity]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityListID] FOREIGN KEY([ReclamationPacificNorthActivityListID])
REFERENCES [Reclamation].[ReclamationPacificNorthActivityList] ([ReclamationPacificNorthActivityListID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreementPacificNorthActivity] CHECK CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityListID]