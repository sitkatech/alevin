SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[AgreementCostAuthority](
	[AgreementCostAuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[AgreementID] [int] NOT NULL,
	[CostAuthorityID] [int] NOT NULL,
 CONSTRAINT [PK_AgreementReclamationCostAuthority_ReclamationAgreementReclamationCostAuthorityID] PRIMARY KEY CLUSTERED 
(
	[AgreementCostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AgreementReclamationCostAuthority_ReclamationAgreementID_ReclamationCostAuthorityID] UNIQUE NONCLUSTERED 
(
	[AgreementID] ASC,
	[CostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[AgreementCostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_AgreementReclamationCostAuthority_Agreement_ReclamationAgreementID] FOREIGN KEY([AgreementID])
REFERENCES [Reclamation].[Agreement] ([AgreementID])
GO
ALTER TABLE [Reclamation].[AgreementCostAuthority] CHECK CONSTRAINT [FK_AgreementReclamationCostAuthority_Agreement_ReclamationAgreementID]
GO
ALTER TABLE [Reclamation].[AgreementCostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_AgreementReclamationCostAuthority_CostAuthority_ReclamationCostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [Reclamation].[AgreementCostAuthority] CHECK CONSTRAINT [FK_AgreementReclamationCostAuthority_CostAuthority_ReclamationCostAuthorityID]