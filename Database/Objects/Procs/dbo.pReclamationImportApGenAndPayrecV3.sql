IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportApGenAndPayrecV3'))
    drop procedure dbo.pReclamationImportApGenAndPayrecV3
go

create procedure dbo.pReclamationImportApGenAndPayrecV3

as
begin

if (
    (not EXISTS(SELECT 1 FROM Staging.StageImpApGenSheet))
    OR 
    (not EXISTS(SELECT 1 FROM Staging.StageImpUnexpendedBalancePayRecV3))
    )
begin
   raiserror('There is no data in at least one of the tables for publishing. Publishing halted.', 16,1)
   return -1
end

    -- TODO: A sanity check that there are actually records to import
    delete from ImportFinancial.ImpApGenSheet
    INSERT INTO [ImportFinancial].[ImpApGenSheet]
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

    delete from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3
    INSERT INTO [ImportFinancial].ImportFinancialImpPayRecUnexpendedV3
               (
                BusinessArea
               ,FABudgetActivity
               ,FunctionalArea
               ,ObligationNumber
               ,ObligationItem
               ,Fund
               ,FundedProgram
               ,WBSElement
               ,WBSElementDescription
               ,BudgetObjectClass
               ,Vendor
               ,VendorName
               ,PostingDatePerSpl
               ,UnexpendedBalance
               )
    SELECT
                BusinessArea
               ,FABudgetActivity
               ,FunctionalArea
               ,ObligationNumber
               ,ObligationItem
               ,Fund
               ,FundedProgram
               ,WBSElement
               ,WBSElementDescription
               ,BudgetObjectClass
               ,Vendor
               ,VendorName
               ,PostingDatePerSpl
               ,UnexpendedBalance
      FROM Staging.StageImpUnexpendedBalancePayRecV3

      --select * from     Staging.StageImpUnexpendedBalancePayRecV3

    delete from ImportFinancial.WbsElementObligationItemBudget;
    delete from ImportFinancial.WbsElementObligationItemInvoice;
    --delete from ImportFinancial.WbsElement; -- FK Issues
    delete from ImportFinancial.ObligationItem;
    delete from ImportFinancial.ObligationNumber;
    delete from ImportFinancial.Vendor;

    -- Table of potentially new WBS elements
    -- (We'll figure out if there's a corresponding, existing WbsElement in a second.)
    DROP TABLE IF EXISTS #PotentiallyNewWbsElements
    select
    distinct
            coalesce(pr.WBSElement, ap.WBSElementKey) as WbsElementKey,
            coalesce(pr.WBSElementDescription, ap.WBSElementText) as WbsElementText,
            null as ExistingWbsElementID
    into #PotentiallyNewWbsElements
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        full outer join ImportFinancial.ImpApGenSheet as ap on pr.WBSElement = ap.WBSElementKey
    where
        pr.WBSElement != '#'

    -- Is there a completely matching WBSElement already in the DB?
    -- We mark these with their WbsElementIDs.
    update #PotentiallyNewWbsElements
    set ExistingWbsElementID = existWbs.WbsElementID
    from #PotentiallyNewWbsElements as pNewWbs
         inner join ImportFinancial.WbsElement as existWbs on existWbs.WbsElementKey = pNewWbs.WbsElementKey and existWbs.WbsElementText = pNewWbs.WbsElementText

    -- Insert the previously unknown WbsElements (if any)
    insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
    select pNewWbs.WbsElementKey, pNewWbs.WbsElementText
    from #PotentiallyNewWbsElements as pNewWbs
    where pNewWbs.ExistingWbsElementID is null

    -- This is the "Unknown-unknown Taxonmy Leaf"
    declare @unknownTaxonomyLeafID int
    set @unknownTaxonomyLeafID = (select TaxonomyLeafID from dbo.TaxonomyLeaf as tl where tl.TaxonomyLeafName = 'xxxx.xxx unknown')

    --insert missing WBS elements into the Reclamation.CostAuthority table
    insert into Reclamation.CostAuthority(CostAuthorityWorkBreakdownStructure, AccountStructureDescription, TaxonomyLeafID)
    select wbs.WbsElementKey, wbs.WbsElementText, @unknownTaxonomyLeafID
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
            coalesce(pr.Vendor, ap.VendorKey) as VendorKey,
            coalesce(pr.VendorName, ap.VendorText) as VendorText
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        full outer join ImportFinancial.ImpApGenSheet as ap on pr.Vendor = ap.VendorKey
    where
        -- These are unassigned/blank vendors; see above
        pr.Vendor != '#'

    insert into ImportFinancial.ObligationNumber(ObligationNumberKey)
    select 
        distinct
            coalesce(pr.ObligationNumber , ap.PONumberKey) as ObligationNumberKey
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        full outer join ImportFinancial.ImpApGenSheet as ap on pr.ObligationNumber = ap.PONumberKey

    update ImportFinancial.ObligationNumber
    set ReclamationAgreementID = rca.AgreementID
    from Reclamation.Agreement as rca
    inner join ImportFinancial.ObligationNumber as onum on rca.AgreementNumber = onum.ObligationNumberKey

    insert into ImportFinancial.ObligationItem(ObligationItemKey, ObligationNumberID, VendorID)
    select 
        distinct
            coalesce(pr.ObligationItem , ap.PurchOrdLineItmKey) as ObligationItemKey,
            (select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.ObligationNumber) as ObligationNumberID,
            (coalesce((select VendorID from ImportFinancial.Vendor as v where v.VendorKey = pr.Vendor),
                      (select VendorID from ImportFinancial.Vendor as v where v.VendorKey = ap.VendorKey))) as VendorID
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        full outer join ImportFinancial.ImpApGenSheet as ap on pr.ObligationNumber = ap.PONumberKey

    -- Temp table to help with BOC FBMS years for ImportFinancialImpPayRecUnexpendedV3
    DROP TABLE IF EXISTS #BudgetObjectCodesFbmsYear_ImportFinancialImpPayRecUnexpendedV3

    select boc.BudgetObjectCodeID,
           boc.BudgetObjectCodeName,
           --boq.pr_CleanedBudgetObjectCode,
           boq.PossiblyDirtyBudgetObjectClassKey,
           boq.FbmsYear
    into #BudgetObjectCodesFbmsYear_ImportFinancialImpPayRecUnexpendedV3
    from
    (
        select
                distinct
                pr.BudgetObjectClass as pr_BudgetObjectCode,
                pr.BudgetObjectClass as PossiblyDirtyBudgetObjectClassKey,
                dbo.CleanBudgetObjectCode(pr.BudgetObjectClass) as pr_CleanedBudgetObjectCode,
                COALESCE(
                    -- If found, use appropriate, matching year
                    (select distinct boc.FbmsYear from Reclamation.BudgetObjectCode as boc where boc.FbmsYear = YEAR(pr.PostingDatePerSpl)),
                    -- Otherwise, default to the latest year
                    (select MAX(boc.FbmsYear) from Reclamation.BudgetObjectCode as boc)
                    ) as FbmsYear
        from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
    ) as boq
    join Reclamation.BudgetObjectCode as boc on boq.pr_CleanedBudgetObjectCode = boc.BudgetObjectCodeName and boq.FbmsYear = boc.FbmsYear
    order by boc.BudgetObjectCodeID, boc.BudgetObjectCodeName, boc.FbmsYear

