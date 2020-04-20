SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ProjectFundingSourceBudget](
	[ProjectFundingSourceBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[ProjectedAmount] [money] NULL,
	[CalendarYear] [int] NULL,
	[CostTypeID] [int] NULL,
 CONSTRAINT [PK_ProjectFundingSourceBudget_ProjectFundingSourceBudgetID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceBudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFundingSourceBudget_ProjectID_FundingSourceID_CostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[FundingSourceID] ASC,
	[CostTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_CostType_CostTypeID]
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_CostType_CostTypeID_TenantID] FOREIGN KEY([CostTypeID], [TenantID])
REFERENCES [dbo].[CostType] ([CostTypeID], [TenantID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_CostType_CostTypeID_TenantID]
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID]
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_FundingSource_FundingSourceID_TenantID]
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_Project_ProjectID]
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_Project_ProjectID_TenantID]
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceBudget_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [Reclamation].[ProjectFundingSourceBudget] CHECK CONSTRAINT [FK_ProjectFundingSourceBudget_Tenant_TenantID]