IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportPnBudget'))
    drop procedure dbo.pReclamationImportPnBudget
go

create procedure dbo.pReclamationImportPnBudget


as
begin

if (
    (not EXISTS(SELECT 1 FROM Staging.StageImpPnBudget))
    )
begin
   raiserror('pReclamationImportPnBudget: There is no data in at least one of the tables for publishing. Publishing halted.', 16,1)
   return -1
end


    delete from ImportFinancial.ImpPnBudget;

    INSERT INTO ImportFinancial.ImpPnBudget
               (
                    FundedProgram,
                    FundType,
                    Fund,
                    FundsCenter,
                    FiscalYearPeriod,
                    CommitmentItem,
                    FiDocNumber,
                    Recoveries,
                    CommittedButNotObligated,
                    TotalObligations,
                    TotalExpenditures,
                    UndeliveredOrders
               )
    SELECT 
                    FundedProgram,
                    FundType,
                    Fund,
                    FundsCenter,
                    FiscalYearPeriod,
                    CommitmentItem,
                    FiDocNumber,
                    Recoveries,
                    CommittedButNotObligated,
                    TotalObligations,
                    TotalExpenditures,
                    UndeliveredOrders
      FROM Staging.StageImpPnBudget

--These are WBS Elements referenced by the incoming PnBudget table that we 
--need to add to the WbsElement table. Since we don't know their WbsElementText,
--we put in something of a placeholder. Likely we will need to do better in the future.
DROP TABLE IF EXISTS #PreviouslyUnknownWbsElements

-- 22 out of 188 unknown on first run.
-- We do the best we can to import these, but it's not perfect.
-- 'FPDEFAULT' comes along for the ride here on the first pass, but I don't know what to do with it otherwise.

select
distinct
    ipn.FundedProgram as ipnFundedProgram,
    SUBSTRING(ipn.FundedProgram, 1, 2) + '.' + SUBSTRING(ipn.FundedProgram, 3, 8) + '.' + SUBSTRING(ipn.FundedProgram, 11, datalength(ipn.FundedProgram)) as WbsElementKey,
    '[From ImpPnBudget -- need more info]' as WbsElementText,
    replace(ipn.FundedProgram, '.', '') as ipnFundedProgramDotStripped,
    replace(wbs.WbsElementKey,'.','') as wbsElementKeyDotStripped
into #PreviouslyUnknownWbsElements
from ImportFinancial.ImpPnBudget as ipn
full outer join ImportFinancial.WbsElement as wbs on ipn.FundedProgram = replace(wbs.WbsElementKey,'.','')
where wbs.WbsElementKey is null


-- I make sure we really did the above correctly
if exists(
    select * from #PreviouslyUnknownWbsElements 
    where ipnFundedProgram != replace(WbsElementKey, '.', '')
    ) 
raiserror('Problem in join; should never happen', 16, 1)

-- Insert new WBS elements
insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
select new_wbs.WbsElementKey, new_wbs.WbsElementText
from #PreviouslyUnknownWbsElements as new_wbs

drop table #PreviouslyUnknownWbsElements


-- Clean out the target table
delete from ImportFinancial.WbsElementPnBudget

-- Load up the target table
insert into ImportFinancial.WbsElementPnBudget (WbsElementID,
                                                CostAuthorityID,
                                                PnBudgetFundTypeID,
                                                FundingSourceID,
                                                FundsCenter,
                                                FiscalQuarterID,
                                                FiscalYear,
                                                BudgetObjectCodeID,
                                                FIDocNumber,
                                                Recoveries,
                                                CommittedButNotObligated,
                                                TotalObligations,
                                                TotalExpenditures,
                                                UndeliveredOrders)
-- 17,994 rows
select
    wbs.WbsElementID,
    ca.CostAuthorityID,
    --wbs.WbsElementKey,
    pnft.PnBudgetFundTypeID,
    --pnft.PnBudgetFundTypeName
    fs.FundingSourceID,
    --fs.FundingSourceName
    ipn.FundsCenter,
    --ipn.FiscalYearPeriod,
    fq.FiscalQuarterID,
    substring(ipn.FiscalYearPeriod, 5, 4) as FiscalYear,
    dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalDate(ipn.CommitmentItem, convert(int,substring(ipn.FiscalYearPeriod, 5, 4))) as BudgetObjectCodeID,
    ipn.FiDocNumber,
    ipn.Recoveries,
    ipn.CommittedButNotObligated,
    ipn.TotalObligations,
    ipn.TotalExpenditures,
    ipn.UndeliveredOrders
from ImportFinancial.ImpPnBudget as ipn
inner join ImportFinancial.WbsElement as wbs on ipn.FundedProgram = replace(wbs.WbsElementKey,'.','')
--Nullable for now; we'd like to close this up if we can.
left join Reclamation.CostAuthority as ca on wbs.WbsElementKey = ca.CostAuthorityWorkBreakdownStructure
inner join ImportFinancial.PnBudgetFundType as pnft on ipn.FundType = pnft.PnBudgetFundTypeDisplayName
inner join dbo.FundingSource as fs on ipn.Fund = fs.FundingSourceName
inner join ImportFinancial.FiscalQuarter as fq on convert(INT, substring(ipn.FiscalYearPeriod, 3, 1)) + 1 = fq.FiscalQuarterNumber


end

/*

exec dbo.pReclamationImportPnBudget
select * from ImportFinancial.ImpPnBudget

*/