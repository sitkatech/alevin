


/****** Object:  Index [AK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatchID_CalendarYear]    Script Date: 6/11/2020 5:50:49 PM ******/
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate] DROP CONSTRAINT [AK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatchID_CalendarYear]
GO

/****** Object:  Index [AK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatchID_CalendarYear]    Script Date: 6/11/2020 5:50:49 PM ******/
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentifiedUpdate] ADD  CONSTRAINT [AK_ProjectNoFundingSourceIdentifiedUpdate_ProjectUpdateBatchID_CalendarYear_CostTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[CalendarYear] ASC,
    [CostTypeID] ASC
) ON [PRIMARY]
GO

