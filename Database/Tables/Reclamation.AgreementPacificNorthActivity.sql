SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[AgreementPacificNorthActivity](
	[AgreementPacificNorthActivityID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NOT NULL,
	[ReclamationPacificNorthActivityListID] [int] NOT NULL,
 CONSTRAINT [PK_AgreementPacificNorthActivity_AgreementPacificNorthActivityID] PRIMARY KEY CLUSTERED 
(
	[AgreementPacificNorthActivityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_AgreementPacificNorthActivity_ReclamationAgreementID_ReclamationPacificNorthActivityListID] UNIQUE NONCLUSTERED 
(
	[ReclamationAgreementID] ASC,
	[ReclamationPacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[AgreementPacificNorthActivity]  WITH CHECK ADD  CONSTRAINT [FK_AgreementPacificNorthActivity_Agreement_ReclamationAgreementID_AgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [Reclamation].[Agreement] ([AgreementID])
GO
ALTER TABLE [Reclamation].[AgreementPacificNorthActivity] CHECK CONSTRAINT [FK_AgreementPacificNorthActivity_Agreement_ReclamationAgreementID_AgreementID]
GO
ALTER TABLE [Reclamation].[AgreementPacificNorthActivity]  WITH CHECK ADD  CONSTRAINT [FK_AgreementPacificNorthActivity_PacificNorthActivityList_ReclamationPacificNorthActivityListID_PacificNorthActivityListID] FOREIGN KEY([ReclamationPacificNorthActivityListID])
REFERENCES [Reclamation].[PacificNorthActivityList] ([PacificNorthActivityListID])
GO
ALTER TABLE [Reclamation].[AgreementPacificNorthActivity] CHECK CONSTRAINT [FK_AgreementPacificNorthActivity_PacificNorthActivityList_ReclamationPacificNorthActivityListID_PacificNorthActivityListID]