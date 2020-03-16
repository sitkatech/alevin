
-- Be sure prior script includes latest version of this file!!!
exec dbo.pReclamationImportFinancialStagingDataImport
GO

ALTER TABLE [ImportFinancial].[ObligationItem] DROP CONSTRAINT [AK_ObligationItem_ObligationItemKey_ObligationNumberID_VendorID]
GO

-- We can finally do this
alter table ImportFinancial.ObligationItem
alter column VendorID int not null 
GO

ALTER TABLE [ImportFinancial].[ObligationItem] ADD  CONSTRAINT [AK_ObligationItem_ObligationItemKey_ObligationNumberID_VendorID] UNIQUE NONCLUSTERED 
(
    [ObligationItemKey] ASC,
    [ObligationNumberID] ASC,
    [VendorID] ASC
)ON [PRIMARY]
GO


