SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationStagingCostAuthorityAgreement](
	[ReclamationStagingCostAuthorityAgreementID] [int] IDENTITY(1,1) NOT NULL,
	[OriginalReclamationCostAuthorityAgreementID] [int] NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostAuthorityNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PacificNorthActivityNumber] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementID] [int] NULL,
	[CostAuthorityID] [int] NULL,
 CONSTRAINT [PK_ReclamationStagingCostAuthorityAgreement_ReclamationStagingCostAuthorityAgreementID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingCostAuthorityAgreementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ReclamationStagingCostAuthorityAgreement]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationStagingCostAuthorityAgreement_Agreement_AgreementID] FOREIGN KEY([AgreementID])
REFERENCES [Reclamation].[Agreement] ([AgreementID])
GO
ALTER TABLE [Reclamation].[ReclamationStagingCostAuthorityAgreement] CHECK CONSTRAINT [FK_ReclamationStagingCostAuthorityAgreement_Agreement_AgreementID]
GO
ALTER TABLE [Reclamation].[ReclamationStagingCostAuthorityAgreement]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationStagingCostAuthorityAgreement_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [Reclamation].[ReclamationStagingCostAuthorityAgreement] CHECK CONSTRAINT [FK_ReclamationStagingCostAuthorityAgreement_CostAuthority_CostAuthorityID]