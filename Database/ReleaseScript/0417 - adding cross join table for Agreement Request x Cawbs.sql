
CREATE TABLE [dbo].[ReclamationCostAuthorityAgreementRequest](
	[ReclamationCostAuthorityAgreementRequestID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityID] [int] NOT NULL,
    [AgreementRequestID] [int] NOT NULL,
    [ProjectedObligation] money,
	[ReclamationCostAuthorityAgreementRequestNote] varchar(800) null


 CONSTRAINT [PK_ReclamationCostAuthorityAgreementRequest_ReclamationCostAuthorityAgreementRequestID] PRIMARY KEY CLUSTERED 
(
	[ReclamationCostAuthorityAgreementRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ReclamationCostAuthorityAgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthorityAgreementRequest_ReclamationAgreementRequest_AgreementRequestID_ReclamationAgreementRequestID] FOREIGN KEY([AgreementRequestID])
REFERENCES [dbo].[ReclamationAgreementRequest] ([ReclamationAgreementRequestID])
GO

ALTER TABLE [dbo].[ReclamationCostAuthorityAgreementRequest] CHECK CONSTRAINT [FK_ReclamationCostAuthorityAgreementRequest_ReclamationAgreementRequest_AgreementRequestID_ReclamationAgreementRequestID]
GO

ALTER TABLE [dbo].[ReclamationCostAuthorityAgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthorityAgreementRequest_ReclamationCostAuthority_CostAuthorityID_ReclamationCostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [dbo].[ReclamationCostAuthority] ([ReclamationCostAuthorityID])
GO

ALTER TABLE [dbo].[ReclamationCostAuthorityAgreementRequest] CHECK CONSTRAINT [FK_ReclamationCostAuthorityAgreementRequest_ReclamationCostAuthority_CostAuthorityID_ReclamationCostAuthorityID]
GO

