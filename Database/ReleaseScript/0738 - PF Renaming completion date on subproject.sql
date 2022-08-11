

EXECUTE sp_rename N'dbo.Subproject.CompleteionYear', N'Tmp_CompletionYear', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Subproject.Tmp_CompletionYear', N'CompletionYear', 'COLUMN' 
GO

EXECUTE sp_rename N'dbo.Subproject.ProjectStageID', N'Tmp_SubprojectStageID', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Subproject.Tmp_SubprojectStageID', N'SubprojectStageID', 'COLUMN' 
GO

Alter table dbo.Subproject
Add SubprojectName varchar(140) not null,
SubprojectDescription varchar(4000) not null
