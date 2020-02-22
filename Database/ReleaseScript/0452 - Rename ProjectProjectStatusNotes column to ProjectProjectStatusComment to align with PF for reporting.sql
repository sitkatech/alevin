EXEC sp_rename 'dbo.ProjectProjectStatus.ProjectProjectStatusNotes', 'ProjectProjectStatusComment', 'COLUMN';

delete from dbo.FieldDefinitionDefault where FieldDefinitionID = 10037