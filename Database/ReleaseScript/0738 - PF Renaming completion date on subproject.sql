

EXECUTE sp_rename N'dbo.Subproject.CompleteionYear', N'Tmp_CompletionYear', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Subproject.Tmp_CompletionYear', N'CompletionYear', 'COLUMN' 
GO

EXECUTE sp_rename N'dbo.Subproject.ProjectStageID', N'Tmp_SubprojectStageID', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Subproject.Tmp_SubprojectStageID', N'SubprojectStageID', 'COLUMN' 
GO

EXEC sp_rename N'dbo.FK_Subproject_ProjectStage_ProjectStageID', N'FK_Subproject_ProjectStage_SubprojectStageID_ProjectStageID'


Alter table dbo.Subproject
Add SubprojectName varchar(140) not null,
SubprojectDescription varchar(4000) not null




