SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subproject](
	[SubprojectID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[SubprojectStageID] [int] NOT NULL,
	[ImplementationStartYear] [int] NULL,
	[CompletionYear] [int] NULL,
	[Notes] [dbo].[html] NULL,
	[SubprojectName] [varchar](140) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SubprojectDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Subproject_SubprojectID] PRIMARY KEY CLUSTERED 
(
	[SubprojectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_Subproject_SubprojectID_TenantID] UNIQUE NONCLUSTERED 
(
	[SubprojectID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Subproject]  WITH CHECK ADD  CONSTRAINT [FK_Subproject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[Subproject] CHECK CONSTRAINT [FK_Subproject_Project_ProjectID]
GO
ALTER TABLE [dbo].[Subproject]  WITH CHECK ADD  CONSTRAINT [FK_Subproject_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[Subproject] CHECK CONSTRAINT [FK_Subproject_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[Subproject]  WITH CHECK ADD  CONSTRAINT [FK_Subproject_ProjectStage_SubprojectStageID_ProjectStageID] FOREIGN KEY([SubprojectStageID])
REFERENCES [dbo].[ProjectStage] ([ProjectStageID])
GO
ALTER TABLE [dbo].[Subproject] CHECK CONSTRAINT [FK_Subproject_ProjectStage_SubprojectStageID_ProjectStageID]
GO
ALTER TABLE [dbo].[Subproject]  WITH CHECK ADD  CONSTRAINT [FK_Subproject_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Subproject] CHECK CONSTRAINT [FK_Subproject_Tenant_TenantID]