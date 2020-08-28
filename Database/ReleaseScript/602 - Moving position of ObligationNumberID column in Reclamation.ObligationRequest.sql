GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_ObligationNumber_ObligationNumberID
GO
ALTER TABLE ImportFinancial.ObligationNumber SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_Person_CreatePersonID_PersonID
GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_Person_UpdatePersonID_PersonID
GO
ALTER TABLE dbo.Person SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_ObligationRequestFundingPriority_ReclamationObligationRequestFundingPriorityID_ObligationRequestFundingPrio
GO
ALTER TABLE Reclamation.ObligationRequestFundingPriority SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_ObligationRequestStatus_ObligationRequestStatusID
GO
ALTER TABLE Reclamation.ObligationRequestStatus SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_ContractType_ContractTypeID
GO
ALTER TABLE Reclamation.ContractType SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ObligationRequest
	DROP CONSTRAINT FK_ObligationRequest_Agreement_AgreementID
GO
ALTER TABLE Reclamation.Agreement SET (LOCK_ESCALATION = TABLE)
GO
CREATE TABLE Reclamation.Tmp_ObligationRequest
	(
	ObligationRequestID int NOT NULL IDENTITY (1, 1),
	IsModification bit NOT NULL,
	AgreementID int NULL,
	ObligationNumberID int NULL,
	ContractTypeID int NOT NULL,
	ObligationRequestStatusID int NOT NULL,
	DescriptionOfNeed nvarchar(250) NOT NULL,
	ReclamationObligationRequestFundingPriorityID int NULL,
	TargetAwardDate datetime NULL,
	PALT int NULL,
	TargetSubmittalDate datetime NULL,
	CreateDate datetime NOT NULL,
	CreatePersonID int NOT NULL,
	UpdateDate datetime NULL,
	UpdatePersonID int NULL,
	RequisitionNumber nvarchar(50) NULL,
	RequisitionDate datetime NULL,
	ContractSpecialist nvarchar(250) NULL,
	AssignedDate datetime NULL,
	DateSentForDeptReview datetime NULL,
	DCApprovalDate datetime NULL,
	ActualAwardDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Reclamation.Tmp_ObligationRequest SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT Reclamation.Tmp_ObligationRequest ON
GO
IF EXISTS(SELECT * FROM Reclamation.ObligationRequest)
	 EXEC('INSERT INTO Reclamation.Tmp_ObligationRequest (ObligationRequestID, IsModification, AgreementID, ObligationNumberID, ContractTypeID, ObligationRequestStatusID, DescriptionOfNeed, ReclamationObligationRequestFundingPriorityID, TargetAwardDate, PALT, TargetSubmittalDate, CreateDate, CreatePersonID, UpdateDate, UpdatePersonID, RequisitionNumber, RequisitionDate, ContractSpecialist, AssignedDate, DateSentForDeptReview, DCApprovalDate, ActualAwardDate)
		SELECT ObligationRequestID, IsModification, AgreementID, ObligationNumberID, ContractTypeID, ObligationRequestStatusID, DescriptionOfNeed, ReclamationObligationRequestFundingPriorityID, TargetAwardDate, PALT, TargetSubmittalDate, CreateDate, CreatePersonID, UpdateDate, UpdatePersonID, RequisitionNumber, RequisitionDate, ContractSpecialist, AssignedDate, DateSentForDeptReview, DCApprovalDate, ActualAwardDate FROM Reclamation.ObligationRequest WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT Reclamation.Tmp_ObligationRequest OFF
GO
ALTER TABLE Reclamation.ObligationRequestSubmissionNote
	DROP CONSTRAINT FK_ObligationRequestSubmissionNote_ObligationRequest_ObligationRequestID
GO
ALTER TABLE Reclamation.CostAuthorityObligationRequest
	DROP CONSTRAINT FK_CostAuthorityObligationRequest_ObligationRequest_ObligationRequestID
GO
DROP TABLE Reclamation.ObligationRequest
GO
EXECUTE sp_rename N'Reclamation.Tmp_ObligationRequest', N'ObligationRequest', 'OBJECT' 
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	PK_ObligationRequest_ObligationRequestID PRIMARY KEY CLUSTERED 
	(
	ObligationRequestID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_Agreement_AgreementID FOREIGN KEY
	(
	AgreementID
	) REFERENCES Reclamation.Agreement
	(
	AgreementID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_ContractType_ContractTypeID FOREIGN KEY
	(
	ContractTypeID
	) REFERENCES Reclamation.ContractType
	(
	ContractTypeID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_ObligationRequestStatus_ObligationRequestStatusID FOREIGN KEY
	(
	ObligationRequestStatusID
	) REFERENCES Reclamation.ObligationRequestStatus
	(
	ObligationRequestStatusID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_ObligationRequestFundingPriority_ReclamationObligationRequestFundingPriorityID_ObligationRequestFundingPrio FOREIGN KEY
	(
	ReclamationObligationRequestFundingPriorityID
	) REFERENCES Reclamation.ObligationRequestFundingPriority
	(
	ObligationRequestFundingPriorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_Person_CreatePersonID_PersonID FOREIGN KEY
	(
	CreatePersonID
	) REFERENCES dbo.Person
	(
	PersonID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_Person_UpdatePersonID_PersonID FOREIGN KEY
	(
	UpdatePersonID
	) REFERENCES dbo.Person
	(
	PersonID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequest ADD CONSTRAINT
	FK_ObligationRequest_ObligationNumber_ObligationNumberID FOREIGN KEY
	(
	ObligationNumberID
	) REFERENCES ImportFinancial.ObligationNumber
	(
	ObligationNumberID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthorityObligationRequest ADD CONSTRAINT
	FK_CostAuthorityObligationRequest_ObligationRequest_ObligationRequestID FOREIGN KEY
	(
	ObligationRequestID
	) REFERENCES Reclamation.ObligationRequest
	(
	ObligationRequestID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthorityObligationRequest SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ObligationRequestSubmissionNote ADD CONSTRAINT
	FK_ObligationRequestSubmissionNote_ObligationRequest_ObligationRequestID FOREIGN KEY
	(
	ObligationRequestID
	) REFERENCES Reclamation.ObligationRequest
	(
	ObligationRequestID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ObligationRequestSubmissionNote SET (LOCK_ESCALATION = TABLE)
GO
