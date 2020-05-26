
/****** Object:  Index [AK_ProjectNoFundingSourceIdentified_ProjectID_CalendarYear]    Script Date: 5/21/2020 5:55:51 PM ******/
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified] DROP CONSTRAINT [AK_ProjectNoFundingSourceIdentified_ProjectID_CalendarYear]
GO

/****** Object:  Index [AK_ProjectNoFundingSourceIdentified_ProjectID_CalendarYear]    Script Date: 5/21/2020 5:55:51 PM ******/
ALTER TABLE [dbo].[ProjectNoFundingSourceIdentified] ADD  CONSTRAINT [AK_ProjectNoFundingSourceIdentified_ProjectID_CostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
    CostTypeID ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


