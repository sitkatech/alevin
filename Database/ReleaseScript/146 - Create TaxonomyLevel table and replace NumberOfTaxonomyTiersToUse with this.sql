CREATE TABLE dbo.TaxonomyLevel(
	TaxonomyLevelID int NOT NULL CONSTRAINT PK_TaxonomyLevel_TaxonomyLevelID PRIMARY KEY,
	TaxonomyLevelName varchar(100) NOT NULL CONSTRAINT AK_TaxonomyLevel_TaxonomyLevelName UNIQUE,
	TaxonomyLevelDisplayName varchar(100) NOT NULL CONSTRAINT AK_TaxonomyLevel_TaxonomyLevelDisplayName UNIQUE
)

alter table dbo.TenantAttribute add TaxonomyLevelID int null, AssociatePerfomanceMeasureTaxonomyLevelID int null
alter table dbo.TenantAttribute add constraint FK_TenantAttribute_TaxonomyLevel_TaxonomyLevelID foreign key (TaxonomyLevelID) references dbo.TaxonomyLevel(TaxonomyLevelID)
alter table dbo.TenantAttribute add constraint FK_TenantAttribute_TaxonomyLevel_AssociatePerfomanceMeasureTaxonomyLevelID_TaxonomyLevelID foreign key (AssociatePerfomanceMeasureTaxonomyLevelID) references dbo.TaxonomyLevel(TaxonomyLevelID)
ALTER TABLE dbo.TenantAttribute DROP CONSTRAINT CK_TenantAttribute_NumberOfTaxonomyTiersToUseBetweenOneAndThree
GO

insert into dbo.TaxonomyLevel(TaxonomyLevelID, TaxonomyLevelName, TaxonomyLevelDisplayName)
values
(1, 'Leaf', 'Leaf (1 level)'),
(2, 'Branch', 'Branch (2 levels)'),
(3, 'Trunk', 'Trunk (3 levels)')

update dbo.TenantAttribute
set TaxonomyLevelID = NumberOfTaxonomyTiersToUse

update dbo.TenantAttribute
set AssociatePerfomanceMeasureTaxonomyLevelID = 2


alter table dbo.TenantAttribute alter column TaxonomyLevelID int not null
alter table dbo.TenantAttribute alter column AssociatePerfomanceMeasureTaxonomyLevelID int not null
alter table dbo.TenantAttribute drop column NumberOfTaxonomyTiersToUse

alter table dbo.TenantAttribute add constraint CK_TenantAttribute_AssociatedPerfomanceMeasureTaxonomyLevelLessThanEqualToTaxonomyLevelID check (AssociatePerfomanceMeasureTaxonomyLevelID <= TaxonomyLevelID)


delete from dbo.FirmaPage where FirmaPageTypeID = 23


insert into dbo.TaxonomyTrunk(TenantID, TaxonomyTrunkName)
values
(1, 'Default'),
(7, 'Default')


insert into dbo.TaxonomyBranch(TenantID, TaxonomyTrunkID, TaxonomyBranchName, TaxonomyBranchDescription, ThemeColor)
select 1 as TenantID, TaxonomyTrunkID, 'Default', 'TBD', '#86cceb'
from dbo.TaxonomyTrunk
where TenantID = 1

insert into dbo.TaxonomyBranch(TenantID, TaxonomyTrunkID, TaxonomyBranchName, TaxonomyBranchDescription, ThemeColor)
select 7 as TenantID, TaxonomyTrunkID, 'Default', 'TBD', '#86cceb'
from dbo.TaxonomyTrunk
where TenantID = 7

insert into dbo.TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
select 1 as TenantID, TaxonomyBranchID, 'Default', 'TBD'
from dbo.TaxonomyBranch
where TenantID = 1

insert into dbo.TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription)
select 7 as TenantID, TaxonomyBranchID, 'Default', 'TBD'
from dbo.TaxonomyBranch
where TenantID = 7


alter table dbo.TaxonomyLeaf add ThemeColor varchar(7) null