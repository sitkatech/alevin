-- Revised version of [Staging].[StageImpPayRecV3]

CREATE TABLE Staging.StageImpUnexpendedBalancePayRecV3
(
    StageImpUnexpendedBalancePayRecV3ID [int] IDENTITY(1,1) NOT NULL,
    [BusinessArea] [nvarchar](255) NULL,
    [FABudgetActivity] [nvarchar](255) NULL,
    [FunctionalArea] [nvarchar](255) NULL,
    [ObligationNumber] [nvarchar](255) NULL,
    [ObligationItem] [nvarchar](255) NULL,
    [Fund] [nvarchar](255) NULL,
    [FundedProgram] [nvarchar](255) NULL,
    [WBSElement] [nvarchar](255) NULL,
    [WBSElementDescription] [nvarchar](255) NULL,
    [BudgetObjectClass] [nvarchar](255) NULL,
    [Vendor] [nvarchar](255) NULL,
    [VendorName] [nvarchar](255) NULL,
    [PostingDatePerSplKey] [datetime] NULL,
    [UnexpendedBalance] [float] NULL,
 CONSTRAINT [PK_StageImpUnexpendedBalancePayRecV3_StageImpUnexpendedBalancePayRecV3ID] PRIMARY KEY CLUSTERED 
(
    StageImpUnexpendedBalancePayRecV3ID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

-- TODO: Kill [Staging].[StageImpPayRecV3] entirely!
sp_rename 'Staging.StageImpPayRecV3', 'Staging.StageImpOriginalPayRecV3'

-- Try killing it outright
drop table Staging.[Staging.StageImpOriginalPayRecV3]
GO
