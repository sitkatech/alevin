
ALTER TABLE Reclamation.CostAuthority
	DROP CONSTRAINT FK_CostAuthority_Subbasin_SubbasinID
GO
ALTER TABLE Reclamation.Subbasin SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.CostAuthority
	DROP CONSTRAINT FK_CostAuthority_Basin_BasinID
GO
ALTER TABLE Reclamation.Basin SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.CostAuthority
	DROP CONSTRAINT FK_CostAuthority_HCategory_HabitatCategoryID_HCategoryID
GO
ALTER TABLE Reclamation.HCategory SET (LOCK_ESCALATION = TABLE)
GO
CREATE TABLE Reclamation.Tmp_CostAuthority
	(
	CostAuthorityID int NOT NULL IDENTITY (1, 1),
	CostAuthorityWorkBreakdownStructure nvarchar(255) NULL,
	CostAuthorityNumber nvarchar(255) NULL,
	AccountStructureDescription nvarchar(255) NULL,
	CostCenter nvarchar(255) NULL,
	AgencyProjectType nvarchar(255) NULL,
	ProjectNumber nvarchar(255) NULL,
	Authority nvarchar(255) NULL,
	Job nvarchar(3) NULL,
	Number nvarchar(4) NULL,
	JobNumber nvarchar(255) NULL,
	WBSStatus nvarchar(255) NULL,
	HCategoryLU float(53) NULL,
	WBSNoDot nvarchar(255) NULL,
	HabitatCategoryID int NULL,
	BasinID int NULL,
	SubbasinID int NULL
	)  ON [PRIMARY]
GO
ALTER TABLE Reclamation.Tmp_CostAuthority SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT Reclamation.Tmp_CostAuthority ON
GO
IF EXISTS(SELECT * FROM Reclamation.CostAuthority)
	 EXEC('INSERT INTO Reclamation.Tmp_CostAuthority (CostAuthorityID, CostAuthorityWorkBreakdownStructure, CostAuthorityNumber, AccountStructureDescription, CostCenter, AgencyProjectType, ProjectNumber, Authority, Job, Number, JobNumber, WBSStatus, HCategoryLU, WBSNoDot, HabitatCategoryID, BasinID, SubbasinID)
		SELECT CostAuthorityID, CostAuthorityWorkBreakdownStructure, CostAuthorityNumber, AccountStructureDescription, CostCenter, AgencyProjectType, ProjectNumber, Authority, Job, Number, JobNumber, WBSStatus, HCategoryLU, WBSNoDot, HabitatCategoryID, BasinID, SubbasinID FROM Reclamation.CostAuthority WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT Reclamation.Tmp_CostAuthority OFF
GO
ALTER TABLE Reclamation.ReclamationStagingCostAuthorityAgreement
	DROP CONSTRAINT FK_ReclamationStagingCostAuthorityAgreement_CostAuthority_CostAuthorityID
GO
ALTER TABLE ImportFinancial.WbsElementObligationItemBudget
	DROP CONSTRAINT FK_WbsElementObligationItemBudget_CostAuthority_CostAuthorityID
GO
ALTER TABLE ImportFinancial.WbsElementObligationItemInvoice
	DROP CONSTRAINT FK_WbsElementObligationItemInvoice_CostAuthority_CostAuthorityID
GO
ALTER TABLE Reclamation.CostAuthorityAgreementRequest
	DROP CONSTRAINT FK_CostAuthorityAgreementRequest_CostAuthority_CostAuthorityID
GO
ALTER TABLE Reclamation.AgreementCostAuthority
	DROP CONSTRAINT FK_AgreementCostAuthority_CostAuthority_CostAuthorityID
GO
ALTER TABLE Reclamation.CostAuthorityProject
	DROP CONSTRAINT FK_CostAuthorityProject_CostAuthority_ReclamationCostAuthorityID_CostAuthorityID
GO
DROP TABLE Reclamation.CostAuthority
GO
EXECUTE sp_rename N'Reclamation.Tmp_CostAuthority', N'CostAuthority', 'OBJECT' 
GO
ALTER TABLE Reclamation.CostAuthority ADD CONSTRAINT
	PK_CostAuthority_CostAuthorityID PRIMARY KEY CLUSTERED 
	(
	CostAuthorityID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE Reclamation.CostAuthority ADD CONSTRAINT
	FK_CostAuthority_HCategory_HabitatCategoryID_HCategoryID FOREIGN KEY
	(
	HabitatCategoryID
	) REFERENCES Reclamation.HCategory
	(
	HCategoryID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthority ADD CONSTRAINT
	FK_CostAuthority_Basin_BasinID FOREIGN KEY
	(
	BasinID
	) REFERENCES Reclamation.Basin
	(
	BasinID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthority ADD CONSTRAINT
	FK_CostAuthority_Subbasin_SubbasinID FOREIGN KEY
	(
	SubbasinID
	) REFERENCES Reclamation.Subbasin
	(
	SubbasinID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthorityProject ADD CONSTRAINT
	FK_CostAuthorityProject_CostAuthority_ReclamationCostAuthorityID_CostAuthorityID FOREIGN KEY
	(
	ReclamationCostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthorityProject SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.AgreementCostAuthority ADD CONSTRAINT
	FK_AgreementCostAuthority_CostAuthority_CostAuthorityID FOREIGN KEY
	(
	CostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.AgreementCostAuthority SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.CostAuthorityAgreementRequest ADD CONSTRAINT
	FK_CostAuthorityAgreementRequest_CostAuthority_CostAuthorityID FOREIGN KEY
	(
	CostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.CostAuthorityAgreementRequest SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementObligationItemInvoice ADD CONSTRAINT
	FK_WbsElementObligationItemInvoice_CostAuthority_CostAuthorityID FOREIGN KEY
	(
	CostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementObligationItemInvoice SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE ImportFinancial.WbsElementObligationItemBudget ADD CONSTRAINT
	FK_WbsElementObligationItemBudget_CostAuthority_CostAuthorityID FOREIGN KEY
	(
	CostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE ImportFinancial.WbsElementObligationItemBudget SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE Reclamation.ReclamationStagingCostAuthorityAgreement ADD CONSTRAINT
	FK_ReclamationStagingCostAuthorityAgreement_CostAuthority_CostAuthorityID FOREIGN KEY
	(
	CostAuthorityID
	) REFERENCES Reclamation.CostAuthority
	(
	CostAuthorityID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE Reclamation.ReclamationStagingCostAuthorityAgreement SET (LOCK_ESCALATION = TABLE)
GO
