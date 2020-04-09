IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportFinancialStagingDataImport'))
    drop procedure dbo.pReclamationImportFinancialStagingDataImport
go

create procedure dbo.pReclamationImportFinancialStagingDataImport

as
begin

if (
    (not EXISTS(SELECT 1 FROM Staging.[StageImpApGenSheet]))
    OR 
    (not EXISTS(SELECT 1 FROM Staging.[StageImpPayRecV3]))
    )
begin
   raiserror('There is no data in at least one of the tables for publishing. Publishing halted.', 16,1)
   return -1
end

    -- TODO: A sanity check that there are actually records to import
    delete from ImportFinancial.impApGenSheet
    INSERT INTO [ImportFinancial].[impApGenSheet]
               (
                PONumberKey
               ,PurchOrdLineItmKey
               ,ReferenceKey
               ,VendorKey
               ,VendorText
               ,FundKey
               ,FundedProgramKey
               ,WBSElementKey
               ,WBSElementText
               ,BudgetObjectClassKey
               ,DebitAmount
               ,CreditAmount
               ,DebitCreditTotal
               ,[CreatedOnKey]
               ,[PostingDateKey]
               )
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
          ,[CreatedOnKey]
          ,[PostingDateKey]
      FROM Staging.[StageImpApGenSheet]

    delete from ImportFinancial.impPayRecV3
    INSERT INTO [ImportFinancial].[impPayRecV3]
               (
                BusinessAreaKey
               ,FABudgetActivityKey
               ,FunctionalAreaText
               ,ObligationNumberKey
               ,ObligationItemKey
               ,FundKey
               ,FundedProgramKey
               ,WBSElementKey
               ,WBSElementText
               ,BudgetObjectClassKey
               ,VendorKey
               ,VendorText
               ,Obligation
               ,GoodsReceipt
               ,Invoiced
               ,Disbursed
               ,UnexpendedBalance
               ,CreatedOnKey
               ,DateOfUpdateKey
               ,PostingDateKey
               ,PostingDatePerSplKey
               ,DocumentDateOfBlKey
               )
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
          ,[CreatedOnKey]
          ,[DateOfUpdateKey]
          ,[PostingDateKey]
          ,[PostingDatePerSplKey]
          ,[DocumentDateOfBlKey]
      FROM Staging.[StageImpPayRecV3]

    delete from ImportFinancial.WbsElementObligationItemBudget;
    delete from ImportFinancial.WbsElementObligationItemInvoice;
    delete from ImportFinancial.WbsElement;
    delete from ImportFinancial.ObligationItem;
    delete from ImportFinancial.ObligationNumber;
    delete from ImportFinancial.Vendor;

	--INSERTS
	insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
	select 
		distinct
			coalesce(pr.WBSElementKey, ap.WBSElementKey) as WbsElementKey,
			coalesce(pr.WBSElementText, ap.WBSElementText) as WbsElementText
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.WBSElementKey = ap.WBSElementKey
	where
		pr.WBSElementKey != '#'

	--insert missing WBS elements into the Reclamation.CostAuthority table
	insert into Reclamation.CostAuthority(CostAuthorityWorkBreakdownStructure, AccountStructureDescription)  
    select wbs.WbsElementKey, wbs.WbsElementText
    from 
		Reclamation.CostAuthority as ca
		right join ImportFinancial.WbsElement as wbs on ca.CostAuthorityWorkBreakdownStructure = wbs.WbsElementKey
	where
		ca.CostAuthorityWorkBreakdownStructure is null


-- We'd really prefer not to have an "Unassigned Vendor" but we feel we've been pushed into a corner for the moment.
-- Fortunately it is very rare. -- SLG 3/13/2020