--    select * from ImportFinancial.WbsElementObligationItemBudget

-- select * from #BudgetObjectCodesFbmsYear_ImportFinancialImpPayRecUnexpendedV3

    insert into ImportFinancial.WbsElementObligationItemBudget(
                                                               WbsElementID,
                                                               CostAuthorityID,
                                                               ObligationItemID,
                                                               UnexpendedBalance,
                                                               PostingDatePerSplKey,
                                                               BudgetObjectCodeID,
                                                               FundingSourceID
                                                               )
    select
        (select WbsElementID from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = pr.WBSElement) as WbsElementID,
        (select CostAuthorityID from Reclamation.CostAuthority as ca where ca.CostAuthorityWorkBreakdownStructure = pr.WBSElement) as CostAuthorityID,
        (select obi.ObligationItemID from ImportFinancial.ObligationItem as obi join ImportFinancial.ObligationNumber as obn on obi.ObligationNumberID = obn.ObligationNumberID join ImportFinancial.Vendor as v on obi.VendorID = v.VendorID where obi.ObligationItemKey = pr.ObligationItem and obn.ObligationNumberKey = pr.ObligationNumber and v.VendorKey = pr.Vendor) as ObligationItemID,
        pr.UnexpendedBalance as UnexpendedBalance,
        pr.PostingDatePerSpl as PostingDatePerSpl,
        -- It seems we have data where we can't look up the BOC in the provided data. 
        -- For example, we currently don't have BOC 252Q00, but it turns up in the impApGen/ImpPayRec imports.
        -- So, BudgetObjectCode is nullable for now. Pity. -- SLG 3/18/2020
        bocyear.BudgetObjectCodeID,
        f.FundingSourceID as FundingSourceID
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        left join #BudgetObjectCodesFbmsYear_ImportFinancialImpPayRecUnexpendedV3 as bocyear on YEAR(pr.PostingDatePerSpl) = bocyear.FbmsYear and pr.BudgetObjectClass = bocyear.PossiblyDirtyBudgetObjectClassKey
        join dbo.FundingSource as f on REPLACE(pr.Fund, '1400/', '') = f.FundingSourceName
    where 
        pr.WBSElement != '#'
    order by ObligationItemID

    --select distinct CostAuthorityWorkBreakdownStructure, count(*) from Reclamation.CostAuthority group by CostAuthorityWorkBreakdownStructure order by count(*) desc
    --select * from Reclamation.CostAuthority where CostAuthorityWorkBreakdownStructure = 'RX.16786820.3000100'

    -- Temp table to help with BOC FBMS years for ImpApGenSheet
    DROP TABLE IF EXISTS #BudgetObjectCodesFbmsYear_ImpApGenSheet

    select boc.BudgetObjectCodeID,
           boc.BudgetObjectCodeName,
           --boq.pr_CleanedBudgetObjectCode,
           boq.PossiblyDirtyBudgetObjectClassKey,
           boq.FbmsYear
    into #BudgetObjectCodesFbmsYear_ImpApGenSheet
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
        from ImportFinancial.ImpApGenSheet as pr
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
          ImportFinancial.ImpApGenSheet as ap
          left join #BudgetObjectCodesFbmsYear_ImpApGenSheet as bocyear on YEAR(ap.PostingDateKey) = bocyear.FbmsYear and ap.BudgetObjectClassKey = bocyear.PossiblyDirtyBudgetObjectClassKey
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


exec dbo.pReclamationImportApGenAndPayrecV3

select * from 
*/
