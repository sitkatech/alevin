SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ObligationRequestSubmissionNote](
	[ObligationRequestSubmissionNoteID] [int] IDENTITY(1,1) NOT NULL,
	[ObligationRequestID] [int] NOT NULL,
	[Note] [varchar](8000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_ObligationRequestSubmissionNote_ObligationRequestSubmissionNoteID] PRIMARY KEY CLUSTERED 
(
	[ObligationRequestSubmissionNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ObligationRequestSubmissionNote_ObligationRequest_ObligationRequestID] FOREIGN KEY([ObligationRequestID])
REFERENCES [Reclamation].[ObligationRequest] ([ObligationRequestID])
GO
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] CHECK CONSTRAINT [FK_ObligationRequestSubmissionNote_ObligationRequest_ObligationRequestID]
GO
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ObligationRequestSubmissionNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] CHECK CONSTRAINT [FK_ObligationRequestSubmissionNote_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote]  WITH CHECK ADD  CONSTRAINT [FK_ObligationRequestSubmissionNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[ObligationRequestSubmissionNote] CHECK CONSTRAINT [FK_ObligationRequestSubmissionNote_Person_UpdatePersonID_PersonID]