

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


update Reclamation.BudgetObjectCode
set BudgetObjectCodeGroupID = (
                                select
                                    bocg.BudgetObjectCodeGroupID
                                from
                                    #TempBudgetObjectCodeStuff as bocg
                                where SUBSTRING(Reclamation.BudgetObjectCode.BudgetObjectCodeName, 1, 3) = bocg.StrippedBudgetObjectCodeGroupPrefix
                                    --join Reclamation.BudgetObjectCode as boc on bocg.StrippedBudgetObjectCodeGroupPrefix = left(boc.BudgetObjectCodeName, 3)
                              )
GO

/*
select boc.BudgetObjectCodeID,
       boc.BudgetObjectCodeName,
       bocg.BudgetObjectCodeGroupID,
       bocg.BudgetObjectCodeGroupPrefix,
       bocg.BudgetObjectCodeGroupName
from Reclamation.BudgetObjectCode as boc
inner join Reclamation.BudgetObjectCodeGroup as bocg on boc.BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
GO
*/

-- Just which codes have problems up to here
/*
select distinct boc.BudgetObjectCodeName from Reclamation.BudgetObjectCode as boc where BudgetObjectCodeGroupID is null
*/

-- Using the output above, we manually assign the following BOC to their groups. Dorothy said this is just the way things are,
-- so we roll with it. This is one advantage of using a loose grouping rather than something more locked down.

IF OBJECT_ID('tempdb..#BudgetObjectCodeToBudgetObjectCodeGroupManualMap') IS NOT NULL DROP table #BudgetObjectCodeToBudgetObjectCodeGroupManualMap

CREATE TABLE #BudgetObjectCodeToBudgetObjectCodeGroupManualMap
(
    BudgetObjectCodeName nvarchar(6) not null,
    BudgetObjectCodeGroupPrefix nvarchar(5) not null,
    BudgetObjectCodeGroupID int null -- Fix this up in second pass
);
GO

--select * from Reclamation.BudgetObjectCode
--select * from Reclamation.BudgetObjectCodeGroup

insert into #BudgetObjectCodeToBudgetObjectCodeGroupManualMap(BudgetObjectCodeName, BudgetObjectCodeGroupPrefix)
values
('122000', '12.1'),
('122A00', '12.1'),
('122B00', '12.1'),

('221A00', '22'),
('221B00', '22'),
('222C00', '22'),
('223A00', '22'),
('224F00', '22'),
('224G00', '22'),
('224K00', '22'),
('224L00', '22'),

('241A00', '24'),
('241B00', '24'),
('241E00', '24'),
('241F00', '24'),
('242A00', '24'),
('242B00', '24'),
('243C00', '24'),
('243D00', '24'),

('261A00', '26'),
('261B00', '26'),
('261C00', '26'),
('261Ci0', '26'),
('261F00', '26'),
('261M00', '26'),
('261X00', '26'),
('262A00', '26'),
('262F00', '26'),
('262J00', '26'),
('262V00', '26'),
('263L00', '26'),
('263O00', '26'),
('264A00', '26'),
('264B00', '26'),
('264J00', '26'),
('264K00', '26'),
('264S00', '26'),
('264W00', '26'),
('265C00', '26'),
('265F00', '26'),
('265S00', '26'),
('267A00', '26'),
('269A00', '26'),
('269B00', '26'),
('269C00', '26'),
('269D00', '26'),
('269F00', '26'),
('269G00', '26'),

('311999', '31'),
('311A00', '31'),
('311C00', '31'),
('311D00', '31'),
('311E00', '31'),
('311H00', '31'),
('311J00', '31'),
('311K00', '31'),
('311L00', '31'),
('311V00', '31'),

('312A00', '31'),
('312B00', '31'),
('312C00', '31'),
('312D00', '31'),
('312E00', '31'),
('312F00', '31'),
('312G00', '31'),
('312H00', '31'),
('312J00', '31'),
('312K00', '31'),
('312L00', '31'),
('312P00', '31'),
('312T00', '31'),
('312V00', '31'),
('312W00', '31'),
('312X00', '31'),
('312Z00', '31'),

('313999', '31'),
('313L00', '31'),

('321999', '32'),
('321A00', '32'),
('321B00', '32'),
('321E00', '32'),
('321L00', '32'),

('322000', '32'),
('322999', '32'),
('322B00', '32'),
('322C00', '32'),
('322D00', '32'),
('322E00', '32'),
('322R00', '32'),
('322S00', '32'),
('322Z00', '32'),

('324J00', '32.3'),

('325A00', '32.3'),
('325E00', '32.3'),

('326B00', '32.3'),
('326C00', '32.3'),
('326D00', '32.3'),
('326E00', '32.3'),
('326R00', '32.3'),
('326S00', '32.3'),
('326Z00', '32.3'),


