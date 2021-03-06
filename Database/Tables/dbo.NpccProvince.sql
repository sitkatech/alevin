SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NpccProvince](
	[NpccProvinceID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[NpccProvinceName] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[NpccProvinceFeature] [geometry] NULL,
	[NpccProvinceDescriptionContent] [dbo].[html] NULL,
 CONSTRAINT [PK_NpccProvince_NpccProvinceID] PRIMARY KEY CLUSTERED 
(
	[NpccProvinceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_NpccProvince_NpccProvinceID_TenantID] UNIQUE NONCLUSTERED 
(
	[NpccProvinceID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_NpccProvince_TenantID_NpccProvinceName] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
	[NpccProvinceName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[NpccProvince]  WITH CHECK ADD  CONSTRAINT [FK_NpccProvince_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[NpccProvince] CHECK CONSTRAINT [FK_NpccProvince_Tenant_TenantID]
GO
ALTER TABLE [dbo].[NpccProvince]  WITH CHECK ADD  CONSTRAINT [CK_NpccProvince_NpccProvinceFeature_SpatialReferenceID_Must_Be_4326] CHECK  (([NpccProvinceFeature] IS NULL OR [NpccProvinceFeature].[STSrid]=(4326)))
GO
ALTER TABLE [dbo].[NpccProvince] CHECK CONSTRAINT [CK_NpccProvince_NpccProvinceFeature_SpatialReferenceID_Must_Be_4326]