SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationAgreementProject](
	[ReclamationAgreementProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_ReclamationAgreementProject_ReclamationAgreementProjectID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReclamationAgreementProject]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementProject_ProjectID_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ReclamationAgreementProject] CHECK CONSTRAINT [FK_ReclamationAgreementProject_ProjectID_ProjectID]
GO
ALTER TABLE [dbo].[ReclamationAgreementProject]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementProject_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [dbo].[ReclamationAgreement] ([ReclamationAgreementID])
GO
ALTER TABLE [dbo].[ReclamationAgreementProject] CHECK CONSTRAINT [FK_ReclamationAgreementProject_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID]