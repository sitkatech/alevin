SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote](
	[ReclamationAgreementRequestSubmissionNoteID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementRequestID] [int] NOT NULL,
	[Note] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ReclamationAgreementRequestSubmissionNote_ReclamationAgreementRequestSubmissionNoteID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementRequestSubmissionNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID]
GO
ALTER TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_ReclamationAgreementRequest_ReclamationAgreementRequestID] FOREIGN KEY([ReclamationAgreementRequestID])
REFERENCES [Reclamation].[ReclamationAgreementRequest] ([ReclamationAgreementRequestID])
GO
ALTER TABLE [Reclamation].[ReclamationAgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_ReclamationAgreementRequest_ReclamationAgreementRequestID]