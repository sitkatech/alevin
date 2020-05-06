-- Fixing casing issues

--begin tran

exec sp_rename 'ImportFinancial.impApGenSheet', 'ImpApGenSheet'
GO
exec sp_rename 'ImportFinancial.impPayRecV3', 'ImpPayrecV3'
GO

--rollback tran

CREATE TABLE ImportFinancial.ImpPnBudget
(
    ImpPnBudgetID [int] IDENTITY(1,1) NOT NULL,
    [FundedProgram] [nvarchar](255) NULL,
    [FundType] [nvarchar](255) NULL,
    [Fund] [nvarchar](255) NULL,
    [FundsCenter] [nvarchar](255) NULL,
    [FiscalYearPeriod] [nvarchar](255) NULL,
    [CommitmentItem] [nvarchar](255) NULL,
    [FiDocNumber] [nvarchar](255) NULL,
    [Recoveries] [float] NULL,
    [CommittedButNotObligated] [float] NULL,
    [TotalObligations] [float] NULL,
    [TotalExpenditures] [float] NULL,
    [UndeliveredOrders] [float] NULL,
 CONSTRAINT [PK_ImpPnBudget_ImpPnBudgetID] PRIMARY KEY CLUSTERED 
(
    ImpPnBudgetID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

-- WBS Elements have a weak link to this for forensics when an import doesn't find
-- and existing WBS element.

-- No single ImpPnBudget is actually responsible, so, shelving this idea.

/*
alter table ImportFinancial.WbsElement
add ImpPnBudgetID int null
GO


ALTER TABLE [ImportFinancial].WbsElement
WITH CHECK ADD CONSTRAINT [FK_WbsElement_ImpPnBudget_ImpPnBudgetID] FOREIGN KEY(ImpPnBudgetID)
REFERENCES [ImportFinancial].ImpPnBudget (ImpPnBudgetID)
GO
*/