-- Removing the redundant key I built. This is data duplication and denormalization;
-- it will just lead to problems I think. I'll attempt to do the same thing in C#, by
-- navigating the long way round:
--
-- Project => CostAuthorityProject (If is Primary) =>  CostAuthority => TaxonomyLeafID

-- Commenting out long enough to write a test to verify things work correctly. Afterwards, we'll
-- take this back out again. -- SLG 4/20/2020
/*

alter table dbo.Project
drop constraint FK_Project_TaxonomyLeaf_TaxonomyLeafID
GO

alter table dbo.Project
drop constraint FK_Project_TaxonomyLeaf_TaxonomyLeafID_TenantID
GO

alter table dbo.Project
drop column TaxonomyLeafID
GO

*/

-- Trying to make this into an override and salvage it
alter table dbo.Project
alter column TaxonomyLeafID int null
GO

sp_rename 'dbo.project.TaxonomyLeafID', 'OverrideTaxonomyLeafID'
GO

exec sp_rename 'dbo.FK_Project_TaxonomyLeaf_TaxonomyLeafID', 'FK_Project_TaxonomyLeaf_OverrideTaxonomyLeafID_TaxonomyLeafID', 'OBJECT'
GO

exec sp_rename 'dbo.FK_Project_TaxonomyLeaf_TaxonomyLeafID_TenantID', 'FK_Project_TaxonomyLeaf_OverrideTaxonomyLeafID_TenantID_TaxonomyLeafID_TenantID', 'OBJECT'
GO