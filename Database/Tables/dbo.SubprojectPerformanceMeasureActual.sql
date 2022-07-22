SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubprojectPerformanceMeasureActual](
	[SubprojectPerformanceMeasureActualID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ActualValue] [float] NOT NULL,
	[PerformanceMeasureReportingPeriodID] [int] NOT NULL,
 CONSTRAINT [PK_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID] PRIMARY KEY CLUSTERED 
(
	[SubprojectPerformanceMeasureActualID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[SubprojectPerformanceMeasureActualID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_TenantID] UNIQUE NONCLUSTERED 
(
	[SubprojectPerformanceMeasureActualID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID] FOREIGN KEY([PerformanceMeasureReportingPeriodID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID] FOREIGN KEY([PerformanceMeasureReportingPeriodID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureReportingPeriod] ([PerformanceMeasureReportingPeriodID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID] FOREIGN KEY([SubprojectID])
REFERENCES [dbo].[Subproject] ([SubprojectID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID])
REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActual] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActual_Tenant_TenantID]