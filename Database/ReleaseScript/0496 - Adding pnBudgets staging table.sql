
/*
        public const string FundedProgram = "Funded Program";
        public const string FundType = "Fund Type";
        public const string Fund = "Fund";
        public const string FundsCenter = "Funds Center";
        public const string FiscalYearPeriod = "Fiscal year/period";
        public const string CommitmentItem = "Commitment item";
        public const string FiDocNumber = "FI doc:doc.number";
        public const string Recoveries = "Recoveries";
        public const string CommittedButNotObligated = "Committed But Not Obligated";
        public const string TotalObligations = "Total Obligations";
        public const string TotalExpenditures = "Total Expenditures";
        public const string UndeliveredOrders = "Undelivered Orders";
*/

--begin tran

CREATE TABLE Staging.StagePnBudget
(
    StagePnBudgetID [int] IDENTITY(1,1) NOT NULL,
    FundedProgram [nvarchar](255) NULL,
    FundType [nvarchar](255) NULL,
    Fund [nvarchar](255) NULL,
    FundsCenter [nvarchar](255) NULL,
    FiscalYearPeriod [nvarchar](255) NULL,
    CommitmentItem [nvarchar](255) NULL,
    FiDocNumber [nvarchar](255) NULL,
    Recoveries float NULL,
    CommittedButNotObligated float NULL,
    TotalObligations  float NULL,
    TotalExpenditures float NULL,
    UndeliveredOrders float NULL
 CONSTRAINT [PK_StagePnBudget_StagePnBudgetID] PRIMARY KEY CLUSTERED 
(
    StagePnBudgetID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

--rollback tran

