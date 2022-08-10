

EXECUTE sp_rename N'dbo.Subproject.CompleteionYear', N'Tmp_CompletionYear', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Subproject.Tmp_CompletionYear', N'CompletionYear', 'COLUMN' 
GO

