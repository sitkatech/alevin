SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agreement](
	[AgreementID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NULL,
	[AgreementNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContractorLU] [float] NULL,
	[ContractType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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
 CONSTRAINT [PK_Agreement_AgreementID] PRIMARY KEY CLUSTERED 
(
	[AgreementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Agreement]  WITH CHECK ADD  CONSTRAINT [FK_Agreement_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[Agreement] CHECK CONSTRAINT [FK_Agreement_Organization_OrganizationID]