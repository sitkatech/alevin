SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubprojectActionItem](
	[SubprojectActionItemID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ActionItemStateID] [int] NOT NULL,
	[SubprojectActionItemText] [varchar](5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AssignedToPersonID] [int] NOT NULL,
	[AssignedOnDate] [datetime] NOT NULL,
	[DueByDate] [datetime] NOT NULL,
	[CompletedOnDate] [datetime] NULL,
	[SubprojectProjectStatusID] [int] NULL,
	[SubprojectID] [int] NOT NULL,
 CONSTRAINT [PK_SubprojectActionItem_SubprojectActionItemID] PRIMARY KEY CLUSTERED 
(
	[SubprojectActionItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_ActionItemState_ActionItemStateID] FOREIGN KEY([ActionItemStateID])
REFERENCES [dbo].[ActionItemState] ([ActionItemStateID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_ActionItemState_ActionItemStateID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_Person_AssignedToPersonID_PersonID] FOREIGN KEY([AssignedToPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_Person_AssignedToPersonID_PersonID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_Person_AssignedToPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([AssignedToPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_Person_AssignedToPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_Subproject_SubprojectID] FOREIGN KEY([SubprojectID])
REFERENCES [dbo].[Subproject] ([SubprojectID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_Subproject_SubprojectID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID])
REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_Subproject_SubprojectID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_SubprojectProjectStatus_SubprojectProjectStatusID] FOREIGN KEY([SubprojectProjectStatusID])
REFERENCES [dbo].[SubprojectProjectStatus] ([SubprojectProjectStatusID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_SubprojectProjectStatus_SubprojectProjectStatusID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_SubprojectProjectStatus_SubprojectProjectStatusID_TenantID] FOREIGN KEY([SubprojectProjectStatusID], [TenantID])
REFERENCES [dbo].[SubprojectProjectStatus] ([SubprojectProjectStatusID], [TenantID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_SubprojectProjectStatus_SubprojectProjectStatusID_TenantID]
GO
ALTER TABLE [dbo].[SubprojectActionItem]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectActionItem_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SubprojectActionItem] CHECK CONSTRAINT [FK_SubprojectActionItem_Tenant_TenantID]