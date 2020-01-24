



create schema imp
go;






IF EXISTS(SELECT *
          FROM   imp.WbsElement)
  DROP TABLE dbo.Scores




--CREATE TABLES AND AKs
create table imp.WbsElement(
	WbsElementID int not null identity(1,1) constraint PK_WbsElement_WbsElementID primary key,
	WbsElementKey varchar(100) not null,
	WbsElementText varchar(500) not null
)

ALTER TABLE imp.WbsElement ADD  CONSTRAINT [AK_WbsElement_WbsElementKey] UNIQUE NONCLUSTERED 
(
	WbsElementKey ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

create table imp.Vendor(
	VendorID int not null identity(1,1) constraint PK_Vendor_VendorID primary key,
	VendorKey varchar(100) not null,
	VendorText varchar(500) not null
)

ALTER TABLE imp.Vendor ADD  CONSTRAINT [AK_Vendor_VendorKey] UNIQUE NONCLUSTERED 
(
	VendorKey ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

create table imp.ObligationNumber(
	ObligationNumberID int not null identity(1,1) constraint PK_ObligationNumber_ObligationNumberID primary key,
	ObligationNumberKey varchar(100) not null
)

ALTER TABLE imp.ObligationNumber ADD  CONSTRAINT [AK_ObligationNumber_ObligationNumberKey] UNIQUE NONCLUSTERED 
(
	ObligationNumberKey ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

create table imp.ObligationItem(
	ObligationItemID int not null identity(1,1) constraint PK_ObligationItem_ObligationItemID primary key,
	ObligationItemKey varchar(100) not null,
	ObligationNumberID int not null constraint FK_ObligationItem_ObligationNumber_ObligationNumberID foreign key references imp.ObligationNumber(ObligationNumberID)
)

ALTER TABLE imp.ObligationItem ADD  CONSTRAINT [AK_ObligationItem_ObligationItemKey] UNIQUE NONCLUSTERED 
(
	ObligationItemKey ASC,
	ObligationNumberID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO







--INSERTS
insert into imp.WbsElement(WbsElementKey, WbsElementText)
select 
	distinct
		coalesce(pr.[WBS Element - Key], ap.[WBS Element - Key]) as WbsElementKey,
		coalesce(pr.[WBS Element - Text], ap.[WBS Element - Text]) as WbsElementText
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[WBS Element - Key] = ap.[WBS Element - Key]
where
	pr.[WBS Element - Text] = ap.[WBS Element - Text] and pr.[WBS Element - Key] != '#'


insert into imp.Vendor(VendorKey, VendorText)
select 
	distinct
		coalesce(pr.[Vendor - Key], ap.[Vendor - Key]) as VendorKey,
		coalesce(pr.[Vendor - Text], ap.[Vendor - Text]) as VendorText
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[Vendor - Key] = ap.[Vendor - Key]
where
	pr.[Vendor - Text] = ap.[Vendor - Text] and pr.[Vendor - Key] != '#'


insert into imp.ObligationNumber(ObligationNumberKey)
select 
	distinct
		coalesce(pr.[Obligation Number - Key] , ap.[PO Number - Key]) as ObligationNumberKey
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]


insert into imp.ObligationItem(ObligationItemKey, ObligationNumberID)
select 
	distinct
		coalesce(pr.[Obligation Item - Key] , ap.[Purch Ord Line Itm - Key]) as ObligationItemKey,
		(select ObligationNumberID from imp.ObligationNumber as ob where ob.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationNumberID
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]






--testing for creates and inserts
--select * from dbo.impPayRecV3

--select 
--	distinct
--		coalesce(pr.[Obligation Number - Key] , ap.[PO Number - Key]) as ObligationNumberKey,
--		coalesce(pr.[Obligation Item - Key] , ap.[Purch Ord Line Itm - Key]) as ObligationItemKey,
--		(select ObligationNumberID from imp.ObligationNumber as ob where ob.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationNumberID
--from
--	dbo.impPayRecV3 as pr
--	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]



--where
--	pr.[Vendor - Text] = ap.[Vendor - Text] and pr.[Vendor - Key] != '#'

