
-- Can't do the rename since the table doesn't seem to exist
--exec sp_rename 'dbo.PK_LastSQLServerDatabaseBackup', 'PK_LastSQLServerDatabaseBackup_LastSQLServerDatabaseBackupID', 'OBJECT'


IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[LastSQLServerDatabaseBackup]') AND type in (N'U'))

BEGIN

CREATE TABLE [dbo].[LastSQLServerDatabaseBackup](
	[LastSQLServerDatabaseBackupID] [int] IDENTITY(1,1) NOT NULL,
	[BackupName] [nvarchar](128) NULL,
	[UserName] [nvarchar](128) NULL,
	[ServerName] [nvarchar](128) NULL,
	[DatabaseName] [nvarchar](128) NULL,
	[DatabaseVersion] [int] NULL,
	[DatabaseCreationDate] [datetime] NULL,
	[BackupSize] [numeric](20, 0) NULL,
	[BackupStartDate] [datetime] NULL,
	[BackupFinishDate] [datetime] NULL,
	[MachineName] [nvarchar](128) NULL,
	[Collation] [nvarchar](128) NULL,
	[CompressedBackupSize] [bigint] NULL,
 CONSTRAINT [PK_LastSQLServerDatabaseBackup_LastSQLServerDatabaseBackupID] PRIMARY KEY NONCLUSTERED 
(
	[LastSQLServerDatabaseBackupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

END



