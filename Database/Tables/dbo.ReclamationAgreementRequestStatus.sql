SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationAgreementRequestStatus](
	[ReclamationAgreementRequestStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementRequestStatusName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementRequestStatusDisplayName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationAgreementRequestStatus_ReclamationAgreementRequestStatusID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementRequestStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
