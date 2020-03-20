-- begin tran

-- We have to wipe these tables to set new non-null foreign keys.
delete from ImportFinancial.WbsElementObligationItemBudget
delete from ImportFinancial.WbsElementObligationItemInvoice

-- Ah, but it seems we have data where we can't look up the BOC in the provided data. 
-- For example, we currently don't have BOC 252Q00, but it turns up in the impApGen/ImpPayRec imports.
-- So, BudgetObjectCode is nullable for now. Pity. -- SLG 3/18/2020

alter table ImportFinancial.WbsElementObligationItemBudget
add BudgetObjectCodeID int /*not*/ null
GO

ALTER TABLE ImportFinancial.WbsElementObligationItemBudget  WITH CHECK 
ADD CONSTRAINT [FK_WbsElementObligationItemBudget_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY(BudgetObjectCodeID)
REFERENCES Reclamation.BudgetObjectCode (BudgetObjectCodeID)
GO

alter table ImportFinancial.WbsElementObligationItemInvoice
add BudgetObjectCodeID int /*not*/ null
GO

ALTER TABLE ImportFinancial.WbsElementObligationItemInvoice  WITH CHECK 
ADD CONSTRAINT [FK_WbsElementObligationItemInvoice_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY(BudgetObjectCodeID)
REFERENCES Reclamation.BudgetObjectCode (BudgetObjectCodeID)
GO

-- We want to make keys non-nullable, so we have to 

--rollback tran