SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption](
	[SubprojectPerformanceMeasureActualSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectPerformanceMeasureActualID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActualSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[SubprojectPerformanceMeasureActualSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_Performance] FOREIGN KEY([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_Performance]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI1] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI1]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI2] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI2]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI3] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionI3]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_1] FOREIGN KEY([SubprojectPerformanceMeasureActualID])
REFERENCES [dbo].[SubprojectPerformanceMeasureActual] ([SubprojectPerformanceMeasureActualID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_1]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_2] FOREIGN KEY([SubprojectPerformanceMeasureActualID], [PerformanceMeasureID])
REFERENCES [dbo].[SubprojectPerformanceMeasureActual] ([SubprojectPerformanceMeasureActualID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_2]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_T] FOREIGN KEY([SubprojectPerformanceMeasureActualID], [TenantID])
REFERENCES [dbo].[SubprojectPerformanceMeasureActual] ([SubprojectPerformanceMeasureActualID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_SubprojectPerformanceMeasureActual_SubprojectPerformanceMeasureActualID_T]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureActualSubcategoryOption_Tenant_TenantID]