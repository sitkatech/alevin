--ProjectID:13726 Project Name:Grande Ronde Geom CC RA 4
--   Direct TaxonomyLeafID: 2344 Direct TaxonomyLeafName: 6808.500 Complexity
--   Roundabout TaxonomyLeafID: [null]

/*
select * 
from dbo.Project as p
inner join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
where p.ProjectID = 13726

select * from Reclamation.CostAuthorityProject
*/


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
inner join dbo.TaxonomyLeaf as tl on p.TaxonomyLeafID = tl.TaxonomyLeafID
inner join Reclamation.CostAuthority as ca on tl.TaxonomyLeafID = ca.TaxonomyLeafID
--where p.ProjectID = 13726
order by p.ProjectID

*/


update dbo.Project
set OverrideTaxonomyLeafID = null
where ProjectID not in 
(
    select ProjectID from #ProjectsWithDirectButNoIndirectTaxonomyLeafs
)
and TenantID = 12





/*
select * from 
dbo.Project


inner join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID

select 
*/
