alter table ImportFinancial.ObligationItem
add VendorID int null constraint FK_ObligationItem_Vendor_VendorID foreign key references ImportFinancial.Vendor(VendorID)
GO



ALTER TABLE [ImportFinancial].[ObligationItem] DROP CONSTRAINT [AK_ObligationItem_ObligationItemKey_ObligationNumberID]
GO
ALTER TABLE [ImportFinancial].[ObligationItem] ADD  CONSTRAINT [AK_ObligationItem_ObligationItemKey_ObligationNumberID_VendorID] UNIQUE NONCLUSTERED 
(
	[ObligationItemKey] ASC,
	[ObligationNumberID] ASC,
    VendorID ASC
)ON [PRIMARY]
GO

