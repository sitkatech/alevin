SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption](
	[SubprojectPerformanceMeasureExpectedSubcategoryOptionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectPerformanceMeasureExpectedID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryOptionID] [int] NOT NULL,
	[PerformanceMeasureID] [int] NOT NULL,
	[PerformanceMeasureSubcategoryID] [int] NOT NULL,
 CONSTRAINT [PK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpectedSubcategoryOptionID] PRIMARY KEY CLUSTERED 
(
	[SubprojectPerformanceMeasureExpectedSubcategoryOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID] FOREIGN KEY([PerformanceMeasureID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID_TenantID] FOREIGN KEY([PerformanceMeasureID], [TenantID])
REFERENCES [dbo].[PerformanceMeasure] ([PerformanceMeasureID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID] FOREIGN KEY([PerformanceMeasureSubcategoryID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID] FOREIGN KEY([PerformanceMeasureSubcategoryID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureSubcategory] ([PerformanceMeasureSubcategoryID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptio1] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptio1]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptio2] FOREIGN KEY([PerformanceMeasureSubcategoryOptionID], [TenantID])
REFERENCES [dbo].[PerformanceMeasureSubcategoryOption] ([PerformanceMeasureSubcategoryOptionID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptio2]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec1] FOREIGN KEY([SubprojectPerformanceMeasureExpectedID])
REFERENCES [dbo].[SubprojectPerformanceMeasureExpected] ([SubprojectPerformanceMeasureExpectedID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec1]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec2] FOREIGN KEY([SubprojectPerformanceMeasureExpectedID], [PerformanceMeasureID])
REFERENCES [dbo].[SubprojectPerformanceMeasureExpected] ([SubprojectPerformanceMeasureExpectedID], [PerformanceMeasureID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec2]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec3] FOREIGN KEY([SubprojectPerformanceMeasureExpectedID], [TenantID])
REFERENCES [dbo].[SubprojectPerformanceMeasureExpected] ([SubprojectPerformanceMeasureExpectedID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpec3]
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption] CHECK CONSTRAINT [FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_Tenant_TenantID]