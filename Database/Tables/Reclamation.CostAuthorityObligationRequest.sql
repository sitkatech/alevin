SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthorityObligationRequest](
	[CostAuthorityObligationRequestID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityID] [int] NOT NULL,
	[ObligationRequestID] [int] NOT NULL,
	[ProjectedObligation] [money] NULL,
	[CostAuthorityObligationRequestNote] [varchar](800) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_CostAuthorityObligationRequest_CostAuthorityObligationRequestID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityObligationRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] CHECK CONSTRAINT [FK_CostAuthorityObligationRequest_CostAuthority_CostAuthorityID]
GO
ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_ObligationRequest_ObligationRequestID] FOREIGN KEY([ObligationRequestID])
REFERENCES [Reclamation].[ObligationRequest] ([ObligationRequestID])
GO
ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] CHECK CONSTRAINT [FK_CostAuthorityObligationRequest_ObligationRequest_ObligationRequestID]