--  #    Not assigned
    insert into ImportFinancial.Vendor (VendorKey, VendorText)
    values
    ('#', 'Not Assigned')

	insert into ImportFinancial.Vendor(VendorKey, VendorText)
	select 
		distinct
			coalesce(pr.VendorKey, ap.VendorKey) as VendorKey,
			coalesce(pr.VendorText, ap.VendorText) as VendorText
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.VendorKey = ap.VendorKey
	where
        -- These are unassigned/blank vendors; see above
		pr.VendorKey != '#'

	insert into ImportFinancial.ObligationNumber(ObligationNumberKey)
	select 
		distinct
			coalesce(pr.ObligationNumberKey , ap.PONumberKey) as ObligationNumberKey
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.ObligationNumberKey = ap.PONumberKey

    update ImportFinancial.ObligationNumber
    set ReclamationAgreementID = rca.AgreementID
    from Reclamation.Agreement as rca
    inner join ImportFinancial.ObligationNumber as onum on rca.AgreementNumber = onum.ObligationNumberKey

	insert into ImportFinancial.ObligationItem(ObligationItemKey, ObligationNumberID, VendorID)
	select 
		distinct
			coalesce(pr.ObligationItemKey , ap.PurchOrdLineItmKey) as ObligationItemKey,
			(select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.ObligationNumberKey) as ObligationNumberID,
            (coalesce((select VendorID from ImportFinancial.Vendor as v where v.VendorKey = pr.VendorKey),
                      (select VendorID from ImportFinancial.Vendor as v where v.VendorKey = ap.VendorKey))) as VendorID
	from
		ImportFinancial.impPayRecV3 as pr
		full outer join ImportFinancial.impApGenSheet as ap on pr.ObligationNumberKey = ap.PONumberKey


    -- Temp table to help with BOC FBMS years for impPayRecV3
    IF OBJECT_ID('tempdb..#BudgetObjectCodesFbmsYear_impPayRecV3') IS NOT NULL DROP table #BudgetObjectCodesFbmsYear_impPayRecV3

    select boc.BudgetObjectCodeID,
           boc.BudgetObjectCodeName,
           --boq.pr_CleanedBudgetObjectCode,
           boq.PossiblyDirtyBudgetObjectClassKey,
           boq.FbmsYear
    into #BudgetObjectCodesFbmsYear_impPayRecV3
    from
    (
        select
                distinct
                pr.BudgetObjectClassKey as pr_BudgetObjectCode,
                pr.BudgetObjectClassKey as PossiblyDirtyBudgetObjectClassKey,
                dbo.CleanBudgetObjectCode(pr.BudgetObjectClassKey) as pr_CleanedBudgetObjectCode,
                COALESCE(
                    -- If found, use appropriate, matching year
                    (select distinct boc.FbmsYear from Reclamation.BudgetObjectCode as boc where boc.FbmsYear = YEAR(pr.PostingDateKey)),
                    -- Otherwise, default to the latest year
                    (select MAX(boc.FbmsYear) from Reclamation.BudgetObjectCode as boc)
                    ) as FbmsYear
        from ImportFinancial.impPayRecV3 as pr
    ) as boq
    join Reclamation.BudgetObjectCode as boc on boq.pr_CleanedBudgetObjectCode = boc.BudgetObjectCodeName and boq.FbmsYear = boc.FbmsYear
    order by boc.BudgetObjectCodeID, boc.BudgetObjectCodeName, boc.FbmsYear

    insert into ImportFinancial.WbsElementObligationItemBudget(
                                                               WbsElementID,
                                                               CostAuthorityID,
                                                               ObligationItemID,
                                                               Obligation,
                                                               GoodsReceipt,
                                                               Invoiced,
                                                               Disbursed,
                                                               UnexpendedBalance,
                                                               CreatedOnKey,
                                                               DateOfUpdateKey,
                                                               PostingDateKey,
                                                               PostingDatePerSplKey,
                                                               DocumentDateOfBlKey,
                                                               BudgetObjectCodeID,
                                                               FundingSourceID
                                                               )
	select 
		(select WbsElementID from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = pr.WBSElementKey) as WbsElementID,
		(select CostAuthorityID from Reclamation.CostAuthority as ca where ca.CostAuthorityWorkBreakdownStructure = pr.WBSElementKey) as CostAuthorityID,
		(select obi.ObligationItemID from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID join ImportFinancial.Vendor as v on obi.VendorID = v.VendorID where obi.ObligationItemKey = pr.ObligationItemKey and obn.ObligationNumberKey = pr.ObligationNumberKey and v.VendorKey = pr.VendorKey) as ObligationItemID,
		pr.Obligation as Obligation,
		pr.GoodsReceipt as GoodsReceipt,
		pr.Invoiced as Invoiced,
		pr.Disbursed as Disbursed,
		pr.UnexpendedBalance as UnexpendedBalance,
        pr.CreatedOnKey as CreatedOnKey,
        pr.DateOfUpdateKey as DateOfUpdateKey,
        pr.PostingDateKey as PostingDateKey,
        pr.PostingDatePerSplKey as PostingDatePerSplKey,
        pr.DocumentDateOfBlKey as DocumentDateOfBlKey,
        -- It seems we have data where we can't look up the BOC in the provided data. 
        -- For example, we currently don't have BOC 252Q00, but it turns up in the impApGen/ImpPayRec imports.
        -- So, BudgetObjectCode is nullable for now. Pity. -- SLG 3/18/2020
        bocyear.BudgetObjectCodeID,
        f.FundingSourceID as FundingSourceID
    from
        ImportFinancial.impPayRecV3 as pr
        join #BudgetObjectCodesFbmsYear_impPayRecV3 as bocyear on YEAR(pr.PostingDateKey) = bocyear.FbmsYear and pr.BudgetObjectClassKey = bocyear.PossiblyDirtyBudgetObjectClassKey
        join dbo.FundingSource as f on REPLACE(pr.FundKey, '1400/', '') = f.FundingSourceName
    where 
        pr.WBSElementKey != '#'
    order by ObligationItemID



    -- Temp table to help with BOC FBMS years for impApGenSheet
    IF OBJECT_ID('tempdb..#BudgetObjectCodesFbmsYear_impApGenSheet') IS NOT NULL DROP table #BudgetObjectCodesFbmsYear_impApGenSheet

    select boc.BudgetObjectCodeID,
           boc.BudgetObjectCodeName,
           --boq.pr_CleanedBudgetObjectCode,
           boq.PossiblyDirtyBudgetObjectClassKey,
           boq.FbmsYear
    into #BudgetObjectCodesFbmsYear_impApGenSheet
    from
    (
        select
                distinct
                pr.BudgetObjectClassKey as pr_BudgetObjectCode,
                pr.BudgetObjectClassKey as PossiblyDirtyBudgetObjectClassKey,
                dbo.CleanBudgetObjectCode(pr.BudgetObjectClassKey) as pr_CleanedBudgetObjectCode,
                COALESCE(
                    -- If found, use appropriate, matching year
                    (select distinct boc.FbmsYear from Reclamation.BudgetObjectCode as boc where boc.FbmsYear = YEAR(pr.PostingDateKey)),
                    -- Otherwise, default to the latest year
                    (select MAX(boc.FbmsYear) from Reclamation.BudgetObjectCode as boc)
                    ) as FbmsYear
        from ImportFinancial.impApGenSheet as pr
    ) as boq
    join Reclamation.BudgetObjectCode as boc on boq.pr_CleanedBudgetObjectCode = boc.BudgetObjectCodeName and boq.FbmsYear = boc.FbmsYear
    order by boc.BudgetObjectCodeID, boc.BudgetObjectCodeName, boc.FbmsYear

    insert into ImportFinancial.WbsElementObligationItemInvoice(
                                                                WbsElementID,
                                                                CostAuthorityID,
                                                                ObligationItemID,
                                                                DebitAmount,
                                                                CreditAmount,
                                                                DebitCreditTotal,
                                                                CreatedOnKey,
                                                                PostingDateKey,
                                                                BudgetObjectCodeID,
                                                                FundingSourceID
                                                                )
    select q.WbsElementID,
           q.CostAuthorityID,
           q.ObligationItemID,
           q.DebitAmount,
           q.CreditAmount,
           q.DebitCreditTotal,
           q.CreatedOnKey,
           q.PostingDateKey,
           q.BudgetObjectCodeID,
           q.FundingSourceID
    from
    (
       select 
          (select WbsElementID from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = ap.WBSElementKey) as WbsElementID,
          (select CostAuthorityID from Reclamation.CostAuthority as ca where ca.CostAuthorityWorkBreakdownStructure = ap.WBSElementKey) as CostAuthorityID,
          (
               select obi.ObligationItemID from ImportFinancial.ObligationItem as obi 
               join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID 
               join ImportFinancial.Vendor as v on obi.VendorID = v.VendorID 
               where obi.ObligationItemKey = ap.PurchOrdLineItmKey and obn.ObligationNumberKey = ap.PONumberKey and v.VendorKey = ap.VendorKey
          )
          as ObligationItemID,
          ap.DebitAmount as DebitAmount,
          ap.CreditAmount as CreditAmount,
          ap.DebitCreditTotal as DebitCreditTotal,
          ap.CreatedOnKey,
          ap.PostingDateKey,
        -- It seems we have data where we can't look up the BOC in the provided data. 
        -- For example, we currently don't have BOC 252Q00, but it turns up in the impApGen/ImpPayRec imports.
        -- So, BudgetObjectCode is nullable for now. Pity. -- SLG 3/18/2020
           bocyear.BudgetObjectCodeID,
           f.FundingSourceID
       from
          ImportFinancial.impApGenSheet as ap
          join #BudgetObjectCodesFbmsYear_impApGenSheet as bocyear on YEAR(ap.PostingDateKey) = bocyear.FbmsYear and ap.BudgetObjectClassKey = bocyear.PossiblyDirtyBudgetObjectClassKey
          join dbo.FundingSource as f on REPLACE(ap.FundKey, '1400/', '') = f.FundingSourceName
       where
         ap.WBSElementKey != '#'
    ) as q
    -- Has no Obligations on the AP-Gen tab
    where q.ObligationItemID is not null


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

		select * from dbo.impPayRecV3 as pr where pr.WBSElementKey like '%#%'

		select * from dbo.impPayRecV3 as pr where pr.UnexpendedBalance = 3790.98

		select * from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = 'RX.16786807.5001500'

		select distinct WbsElementKey from ImportFinancial.WbsElement

		select * from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID

		select * from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID where obi.ObligationItemID = 249


exec dbo.pReclamationImportFinancialStagingDataImport

select * from 
*/
