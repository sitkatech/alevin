

alter table dbo.ProjectProjectStatus
drop column ProjectProjectStatusComment;


alter table dbo.ProjectProjectStatus
add
	ProjectProjectStatusRecentActivities varchar(2000) null,
	ProjectProjectStatusUpcomingActivities varchar(2000) null,
	ProjectProjectStatusRisksOrIssues varchar(2000) null,
	ProjectProjectStatusNotes varchar(2000) null;




INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES
(10034, N'StatusRecentActivities', N'Status Recent Activities'),
(10035, N'StatusUpcomingActivities', N'Status Upcoming Activities'),
(10036, N'StatusRisksOrIssues', N'Status Risks/Issues'),
(10037, N'StatusNotes', N'Status Notes');


insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10034, N'Status Recent Activities')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10035, N'Status Upcoming Activities')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10036, N'Status Risks/Issues')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10037, N'Status Notes')