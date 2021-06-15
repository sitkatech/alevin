SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonSettingGridColumnSetting](
	[PersonSettingGridColumnSettingID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[PersonSettingGridColumnID] [int] NOT NULL,
 CONSTRAINT [PK_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID] PRIMARY KEY CLUSTERED 
(
	[PersonSettingGridColumnSettingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PersonSettingGridColumnSetting_PersonID_PersonSettingGridColumnID] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC,
	[PersonSettingGridColumnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_PersonSettingGridColumnSetting_PersonSettingGridColumnSettingID_TenantID] UNIQUE NONCLUSTERED 
(
	[PersonSettingGridColumnSettingID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_Person_PersonID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID] FOREIGN KEY([PersonSettingGridColumnID])
REFERENCES [dbo].[PersonSettingGridColumn] ([PersonSettingGridColumnID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID_TenantID] FOREIGN KEY([PersonSettingGridColumnID], [TenantID])
REFERENCES [dbo].[PersonSettingGridColumn] ([PersonSettingGridColumnID], [TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_PersonSettingGridColumn_PersonSettingGridColumnID_TenantID]
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting]  WITH CHECK ADD  CONSTRAINT [FK_PersonSettingGridColumnSetting_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonSettingGridColumnSetting] CHECK CONSTRAINT [FK_PersonSettingGridColumnSetting_Tenant_TenantID]