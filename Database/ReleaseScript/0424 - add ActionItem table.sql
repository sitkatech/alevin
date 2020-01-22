
--begin tran

CREATE TABLE [dbo].[ActionItem](
	[ActionItemID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] not null,
    [ActionItemStateID] int not null,
    [ActionItemText] varchar(5000) null,
    [AssignedToPersonID] int not null,
    [AssignedOnDate] datetime not null,
    [DueByDate] datetime not null,
    [CompletedOnDate] datetime null,
    [ProjectProjectStatusID] int null,
    [ProjectID] int not null
 CONSTRAINT [PK_ActionItem_ActionItemID] PRIMARY KEY CLUSTERED 
(
	[ActionItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

-- tenant
ALTER TABLE [dbo].ActionItem  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].ActionItem CHECK CONSTRAINT [FK_ActionItem_Tenant_TenantID]
GO


-- project
ALTER TABLE [dbo].ActionItem  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO

ALTER TABLE [dbo].ActionItem CHECK CONSTRAINT [FK_ActionItem_Project_ProjectID]
GO

-- Assigned to person
ALTER TABLE [dbo].ActionItem  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_Person_AssignedToPersonID_PersonID] FOREIGN KEY([AssignedToPersonID])
REFERENCES [dbo].Person ([PersonID])
GO

ALTER TABLE [dbo].ActionItem CHECK CONSTRAINT [FK_ActionItem_Person_AssignedToPersonID_PersonID]
GO

-- Status Update
ALTER TABLE [dbo].ActionItem  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID] FOREIGN KEY([ProjectProjectStatusID])
REFERENCES [dbo].[ProjectProjectStatus] ([ProjectProjectStatusID])
GO

ALTER TABLE [dbo].ActionItem CHECK CONSTRAINT [FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID]
GO





-- Action Item State to go here
CREATE TABLE [dbo].[ActionItemState](
	ActionItemStateID [int] NOT NULL,
    ActionItemStateName varchar(100) not null,
    ActionItemStateDisplayName varchar(100) not null,
    SortOrder int not null,
 CONSTRAINT [PK_ActionItemState_ActionItemStateID] PRIMARY KEY CLUSTERED 
(
	[ActionItemStateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert dbo.ActionItemState (ActionItemStateID, ActionItemStateName, ActionItemStateDisplayName, SortOrder) values 
(1, 'Incomplete', 'Incomplete', 10),
(2, 'Complete', 'Complete', 20)


-- action item state key to action item
ALTER TABLE [dbo].ActionItem  WITH CHECK ADD  CONSTRAINT [FK_ActionItem_ActionItemState_ActionItemStateID] FOREIGN KEY([ActionItemStateID])
REFERENCES [dbo].[ActionItemState] ([ActionItemStateID])
GO

ALTER TABLE [dbo].ActionItem CHECK CONSTRAINT [FK_ActionItem_ActionItemState_ActionItemStateID]
GO



-- Field Definitions
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(10034,N'ActionItem', N'Action Item'),
(10035,N'ActionItemState', N'Action Item State'),
(10036,N'ActionItemAssignedToPerson', N'Assigned To'),
(10037,N'ActionItemAssignedOnDate', N'Assigned On'),
(10038,N'ActionItemDueByDate', N'Due By'),
(10039,N'ActionItemCompletedOnDate', N'Completed On'),
(10040,N'ActionItemProjectStatus', N'Related Project Status'),
(10041,N'ActionItemText', N'Action Item Text')


go

-- Firma Page
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(10004, 'ActionItemEditDialog', 'Action Item Edit Dialog', 2)

go
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 10004, '<p>Action Item Edit Dialog</p>' 
from dbo.Tenant


--rollback tran