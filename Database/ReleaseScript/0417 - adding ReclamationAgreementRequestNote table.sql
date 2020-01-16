--begin tran

CREATE TABLE [dbo].[ReclamationAgreementRequestSubmissionNote](
	[ReclamationAgreementRequestSubmissionNoteID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementRequestID] [int] NOT NULL,
	[Note] [varchar](8000) NOT NULL,
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

ALTER TABLE [dbo].[ReclamationAgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[ReclamationAgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_CreatePersonID_PersonID]
GO

ALTER TABLE [dbo].[ReclamationAgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[ReclamationAgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_Person_UpdatePersonID_PersonID]
GO

ALTER TABLE [dbo].[ReclamationAgreementRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_ReclamationAgreementRequest_ReclamationAgreementRequestID] FOREIGN KEY([ReclamationAgreementRequestID])
REFERENCES [dbo].[ReclamationAgreementRequest] ([ReclamationAgreementRequestID])
GO

ALTER TABLE [dbo].[ReclamationAgreementRequestSubmissionNote] CHECK CONSTRAINT [FK_ReclamationAgreementRequestSubmissionNote_ReclamationAgreementRequest_ReclamationAgreementRequestID]
GO

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10030,N'AgreementRequestSubmissionNote', N'Submission Note')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10030,N'Agreement Request Submission Note')

 go



--rollback tran