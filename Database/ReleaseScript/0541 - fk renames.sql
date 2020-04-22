
/****** Object:  Index [PK_AgreementRequestSubmissionNote_AgreementRequestSubmissionNoteID]    Script Date: 4/22/2020 10:22:46 AM ******/
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] DROP CONSTRAINT [PK_AgreementRequestSubmissionNote_AgreementRequestSubmissionNoteID] WITH ( ONLINE = OFF )
GO

/****** Object:  Index [PK_AgreementRequestSubmissionNote_AgreementRequestSubmissionNoteID]    Script Date: 4/22/2020 10:22:46 AM ******/
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] ADD  CONSTRAINT [PK_ObligationRequestSubmissionNote_ObligationRequestSubmissionNoteID] PRIMARY KEY CLUSTERED 
(
	[ObligationRequestSubmissionNoteID] ASC
)



ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] DROP CONSTRAINT [FK_AgreementRequestSubmissionNote_AgreementRequest_ReclamationAgreementRequestID_AgreementRequestID]
GO

ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ObligationRequestSubmissionNote_ObligationRequest_ObligationRequestID] FOREIGN KEY([ObligationRequestID])
REFERENCES [Reclamation].[ObligationRequest] ([ObligationRequestID])
GO


ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] DROP CONSTRAINT [FK_AgreementRequestSubmissionNote_Person_CreatePersonID_PersonID]
GO

ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ObligationRequestSubmissionNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO


ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] DROP CONSTRAINT [FK_AgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID]
GO

ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ObligationRequestSubmissionNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO



/****** Object:  Index [PK_CostAuthorityAgreementRequest_CostAuthorityAgreementRequestID]    Script Date: 4/22/2020 10:35:35 AM ******/
ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] DROP CONSTRAINT [PK_CostAuthorityAgreementRequest_CostAuthorityAgreementRequestID] WITH ( ONLINE = OFF )
GO

/****** Object:  Index [PK_CostAuthorityAgreementRequest_CostAuthorityAgreementRequestID]    Script Date: 4/22/2020 10:35:35 AM ******/
ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] ADD  CONSTRAINT [PK_CostAuthorityObligationRequest_CostAuthorityObligationRequestID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityObligationRequestID] ASC
)


ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] DROP CONSTRAINT [FK_CostAuthorityAgreementRequest_AgreementRequest_AgreementRequestID]
GO

ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_ObligationRequest_ObligationRequestID] FOREIGN KEY([ObligationRequestID])
REFERENCES [Reclamation].[ObligationRequest] ([ObligationRequestID])
GO

ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] DROP CONSTRAINT [FK_CostAuthorityAgreementRequest_CostAuthority_CostAuthorityID]
GO

ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO




