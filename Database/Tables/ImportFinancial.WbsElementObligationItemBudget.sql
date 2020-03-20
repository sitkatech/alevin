SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[WbsElementObligationItemBudget](
	[WbsElementObligationItemBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[WbsElementID] [int] NOT NULL,
	[ObligationItemID] [int] NOT NULL,
	[Obligation] [float] NULL,
	[GoodsReceipt] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Invoiced] [float] NULL,
	[Disbursed] [float] NULL,
	[UnexpendedBalance] [float] NULL,
	[CostAuthorityID] [int] NOT NULL,
	[CreatedOnKey] [datetime] NULL,
	[DateOfUpdateKey] [datetime] NULL,
	[PostingDateKey] [datetime] NULL,
	[PostingDatePerSplKey] [datetime] NULL,
	[DocumentDateOfBlKey] [datetime] NULL,
	[BudgetObjectCodeID] [int] NULL,
	[FundID] [int] NOT NULL,
 CONSTRAINT [PK_WbsElementObligationItemBudget_WbsElementObligationItemBudgetID] PRIMARY KEY CLUSTERED 
(
	[WbsElementObligationItemBudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemBudget_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY([BudgetObjectCodeID])
REFERENCES [Reclamation].[BudgetObjectCode] ([BudgetObjectCodeID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget] CHECK CONSTRAINT [FK_WbsElementObligationItemBudget_BudgetObjectCode_BudgetObjectCodeID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemBudget_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget] CHECK CONSTRAINT [FK_WbsElementObligationItemBudget_CostAuthority_CostAuthorityID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemBudget_Fund_FundID] FOREIGN KEY([FundID])
REFERENCES [Reclamation].[Fund] ([FundID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget] CHECK CONSTRAINT [FK_WbsElementObligationItemBudget_Fund_FundID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemBudget_ObligationItem_ObligationItemID] FOREIGN KEY([ObligationItemID])
REFERENCES [ImportFinancial].[ObligationItem] ([ObligationItemID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget] CHECK CONSTRAINT [FK_WbsElementObligationItemBudget_ObligationItem_ObligationItemID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemBudget_WbsElement_WbsElementID] FOREIGN KEY([WbsElementID])
REFERENCES [ImportFinancial].[WbsElement] ([WbsElementID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemBudget] CHECK CONSTRAINT [FK_WbsElementObligationItemBudget_WbsElement_WbsElementID]