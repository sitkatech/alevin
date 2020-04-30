SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [ImportFinancial].[WbsElementPnBudget](
	[WbsElementPnBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[WbsElementID] [int] NOT NULL,
	[PnBudgetFundTypeID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[FundsCenter] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FiscalQuarterID] [int] NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[CommitmentItemID] [int] NOT NULL,
	[FIDocNumber] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Recoveries] [float] NULL,
	[CommittedButNotObligated] [float] NULL,
	[TotalObligations] [float] NULL,
	[TotalExpenditures] [float] NULL,
	[UndeliveredOrders] [float] NULL,
 CONSTRAINT [PK_WbsElementPnBudget_WbsElementPnBudgetID] PRIMARY KEY CLUSTERED 
(
	[WbsElementPnBudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID] FOREIGN KEY([CommitmentItemID])
REFERENCES [ImportFinancial].[CommitmentItem] ([CommitmentItemID])
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget] CHECK CONSTRAINT [FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID]
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementPnBudget_FiscalQuarter_FiscalQuarterID] FOREIGN KEY([FiscalQuarterID])
REFERENCES [ImportFinancial].[FiscalQuarter] ([FiscalQuarterID])
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget] CHECK CONSTRAINT [FK_WbsElementPnBudget_FiscalQuarter_FiscalQuarterID]
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementPnBudget_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget] CHECK CONSTRAINT [FK_WbsElementPnBudget_FundingSource_FundingSourceID]
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementPnBudget_PnBudgetFundType_PnBudgetFundTypeID] FOREIGN KEY([PnBudgetFundTypeID])
REFERENCES [ImportFinancial].[PnBudgetFundType] ([PnBudgetFundTypeID])
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget] CHECK CONSTRAINT [FK_WbsElementPnBudget_PnBudgetFundType_PnBudgetFundTypeID]
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget]  WITH CHECK ADD  CONSTRAINT [FK_WbsElementPnBudget_WbsElement_WbsElementID] FOREIGN KEY([WbsElementID])
REFERENCES [ImportFinancial].[WbsElement] ([WbsElementID])
GO
ALTER TABLE [ImportFinancial].[WbsElementPnBudget] CHECK CONSTRAINT [FK_WbsElementPnBudget_WbsElement_WbsElementID]