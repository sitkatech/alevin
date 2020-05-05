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

    -- TODO: A sanity check that there are actually records to import
    delete from ImportFinancial.ImpPnBudget
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

/*

select * from ImportFinancial.ImpPnBudget

*/



/*
select wbs.WbsElementKey,
       ipn.*
from ImportFinancial.ImpPnBudget as ipn
left join ImportFinancial.WbsElement as wbs on ipn.FundedProgram = replace(wbs.WbsElementKey,'.','')
where wbs.WbsElementKey is null
and
ipn.FundedProgram != 'FPDEFAULT'
*/

select * from ImportFinancial.WbsElement

--These are WBS Elements referenced by the incoming PnBudget table that we 
--need to add to the WbsElement table. Since we don't know their WbsElementText,
--we put in something of a placeholder, and link with a back pointer to ImpPnBudget
--for forensics.
DROP TABLE IF EXISTS #PreviouslyUnknownWbsElements
GO


/*
-- This is not the most efficient way to get this done, but I'm missing something and stuck
-- and trying to make headway somehow. So going about the problem in a roundabout way and
-- hoping to find my problem.

-- Putting *ALL* matchups into a table
select
distinct
    ipn.FundedProgram as ipnFundedProgram,
    SUBSTRING(ipn.FundedProgram, 1, 2) + '.' + SUBSTRING(ipn.FundedProgram, 3, 8) + '.' + SUBSTRING(ipn.FundedProgram, 10, 99) as WbsElementKey,
    '[From ImpPnBudget -- need more info]' as WbsElementText,
    replace(ipn.FundedProgram, '.', '') as ipnFundedProgramDotStripped,
    replace(wbs.WbsElementKey,'.','') as wbsElementKeyDotStripped
into #PreviouslyUnknownWbsElements
from ImportFinancial.ImpPnBudget as ipn
left join ImportFinancial.WbsElement as wbs on replace(ipn.FundedProgram, '.', '') = replace(wbs.WbsElementKey,'.','')
GO


select * 
from #PreviouslyUnknownWbsElements as puwbs
inner join ImportFinancial.WbsElement as wbs on puwbs.WbsElementKey = wbs.WbsElementKey
where wbsElementKeyDotStripped is null
*/



-- 22 out of 188 unknown so far.
-- We do the best we can to import these, but it's not perfect.
-- 'FPDEFAULT' comes along for the ride here on the first pass, but I don't know what to do with it otherwise.

DROP TABLE IF EXISTS #PreviouslyUnknownWbsElements
GO

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
GO

-- I did make this mistake before
if exists(
    select * from #PreviouslyUnknownWbsElements 
    where ipnFundedProgram != replace(WbsElementKey, '.', '')
    ) 
raiserror('Problem in join; should never happen', 16, 1)


insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
select new_wbs.WbsElementKey, new_wbs.WbsElementText
from #PreviouslyUnknownWbsElements as new_wbs
GO




select * from  #PreviouslyUnknownWbsElements where WbsElementKey = 'RX.16786801.11300000'

select * from ImportFinancial.ImpPnBudget as ipn
select * from ImportFinancial.WbsElement as wbs where wbs.WbsElementKey = 'RX.16786801.11300000'

/*
select * from ImportFinancial.WbsElement where WbsElementKey = 'RR.16786821.13008580'
select * from #PreviouslyUnknownWbsElements where WbsElementKey = 'RR.16786821.13008580'
*/

select
distinct
    ipn.FundedProgram as ipnFundedProgram,
    SUBSTRING(ipn.FundedProgram, 1, 2) + '.' + SUBSTRING(ipn.FundedProgram, 3, 8) + '.' + SUBSTRING(ipn.FundedProgram, 10, 99) as WbsElementKey,
    '[From ImpPnBudget -- need more info]' as WbsElementText,
    replace(ipn.FundedProgram, '.', '') as ipnFundedProgramDotStripped,
    replace(wbs.WbsElementKey,'.','') as wbsElementKeyDotStripped
into #PreviouslyUnknownWbsElements
from ImportFinancial.ImpPnBudget as ipn
left join ImportFinancial.WbsElement as wbs on replace(ipn.FundedProgram, '.', '') = replace(wbs.WbsElementKey,'.','')
where wbs.WbsElementKey is null



