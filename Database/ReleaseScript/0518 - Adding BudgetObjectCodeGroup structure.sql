--select * from [ReclamationOneTimeImport].[BocCleaned]
--select * from Reclamation.BudgetObjectCode

--begin tran

CREATE TABLE Reclamation.BudgetObjectCodeGroup
(
    BudgetObjectCodeGroupID [int] IDENTITY(1,1) NOT NULL,
    -- '10', '11', '11.1', etc.
    BudgetObjectCodeGroupPrefix nvarchar(5) not null,
    BudgetObjectCodeGroupName [nvarchar](100) not NULL,
    BudgetObjectCodeGroupDefinition [nvarchar](500) null,
    ParentBudgetObjectCodeGroupID int null constraint FK_BudgetObjectCodeGroup_BudgetObjectCodeGroup_ParentBudgetObjectCodeGroupID foreign key references Reclamation.BudgetObjectCodeGroup(BudgetObjectCodeGroupID)
 CONSTRAINT [PK_BudgetObjectCodeGroup_BudgetObjectCodeGroupID] PRIMARY KEY CLUSTERED 
 (
    BudgetObjectCodeGroupID ASC
 ) ON [PRIMARY]
)
GO

ALTER TABLE Reclamation.BudgetObjectCodeGroup
ADD CONSTRAINT UC_BudgetObjectCodeGroup_BudgetObjectCodeGroupPrefix UNIQUE (BudgetObjectCodeGroupPrefix); 


ALTER TABLE Reclamation.BudgetObjectCodeGroup
ADD CONSTRAINT UC_BudgetObjectCodeGroup_BudgetObjectCodeGroupName UNIQUE (BudgetObjectCodeGroupName); 

--rollback tran