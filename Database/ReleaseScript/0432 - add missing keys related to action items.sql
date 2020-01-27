alter table dbo.ActionItem add constraint FK_ActionItem_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
go

alter table dbo.ActionItem add constraint FK_ActionItem_Person_AssignedToPersonID_TenantID_PersonID_TenantID foreign key (AssignedToPersonID, TenantID) references dbo.Person(PersonID, TenantID)
go

alter table dbo.ActionItem add constraint FK_ActionItem_ProjectProjectStatus_ProjectProjectStatusID_TenantID foreign key (ProjectProjectStatusID, TenantID) references dbo.ProjectProjectStatus(ProjectProjectStatusID, TenantID)
go