select * from
(
    select
    distinct
        ipn.FundedProgram as ipnFundedProgram,
        SUBSTRING(ipn.FundedProgram, 1, 2) + '.' + SUBSTRING(ipn.FundedProgram, 3, 8) + '.' + SUBSTRING(ipn.FundedProgram, 10, 99) as WbsElementKey,
        '[From ImpPnBudget -- need more info]' as WbsElementText,
        replace(ipn.FundedProgram, '.', '') as ipnFundedProgramDotStripped,
        replace(wbs.WbsElementKey,'.','') as wbsElementKeyDotStripped
    from ImportFinancial.ImpPnBudget as ipn
    left join ImportFinancial.WbsElement as wbs on replace(ipn.FundedProgram, '.', '') = replace(wbs.WbsElementKey,'.','')
) as x
order by x.WbsElementKey

where
wbs.WbsElementKey like '%16786812%'


select * from ImportFinancial.WbsElement where WbsElementKey = 'RX.16786802.21000000'






insert into ImportFinancial.WbsElement(WbsElementKey, WbsElementText)
select new_wbs.WbsElementKey, new_wbs.WbsElementText
from #PreviouslyUnknownWbsElements as new_wbs
GO








select wbs.*
from ImportFinancial.WbsElement as wbs
where WbsElementKey = 'RR.16786821.13008580'

select
distinct
    ipn.FundedProgram as ipnFundedProgram,
    SUBSTRING(ipn.FundedProgram, 1, 2) + '.' + SUBSTRING(ipn.FundedProgram, 3, 8) + '.' + SUBSTRING(ipn.FundedProgram, 10, 99) as WbsElementKey,
    '[From ImpPnBudget -- need more info]' as WbsElementText,
    replace(ipn.FundedProgram, '.', '') as ipnFundedProgramDotStripped,
    replace(wbs.WbsElementKey,'.','') as wbsElementKeyDotStripped
into #PreviouslyUnknownWbsElements
from ImportFinancial.ImpPnBudget as ipn
left join ImportFinancial.WbsElement as wbs on replace(ipn.FundedProgram, '.', '') = replace(wbs.WbsElementKey,'.','')
--where wbs.WbsElementKey is not null
where wbs.WbsElementKey = 'RR.16786821.13008580'
GO

select * from #PreviouslyUnknownWbsElements





drop table #PreviouslyUnknownWbsElements
GO





-- Clean out the target table
delete from ImportFinancial.WbsElementPnBudget

-- Load up the target table
insert into ImportFinancial.WbsElementPnBudget (WbsElementID,
                                                PnBudgetFundTypeID,
                                                FundingSourceID,
                                                FundsCenter,
                                                FiscalQuarterID,
                                                FiscalYear,
                                                CommitmentItemID,
                                                FIDocNumber,
                                                Recoveries,
                                                CommittedButNotObligated,
                                                TotalObligations,
                                                TotalExpenditures,
                                                UndeliveredOrders)


select
    wbs.WbsElementID,
    wbs.WbsElementKey,
    pnft.PnBudgetFundTypeID,
    pnft.PnBudgetFundTypeName
from ImportFinancial.ImpPnBudget as ipn
inner join ImportFinancial.WbsElement as wbs on ipn.FundedProgram = replace(wbs.WbsElementKey,'.','')
inner join ImportFinancial.PnBudgetFundType as pnft on ipn.FundType = pnft.PnBudgetFundTypeDisplayName

select * from ImportFinancial.ImpPnBudget as ipn
select * from ImportFinancial.PnBudgetFundType


/*


select *  
from ImportFinancial.ImpPnBudget as ipn

-- Anything like RX167868141000000?
select * from
ImportFinancial.WbsElement as wbs
where wbs.WbsElementKey like
'%16786814%'

select * from ImportFinancial.ImpPnBudget

*/

/*

select * from ImportFinancial.WbsElement as wbs
where wbs.WbsElementKey like '%16786821%'

select ipn.*
from ImportFinancial.ImpPnBudget as ipn
where ipn.FundedProgram = 'FPDEFAULT'



select * from ImportFinancial.WbsElement
where WbsElementKey like '%16786%'

select ipn.*
from ImportFinancial.ImpPnBudget as ipn

end
GO
*/

/*

exec dbo.pReclamationImportPnBudget
select * from ImportFinancial.ImpPnBudget

*/