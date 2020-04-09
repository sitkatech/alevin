SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[BudgetObjectCodeGroup](
	[BudgetObjectCodeGroupID] [int] IDENTITY(1,1) NOT NULL,
	[BudgetObjectCodeGroupPrefix] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BudgetObjectCodeGroupName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BudgetObjectCodeGroupDefinition] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ParentBudgetObjectCodeGroupID] [int] NULL,
	[CostTypeID] [int] NULL,
 CONSTRAINT [PK_BudgetObjectCodeGroup_BudgetObjectCodeGroupID] PRIMARY KEY CLUSTERED 
(
	[BudgetObjectCodeGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_BudgetObjectCodeGroup_BudgetObjectCodeGroupName] UNIQUE NONCLUSTERED 
(
	[BudgetObjectCodeGroupName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_BudgetObjectCodeGroup_BudgetObjectCodeGroupPrefix] UNIQUE NONCLUSTERED 
(
	[BudgetObjectCodeGroupPrefix] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[BudgetObjectCodeGroup]  WITH CHECK ADD  CONSTRAINT [FK_BudgetObjectCodeGroup_BudgetObjectCodeGroup_ParentBudgetObjectCodeGroupID_BudgetObjectCodeGroupID] FOREIGN KEY([ParentBudgetObjectCodeGroupID])
REFERENCES [Reclamation].[BudgetObjectCodeGroup] ([BudgetObjectCodeGroupID])
GO
ALTER TABLE [Reclamation].[BudgetObjectCodeGroup] CHECK CONSTRAINT [FK_BudgetObjectCodeGroup_BudgetObjectCodeGroup_ParentBudgetObjectCodeGroupID_BudgetObjectCodeGroupID]
GO
ALTER TABLE [Reclamation].[BudgetObjectCodeGroup]  WITH CHECK ADD  CONSTRAINT [FK_BudgetObjectCodeGroup_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [Reclamation].[BudgetObjectCodeGroup] CHECK CONSTRAINT [FK_BudgetObjectCodeGroup_CostType_CostTypeID]