










--INSERTS
insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
select 
	distinct
		coalesce(pr.[WBS Element - Key], ap.[WBS Element - Key]) as WbsElementKey,
		coalesce(pr.[WBS Element - Text], ap.[WBS Element - Text]) as WbsElementText
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[WBS Element - Key] = ap.[WBS Element - Key]
where
	pr.[WBS Element - Text] = ap.[WBS Element - Text] and pr.[WBS Element - Key] != '#'


insert into ImportFinancial.Vendor(VendorKey, VendorText)
select 
	distinct
		coalesce(pr.[Vendor - Key], ap.[Vendor - Key]) as VendorKey,
		coalesce(pr.[Vendor - Text], ap.[Vendor - Text]) as VendorText
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[Vendor - Key] = ap.[Vendor - Key]
where
	pr.[Vendor - Text] = ap.[Vendor - Text] and pr.[Vendor - Key] != '#'


insert into ImportFinancial.ObligationNumber(ObligationNumberKey)
select 
	distinct
		coalesce(pr.[Obligation Number - Key] , ap.[PO Number - Key]) as ObligationNumberKey
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]


insert into ImportFinancial.ObligationItem(ObligationItemKey, ObligationNumberID)
select 
	distinct
		coalesce(pr.[Obligation Item - Key] , ap.[Purch Ord Line Itm - Key]) as ObligationItemKey,
		(select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationNumberID
from
	dbo.impPayRecV3 as pr
	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]






--testing for creates and inserts
--select * from dbo.impPayRecV3

--select 
--	distinct
--		coalesce(pr.[Obligation Number - Key] , ap.[PO Number - Key]) as ObligationNumberKey,
--		coalesce(pr.[Obligation Item - Key] , ap.[Purch Ord Line Itm - Key]) as ObligationItemKey,
--		(select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationNumberID
--from
--	dbo.impPayRecV3 as pr
--	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]



--where
--	pr.[Vendor - Text] = ap.[Vendor - Text] and pr.[Vendor - Key] != '#'

