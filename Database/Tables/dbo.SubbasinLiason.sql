SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubbasinLiason](
	[SubbasinLiasonID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
 CONSTRAINT [PK_SubbasinLiason_SubbasinLiasonID] PRIMARY KEY CLUSTERED 
(
	[SubbasinLiasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SubbasinLiason_SubbasinLiasonID_TenantID] UNIQUE NONCLUSTERED 
(
	[SubbasinLiasonID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubbasinLiason]  WITH CHECK ADD  CONSTRAINT [FK_SubbasinLiason_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[SubbasinLiason] CHECK CONSTRAINT [FK_SubbasinLiason_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[SubbasinLiason]  WITH CHECK ADD  CONSTRAINT [FK_SubbasinLiason_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[SubbasinLiason] CHECK CONSTRAINT [FK_SubbasinLiason_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[SubbasinLiason]  WITH CHECK ADD  CONSTRAINT [FK_SubbasinLiason_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubbasinLiason] CHECK CONSTRAINT [FK_SubbasinLiason_Tenant_TenantID]