SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate](
	[ProjectNoFundingSourceIdentifiedUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[CalendarYear] [int] NULL,
	[NoFundingSourceIdentifiedYet] [money] NULL,
	[CostTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectNoFundingSourceIdentifiedUpdate_ProjectNoFundingSourceIdentifiedUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectNoFundingSourceIdentifiedUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatchID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_CostType_CostTypeID]
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate] CHECK CONSTRAINT [FK_ProjectNoFundingSourceIdentifiedUpdate_Tenant_TenantID]