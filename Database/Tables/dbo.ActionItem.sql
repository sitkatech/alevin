SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ActionItem](
	[ActionItemID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ActionItemStateID] [int] NOT NULL,
	[ActionItemText] [varchar](5000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AssignedToPersonID] [int] NOT NULL,
	[AssignedOnDate] [datetime] NOT NULL,
	[DueByDate] [datetime] NOT NULL,
	[CompletedOnDate] [datetime] NULL,
	[ProjectProjectStatusID] [int] NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_ActionItem_ActionItemID] PRIMARY KEY CLUSTERED 
(
	[ActionItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_ActionItemState_ActionItemStateID] FOREIGN KEY([ActionItemStateID])
REFERENCES [dbo].[ActionItemState] ([ActionItemStateID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_ActionItemState_ActionItemStateID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Person_AssignedToPersonID_PersonID] FOREIGN KEY([AssignedToPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_Person_AssignedToPersonID_PersonID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Person_AssignedToPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([AssignedToPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_Person_AssignedToPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_Project_ProjectID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID] FOREIGN KEY([ProjectProjectStatusID])
REFERENCES [dbo].[ProjectProjectStatus] ([ProjectProjectStatusID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID_TenantID] FOREIGN KEY([ProjectProjectStatusID], [TenantID])
REFERENCES [dbo].[ProjectProjectStatus] ([ProjectProjectStatusID], [TenantID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID_TenantID]
GO
ALTER TABLE [dbo].[ActionItem]  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ActionItem] CHECK CONSTRAINT [FK_ActionItem_Tenant_TenantID]