
alter table Reclamation.BudgetObjectCode
add IsExpiredOrDeleted bit null
GO

-- The current data we have is all valid (not expired or deleted)
update Reclamation.BudgetObjectCode
set IsExpiredOrDeleted = 0
GO

alter table Reclamation.BudgetObjectCode
alter column IsExpiredOrDeleted bit not null
GO


