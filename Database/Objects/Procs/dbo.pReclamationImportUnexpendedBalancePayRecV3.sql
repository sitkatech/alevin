IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportUnexpendedBalancePayRecV3'))
    drop procedure dbo.pReclamationImportUnexpendedBalancePayRecV3
go

create procedure dbo.pReclamationImportUnexpendedBalancePayRecV3

as
begin

if (
    (not EXISTS(SELECT 1 FROM Staging.StageImpUnexpendedBalancePayRecV3))
    )
begin
   raiserror('dbo.pReclamationImportUnexpendedBalancePayRecV3: There is no data in Staging.StageImpUnexpendedBalancePayRecV3. Publishing halted.', 16,1)
   return -1
end

    delete from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3
    INSERT INTO [ImportFinancial].ImportFinancialImpPayRecUnexpendedV3
               (
                BusinessArea
               ,FABudgetActivity
               ,FunctionalArea
               ,ObligationNumber
               ,ObligationItem
               ,Fund
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
               ,WBSElement
               ,WBSElementDescription
               ,BudgetObjectClass
               ,Vendor
               ,VendorName
               ,PostingDatePerSpl
               ,UnexpendedBalance
      FROM Staging.StageImpUnexpendedBalancePayRecV3

-- Right now we know of 2 rows with bum dates. Make sure these are there. If they disappear, we'd want to know and
-- consciously fix this check, so we can be sure it indicates we fixed something, and to make sure it doesn't 
-- mean something worse/unintended. If they grow, that's likely a bad sign, and something we'd also want to look at. -- SLG 6/24/2020
declare @nullSplDateCount int
set @nullSplDateCount = (select count(*) from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr where PostingDatePerSpl is null)
if (@nullSplDateCount != 2)
begin
   raiserror('Expected exactly two PostingDatePerSpl in ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 with null values.', 16,1)
   return -1
end

    delete from ImportFinancial.WbsElementObligationItemBudget;
    --delete from ImportFinancial.WbsElement; -- FK Issues
    delete from ImportFinancial.ObligationItem;
    -- Below we insert new, unrecognized ObligationNumbers
    --delete from ImportFinancial.ObligationNumber;
    delete from ImportFinancial.Vendor;

    -- #PotentiallyNewWbsElements may be irrelvant with the removal of ImportFinancial.ImpApGenSheet; haven't thought it through yet.
    -- SLG 7/21/2020

    -- Table of potentially new WBS elements
    -- (We'll figure out if there's a corresponding, existing WbsElement in a second.)
    DROP TABLE IF EXISTS #PotentiallyNewWbsElements
    select
    distinct
            pr.WBSElement as WbsElementKey,
            pr.WBSElementDescription as WbsElementText,
            null as ExistingWbsElementID,
            -- 0 means this is a completely new record, insert. 1 means it's an existing record that just needs a text fixup for WbsElementText
            0 as JustFixupWbsElementText
    into #PotentiallyNewWbsElements
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        -- This goes; but can the rest stay? -- SLG 7/21/2020
        --full outer join ImportFinancial.ImpApGenSheet as ap on pr.WBSElement = ap.WBSElementKey
    where
        pr.WBSElement != '#'

--select * from #PotentiallyNewWbsElements
--where WbsElementKey like '%RX.16786911.7000000%'

--select * from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey like '%RX.16786911.7000000%'

    -- Completely matching WBSElement already in the DB?
    update #PotentiallyNewWbsElements
    set ExistingWbsElementID = existWbs.WbsElementID,
        JustFixupWbsElementText = 0
    from #PotentiallyNewWbsElements as pNewWbs
         inner join ImportFinancial.WbsElement as existWbs on existWbs.WbsElementKey = pNewWbs.WbsElementKey and existWbs.WbsElementText = pNewWbs.WbsElementText

    -- WBSes that match EXCEPT for their WbsElementText? 
    -- (we'll need to update their WbsElementText)
    update #PotentiallyNewWbsElements
    set ExistingWbsElementID = existWbs.WbsElementID,
        JustFixupWbsElementText = 1
    from #PotentiallyNewWbsElements as pNewWbs
         inner join ImportFinancial.WbsElement as existWbs on existWbs.WbsElementKey = pNewWbs.WbsElementKey and existWbs.WbsElementText != pNewWbs.WbsElementText

    -- Insert the previously unknown WbsElements (if any)
    insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
    select pNewWbs.WbsElementKey, pNewWbs.WbsElementText
    from #PotentiallyNewWbsElements as pNewWbs
    where pNewWbs.ExistingWbsElementID is null and pNewWbs.JustFixupWbsElementText = 0

    -- Do text fixups on the Elements whose text labels don't align. Treat this incoming data source as authoritative for the name if we find a discrepancy.
    update ImportFinancial.WbsElement
    set WbsElementText = pFixupWbsElements.WbsElementText
    from #PotentiallyNewWbsElements as pFixupWbsElements
    inner join  ImportFinancial.WbsElement as wbs on pFixupWbsElements.ExistingWbsElementID = wbs.WbsElementID
    where pFixupWbsElements.JustFixupWbsElementText = 1

    -- This is the "Unknown-unknown Taxonomy Leaf"
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
            pr.Vendor as VendorKey,
            pr.VendorName as VendorText
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        --full outer join ImportFinancial.ImpApGenSheet as ap on pr.Vendor = ap.VendorKey
    where
        -- These are unassigned/blank vendors; see above
        pr.Vendor != '#'

    -- Insert unrecognized, new ObligationNumbers
    insert into ImportFinancial.ObligationNumber(ObligationNumberKey)
    select 
        distinct
            pr.ObligationNumber as ObligationNumberKey
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        left join ImportFinancial.ObligationNumber as existObNum on pr.ObligationNumber = existObNum.ObligationNumberKey
        where existObNum.ObligationNumberKey is null


--select * from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 

--update ImportFinancial.ImportFinancialImpPayRecUnexpendedV3
--set ObligationNumber = 'SLG93939392'
--where ImportFinancialImpPayRecUnexpendedV3ID = 34730

--select * from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
--select * from ImportFinancial.ObligationNumber as num


    update ImportFinancial.ObligationNumber
    set ReclamationAgreementID = rca.AgreementID
    from Reclamation.Agreement as rca
    inner join ImportFinancial.ObligationNumber as onum on rca.AgreementNumber = onum.ObligationNumberKey


    -- Now that WBSes and CostAuthorities have been inserted, associate any pairs coming in from each line of the ImportFinancialImpPayRecUnexpendedV3
    -- that are not already associated.

    DROP TABLE IF EXISTS #IncomingAgreementCostAuthorities
    select
    distinct
        pr.ObligationNumber,
        pr.WBSElement,
        ca.CostAuthorityID,
        agr.AgreementID
    into #IncomingAgreementCostAuthorities
    from 
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        join Reclamation.CostAuthority as ca on pr.WBSElement = ca.CostAuthorityWorkBreakdownStructure
        join Reclamation.Agreement as agr on pr.ObligationNumber = agr.AgreementNumber


        -- Add AgreementCostAuthorities
        insert into Reclamation.AgreementCostAuthority(AgreementID, CostAuthorityID)
        select 
                tmp.AgreementID,
                tmp.CostAuthorityID
        from
            #IncomingAgreementCostAuthorities as tmp
            left join Reclamation.AgreementCostAuthority as aca on tmp.AgreementID = aca.AgreementID and tmp.CostAuthorityID = aca.CostAuthorityID
        where
            aca.AgreementID is null or aca.CostAuthorityID is null


    insert into ImportFinancial.ObligationItem(ObligationItemKey, ObligationNumberID, VendorID)
    select 
        distinct
            pr.ObligationItem as ObligationItemKey,
            (select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.ObligationNumber) as ObligationNumberID,
            (select VendorID from ImportFinancial.Vendor as v where v.VendorKey = pr.Vendor) as VendorID
    from
        ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr
        --full outer join ImportFinancial.ImpApGenSheet as ap on pr.ObligationNumber = ap.PONumberKey

    -- Temp table to help with BOC FBMS years for ImportFinancialImpPayRecUnexpendedV3
    DROP TABLE IF EXISTS #BudgetObjectCodesFbmsYear_ImportFinancialImpPayRecUnexpendedV3

    select boc.BudgetObjectCodeID,
           UPPER(boc.BudgetObjectCodeName) as BudgetObjectCodeName,
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
    join Reclamation.BudgetObjectCode as boc on 
        boq.pr_CleanedBudgetObjectCode = boc.BudgetObjectCodeName
        and
        boq.FbmsYear = boc.FbmsYear
    order by boc.BudgetObjectCodeID, boc.BudgetObjectCodeName, boc.FbmsYear

    -- Refresh Oblibation Request Matches
    exec dbo.pRefreshCostAuthorityObligationNumberMatches

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
        --pr.BudgetObjectClass as pr_BudgetObjectClass,
        --bocyear.PossiblyDirtyBudgetObjectClassKey as bocyear_PossiblyDirtyBudgetObjectClassKey,
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
        left join #BudgetObjectCodesFbmsYear_ImportFinancialImpPayRecUnexpendedV3 as bocyear on 
                    YEAR(pr.PostingDatePerSpl) = bocyear.FbmsYear
                    and
                    LEFT(CONCAT(pr.BudgetObjectClass,'000000'), 6) = bocyear.BudgetObjectCodeName
        join dbo.FundingSource as f on REPLACE(pr.Fund, '1400/', '') = f.FundingSourceName
    where 
        pr.WBSElement != '#'
-- FOR EXPERIMENTATION ONLY! DO NOT COMMIT FOR LONG!
        --and
        --bocyear.BudgetObjectCodeID is null
    order by ObligationItemID

    -- Update VendorNumbers for any Organizations for Vendors we recognize by text from the incoming Vendor import table
    -- This only works for Reclamation (Tenant 12)
    update dbo.Organization
    set VendorNumber = iv.VendorKey
    from ImportFinancial.Vendor as iv
    join dbo.Organization as do on iv.VendorText = do.OrganizationName 
    where TenantID = 12

end
GO


/*

exec dbo.pReclamationImportUnexpendedBalancePayRecV3

*/
