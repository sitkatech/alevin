

-- FK BudgetObjectCode ==> BudgetObjectCodeGroup

alter table Reclamation.BudgetObjectCode
add BudgetObjectCodeGroupID int null 
constraint FK_BudgetObjectCode_BudgetObjectCodeGroup_BudgetObjectCodeGroupID 
foreign key references Reclamation.BudgetObjectCodeGroup(BudgetObjectCodeGroupID)
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



/*

select * from #TempBudgetObjectCodeStuff

select * from Reclamation.BudgetObjectCodeGroup
select * from Reclamation.BudgetObjectCode

*/

begin tran

select * from Reclamation.BudgetObjectCode

update Reclamation.BudgetObjectCode
set BudgetObjectCodeGroupID = (
                                select
                                    bocg.BudgetObjectCodeGroupID
                                from
                                    #TempBudgetObjectCodeStuff as bocg
                                where SUBSTRING(Reclamation.BudgetObjectCode.BudgetObjectCodeName, 1, 3) = bocg.StrippedBudgetObjectCodeGroupPrefix
                                    --join Reclamation.BudgetObjectCode as boc on bocg.StrippedBudgetObjectCodeGroupPrefix = left(boc.BudgetObjectCodeName, 3)
                              )

select boc.BudgetObjectCodeID,
       boc.BudgetObjectCodeName,
       bocg.BudgetObjectCodeGroupID,
       bocg.BudgetObjectCodeGroupPrefix,
       bocg.BudgetObjectCodeGroupName
from Reclamation.BudgetObjectCode as boc
inner join Reclamation.BudgetObjectCodeGroup as bocg on boc.BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
GO

select * from Reclamation.BudgetObjectCode where BudgetObjectCodeGroupID is null
GO

alter table Reclamation.BudgetObjectCode
alter column BudgetObjectCodeGroupID int not null

GO

rollback tran

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