SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportTemplate](
	[ReportTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[FileResourceInfoID] [int] NOT NULL,
	[DisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ReportTemplateModelTypeID] [int] NOT NULL,
	[ReportTemplateModelID] [int] NOT NULL,
 CONSTRAINT [PK_ReportTemplate_ReportTemplateID] PRIMARY KEY CLUSTERED 
(
	[ReportTemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ReportTemplate_ReportTemplateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ReportTemplateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_FileResourceInfo_FileResourceInfoID] FOREIGN KEY([FileResourceInfoID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID])
GO
ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_FileResourceInfo_FileResourceInfoID]
GO
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_FileResourceInfo_FileResourceInfoID_TenantID] FOREIGN KEY([FileResourceInfoID], [TenantID])
REFERENCES [dbo].[FileResourceInfo] ([FileResourceInfoID], [TenantID])
GO
ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_FileResourceInfo_FileResourceInfoID_TenantID]
GO
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_ReportTemplateModel_ReportTemplateModelID] FOREIGN KEY([ReportTemplateModelID])
REFERENCES [dbo].[ReportTemplateModel] ([ReportTemplateModelID])
GO
ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_ReportTemplateModel_ReportTemplateModelID]
GO
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_ReportTemplateModelType_ReportTemplateModelTypeID] FOREIGN KEY([ReportTemplateModelTypeID])
REFERENCES [dbo].[ReportTemplateModelType] ([ReportTemplateModelTypeID])
GO
ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_ReportTemplateModelType_ReportTemplateModelTypeID]
GO
ALTER TABLE [dbo].[ReportTemplate]  WITH CHECK ADD  CONSTRAINT [FK_ReportTemplate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ReportTemplate] CHECK CONSTRAINT [FK_ReportTemplate_Tenant_TenantID]