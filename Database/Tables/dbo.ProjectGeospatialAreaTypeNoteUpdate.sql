SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate](
	[ProjectGeospatialAreaTypeNoteUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[GeospatialAreaTypeID] [int] NOT NULL,
	[Notes] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_ProjectGeospatialAreaTypeNoteUpdate_ProjectGeospatialAreaTypeNoteUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectGeospatialAreaTypeNoteUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatchID_GeospatialAreaTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[GeospatialAreaTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_GeospatialAreaType_GeospatialAreaTypeID] FOREIGN KEY([GeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_GeospatialAreaType_GeospatialAreaTypeID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_GeospatialAreaType_GeospatialAreaTypeID_TenantID] FOREIGN KEY([GeospatialAreaTypeID], [TenantID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_GeospatialAreaType_GeospatialAreaTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaTypeNoteUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaTypeNoteUpdate_Tenant_TenantID]