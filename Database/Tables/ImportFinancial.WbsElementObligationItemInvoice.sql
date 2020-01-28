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
 CONSTRAINT [PK_WbsElementObligationItemInvoice_WbsElementObligationItemInvoiceID] PRIMARY KEY CLUSTERED 
(
	[WbsElementObligationItemInvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

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