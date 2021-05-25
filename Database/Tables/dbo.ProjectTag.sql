SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectTag](
	[ProjectTagID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[TagID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectTag_ProjectTagID] PRIMARY KEY CLUSTERED 
(
	[ProjectTagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectTag_ProjectID_TagID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[TagID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectTag]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTag_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectTag] CHECK CONSTRAINT [FK_ProjectTag_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectTag]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTag_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectTag] CHECK CONSTRAINT [FK_ProjectTag_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectTag]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTag_Tag_TagID] FOREIGN KEY([TagID])
REFERENCES [dbo].[Tag] ([TagID])
GO
ALTER TABLE [dbo].[ProjectTag] CHECK CONSTRAINT [FK_ProjectTag_Tag_TagID]
GO
ALTER TABLE [dbo].[ProjectTag]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTag_Tag_TagID_TenantID] FOREIGN KEY([TagID], [TenantID])
REFERENCES [dbo].[Tag] ([TagID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectTag] CHECK CONSTRAINT [FK_ProjectTag_Tag_TagID_TenantID]
GO
ALTER TABLE [dbo].[ProjectTag]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTag_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectTag] CHECK CONSTRAINT [FK_ProjectTag_Tenant_TenantID]