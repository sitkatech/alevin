SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthorityAgreementRequest](
	[CostAuthorityAgreementRequestID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityID] [int] NOT NULL,
	[AgreementRequestID] [int] NOT NULL,
	[ProjectedObligation] [money] NULL,
	[ReclamationCostAuthorityAgreementRequestNote] [varchar](800) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_CostAuthorityAgreementRequest_CostAuthorityAgreementRequestID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityAgreementRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[CostAuthorityAgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityAgreementRequest_AgreementRequest_AgreementRequestID] FOREIGN KEY([AgreementRequestID])
REFERENCES [Reclamation].[AgreementRequest] ([AgreementRequestID])
GO
ALTER TABLE [Reclamation].[CostAuthorityAgreementRequest] CHECK CONSTRAINT [FK_CostAuthorityAgreementRequest_AgreementRequest_AgreementRequestID]
GO
ALTER TABLE [Reclamation].[CostAuthorityAgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityAgreementRequest_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [Reclamation].[CostAuthorityAgreementRequest] CHECK CONSTRAINT [FK_CostAuthorityAgreementRequest_CostAuthority_CostAuthorityID]