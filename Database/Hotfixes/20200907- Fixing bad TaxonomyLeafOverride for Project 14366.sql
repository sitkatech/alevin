66

-- Unsure how we got into this funky state, but this corrects the redundant overrides for TaxonomyLeaf for ProjectID 14366.
-- I've improved error checking in this error to help guide us to the right solution faster next time..
update Reclamation.CostAuthorityProject
set IsPrimaryProjectCawbs = 1
where ProjectID = 14366 

update dbo.Project
set OverrideTaxonomyLeafID = null
where ProjectID = 14366



--select * from Reclamation.CostAuthorityProject
--where ProjectID = 14366




--select p.OverrideTaxonomyLeafID
--from dbo.Project as p
--where ProjectID = 14366

select * from Re