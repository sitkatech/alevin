SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[AgreementRequestSubmissionNote](
	[AgreementRequestSubmissionNoteID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementRequestID] [int] NOT NULL,
	[Note] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_AgreementRequestSubmissionNote_ReclamationAgreementRequestSubmissionNoteID] PRIMARY KEY CLUSTERED 
(
	[AgreementRequestSubmissionNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[AgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequestSubmissionNote_AgreementRequest_ReclamationAgreementRequestID] FOREIGN KEY([ReclamationAgreementRequestID])
REFERENCES [Reclamation].[AgreementRequest] ([AgreementRequestID])
GO
ALTER TABLE [Reclamation].[AgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_AgreementRequestSubmissionNote_AgreementRequest_ReclamationAgreementRequestID]
GO
ALTER TABLE [Reclamation].[AgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequestSubmissionNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[AgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_AgreementRequestSubmissionNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [Reclamation].[AgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[AgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_AgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID]