
ALTER TABLE ImportFinancial.ImpProcessing
	DROP CONSTRAINT FK_ImpProcessing_ImpProcessingTableType_ImpProcessingTableTypeID
GO
ALTER TABLE ImportFinancial.ImpProcessingTableType SET (LOCK_ESCALATION = TABLE)
GO

ALTER TABLE ImportFinancial.ImpProcessing
	DROP CONSTRAINT FK_ImpProcessing_Person_UploadPersonID_PersonID
GO
ALTER TABLE ImportFinancial.ImpProcessing
	DROP CONSTRAINT FK_ImpProcessing_Person_LastProcessedPersonID_PersonID
GO
ALTER TABLE dbo.Person SET (LOCK_ESCALATION = TABLE)
GO

CREATE TABLE ImportFinancial.Tmp_ImpProcessing
	(
	ImpProcessingID int NOT NULL IDENTITY (1, 1),
	ImpProcessingTableTypeID int NOT NULL,
	UploadDate datetime NULL,
	UploadPersonID int NULL,
	UploadedFiscalYears varchar(50) NULL,
	LastProcessedDate datetime NULL,
	LastProcessedPersonID int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ImportFinancial.Tmp_ImpProcessing SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT ImportFinancial.Tmp_ImpProcessing ON
GO
IF EXISTS(SELECT * FROM ImportFinancial.ImpProcessing)
	 EXEC('INSERT INTO ImportFinancial.Tmp_ImpProcessing (ImpProcessingID, ImpProcessingTableTypeID, UploadDate, UploadPersonID, LastProcessedDate, LastProcessedPersonID)
		SELECT ImpProcessingID, ImpProcessingTableTypeID, UploadDate, UploadPersonID, LastProcessedDate, LastProcessedPersonID FROM ImportFinancial.ImpProcessing WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT ImportFinancial.Tmp_ImpProcessing OFF
GO
DROP TABLE ImportFinancial.ImpProcessing
GO
EXECUTE sp_rename N'ImportFinancial.Tmp_ImpProcessing', N'ImpProcessing', 'OBJECT' 
GO
ALTER TABLE ImportFinancial.ImpProcessing ADD CONSTRAINT
	PK_ImpProcessing_ImpProcessingID PRIMARY KEY CLUSTERED 
	(
	ImpProcessingID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE ImportFinancial.ImpProcessing ADD CONSTRAINT
	FK_ImpProcessing_Person_UploadPersonID_PersonID FOREIGN KEY
	(
	UploadPersonID
	) REFERENCES dbo.Person
	(
	PersonID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.ImpProcessing ADD CONSTRAINT
	FK_ImpProcessing_Person_LastProcessedPersonID_PersonID FOREIGN KEY
	(
	LastProcessedPersonID
	) REFERENCES dbo.Person
	(
	PersonID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.ImpProcessing ADD CONSTRAINT
	FK_ImpProcessing_ImpProcessingTableType_ImpProcessingTableTypeID FOREIGN KEY
	(
	ImpProcessingTableTypeID
	) REFERENCES ImportFinancial.ImpProcessingTableType
	(
	ImpProcessingTableTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO


/*

select * from ImportFinancial.ImpProcessing

*/