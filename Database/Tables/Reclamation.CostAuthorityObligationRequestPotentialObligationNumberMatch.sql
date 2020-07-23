SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthorityObligationRequestPotentialObligationNumberMatch](
	[CostAuthorityObligationRequestPotentialObligationNumberMatchID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityObligationRequestID] [int] NOT NULL,
	[ObligationNumberID] [int] NOT NULL,
 CONSTRAINT [PK_CostAuthorityObligationRequestPotentialObligationNumberMatch_CostAuthorityObligationRequestPotentialObligationNumberMatchID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityObligationRequestPotentialObligationNumberMatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CostAuthorityObligationRequestPotentialObligationNumberMatch_CostAuthorityObligationRequestID_ObligationNumberID] UNIQUE NONCLUSTERED 
(
	[CostAuthorityObligationRequestID] ASC,
	[ObligationNumberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
