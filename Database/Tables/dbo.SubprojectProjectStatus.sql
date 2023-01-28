SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubprojectProjectStatus](
	[SubprojectProjectStatusID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[ProjectStatusID] [int] NOT NULL,
	[SubprojectProjectStatusUpdateDate] [datetime] NOT NULL,
	[SubprojectProjectStatusCreatePersonID] [int] NOT NULL,
	[SubprojectProjectStatusCreateDate] [datetime] NOT NULL,
	[SubprojectProjectStatusLastEditedPersonID] [int] NULL,
	[SubprojectProjectStatusLastEditedDate] [datetime] NULL,
	[IsFinalStatusUpdate] [bit] NOT NULL,
	[LessonsLearned] [varchar](2500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubprojectProjectStatusRecentActivities] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubprojectProjectStatusUpcomingActivities] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubprojectProjectStatusRisksOrIssues] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SubprojectProjectStatusComment] [varchar](2000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_SubprojectProjectStatus_SubprojectProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[SubprojectProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_SubprojectProjectStatus_SubprojectProjectStatusID_TenantID] UNIQUE NONCLUSTERED 
(
	[SubprojectProjectStatusID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusCreatePersonID_PersonID] FOREIGN KEY([SubprojectProjectStatusCreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusCreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusCreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([SubprojectProjectStatusCreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusCreatePersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusLastEditedPersonID_PersonID] FOREIGN KEY([SubprojectProjectStatusLastEditedPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusLastEditedPersonID_PersonID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusLastEditedPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([SubprojectProjectStatusLastEditedPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Person_SubprojectProjectStatusLastEditedPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_ProjectStatus_ProjectStatusID] FOREIGN KEY([ProjectStatusID])
REFERENCES [dbo].[ProjectStatus] ([ProjectStatusID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_ProjectStatus_ProjectStatusID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_ProjectStatus_ProjectStatusID_TenantID] FOREIGN KEY([ProjectStatusID], [TenantID])
REFERENCES [dbo].[ProjectStatus] ([ProjectStatusID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_ProjectStatus_ProjectStatusID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Subproject_SubprojectID] FOREIGN KEY([SubprojectID])
REFERENCES [dbo].[Subproject] ([SubprojectID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Subproject_SubprojectID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID])
REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Subproject_SubprojectID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectProjectStatus_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubprojectProjectStatus] CHECK CONSTRAINT [FK_SubprojectProjectStatus_Tenant_TenantID]