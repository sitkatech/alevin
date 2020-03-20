-- begin tran

-- We have to wipe these tables to set new non-null foreign keys.
delete from ImportFinancial.WbsElementObligationItemBudget
delete from ImportFinancial.WbsElementObligationItemInvoice

alter table ImportFinancial.WbsElementObligationItemBudget
add FundID int not null
GO

ALTER TABLE ImportFinancial.WbsElementObligationItemBudget  WITH CHECK 
ADD CONSTRAINT [FK_WbsElementObligationItemBudget_Fund_FundID] FOREIGN KEY(FundID)
REFERENCES Reclamation.Fund (FundID)
GO

alter table ImportFinancial.WbsElementObligationItemInvoice
add FundID int not null
GO

ALTER TABLE ImportFinancial.WbsElementObligationItemInvoice  WITH CHECK 
ADD CONSTRAINT [FK_WbsElementObligationItemInvoice_Fund_FundID] FOREIGN KEY(FundID)
REFERENCES Reclamation.Fund (FundID)
GO

-- We want to make keys non-nullable, so we have to 

--rollback tran