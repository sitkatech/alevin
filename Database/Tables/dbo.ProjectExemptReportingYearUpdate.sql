SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectExemptReportingYearUpdate](
	[ProjectExemptReportingYearUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ProjectExemptReportingTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectExemptReportingYearUpdate_ProjectExemptReportingYearUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectExemptReportingYearUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectExemptReportingYearUpdate_ProjectUpdateBatchID_CalendarYear_ProjectExemptReportingTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[CalendarYear] ASC,
	[ProjectExemptReportingTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExemptReportingYearUpdate_ProjectExemptReportingType_ProjectExemptReportingTypeID] FOREIGN KEY([ProjectExemptReportingTypeID])
REFERENCES [dbo].[ProjectExemptReportingType] ([ProjectExemptReportingTypeID])
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate] CHECK CONSTRAINT [FK_ProjectExemptReportingYearUpdate_ProjectExemptReportingType_ProjectExemptReportingTypeID]
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExemptReportingYearUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate] CHECK CONSTRAINT [FK_ProjectExemptReportingYearUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExemptReportingYearUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate] CHECK CONSTRAINT [FK_ProjectExemptReportingYearUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExemptReportingYearUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectExemptReportingYearUpdate] CHECK CONSTRAINT [FK_ProjectExemptReportingYearUpdate_Tenant_TenantID]