('327A00', '32.3'),
('327B00', '32.3'),
('327C00', '32.3'),
('327L00', '32.3'),
('327Y00', '32.3'),
('327Z00', '32.3'),

('328J00', '32.3'),

('331A00', '33'),

('332A00', '33'),
('332A99', '33'),
('332B99', '33'),

('411C00', '41'),
('411G00', '41'),
('411GM0', '41'),
('411GX0', '41'),
('411P00', '41'),

('412A00', '41'),
('412B00', '41'),
('412BG0', '41'),

('413A00', '41'),
('413AAD', '41'),
('413AEX', '41'),

('414A00', '41'),

('415A00', '41'),

('416A00', '41'),

('421A00', '42'),
('421B00', '42'),
('421D00', '42'),
('421J00', '42'),
('421L00', '42'),
('421R00', '42'),

('430UA0', '43'),
('431A00', '43'),

('441A00', '44'),

('7L0000', '91'),
('8X0000', '91')

--select * from Reclamation.BudgetObjectCodeGroup 
--where BudgetObjectCodeGroupPrefix like '%26.0%'

/*
select * from Reclamation.BudgetObjectCode
select * from Reclamation.BudgetObjectCodeGroup

select * from #BudgetObjectCodeToBudgetObjectCodeGroupManualMap


select 
       bocmap.BudgetObjectCodeName,
       bocmap.BudgetObjectCodeGroupPrefix,
       bocg.BudgetObjectCodeGroupPrefix,
       bocg.BudgetObjectCodeGroupID,
       bocg.BudgetObjectCodeGroupName
from
#BudgetObjectCodeToBudgetObjectCodeGroupManualMap as bocmap 
inner join Reclamation.BudgetObjectCodeGroup as bocg on bocmap.BudgetObjectCodeGroupPrefix = bocg.BudgetObjectCodeGroupPrefix
*/

-- Fill in the BudgetObjectCodeGroupIDs in the map
update #BudgetObjectCodeToBudgetObjectCodeGroupManualMap
set BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
from
#BudgetObjectCodeToBudgetObjectCodeGroupManualMap as bocmap 
inner join Reclamation.BudgetObjectCodeGroup as bocg on bocmap.BudgetObjectCodeGroupPrefix = bocg.BudgetObjectCodeGroupPrefix

-- Make sure we've successfully set all our BOC Group IDs in our Map; this will fail
-- if we failed to assign one, which happenend during development.
alter table #BudgetObjectCodeToBudgetObjectCodeGroupManualMap
alter column BudgetObjectCodeGroupID int not null

-- We can now use our manual map to fix up the missing BudgetObjectCodeGroupIDs
update Reclamation.BudgetObjectCode
set BudgetObjectCodeGroupID = bocmap.BudgetObjectCodeGroupID
from #BudgetObjectCodeToBudgetObjectCodeGroupManualMap as bocmap
where Reclamation.BudgetObjectCode.BudgetObjectCodeName = bocmap.BudgetObjectCodeName

-- Do we have any still missing?
-- If we do, locking down the column below will fail.
/*
select * from Reclamation.BudgetObjectCode
where BudgetObjectCodeGroupID is null
*/

-- Manual fixup. This just looks wrong, so I'm fixing.
update Reclamation.BudgetObjectCode
set BudgetObjectCodeName = '118B00',
    BudgetObjectCodeGroupID = 6
where BudgetObjectCodeID = 356

-- Another clearly wrong missing one
update Reclamation.BudgetObjectCode
set BudgetObjectCodeName = '252L00',
    BudgetObjectCodeGroupID = 26
where BudgetObjectCodeID = 1683

-- If all has gone well, we can finally lock this column down for good.
alter table Reclamation.BudgetObjectCode
alter column BudgetObjectCodeGroupID int not null

-- repair some names
exec sp_rename 'Reclamation.FK_BudgetObjectCodeGroup_BudgetObjectCodeGroup_ParentBudgetObjectCodeGroupID', 'FK_BudgetObjectCodeGroup_BudgetObjectCodeGroup_ParentBudgetObjectCodeGroupID_BudgetObjectCodeGroupID', 'OBJECT'
exec sp_rename 'Reclamation.UC_BudgetObjectCodeGroup_BudgetObjectCodeGroupName', 'AK_BudgetObjectCodeGroup_BudgetObjectCodeGroupName', 'OBJECT'
exec sp_rename 'Reclamation.UC_BudgetObjectCodeGroup_BudgetObjectCodeGroupPrefix', 'AK_BudgetObjectCodeGroup_BudgetObjectCodeGroupPrefix', 'OBJECT'