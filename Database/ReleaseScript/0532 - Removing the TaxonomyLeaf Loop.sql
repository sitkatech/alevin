-- Removing the redundant key I built. This is data duplication and denormalization;
-- it will just lead to problems I think. I'll attempt to do the same thing in C#, by
-- navigating the long way round:
--
-- Project => CostAuthorityProject (If is Primary) =>  CostAuthority => TaxonomyLeafID

alter table dbo.Project
drop constraint FK_Project_TaxonomyLeaf_TaxonomyLeafID
GO

alter table dbo.Project
drop constraint FK_Project_TaxonomyLeaf_TaxonomyLeafID_TenantID
GO

alter table dbo.Project
drop column TaxonomyLeafID
GO

