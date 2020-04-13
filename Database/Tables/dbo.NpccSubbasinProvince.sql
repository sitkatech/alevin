SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NpccSubbasinProvince](
	[NpccSubbasinProvinceID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubbasinID] [int] NOT NULL,
	[NpccProvinceID] [int] NOT NULL,
 CONSTRAINT [PK_NpccSubbasinProvince_NpccSubbasinProvinceID] PRIMARY KEY CLUSTERED 
(
	[NpccSubbasinProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_NpccSubbasinProvince_NpccSubbasinProvinceID_TenantID] UNIQUE NONCLUSTERED 
(
	[NpccSubbasinProvinceID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_NpccSubbasinProvince_SubbasinID_NpccProvinceID] UNIQUE NONCLUSTERED 
(
	[SubbasinID] ASC,
	[NpccProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[NpccSubbasinProvince]  WITH CHECK ADD  CONSTRAINT [FK_NpccSubbasinProvince_GeospatialArea_SubbasinID_GeospatialAreaID] FOREIGN KEY([SubbasinID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[NpccSubbasinProvince] CHECK CONSTRAINT [FK_NpccSubbasinProvince_GeospatialArea_SubbasinID_GeospatialAreaID]
GO
ALTER TABLE [dbo].[NpccSubbasinProvince]  WITH CHECK ADD  CONSTRAINT [FK_NpccSubbasinProvince_GeospatialArea_SubbasinID_GeospatialAreaID_TenantID] FOREIGN KEY([SubbasinID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[NpccSubbasinProvince] CHECK CONSTRAINT [FK_NpccSubbasinProvince_GeospatialArea_SubbasinID_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[NpccSubbasinProvince]  WITH CHECK ADD  CONSTRAINT [FK_NpccSubbasinProvince_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[NpccSubbasinProvince] CHECK CONSTRAINT [FK_NpccSubbasinProvince_Tenant_TenantID]