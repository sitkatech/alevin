
alter table dbo.ProjectFundingSourceBudget
drop column SecuredAmount
go


alter table dbo.ProjectFundingSourceBudgetUpdate
drop column SecuredAmount
go

EXEC sp_rename 'dbo.ProjectFundingSourceBudget.TargetedAmount', 'ProjectedAmount', 'COLUMN';
EXEC sp_rename 'dbo.ProjectFundingSourceBudgetUpdate.TargetedAmount', 'ProjectedAmount', 'COLUMN';

ALTER SCHEMA Reclamation TRANSFER dbo.ProjectFundingSourceBudget;
ALTER SCHEMA Reclamation TRANSFER dbo.ProjectFundingSourceBudgetUpdate;

delete from dbo.ProjectCustomGridConfiguration
where ProjectCustomGridColumnID = 16 --delete any SourcedFunding columns from configurations Then this can be removed from the lookup

delete from dbo.ProjectCustomGridColumn
where ProjectCustomGridColumnID = 16 and ProjectCustomGridColumnName = 'SecuredFunding'