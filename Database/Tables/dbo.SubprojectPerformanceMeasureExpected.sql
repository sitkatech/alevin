SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubprojectPerformanceMeasureExpected](
	[SubprojectPerformanceMeasureExpectedID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[ExpectedValue] [float] NULL,
 CONSTRAINT [PK_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpectedID] PRIMARY KEY CLUSTERED 
(
	[SubprojectPerformanceMeasureExpectedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpectedID_PerformanceMeasureID] UNIQUE NONCLUSTERED 
(
	[SubprojectPerformanceMeasureExpectedID] ASC,
	[PerformanceMeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpectedID_TenantID] UNIQUE NONCLUSTERED 
(
	[SubprojectPerformanceMeasureExpectedID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID] FOREIGN KEY([SubprojectID])
REFERENCES [dbo].[Subproject] ([SubprojectID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID])
REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpected] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpected_Tenant_TenantID]