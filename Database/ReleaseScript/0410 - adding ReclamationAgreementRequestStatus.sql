

CREATE TABLE [dbo].[ReclamationAgreementRequestStatus](
	[ReclamationAgreementRequestStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementRequestStatusName] [varchar](255) NULL,
	[AgreementRequestStatusDisplayName] [varchar](255) NULL,
 CONSTRAINT [PK_ReclamationAgreementRequestStatus_ReclamationAgreementRequestStatusID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementRequestStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[ReclamationAgreementRequestFundingPriority](
	[ReclamationAgreementRequestFundingPriorityID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationAgreementRequestFundingPriorityName] [varchar](255) NULL,
	[AgreementRequestFundingPriorityDisplayName] [varchar](255) NULL,
 CONSTRAINT [PK_ReclamationAgreementRequestFundingPriority_ReclamationAgreementRequestFundingPriorityID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementRequestFundingPriorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

