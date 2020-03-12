IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportFinancialStagingDataImport'))
    drop procedure dbo.pReclamationImportFinancialStagingDataImport
go



create procedure dbo.pReclamationImportFinancialStagingDataImport

as
begin

if (
    (not EXISTS(SELECT 1 FROM ImportFinancial.impApGenSheet))
    OR 
    (not EXISTS(SELECT 1 FROM ImportFinancial.impPayRecV3))
    )
begin
   raiserror('There is no data in at least one of the tables for publishing. Publishing halted.', 16,1)
   return -1
end

    -- TODO: A sanity check that there are actually records to import
    delete from ImportFinancial.impApGenSheet
    INSERT INTO [ImportFinancial].[impApGenSheet]
               ([PO Number - Key]
               ,[Purch Ord Line Itm - Key]
               ,[Reference - Key]
               ,[Vendor - Key]
               ,[Vendor - Text]
               ,[Fund - Key]
               ,[Funded Program - Key]
               ,[WBS Element - Key]
               ,[WBS Element - Text]
               ,[Budget Object Class - Key]
               ,[Debit Amount]
               ,[Credit Amount]
               ,[Debit/Credit Total])
    SELECT 
           [PONumberKey]
          ,[PurchOrdLineItmKey]
          ,[ReferenceKey]
          ,[VendorKey]
          ,[VendorText]
          ,[FundKey]
          ,[FundedProgramKey]
          ,[WBSElementKey]
          ,[WBSElementText]
          ,[BudgetObjectClassKey]
          ,[DebitAmount]
          ,[CreditAmount]
          ,[DebitCreditTotal]
      FROM [dbo].[StageImpApGenSheet]

    delete from ImportFinancial.impPayRecV3
    INSERT INTO [ImportFinancial].[impPayRecV3]
               ([Business area - Key]
               ,[FA Budget Activity - Key]
               ,[Functional area - Text]
               ,[Obligation Number - Key]
               ,[Obligation Item - Key]
               ,[Fund - Key]
               ,[Funded Program - Key (Not Compounded)]
               ,[WBS Element - Key]
               ,[WBS Element - Text]
               ,[Budget Object Class - Key]
               ,[Vendor - Key]
               ,[Vendor - Text]
               ,[Obligation]
               ,[Goods Receipt]
               ,[Invoiced]
               ,[Disbursed]
               ,[Unexpended Balance])
    SELECT
           [BusinessAreaKey]
          ,[FABudgetActivityKey]
          ,[FunctionalAreaText]
          ,[ObligationNumberKey]
          ,[ObligationItemKey]
          ,[FundKey]
          ,[FundedProgramKeyNotCompounded]
          ,[WBSElementKey]
          ,[WBSElementText]
          ,[BudgetObjectClassKey]
          ,[VendorKey]
          ,[VendorText]
          ,[Obligation]
          ,[GoodsReceipt]
          ,[Invoiced]
          ,[Disbursed]
          ,[UnexpendedBalance]
      FROM [dbo].[StageImpPayRecV3]

	delete from ImportFinancial.WbsElementObligationItemBudget;
	delete from ImportFinancial.WbsElementObligationItemInvoice;
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
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.[WBS Element - Key] = ap.[WBS Element - Key]
	where
		pr.[WBS Element - Key] != '#'

	--insert missing WBS elements into the Reclamation.CostAuthority table
	insert into Reclamation.CostAuthority(CostAuthorityWorkBreakdownStructure, AccountStructureDescription)  
    select wbs.WbsElementKey, wbs.WbsElementText
    from 
		Reclamation.CostAuthority as ca
		right join ImportFinancial.WbsElement as wbs on ca.CostAuthorityWorkBreakdownStructure = wbs.WbsElementKey
	where
		ca.CostAuthorityWorkBreakdownStructure is null


	insert into ImportFinancial.Vendor(VendorKey, VendorText)
	select 
		distinct
			coalesce(pr.[Vendor - Key], ap.[Vendor - Key]) as VendorKey,
			coalesce(pr.[Vendor - Text], ap.[Vendor - Text]) as VendorText
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.[Vendor - Key] = ap.[Vendor - Key]
	where
        -- These are unassigned/blank vendors; no reason to take them
		pr.[Vendor - Key] != '#'

	insert into ImportFinancial.ObligationNumber(ObligationNumberKey)
	select 
		distinct
			coalesce(pr.[Obligation Number - Key] , ap.[PO Number - Key]) as ObligationNumberKey
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]

    update ImportFinancial.ObligationNumber
    set ReclamationAgreementID = rca.AgreementID
    from Reclamation.Agreement as rca
    inner join ImportFinancial.ObligationNumber as onum on rca.AgreementNumber = onum.ObligationNumberKey


	insert into ImportFinancial.ObligationItem(ObligationItemKey, ObligationNumberID)
	select 
		distinct
			coalesce(pr.[Obligation Item - Key] , ap.[Purch Ord Line Itm - Key]) as ObligationItemKey,
			(select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationNumberID
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]



	insert into ImportFinancial.WbsElementObligationItemBudget(WbsElementID, CostAuthorityID, ObligationItemID, Obligation, GoodsReceipt, Invoiced, Disbursed, UnexpendedBalance)
	select 
		(select WbsElementID from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = pr.[WBS Element - Key]) as WbsElementID,
		(select CostAuthorityID from Reclamation.CostAuthority as ca where ca.CostAuthorityWorkBreakdownStructure = pr.[WBS Element - Key]) as CostAuthorityID,
		(select obi.ObligationItemID from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID where obi.ObligationItemKey = pr.[Obligation Item - Key] and obn.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationItemID,
		pr.Obligation as Obligation,
		pr.[Goods Receipt] as GoodsReceipt,
		pr.Invoiced as Invoiced,
		pr.Disbursed as Disbursed,
		pr.[Unexpended Balance] as UnexpendedBalance
	from
		ImportFinancial.impPayRecV3 as pr
	where 
		pr.[WBS Element - Key] != '#'



	insert into ImportFinancial.WbsElementObligationItemInvoice(WbsElementID, CostAuthorityID, ObligationItemID, DebitAmount, CreditAmount, DebitCreditTotal)
	select 
		(select WbsElementID from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = ap.[WBS Element - Key]) as WbsElementID,
		(select CostAuthorityID from Reclamation.CostAuthority as ca where ca.CostAuthorityWorkBreakdownStructure = ap.[WBS Element - Key]) as CostAuthorityID,
		(select obi.ObligationItemID from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID where obi.ObligationItemKey = ap.[Purch Ord Line Itm - Key] and obn.ObligationNumberKey = ap.[PO Number - Key]) as ObligationItemID,
		ap.[Debit Amount] as DebitAmount,
		ap.[Credit Amount] as CreditAmount,
		ap.[Debit/Credit Total] as DebitCreditTotal
	from
		ImportFinancial.impApGenSheet as ap
	where
		ap.[WBS Element - Key] != '#'
		

	-- Update VendorNumbers for any Organizations for Vendors we recognize by text from the incoming Vendor import table
	-- This only works for Reclamation (Tenant 12)
	update dbo.Organization
	set VendorNumber = iv.VendorKey
	from ImportFinancial.Vendor as iv
	join dbo.Organization as do on iv.VendorText = do.OrganizationName 
	where TenantID = 12

	--select * 
	--from ImportFinancial.Vendor as iv
	--left join dbo.Organization as do on iv.VendorText = do.OrganizationName 
	--where TenantID = 12 

	--select * from dbo.Organization
	--where VendorNumber is not null
	

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

select * from 
*/
