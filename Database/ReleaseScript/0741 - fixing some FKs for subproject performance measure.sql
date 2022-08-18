
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] DROP CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_Performanc1]
GO

ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_1] FOREIGN KEY([SubprojectPerformanceMeasureActualID])
REFERENCES [dbo].[SubprojectPerformanceMeasureActual] ([SubprojectPerformanceMeasureActualID])
GO

ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_1]
GO





ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] DROP CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_Performanc2]
GO

ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_2] FOREIGN KEY([SubprojectPerformanceMeasureActualID], [PerformanceMeasureID])
REFERENCES [dbo].[SubprojectPerformanceMeasureActual] ([SubprojectPerformanceMeasureActualID], [PerformanceMeasureID])
GO

ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_2]
GO





ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] DROP CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_TenantID_Pe]
GO

ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_T] FOREIGN KEY([SubprojectPerformanceMeasureActualID], [TenantID])
REFERENCES [dbo].[SubprojectPerformanceMeasureActual] ([SubprojectPerformanceMeasureActualID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_T]
GO

