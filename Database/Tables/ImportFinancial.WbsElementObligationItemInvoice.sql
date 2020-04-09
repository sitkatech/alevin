SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[WbsElementObligationItemInvoice](
	[WbsElementObligationItemInvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[WbsElementID] [int] NOT NULL,
	[ObligationItemID] [int] NOT NULL,
	[DebitAmount] [float] NULL,
	[CreditAmount] [float] NULL,
	[DebitCreditTotal] [float] NULL,
	[CostAuthorityID] [int] NOT NULL,
	[CreatedOnKey] [datetime] NULL,
	[PostingDateKey] [datetime] NULL,
	[BudgetObjectCodeID] [int] NULL,
	[FundID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
 CONSTRAINT [PK_WbsElementObligationItemInvoice_WbsElementObligationItemInvoiceID] PRIMARY KEY CLUSTERED 
(
	[WbsElementObligationItemInvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemInvoice_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY([BudgetObjectCodeID])
REFERENCES [Reclamation].[BudgetObjectCode] ([BudgetObjectCodeID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice] CHECK CONSTRAINT [FK_WbsElementObligationItemInvoice_BudgetObjectCode_BudgetObjectCodeID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemInvoice_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice] CHECK CONSTRAINT [FK_WbsElementObligationItemInvoice_CostAuthority_CostAuthorityID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemInvoice_Fund_FundID] FOREIGN KEY([FundID])
REFERENCES [Reclamation].[Fund] ([FundID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice] CHECK CONSTRAINT [FK_WbsElementObligationItemInvoice_Fund_FundID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemInvoice_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice] CHECK CONSTRAINT [FK_WbsElementObligationItemInvoice_FundingSource_FundingSourceID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemInvoice_ObligationItem_ObligationItemID] FOREIGN KEY([ObligationItemID])
REFERENCES [ImportFinancial].[ObligationItem] ([ObligationItemID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice] CHECK CONSTRAINT [FK_WbsElementObligationItemInvoice_ObligationItem_ObligationItemID]
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementObligationItemInvoice_WbsElement_WbsElementID] FOREIGN KEY([WbsElementID])
REFERENCES [ImportFinancial].[WbsElement] ([WbsElementID])
GO
ALTER TABLE [ImportFinancial].[WbsElementObligationItemInvoice] CHECK CONSTRAINT [FK_WbsElementObligationItemInvoice_WbsElement_WbsElementID]