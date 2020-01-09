ALTER TABLE dbo.ProjectProjectStatus ADD  IsFinalStatusUpdate bit null
GO

update dbo.ProjectProjectStatus 
set IsFinalStatusUpdate = 0
GO

ALTER TABLE dbo.ProjectProjectStatus ALTER COLUMN IsFinalStatusUpdate bit not null
GO


ALTER TABLE dbo.ProjectProjectStatus ADD  LessonsLearned varchar(2500)
