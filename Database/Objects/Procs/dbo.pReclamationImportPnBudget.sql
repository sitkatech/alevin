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
    raiserror('pReclamationImportPnBudget: There is no data in Staging.StageImpPnBudget. Publishing halted.', 16,1)
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

-- What years are referenced in the incoming import?
select distinct dbo.GetFiscalYearFromFiscalYearPeriodString(FiscalYearPeriod) from ImportFinancial.ImpPnBudget

-- Clean out the target table using ONLY fiscal years NOT being
-- directly imported by this latest incoming set of data. Specifically,
-- if only FY 2020 is being imported, leave alone previous records for FY 2018, FY 2019, etc.
/*
select * from ImportFinancial.WbsElementPnBudget 
where FiscalYear in (select distinct dbo.GetFiscalYearFromFiscalYearPeriodString(FiscalYearPeriod) from ImportFinancial.ImpPnBudget)
*/

-- Clean out the target table, but just for the FYs we are importing.
delete from ImportFinancial.WbsElementPnBudget
where FiscalYear in (select distinct dbo.GetFiscalYearFromFiscalYearPeriodString(FiscalYearPeriod) from ImportFinancial.ImpPnBudget)

-- Load up the target table
insert into ImportFinancial.WbsElementPnBudget (WbsElementID,
                                                CostAuthorityID,
                                                PnBudgetFundTypeID,
                                                FundingSourceID,
                                                FundsCenter,
                                                FiscalMonthPeriod,
                                                FiscalQuarterID,
                                                FiscalYear,
                                                CalendarMonthNumber,
                                                CalendarYear,
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
    pnft.PnBudgetFundTypeID,
    fs.FundingSourceID,
    ipn.FundsCenter,
    dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString(ipn.FiscalYearPeriod) as FiscalMonth,
    fq.FiscalQuarterID,
    dbo.GetFiscalYearFromFiscalYearPeriodString(ipn.FiscalYearPeriod) as FiscalYear,
    datepart(month, dbo.GetCalendarDateForStartOfFiscalYearPeriod(ipn.FiscalYearPeriod)),     -- CalendarMonthNumber,
    datepart(year, dbo.GetCalendarDateForStartOfFiscalYearPeriod(ipn.FiscalYearPeriod)),    -- CalendarYear
    dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalYear(ipn.CommitmentItem, dbo.GetFiscalYearFromFiscalYearPeriodString(ipn.FiscalYearPeriod)) as BudgetObjectCodeID,
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
inner join ImportFinancial.FiscalQuarter as fq on (dbo.GetFiscalQuarterIDForCalendarDate(dbo.GetCalendarDateForStartOfFiscalYearPeriod(ipn.FiscalYearPeriod))) = fq.FiscalQuarterID

-- Full delete here should be OK since we will be re-constituting from ImportFinancial.WbsElementPnBudget, which should have
-- all the FYs, both the existing, unchanged FYs, as well as the newly-imported FYs.
delete from dbo.ProjectFundingSourceExpenditure

insert into dbo.ProjectFundingSourceExpenditure(TenantID, ProjectID, FundingSourceID, CalendarYear, ExpenditureAmount, CostTypeID)
select 12, cap.ProjectID , x.FundingSourceID, x.CalendarYear, sum(isnull(x.TotalExpenditures,0)) as ExpenditureAmount, null from ImportFinancial.WbsElementPnBudget x
join Reclamation.CostAuthorityProject cap on x.CostAuthorityID = cap.CostAuthorityID
group by x.FundingSourceID, x.CalendarYear, cap.ProjectID

end

/*

exec dbo.pReclamationImportPnBudget

select * from ImportFinancial.WbsElementPnBudget

select distinct FiscalYear
from ImportFinancial.WbsElementPnBudget 


*/