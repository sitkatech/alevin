SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[ObligationNumber](
	[ObligationNumberID] [int] IDENTITY(1,1) NOT NULL,
	[ObligationNumberKey] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReclamationAgreementID] [int] NULL,
 CONSTRAINT [PK_ObligationNumber_ObligationNumberID] PRIMARY KEY CLUSTERED 
(
	[ObligationNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ObligationNumber_ObligationNumberKey] UNIQUE NONCLUSTERED 
(
	[ObligationNumberKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ImportFinancial].[ObligationNumber]  WITH CHECK ADD  CONSTRAINT [FK_ObligationNumber_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY([ReclamationAgreementID])
REFERENCES [Reclamation].[Agreement] ([ReclamationAgreementID])
GO
ALTER TABLE [ImportFinancial].[ObligationNumber] CHECK CONSTRAINT [FK_ObligationNumber_ReclamationAgreement_ReclamationAgreementID]