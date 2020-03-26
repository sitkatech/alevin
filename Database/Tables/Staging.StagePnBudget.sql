SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Staging].[StagePnBudget](
	[StagePnBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[FundedProgram] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fund] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundsCenter] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FiscalYearPeriod] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CommitmentItem] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FiDocNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Recoveries] [float] NULL,
	[CommittedButNotObligated] [float] NULL,
	[TotalObligations] [float] NULL,
	[TotalExpenditures] [float] NULL,
	[UndeliveredOrders] [float] NULL,
 CONSTRAINT [PK_StagePnBudget_StagePnBudgetID] PRIMARY KEY CLUSTERED 
(
	[StagePnBudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
