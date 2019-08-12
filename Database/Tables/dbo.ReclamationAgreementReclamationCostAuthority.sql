SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationAgreementReclamationCostAuthority](
	[ReclamationAgreementReclamationCostAuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NOT NULL,
	[ReclamationCostAuthorityID] [int] NOT NULL,
 CONSTRAINT [PK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreementReclamationCostAuthorityID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementReclamationCostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReclamationAgreementReclamationCostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [dbo].[ReclamationAgreement] ([ReclamationAgreementID])
GO
ALTER TABLE [dbo].[ReclamationAgreementReclamationCostAuthority] CHECK CONSTRAINT [FK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID]
GO
ALTER TABLE [dbo].[ReclamationAgreementReclamationCostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementReclamationCostAuthority_ReclamationCostAuthorityID_ReclamationCostAuthorityID] FOREIGN KEY([ReclamationCostAuthorityID])
REFERENCES [dbo].[ReclamationCostAuthority] ([ReclamationCostAuthorityID])
GO
ALTER TABLE [dbo].[ReclamationAgreementReclamationCostAuthority] CHECK CONSTRAINT [FK_ReclamationAgreementReclamationCostAuthority_ReclamationCostAuthorityID_ReclamationCostAuthorityID]