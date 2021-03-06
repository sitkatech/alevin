SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[BudgetObjectCode](
	[BudgetObjectCodeID] [int] IDENTITY(1,1) NOT NULL,
	[BudgetObjectCodeName] [nvarchar](6) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BudgetObjectCodeItemDescription] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BudgetObjectCodeDefinition] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FbmsYear] [int] NOT NULL,
	[Reportable1099] [bit] NULL,
	[Explanation1099] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BudgetObjectCodeGroupID] [int] NOT NULL,
	[OverrideCostTypeID] [int] NULL,
	[IsExpiredOrDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_BudgetObjectCode_BudgetObjectCodeID] PRIMARY KEY CLUSTERED 
(
	[BudgetObjectCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ] ON [Reclamation].[BudgetObjectCode]
(
	[BudgetObjectCodeName] ASC,
	[FbmsYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Reclamation].[BudgetObjectCode]  WITH CHECK ADD  CONSTRAINT [FK_BudgetObjectCode_BudgetObjectCodeGroup_BudgetObjectCodeGroupID] FOREIGN KEY([BudgetObjectCodeGroupID])
REFERENCES [Reclamation].[BudgetObjectCodeGroup] ([BudgetObjectCodeGroupID])
GO
ALTER TABLE [Reclamation].[BudgetObjectCode] CHECK CONSTRAINT [FK_BudgetObjectCode_BudgetObjectCodeGroup_BudgetObjectCodeGroupID]
GO
ALTER TABLE [Reclamation].[BudgetObjectCode]  WITH CHECK ADD  CONSTRAINT [FK_BudgetObjectCode_CostType_OverrideCostTypeID_CostTypeID] FOREIGN KEY([OverrideCostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [Reclamation].[BudgetObjectCode] CHECK CONSTRAINT [FK_BudgetObjectCode_CostType_OverrideCostTypeID_CostTypeID]