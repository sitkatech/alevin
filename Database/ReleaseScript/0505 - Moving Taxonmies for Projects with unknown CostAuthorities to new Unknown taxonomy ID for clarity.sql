select * from dbo.Project

-- These are the Projects we have TaxonmyLeaves assigned for, but which don't have CostAuthorities, so 
-- we're pretty dang sure the TL is arbitrary and wrong. So, now that we have explict unknown CostAuthorities, we'll
-- use one to illustrate that cluelessness explictly. -- SLG & TK 3/31/2020

update dbo.Project
set TaxonomyLeafID = 2680 -- Unknown TL ID
where ProjectID in 
(
    select p.ProjectID
           --,p.ProjectName,
           --p.ProjectDescription,
           --tl.TaxonomyLeafID,
           --tl.TaxonomyBranchID,
           --tl.TaxonomyLeafName
    from dbo.Project as p
    left join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
    inner join dbo.TaxonomyLeaf as tl on p.TaxonomyLeafID = tl.TaxonomyLeafID
    where p.TenantID = 12
    and
    cap.ProjectID is null
    and
    tl.TaxonomyLeafID = 2339
)
-- TL # 2680 = Uknonwn

/*
-- Remaining questionables with no CostAuthority:

    select p.ProjectID
           ,p.ProjectName,
           p.ProjectDescription,
           tl.TaxonomyLeafID,
           tl.TaxonomyBranchID,
           tl.TaxonomyLeafName
    from dbo.Project as p
    left join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
    inner join dbo.TaxonomyLeaf as tl on p.TaxonomyLeafID = tl.TaxonomyLeafID
    where p.TenantID = 12
    and
    cap.ProjectID is null
    and
    tl.TaxonomyLeafID != 2680


*/