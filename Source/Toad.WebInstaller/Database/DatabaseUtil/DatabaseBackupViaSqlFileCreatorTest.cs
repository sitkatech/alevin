using System.Data.SqlClient;
using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace Toad.WebInstaller.Database.DatabaseUtil
{
    [TestFixture]
    public class DatabaseBackupViaSqlFileCreatorTest
    {
        private const string DatabaseServer = "(local)";
        private const string DefaultStartDatabase = "master";
        private readonly string _testDatabaseName;

        public DatabaseBackupViaSqlFileCreatorTest()
        {
            _testDatabaseName = GetType().Name;
        }

        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void CanScriptOutDatabase()
        {
            // Arrange
            // -------
            using (var initialConn = new SqlConnection(string.Format("Server={0};Database={1};Trusted_Connection=True;pooling=false", DatabaseServer, DefaultStartDatabase)))
            {
                initialConn.Open();
                CleanupDatabase(initialConn);
                SetupTestDatabase(initialConn);
                initialConn.Close();
            }

            try
            {
                var testSubject = new DatabaseBackupViaSqlFileCreator(DatabaseServer, _testDatabaseName);

                // Act
                // ---
                string sqlBackup = testSubject.CreateSqlBackup();

                // Assert
                // ------
                Approvals.Verify(sqlBackup);
            }
            finally
            {
                using (var secondConn = new SqlConnection(string.Format("Server={0};Database={1};Trusted_Connection=True;pooling=false", DatabaseServer, DefaultStartDatabase)))
                {
                    secondConn.Open();
                    // Clean up
                    // ---------
                    CleanupDatabase(secondConn);
                    secondConn.Close();
                }
            }
        }

        private void SetupTestDatabase(SqlConnection initialConn)
        {
            string createTestDatabaseSql = string.Format("create database {0}", _testDatabaseName);
            using (var command = new SqlCommand(createTestDatabaseSql, initialConn))
            {
                command.ExecuteNonQuery();
            }

            using (var testDatabaseConn = new SqlConnection(string.Format("Server={0};Database={1};Trusted_Connection=True;pooling=false", DatabaseServer, _testDatabaseName)))
            {
                testDatabaseConn.Open();
                const string setupTablesSql = @"
create table tblB1
(
    ColB1Int int not null,
    ColC1Int int not null,
    ColB1String varchar(100) not null,
    ColB1Binary varbinary(100) not null,
    constraint PK_tblB1_ColB1Int primary key (ColB1Int),
);

create table tblC1
(
    ColC1Int int not null identity(1,1),
    ColC1String varchar(100),
    ColC1Binary varbinary(100),
    constraint PK_tblC1_ColC1Int primary key (ColC1Int)
);

CREATE TABLE [dbo].[sysdiagrams](
	[name] [sysname] NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON),
    CONSTRAINT [UK_principal_name] UNIQUE NONCLUSTERED 
(
	[principal_id] ASC,
	[name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
) 
EXEC sys.sp_addextendedproperty @name=N'microsoft_database_tools_support', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'sysdiagrams'

alter table tblB1 add constraint FK_tblB1_ColC1Int_tblC1_ColC1Int foreign key (ColC1Int) references tblC1(ColC1Int);


set identity_insert tblC1 on
insert into tblC1(ColC1Int, ColC1String, ColC1Binary) values (1, 'Hi there ╣ unicode', 0x012345);
insert into tblC1(ColC1Int, ColC1String, ColC1Binary) values (2, 'Hi there Some More', 0x0123454);
set identity_insert tblC1 off

insert into tblB1 (ColB1Int, ColC1Int, ColB1String, ColB1Binary) values (1001, 1, 'Hi there', 0x012345);
";

                using (var command = new SqlCommand(setupTablesSql, testDatabaseConn))
                {
                    command.ExecuteNonQuery();
                }
                testDatabaseConn.Close();
            }




        }

        private void CleanupDatabase(SqlConnection conn)
        {
            string clearupDatabaseSql = string.Format(@"
                if exists (select * from sys.databases as sd where sd.name = '{0}')
                begin
                    exec('use {0}
                    -- Erland Sommarskog suggests this before the drop; otherwise we get errors about the database still being in use.
                    ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                    USE master

                    drop database {0}')
                end
                ",  _testDatabaseName);
            
            using (var command = new SqlCommand(clearupDatabaseSql, conn))
            {
                command.ExecuteNonQuery();
            }
        }

    }
}