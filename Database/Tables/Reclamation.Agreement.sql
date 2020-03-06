SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[Agreement](
	[AgreementID] [int] IDENTITY(1,1) NOT NULL,
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
 CONSTRAINT [PK_Agreement_AgreementID] PRIMARY KEY CLUSTERED 
(
	[AgreementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[Agreement]  WITH CHECK ADD  CONSTRAINT [FK_Agreement_ContractType_ContractTypeID] FOREIGN KEY([ContractTypeID])
REFERENCES [Reclamation].[ContractType] ([ContractTypeID])
GO
ALTER TABLE [Reclamation].[Agreement] CHECK CONSTRAINT [FK_Agreement_ContractType_ContractTypeID]
GO
ALTER TABLE [Reclamation].[Agreement]  WITH CHECK ADD  CONSTRAINT [FK_Agreement_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [Reclamation].[Agreement] CHECK CONSTRAINT [FK_Agreement_Organization_OrganizationID]