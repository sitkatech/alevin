IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportCreateFinancialStagingSchema'))
    drop procedure dbo.pReclamationImportCreateFinancialStagingSchema
go



create procedure dbo.pReclamationImportCreateFinancialStagingSchema

as
begin

	IF NOT EXISTS (
		SELECT  schema_name
		FROM    information_schema.schemata
		WHERE   schema_name = 'ImportFinancial' ) -- ImportFinancial is the name of the schema I wanted to check for
	BEGIN
		EXEC sp_executesql N'create schema ImportFinancial'   --ImportFinancial is the schema I want to create
	END



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



end
GO


/*

exec dbo.pReclamationImportCreateFinancialStagingSchema


*/
