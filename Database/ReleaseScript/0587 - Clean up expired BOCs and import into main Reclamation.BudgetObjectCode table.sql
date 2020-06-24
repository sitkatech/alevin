--select * from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]

-- Delete grouping entries in this import
delete from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
where [Group] in (10,11,11.1,11.3,11.5,11.8,11.9,12,12.1,20,21, 43, 44, 90, 91, 93, 94, 99, 99.5, 99.9, 33, 40, 41, 32.3, 26, 30, 92)

-- Delete more grouping entries in this import
delete from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
where [Group] in (21.1, 21.2, 21.3, 21.4, 22, 23, 23.1, 23.2, 23.3, 24, 25.2, 25.3, 25.4, 25.6, 25.7, 25.8, 31, 32, 42, 21.9, 25.5)

-- Manual fixup
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = '259700' where FBMS_2017 = '2597'

-- Now we are left with only actual leaves - real BOC entries, not groups.
-- Fill in the BOC Names
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = FBMS_2015
where FBMS_2015 is not null and BudgetObjectCodeName is null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = FBMS_2016
where FBMS_2016 is not null and BudgetObjectCodeName is null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = FBMS_2017
where FBMS_2017 is not null and BudgetObjectCodeName is null

-- Now we can reconstruct our Group column, with BudgetObjectCodeName fully filled in
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [Group] = SUBSTRING(BudgetObjectCodeName, 1, 2) + '.' + SUBSTRING(BudgetObjectCodeName, 3, 1)


-- Now that we have the BudgetObjectCodeName safely tucked
-- away in, we can get the year columns ready for an unpivot, and
-- put the FbmsYear values into them.
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2004] = 2004 
where [2004] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2005] = 2005 
where [2005] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2006] = 2006 
where [2006] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2010] = 2010 
where [2010] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2011] = 2011 
where [2011] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2014] = 2014
where [FBMS_2014] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2015] = 2015
where [FBMS_2015] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2016] = 2016
where [FBMS_2016] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2017] = 2017
where [FBMS_2017] is not null


--select * from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]

select eboc.BudgetObjectCodeName,
       eboc.BOC_item,
       eboc.Definitions,
       eboc.[1099_Reportable],
       eboc.[1099_Explanation]
from 
[ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] as eboc

-- Temp table to help with BOC FBMS year reconstruction
DROP TABLE IF EXISTS #UnpivotedExpiredBudgetObjectCodes

-- Attempting unpivot
select
       unpiv.BudgetObjectCodeName,
       unpiv.[Group] as PossibleBudgetObjectCodeGroupPrefix,
       -1 as BudgetObjectCodeGroupID,
       unpiv.BOC_item,
       unpiv.Definitions,
       unpiv.[1099_Reportable],
       unpiv.[1099_Explanation],
       unpiv.FbmsYear
into #UnpivotedExpiredBudgetObjectCodes
from
(select
       ebocx.BudgetObjectCodeName,
       ebocx.[Group],
       ebocx.BOC_item,
       ebocx.Definitions,
       ebocx.[1099_Reportable],
       ebocx.[1099_Explanation],
       ebocx.[2004],
       ebocx.[2005],
       ebocx.[2006],
       ebocx.[2010],
       ebocx.[2011],
       ebocx.[FBMS_2014],
       ebocx.[FBMS_2015],
       ebocx.[FBMS_2016],
       ebocx.[FBMS_2017]
  from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] as ebocx) as piv
unpivot
    (FbmsYear for FmbsYear in ([2004],
                               [2005],
                               [2006],
                               [2010],
                               [2011],
                               [FBMS_2014],
                               [FBMS_2015],
                               [FBMS_2016],
                               [FBMS_2017])
    )as unpiv

--select * from #UnpivotedExpiredBudgetObjectCodes

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
from  #UnpivotedExpiredBudgetObjectCodes as unpiv
inner join Reclamation.BudgetObjectCodeGroup as bocg on  unpiv.PossibleBudgetObjectCodeGroupPrefix = bocg.BudgetObjectCodeGroupPrefix

-- We still have some groups unmatched.
--select * from #UnpivotedExpiredBudgetObjectCodes
--where BudgetObjectCodeGroupID = -1

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '22')
where PossibleBudgetObjectCodeGroupPrefix in( '22.1', '22.2')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '25')
where PossibleBudgetObjectCodeGroupPrefix in( '25.9')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '31')
where PossibleBudgetObjectCodeGroupPrefix in( '31.1', '31.2', '31.9')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '32')
where PossibleBudgetObjectCodeGroupPrefix in( '32.1', '32.7', '32.9')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '42')
where PossibleBudgetObjectCodeGroupPrefix in( '42.1')

-- Should be no more groups unmatched.
--select * from #UnpivotedExpiredBudgetObjectCodes
--where BudgetObjectCodeGroupID = -1

/* 
-- Double check visually

select bocg.BudgetObjectCodeGroupID,
       bocg.BudgetObjectCodeGroupPrefix as boc_prefix,
       unpiv.PossibleBudgetObjectCodeGroupPrefix as unpiv_prefix,
       bocg.BudgetObjectCodeGroupName
from #UnpivotedExpiredBudgetObjectCodes as unpiv
inner join Reclamation.BudgetObjectCodeGroup as bocg on unpiv.BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
*/

-- Insert the new BudgetObjectCodes
insert into Reclamation.BudgetObjectCode(BudgetObjectCodeName, 
                                         BudgetObjectCodeItemDescription, 
                                         BudgetObjectCodeDefinition, 
                                         BudgetObjectCodeGroupID, 
                                         FbmsYear, 
                                         Reportable1099, 
                                         Explanation1099, 
                                         IsExpiredOrDeleted)
select newBocs.BudgetObjectCodeName,
       '' as BudgetObjectCodeItemDescription,
       newBocs.Definitions,
       newBocs.BudgetObjectCodeGroupID,
       newBocs.FbmsYear,
       CASE when newBocs.[1099_Reportable] = 'Yes' then 1
            when newBocs.[1099_Reportable] = 'No' then 0
            else null end as Reportable1099,
       newBocs.[1099_Explanation],
       -- All the ones we are importing now are expired/deleted
       1 as IsExpiredOrDeleted
from #UnpivotedExpiredBudgetObjectCodes as newBocs





