


/*
-- Filling in so we can close out the schema as non-null; real work needs to happen during import job
update ImportFinancial.ObligationItem
set VendorID = 

select iag.[Vendor - Key], 
       v.VendorID,
       v.VendorKey,
       iag.[Vendor - Text],
       iag.[PO Number - Key],
       obn.ObligationNumberKey,
       iag.[Purch Ord Line Itm - Key],
       obi.ObligationItemKey
from ImportFinancial.impApGenSheet as iag
join ImportFinancial.Vendor as v on iag.[Vendor - Key] = v.VendorKey
join ImportFinancial.ObligationNumber as obn on iag.[PO Number - Key] = obn.ObligationNumberKey
join ImportFinancial.ObligationItem as obi on iag.[Purch Ord Line Itm - Key] = obi.ObligationItemKey and obn.ObligationNumberID = obi.ObligationNumberID

select * from ImportFinancial.ObligationItem
select * from ImportFinancial.ObligationNumber
select * from ImportFinancial.Vendor 



-- Filling in so we can close out the schema as non-null; real work needs to happen during import job
update ImportFinancial.ObligationItem
set VendorID = v.VendorID
--select iag.[Vendor - Key], 
--       v.VendorID,
--       v.VendorKey,
--       iag.[Vendor - Text],
--       iag.[PO Number - Key],
--       obn.ObligationNumberKey,
--       iag.[Purch Ord Line Itm - Key],
--       obi.ObligationItemKey
from ImportFinancial.impApGenSheet as iag
join ImportFinancial.Vendor as v on iag.[Vendor - Key] = v.VendorKey
join ImportFinancial.ObligationNumber as obn on iag.[PO Number - Key] = obn.ObligationNumberKey
join ImportFinancial.ObligationItem as obi on iag.[Purch Ord Line Itm - Key] = obi.ObligationItemKey and obn.ObligationNumberID = obi.ObligationNumberID

select * from ImportFinancial.impApGenSheet


update ImportFinancial.ObligationItem
set VendorID = v.VendorID

select pr.[Vendor - Key], 
       v.VendorID,
       v.VendorKey,
       pr.[Vendor - Text],
       pr.[Obligation Number - Key],
       obn.ObligationNumberKey,
       pr.[Obligation Item - Key],
       obi.ObligationItemKey
from ImportFinancial.impPayRecV3 as pr
join ImportFinancial.Vendor as v on pr.[Vendor - Key] = v.VendorKey
join ImportFinancial.ObligationNumber as obn on pr.[Obligation Number - Key] = obn.ObligationNumberKey
join ImportFinancial.ObligationItem as obi on pr.[Obligation Item - Key] = obi.ObligationItemKey and obn.ObligationNumberID = obi.ObligationNumberID

*/


--begin tran


exec dbo.pReclamationImportFinancialStagingDataImport
GO

alter table ImportFinancial.ObligationItem
add VendorID int null constraint FK_ObligationItem_Vendor_VendorID foreign key references ImportFinancial.Vendor(VendorID)

GO

-- Part 1

-- Filling in so we can close out the schema as non-null; real work needs to happen during import job
update ImportFinancial.ObligationItem
set VendorID = v.VendorID
--select iag.[Vendor - Key], 
--       v.VendorID,
--       v.VendorKey,
--       iag.[Vendor - Text],
--       iag.[PO Number - Key],
--       obn.ObligationNumberKey,
--       iag.[Purch Ord Line Itm - Key],
--       obi.ObligationItemKey
from ImportFinancial.impApGenSheet as iag
join ImportFinancial.Vendor as v on iag.[Vendor - Key] = v.VendorKey
join ImportFinancial.ObligationNumber as obn on iag.[PO Number - Key] = obn.ObligationNumberKey
join ImportFinancial.ObligationItem as obi on iag.[Purch Ord Line Itm - Key] = obi.ObligationItemKey and obn.ObligationNumberID = obi.ObligationNumberID


-- Part two - Just new records from PayRecV3

update ImportFinancial.ObligationItem
set VendorID = v.VendorID
--select pr.[Vendor - Key], 
--       v.VendorID,
--       v.VendorKey,
--       pr.[Vendor - Text],
--       pr.[Obligation Number - Key],
--       obn.ObligationNumberKey,
--       pr.[Obligation Item - Key],
--       obi.ObligationItemKey
from ImportFinancial.impPayRecV3 as pr
join ImportFinancial.Vendor as v on pr.[Vendor - Key] = v.VendorKey
join ImportFinancial.ObligationNumber as obn on pr.[Obligation Number - Key] = obn.ObligationNumberKey
join ImportFinancial.ObligationItem as obi on pr.[Obligation Item - Key] = obi.ObligationItemKey and obn.ObligationNumberID = obi.ObligationNumberID
where obi.VendorID is null



/*
-- WE WANT THIS, But it doesn't work yet 
alter table ImportFinancial.ObligationItem
alter column VendorID int not null 
*/

/*

-- Experiments

select * from 
ImportFinancial.ObligationItem as oi
join ImportFinancial.ObligationNumber as obn on oi.ObligationNumberID = obn.ObligationNumberID
where VendorID is null

--select * from ImportFinancial.impPayRecV3 as pr
--where pr.[Vendor - Key] is null


--select * from ImportFinancial.impApGenSheet as iag
--where iag.[Vendor - Key] is null

select * from Reclamation.Agreement
where AgreementID = 415

select * from ImportFinancial.impApGenSheet as iag
where iag.[PO Number - Key] like '3200011405'

select * from ImportFinancial.impPayRecV3 as iv
where iv.[Obligation Number - Key] like '3200011405'

select * from ImportFinancial.Vendor
order by VendorText

select * from ImportFinancial.ObligationItem as obi
where obi.VendorID is null


	select distinct
			coalesce(pr.[Vendor - Key], ap.[Vendor - Key]) as VendorKey,
			coalesce(pr.[Vendor - Text], ap.[Vendor - Text]) as VendorText,
            ap.[Vendor - Text],
            pr.[Vendor - Text]
	from
		ImportFinancial.impPayRecV3 as pr
		left join ImportFinancial.impApGenSheet as ap on pr.[Vendor - Key] = ap.[Vendor - Key]
	--where
		--pr.[Vendor - Text] = ap.[Vendor - Text] and pr.[Vendor - Key] != '#'
        order by ap.[Vendor - Text]

select * from ImportFinancial.impPayRecV3 as pr
where pr.[Vendor - Text] like 'KROHN'

*/