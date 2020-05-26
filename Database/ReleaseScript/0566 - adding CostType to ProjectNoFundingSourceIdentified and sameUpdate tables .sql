/*
select * from dbo.ProjectNoFundingSourceIdentified

select * from dbo.CostType
*/

alter table dbo.ProjectNoFundingSourceIdentified
add CostTypeID int constraint FK_ProjectNoFundingSourceIdentified_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID)
go

delete from dbo.ProjectNoFundingSourceIdentified where TenantID != 12

update dbo.ProjectNoFundingSourceIdentified
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Other')
where TenantID = 12;


alter table dbo.ProjectNoFundingSourceIdentified
alter column CostTypeID int not null;


--Now do the Update table
alter table dbo.ProjectNoFundingSourceIdentifiedUpdate
add CostTypeID int constraint FK_ProjectNoFundingSourceIdentifiedUpdate_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID)
go

delete from dbo.ProjectNoFundingSourceIdentifiedUpdate where TenantID != 12

update dbo.ProjectNoFundingSourceIdentifiedUpdate
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Other')
where TenantID = 12;


alter table dbo.ProjectNoFundingSourceIdentifiedUpdate
alter column CostTypeID int not null;
