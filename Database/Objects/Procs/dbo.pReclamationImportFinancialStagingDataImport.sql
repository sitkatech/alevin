IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportFinancialStagingDataImport'))
    drop procedure dbo.pReclamationImportFinancialStagingDataImport
go



create procedure dbo.pReclamationImportFinancialStagingDataImport

as
begin

	
	delete from ImportFinancial.WbsElement;
	delete from ImportFinancial.Vendor;
	delete from ImportFinancial.ObligationItem;
	delete from ImportFinancial.ObligationNumber;


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
		pr.[WBS Element - Key] != '#'


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



	insert into ImportFinancial.WbsElementObligationItemBudget(WbsElementID, ObligationItemID, Obligation, GoodsReceipt, Invoiced, Disbursed, UnexpendedBalance)
	select 
		(select WbsElementID from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = pr.[WBS Element - Key]) as WbsElementID,
		(select obi.ObligationItemID from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID where obi.ObligationItemKey = pr.[Obligation Item - Key] and obn.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationItemID,
		pr.Obligation as Obligation,
		pr.[Goods Receipt] as GoodsReceipt,
		pr.Invoiced as Invoiced,
		pr.Disbursed as Disbursed,
		pr.[Unexpended Balance] as UnexpendedBalance
	from
		dbo.impPayRecV3 as pr
	where 
		pr.[WBS Element - Key] != '#'
		
		

end
GO


/*

		select * from dbo.impPayRecV3 as pr where pr.[WBS Element - Key] like '%#%'

		select * from dbo.impPayRecV3 as pr where pr.[Unexpended Balance] = 3790.98

		select * from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = 'RX.16786807.5001500'

		select distinct WbsElementKey from ImportFinancial.WbsElement

		select * from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID

		select * from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID where obi.ObligationItemID = 249


exec dbo.pReclamationImportFinancialStagingDataImport


*/
