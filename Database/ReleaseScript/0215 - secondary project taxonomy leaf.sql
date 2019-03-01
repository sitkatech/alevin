
create table dbo.SecondaryProjectTaxonomyLeaf(
	SecondaryProjectTaxonomyLeafID int not null identity(1, 1) constraint PK_SecondaryProjectTaxonomyLeaf_SecondaryProjectTaxonomyLeafID primary key,
	
	TenantID int not null constraint FK_SecondaryProjectTaxonomyLeaf_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	constraint AK_SecondaryProjectTaxonomyLeaf_SecondaryProjectTaxonomyLeafID_TenantID unique (SecondaryProjectTaxonomyLeafID, TenantID),
	
	ProjectID int not null constraint FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID foreign key references dbo.Project(ProjectID),
	constraint FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID),
	
	TaxonomyLeafID int not null constraint FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID foreign key references dbo.TaxonomyLeaf(TaxonomyLeafID),
	constraint FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID_TenantID foreign key (TaxonomyLeafID, TenantID) references dbo.TaxonomyLeaf(TaxonomyLeafID, TenantID),
	
	constraint AK_SecondaryProjectTaxonomyLeaf_ProjectID_TaxonomyLeafID unique (ProjectID, TaxonomyLeafID)
);

insert dbo.FieldDefinition(FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName, DefaultDefinition)
values
(269, N'SecondaryProjectTaxonomyLeaf', N'Secondary Project Taxonomy Leaf', N'');

insert dbo.FieldDefinitionData(TenantID, FieldDefinitionID, FieldDefinitionLabel)
select
	TenantID				= t.TenantID,
	FieldDefinitionID		= 269,
	FieldDefinitionLabel	= case when t.TenantName = 'ActionAgendaForPugetSound'
		then 'Secondary Regional Priority Approach'
		else null
	end
from dbo.Tenant t
;

alter table dbo.TenantAttribute add EnableSecondaryProjectTaxonomyLeaf bit null;

go

update dbo.TenantAttribute set
	EnableSecondaryProjectTaxonomyLeaf = case when t.TenantName = 'ActionAgendaForPugetSound'
		then 1
		else 0
	end
from dbo.TenantAttribute ta
	join dbo.Tenant t on ta.TenantID = t.TenantID
;

go

alter table dbo.TenantAttribute alter column EnableSecondaryProjectTaxonomyLeaf bit not null;