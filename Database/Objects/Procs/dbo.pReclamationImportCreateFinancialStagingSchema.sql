IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportCreateFinancialStagingSchema'))
    drop procedure dbo.pReclamationImportCreateFinancialStagingSchema
go



create procedure dbo.pReclamationImportCreateFinancialStagingSchema

as
begin


	IF OBJECT_ID('ImportFinancial.WbsElementObligationItemBudget', 'U') IS NOT NULL 
	begin
	  DROP TABLE ImportFinancial.WbsElementObligationItemBudget
	end

	IF OBJECT_ID('ImportFinancial.WbsElementObligationItemInvoice', 'U') IS NOT NULL 
	begin
	  DROP TABLE ImportFinancial.WbsElementObligationItemBudget
	end

	IF OBJECT_ID('ImportFinancial.WbsElement', 'U') IS NOT NULL 
	begin
	  DROP TABLE ImportFinancial.WbsElement
	end

	IF OBJECT_ID('ImportFinancial.Vendor', 'U') IS NOT NULL 
	begin
	  DROP TABLE ImportFinancial.Vendor
	end

	IF OBJECT_ID('ImportFinancial.ObligationItem', 'U') IS NOT NULL 
	begin
	  DROP TABLE ImportFinancial.ObligationItem
	end

	IF OBJECT_ID('ImportFinancial.ObligationNumber', 'U') IS NOT NULL 
	begin
	  DROP TABLE ImportFinancial.ObligationNumber
	end

	

	--CREATE TABLES AND AKs
	create table ImportFinancial.WbsElement(
		WbsElementID int not null identity(1,1) constraint PK_WbsElement_WbsElementID primary key,
		WbsElementKey varchar(100) not null,
		WbsElementText varchar(500) not null
	)

	ALTER TABLE ImportFinancial.WbsElement ADD  CONSTRAINT [AK_WbsElement_WbsElementKey] UNIQUE NONCLUSTERED 
	(
		WbsElementKey ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


	create table ImportFinancial.Vendor(
		VendorID int not null identity(1,1) constraint PK_Vendor_VendorID primary key,
		VendorKey varchar(100) not null,
		VendorText varchar(500) not null
	)

	ALTER TABLE ImportFinancial.Vendor ADD  CONSTRAINT [AK_Vendor_VendorKey] UNIQUE NONCLUSTERED 
	(
		VendorKey ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


	create table ImportFinancial.ObligationNumber(
		ObligationNumberID int not null identity(1,1) constraint PK_ObligationNumber_ObligationNumberID primary key,
		ObligationNumberKey varchar(100) not null
	)

	ALTER TABLE ImportFinancial.ObligationNumber ADD  CONSTRAINT [AK_ObligationNumber_ObligationNumberKey] UNIQUE NONCLUSTERED 
	(
		ObligationNumberKey ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


	create table ImportFinancial.ObligationItem(
		ObligationItemID int not null identity(1,1) constraint PK_ObligationItem_ObligationItemID primary key,
		ObligationItemKey varchar(100) not null,
		ObligationNumberID int not null constraint FK_ObligationItem_ObligationNumber_ObligationNumberID foreign key references ImportFinancial.ObligationNumber(ObligationNumberID)
	)

	ALTER TABLE ImportFinancial.ObligationItem ADD  CONSTRAINT [AK_ObligationItem_ObligationItemKey] UNIQUE NONCLUSTERED 
	(
		ObligationItemKey ASC,
		ObligationNumberID ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]



	create table ImportFinancial.WbsElementObligationItemBudget(
		WbsElementObligationItemBudgetID int not null identity(1,1) constraint PK_WbsElementObligationItemBudget_WbsElementObligationItemBudgetID primary key,
		WbsElementID int not null constraint FK_WbsElementObligationItemBudget_WbsElement_WbsElementID foreign key references ImportFinancial.WbsElement(WbsElementID),
		ObligationItemID int not null constraint FK_WbsElementObligationItemBudget_ObligationItem_ObligationItemID foreign key references ImportFinancial.ObligationItem(ObligationItemID),
		Obligation float null,
		GoodsReceipt varchar(255) null,
		Invoiced float null,
		Disbursed float null,
		UnexpendedBalance float null
	)

	create table ImportFinancial.WbsElementObligationItemInvoice(
		WbsElementObligationItemInvoiceID int not null identity(1,1) constraint PK_WbsElementObligationItemInvoice_WbsElementObligationItemInvoiceID primary key,
		WbsElementID int not null constraint FK_WbsElementObligationItemInvoice_WbsElement_WbsElementID foreign key references ImportFinancial.WbsElement(WbsElementID),
		ObligationItemID int not null constraint FK_WbsElementObligationItemInvoice_ObligationItem_ObligationItemID foreign key references ImportFinancial.ObligationItem(ObligationItemID),
		DebitAmount float null,
		CreditAmount float null,
		DebitCreditTotal float null
	)



end
GO


/*

exec dbo.pReclamationImportCreateFinancialStagingSchema


*/
