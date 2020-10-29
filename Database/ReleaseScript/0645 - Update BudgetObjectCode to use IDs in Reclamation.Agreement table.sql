
--select * from Reclamation.AgreementCostAuthority

/*
alter table Reclamation.Agreement
add BudgetObjectCodeID int null
GO

ALTER TABLE [Reclamation].Agreement
WITH CHECK ADD  CONSTRAINT [FK_BudgetObjectCodeGroup_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY([BudgetObjectCodeID])
REFERENCES Reclamation.[BudgetObjectCode] ([BudgetObjectCodeID])
GO




DROP table IF EXISTS #TempEasilyFixedBudgetObjectCodes;


select ra.AgreementID,
       ra.BOC,
       boc.BudgetObjectCodeID,
       boc.BudgetObjectCodeName
into #TempEasilyFixedBudgetObjectCodes
from Reclamation.Agreement as ra
left join Reclamation.BudgetObjectCode as boc on ra.BOC = boc.BudgetObjectCodeName
where boc.BudgetObjectCodeID is not null

-- Do the easy wins first
update Reclamation.Agreement
set BudgetObjectCodeID = tboc.BudgetObjectCodeID
from #TempEasilyFixedBudgetObjectCodes as tboc where  Reclamation.Agreement.AgreementID = tboc.AgreementID

-- What's left?
select * from Reclamation.Agreement
where BOC is not null and BudgetObjectCodeID is null

-- Manual fixups 
update Reclamation.Agreement
set BudgetObjectCodeID = rboc.BudgetObjectCodeID
from Reclamation.BudgetObjectCode as rboc
where BOC = '111A' and rboc.BudgetObjectCodeName = 

select * from Reclamation.BudgetObjectCode
where BudgetObjectCodeName like '%111A%'





select * from Reclamation.BudgetObjectCode as boc where BudgetObjectCodeID = 3047
*/
