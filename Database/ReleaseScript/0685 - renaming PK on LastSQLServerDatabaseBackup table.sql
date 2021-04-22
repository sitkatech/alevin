
if exists (select * from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_NAME = 'PK_LastSQLServerDatabaseBackup') begin
    exec sp_rename 'dbo.PK_LastSQLServerDatabaseBackup', 'PK_LastSQLServerDatabaseBackup_LastSQLServerDatabaseBackupID', 'OBJECT'
end