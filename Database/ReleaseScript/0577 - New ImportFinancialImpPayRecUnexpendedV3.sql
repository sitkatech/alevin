

CREATE TABLE [ImportFinancial].ImportFinancialImpPayRecUnexpendedV3
(
    ImportFinancialImpPayRecUnexpendedV3ID [int] IDENTITY(1,1) NOT NULL,
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
    [PostingDatePerSpl] [datetime] NULL,
    [UnexpendedBalance] [datetime] NULL,
 CONSTRAINT [PK_ImportFinancialImpPayRecUnexpendedV3_ImportFinancialImpPayRecUnexpendedV3ID] PRIMARY KEY CLUSTERED 
(
    ImportFinancialImpPayRecUnexpendedV3ID ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

