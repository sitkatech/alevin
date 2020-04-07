--select * from [ReclamationOneTimeImport].[BudgetObjectCodeGroupsOnlySheet_4-7-2020]
--select * from Reclamation.BudgetObjectCodeGroup

insert into Reclamation.BudgetObjectCodeGroup (BudgetObjectCodeGroupPrefix, BudgetObjectCodeGroupName, BudgetObjectCodeGroupDefinition)
select 
    oti.[Group] as BudgetObjectCodeGroupPrefix,
    oti.BOC_Category as BudgetObjectCodeGroupName,
    oti.Definitions as BudgetObjectCodeGroupDefinition
from [ReclamationOneTimeImport].[BudgetObjectCodeGroupsOnlySheet_4-7-2020] as oti
GO

-- Now that we have data in BudgetObjectCodeGroup, fill in self-pointers to arrange the hierarchy just for Groups.

--select * from Reclamation.BudgetObjectCodeGroup

select  bocg.BudgetObjectCodeGroupPrefix,
        SUBSTRING(bocg.BudgetObjectCodeGroupPrefix, 2, 1) as sub,
        LEN(bocg.BudgetObjectCodeGroupPrefix) as lengthTwo
from Reclamation.BudgetObjectCodeGroup as bocg
where ( LEN(BudgetObjectCodeGroupPrefix) = 2 and SUBSTRING(BudgetObjectCodeGroupPrefix, 2, 1) = '0')

-- Parents are null. Just being explicit.
update Reclamation.BudgetObjectCodeGroup
set ParentBudgetObjectCodeGroupID = null
where ( LEN(BudgetObjectCodeGroupPrefix) = 2 and SUBSTRING(BudgetObjectCodeGroupPrefix, 2, 1) = '0')


-- Update middle level (11, 13, 21, 22, etc.)
update Reclamation.BudgetObjectCodeGroup
set ParentBudgetObjectCodeGroupID =
(
    select bocg_inner.BudgetObjectCodeGroupID
    from Reclamation.BudgetObjectCodeGroup as bocg_inner where
                      ( 
                        -- 1X, 2X
                        (LEN(bocg_inner.BudgetObjectCodeGroupPrefix) = 2)
                        -- First letter matches 
                        and (SUBSTRING(bocg_inner.BudgetObjectCodeGroupPrefix, 1, 1) = SUBSTRING(Reclamation.BudgetObjectCodeGroup.BudgetObjectCodeGroupPrefix, 1, 1))
                        -- Our second digit is 0 (meaning we are the appropriate parent)
                        and (SUBSTRING(bocg_inner.BudgetObjectCodeGroupPrefix, 2, 1) = '0')
                        -- Not the same as ourself
                        and bocg_inner.BudgetObjectCodeGroupPrefix != Reclamation.BudgetObjectCodeGroup.BudgetObjectCodeGroupPrefix
                      ) 
)
where LEN(Reclamation.BudgetObjectCodeGroup.BudgetObjectCodeGroupPrefix) = 2

-- Update Third level (11.1, 11.3, 12.1, etc.)
update Reclamation.BudgetObjectCodeGroup
set ParentBudgetObjectCodeGroupID =
(
    select bocg_inner.BudgetObjectCodeGroupID
    from Reclamation.BudgetObjectCodeGroup as bocg_inner where
                      ( 
                        -- Our length is 2 (so we are a mid level parent)
                        (LEN(bocg_inner.BudgetObjectCodeGroupPrefix) = 2)
                        -- First two letters match 
                        and (SUBSTRING(bocg_inner.BudgetObjectCodeGroupPrefix, 1, 2) = SUBSTRING(Reclamation.BudgetObjectCodeGroup.BudgetObjectCodeGroupPrefix, 1, 2))
                        -- Not the same as ourself (just in case, not really needed)
                        and bocg_inner.BudgetObjectCodeGroupPrefix != Reclamation.BudgetObjectCodeGroup.BudgetObjectCodeGroupPrefix
                      )
)
-- We are a length 4, meaning we are third level (leaf)
where LEN(Reclamation.BudgetObjectCodeGroup.BudgetObjectCodeGroupPrefix) = 4


/*

alter table Reclamation.BudgetObjectCode
add BudgetObjectCodeGroupID int null constraint FK_BudgetObjectCode_BudgetObjectCodeGroup_BudgetObjectCodeGroupID foreign key references Reclamation.BudgetObjectCodeGroup(BudgetObjectCodeGroupID)
GO


IF OBJECT_ID('tempdb..#TempBudgetObjectCodeStuff') IS NOT NULL DROP table #TempBudgetObjectCodeStuff

select
    bocg.BudgetObjectCodeGroupID,
    replace(bocg.BudgetObjectCodeGroupPrefix, '.', '') as StrippedBudgetObjectCodeGroupPrefix
into #TempBudgetObjectCodeStuff
from
    Reclamation.BudgetObjectCodeGroup as bocg

update #TempBudgetObjectCodeStuff
set StrippedBudgetObjectCodeGroupPrefix = LEFT(StrippedBudgetObjectCodeGroupPrefix + '00000',3)

*/

/*

select * from #TempBudgetObjectCodeStuff

*/

/*
update Reclamation.BudgetObjectCode
set BudgetObjectCodeGroupID = (
                                select
                                    bocg.BudgetObjectCodeGroupID
                                from
                                    #TempBudgetObjectCodeStuff as bocg
                                    join Reclamation.BudgetObjectCode as boc on bocg.StrippedBudgetObjectCodeGroupPrefix = left(boc.BudgetObjectCodeName, 3)
                              )


                                select
                                    bocg.BudgetObjectCodeGroupID,
                                    count(*) countOfBOCgroup
                                from
                                    #TempBudgetObjectCodeStuff as bocg
                                    join Reclamation.BudgetObjectCode as boc on bocg.StrippedBudgetObjectCodeGroupPrefix = left(boc.BudgetObjectCodeName, 3)
                                    group by bocg.BudgetObjectCodeGroupID
                                    order by count(*) desc



                                select
                                    bocg.BudgetObjectCodeGroupID
                                    --count(*) countOfBOCgroup
                                from
                                    #TempBudgetObjectCodeStuff as bocg
                                    join Reclamation.BudgetObjectCode as boc on bocg.StrippedBudgetObjectCodeGroupPrefix = left(boc.BudgetObjectCodeName, 3)

                                where
                                    bocg.StrippedBudgetObjectCodeGroupPrefix = '110'
                                    --group by bocg.BudgetObjectCodeGroupID
                                    --order by count(*) desc
*/