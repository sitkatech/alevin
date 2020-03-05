SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationAgreement](
	[ReclamationAgreementID] [int] IDENTITY(1,1) NOT NULL,
	[Original_ReclamationAgreementID] [int] NULL,
	[AgreementNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContractorLU] [float] NULL,
	[IsContingent] [bit] NOT NULL,
	[IsIncrementalFunding] [bit] NOT NULL,
	[OldAgreementNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[COR] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TechnicalRepresentative] [float] NULL,
	[BOC] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContractNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ExpirationDate] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FinancialReporting] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OrganizationID] [int] NULL,
	[ContractTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ReclamationAgreement_ReclamationAgreementID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ReclamationAgreement]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreement_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreement] CHECK CONSTRAINT [FK_ReclamationAgreement_Organization_OrganizationID]
GO
ALTER TABLE [Reclamation].[ReclamationAgreement]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreement_ReclamationContractType_ContractTypeID_ReclamationContractTypeID] FOREIGN KEY([ContractTypeID])
REFERENCES [Reclamation].[ReclamationContractType] ([ReclamationContractTypeID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreement] CHECK CONSTRAINT [FK_ReclamationAgreement_ReclamationContractType_ContractTypeID_ReclamationContractTypeID]