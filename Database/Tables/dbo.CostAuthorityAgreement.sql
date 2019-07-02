SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostAuthorityAgreement](
	[CostAuthorityAgreementID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationCostAuthorityAgreementID] [int] NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostAuthorityNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PacificNorthActivityNumber] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementID] [int] NULL,
	[CostAuthorityID] [int] NULL,
 CONSTRAINT [PK_CostAuthorityAgreement_CostAuthorityAgreementID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityAgreementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CostAuthorityAgreement]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityAgreement_Agreement_AgreementID] FOREIGN KEY([AgreementID])
REFERENCES [dbo].[Agreement] ([AgreementID])
GO
ALTER TABLE [dbo].[CostAuthorityAgreement] CHECK CONSTRAINT [FK_CostAuthorityAgreement_Agreement_AgreementID]
GO
ALTER TABLE [dbo].[CostAuthorityAgreement]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityAgreement_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [dbo].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [dbo].[CostAuthorityAgreement] CHECK CONSTRAINT [FK_CostAuthorityAgreement_CostAuthority_CostAuthorityID]