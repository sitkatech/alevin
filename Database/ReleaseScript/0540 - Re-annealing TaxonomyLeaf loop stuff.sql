DROP TABLE IF EXISTS #ProjectsWithBothIndirectAndDirectTaxonomyLeafs
GO

select distinct p.ProjectID
into #ProjectsWithBothIndirectAndDirectTaxonomyLeafs
from dbo.Project as p
left join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
where
cap.ProjectID is not null
and
p.OverrideTaxonomyLeafID is not null
and
p.TenantID = 12

--select * from #ProjectsWithBothIndirectAndDirectTaxonomyLeafs

-- Remove overrides if we have an indirect of some kind
update dbo.Project
set OverrideTaxonomyLeafID = null
where ProjectID in 
(
    select ProjectID from #ProjectsWithBothIndirectAndDirectTaxonomyLeafs
)
and TenantID = 12

/*

-- Turns out some of our indirects did not have IsPrimaryProjectCawbs selected.

-- Code for examining problematic CAP groups, to help guide
-- manual IsPrimaryProjectCawbs as done below.

select p.ProjectID,
       p.ProjectName,
       cap.CostAuthorityProjectID,
       cap.IsPrimaryProjectCawbs,
       cap.PrimaryProjectCawbsUniqueString,
       cap.CostAuthorityID,
       ca.CostAuthorityNumber,
       ca.CostAuthorityWorkBreakdownStructure,
       tl.TaxonomyLeafID,
       tl.TaxonomyLeafName
from 
dbo.Project as p
inner join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
inner join Reclamation.CostAuthority as ca on cap.CostAuthorityID = ca.CostAuthorityID
inner join dbo.TaxonomyLeaf as tl on ca.TaxonomyLeafID = tl.TaxonomyLeafID
where p.ProjectID = 13698
*/

-- These don't have primary bit set. Remember, our goofy index only ensures we don't 
-- have MORE than one primary - NOT that we have AT LEAST one primary. I've resorted to
-- tests & run-time exceptions to limit that.
update Reclamation.CostAuthorityProject
set IsPrimaryProjectCawbs = 1
where CostAuthorityProjectID in
(
-- ProjectID: 
442,
-- ProjectID: 13624
522,
-- ProjectID: 13698
465
)





-- Older notes

-- Example issue:
--ProjectID:13726 Project Name:Grande Ronde Geom CC RA 4
--   Direct TaxonomyLeafID: 2344 Direct TaxonomyLeafName: 6808.500 Complexity
--   Roundabout TaxonomyLeafID: [null]

/*

DROP TABLE IF EXISTS #ProjectsWithDirectButNoIndirectTaxonomyLeafs
GO

select p.ProjectID
into #ProjectsWithDirectButNoIndirectTaxonomyLeafs
from dbo.Project as p
left join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
where
cap.ProjectID is null
and
p.OverrideTaxonomyLeafID is not null
and
p.TenantID = 12

select * from #ProjectsWithDirectButNoIndirectTaxonomyLeafs

*/

/*

select p.ProjectID,
       p.ProjectName,
       tl.TaxonomyLeafID,
       tl.TaxonomyLeafName,
       ca.CostAuthorityID,
       ca.CostAuthorityNumber,
       ca.CostAuthorityWorkBreakdownStructure
from #ProjectsWithDirectButNoIndirectTaxonomyLeafs as pitl
inner join dbo.Project as p on pitl.ProjectID = p.ProjectID
inner join dbo.TaxonomyLeaf as tl on p.OverrideTaxonomyLeafID = tl.TaxonomyLeafID
inner join Reclamation.CostAuthority as ca on tl.TaxonomyLeafID = ca.TaxonomyLeafID
--where p.ProjectID = 13726
order by p.ProjectID

*/

/*

DROP TABLE IF EXISTS #ProjectsWithNeitherDirectNorIndirectTaxonomyLeafs
GO

select p.ProjectID
into #ProjectsWithNeitherDirectNorIndirectTaxonomyLeafs
from dbo.Project as p
left join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
where
cap.ProjectID is null
and
p.OverrideTaxonomyLeafID is null
and
p.TenantID = 12

select * from #ProjectsWithNeitherDirectNorIndirectTaxonomyLeafs

-- This should be empty^^

*/


