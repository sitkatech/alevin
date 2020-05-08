GO
ALTER TABLE ImportFinancial.WbsElementPnBudget
	DROP CONSTRAINT FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID
GO
ALTER TABLE ImportFinancial.CommitmentItem SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget
	DROP CONSTRAINT FK_WbsElementPnBudget_FiscalQuarter_FiscalQuarterID
GO
ALTER TABLE ImportFinancial.FiscalQuarter SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget
	DROP CONSTRAINT FK_WbsElementPnBudget_FundingSource_FundingSourceID
GO
ALTER TABLE dbo.FundingSource SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget
	DROP CONSTRAINT FK_WbsElementPnBudget_PnBudgetFundType_PnBudgetFundTypeID
GO
ALTER TABLE ImportFinancial.PnBudgetFundType SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget
	DROP CONSTRAINT FK_WbsElementPnBudgett_CostAuthority_CostAuthorityID
GO
ALTER TABLE Reclamation.CostAuthority SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget
	DROP CONSTRAINT FK_WbsElementPnBudget_WbsElement_WbsElementID
GO
ALTER TABLE ImportFinancial.WbsElement SET (LOCK_ESCALATION = TABLE)
GO
CREATE TABLE ImportFinancial.Tmp_WbsElementPnBudget
	(
	WbsElementPnBudgetID int NOT NULL IDENTITY (1, 1),
	WbsElementID int NOT NULL,
	CostAuthorityID int NULL,
	PnBudgetFundTypeID int NOT NULL,
	FundingSourceID int NOT NULL,
	FundsCenter varchar(10) NOT NULL,
	FiscalQuarterID int NOT NULL,
	FiscalYear int NOT NULL,
	CommitmentItemID int NULL,
	BudgetObjectCodeID int NULL,
	FIDocNumber varchar(200) NOT NULL,
	Recoveries float(53) NULL,
	CommittedButNotObligated float(53) NULL,
	TotalObligations float(53) NULL,
	TotalExpenditures float(53) NULL,
	UndeliveredOrders float(53) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ImportFinancial.Tmp_WbsElementPnBudget SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT ImportFinancial.Tmp_WbsElementPnBudget ON
GO
IF EXISTS(SELECT * FROM ImportFinancial.WbsElementPnBudget)
	 EXEC('INSERT INTO ImportFinancial.Tmp_WbsElementPnBudget (WbsElementPnBudgetID, WbsElementID, CostAuthorityID, PnBudgetFundTypeID, FundingSourceID, FundsCenter, FiscalQuarterID, FiscalYear, CommitmentItemID, FIDocNumber, Recoveries, CommittedButNotObligated, TotalObligations, TotalExpenditures, UndeliveredOrders)
		SELECT WbsElementPnBudgetID, WbsElementID, CostAuthorityID, PnBudgetFundTypeID, FundingSourceID, FundsCenter, FiscalQuarterID, FiscalYear, CommitmentItemID, FIDocNumber, Recoveries, CommittedButNotObligated, TotalObligations, TotalExpenditures, UndeliveredOrders FROM ImportFinancial.WbsElementPnBudget WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT ImportFinancial.Tmp_WbsElementPnBudget OFF
GO
DROP TABLE ImportFinancial.WbsElementPnBudget
GO
EXECUTE sp_rename N'ImportFinancial.Tmp_WbsElementPnBudget', N'WbsElementPnBudget', 'OBJECT' 
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	PK_WbsElementPnBudget_WbsElementPnBudgetID PRIMARY KEY CLUSTERED 
	(
	WbsElementPnBudgetID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	FK_WbsElementPnBudget_WbsElement_WbsElementID FOREIGN KEY
	(
	WbsElementID
	) REFERENCES ImportFinancial.WbsElement
	(
	WbsElementID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	FK_WbsElementPnBudgett_CostAuthority_CostAuthorityID FOREIGN KEY
	(
	CostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	FK_WbsElementPnBudget_PnBudgetFundType_PnBudgetFundTypeID FOREIGN KEY
	(
	PnBudgetFundTypeID
	) REFERENCES ImportFinancial.PnBudgetFundType
	(
	PnBudgetFundTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	FK_WbsElementPnBudget_FundingSource_FundingSourceID FOREIGN KEY
	(
	FundingSourceID
	) REFERENCES dbo.FundingSource
	(
	FundingSourceID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	FK_WbsElementPnBudget_FiscalQuarter_FiscalQuarterID FOREIGN KEY
	(
	FiscalQuarterID
	) REFERENCES ImportFinancial.FiscalQuarter
	(
	FiscalQuarterID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementPnBudget ADD CONSTRAINT
	FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID FOREIGN KEY
	(
	CommitmentItemID
	) REFERENCES ImportFinancial.CommitmentItem
	(
	CommitmentItemID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE [ImportFinancial].[WbsElementPnBudget]  WITH CHECK 
ADD  CONSTRAINT [FK_WbsElementPnBudget_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY([BudgetObjectCodeID])
REFERENCES Reclamation.[BudgetObjectCode] ([BudgetObjectCodeID])
GO

