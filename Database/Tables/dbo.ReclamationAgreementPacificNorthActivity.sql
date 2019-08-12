SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationAgreementPacificNorthActivity](
	[ReclamationAgreementPacificNorthActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NOT NULL,
	[ReclamationPacificNorthActivityListID] [int] NOT NULL,
 CONSTRAINT [PK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementPacificNorthActivityID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementPacificNorthActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReclamationAgreementPacificNorthActivity]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [dbo].[ReclamationAgreement] ([ReclamationAgreementID])
GO
ALTER TABLE [dbo].[ReclamationAgreementPacificNorthActivity] CHECK CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID]
GO
ALTER TABLE [dbo].[ReclamationAgreementPacificNorthActivity]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationPacificNorthActivityListID_ReclamationPacificNorthActivityListID] FOREIGN KEY([ReclamationPacificNorthActivityListID])
REFERENCES [dbo].[ReclamationPacificNorthActivityList] ([ReclamationPacificNorthActivityListID])
GO
ALTER TABLE [dbo].[ReclamationAgreementPacificNorthActivity] CHECK CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationPacificNorthActivityListID_ReclamationPacificNorthActivityListID]