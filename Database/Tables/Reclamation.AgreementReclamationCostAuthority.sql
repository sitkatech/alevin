SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[AgreementReclamationCostAuthority](
	[ReclamationAgreementReclamationCostAuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NOT NULL,
	[ReclamationCostAuthorityID] [int] NOT NULL,
 CONSTRAINT [PK_AgreementReclamationCostAuthority_ReclamationAgreementReclamationCostAuthorityID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementReclamationCostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_AgreementReclamationCostAuthority_ReclamationAgreementID_ReclamationCostAuthorityID] UNIQUE NONCLUSTERED 
(
	[ReclamationAgreementID] ASC,
	[ReclamationCostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[AgreementReclamationCostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_AgreementReclamationCostAuthority_Agreement_ReclamationAgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [Reclamation].[Agreement] ([ReclamationAgreementID])
GO
ALTER TABLE [Reclamation].[AgreementReclamationCostAuthority] CHECK CONSTRAINT [FK_AgreementReclamationCostAuthority_Agreement_ReclamationAgreementID]
GO
ALTER TABLE [Reclamation].[AgreementReclamationCostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_AgreementReclamationCostAuthority_CostAuthority_ReclamationCostAuthorityID] FOREIGN KEY([ReclamationCostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([ReclamationCostAuthorityID])
GO
ALTER TABLE [Reclamation].[AgreementReclamationCostAuthority] CHECK CONSTRAINT [FK_AgreementReclamationCostAuthority_CostAuthority_ReclamationCostAuthorityID]