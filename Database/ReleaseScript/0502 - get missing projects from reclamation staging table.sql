

--ARRA98 PRESTON GEN PROJT COORD, 12
--begin tran
-- Make the Project we are missing
insert into dbo.Project(TenantID, TaxonomyLeafID, ProjectStageID, ProjectName, ProjectDescription, IsFeatured, ProjectLocationSimpleTypeID, ProjectApprovalStatusID, LastUpdatedDate, ProjectCategoryID)
select
    12 as TenantID,
    2344 as TaxonomyLeafID,
    3 as ProjectStageID,
    rscawbsNeedingProjects.PacificNorthActivityName,
    'XXXXX THIS IS A FRESHLY IMPORTED PROJECT XXXXX' as ProjectDescription,
    0 as IsFeatured,
    3 as ProjectLocationSimpleTypeID,
    3 as ProjectApprovalStatusID,
    getdate() as LastUpdatedDate,
    1 as ProjectCategoryID
from
(
    select distinct rscawbs.PacificNorthActivityName
           --rscawbs.CostAuthorityWorkBreakdownStructure
    from 
    Reclamation.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList as rscawbs
    join Reclamation.CostAuthority as ca on ca.CostAuthorityWorkBreakdownStructure = rscawbs.CostAuthorityWorkBreakdownStructure
    where rscawbs.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID not in 
    (
        -- These are the records we want to OMIT, and NOT create projects for
        select distinct subq.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID
        from
        (
        select
            rscawbs.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID
        from
            Reclamation.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList as rscawbs
            join Reclamation.CostAuthority as ca on ca.CostAuthorityWorkBreakdownStructure = rscawbs.CostAuthorityWorkBreakdownStructure
            join Reclamation.CostAuthorityProject as cap on ca.CostAuthorityID = cap.ReclamationCostAuthorityID
            join dbo.Project as p on cap.ProjectID = p.ProjectID 
            where TenantID = 12

        union
        
        select
            rscawbs.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID
        from
            Reclamation.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList as rscawbs
            join dbo.Project as p on p.ProjectName = rscawbs.PacificNorthActivityName 
            where TenantID = 12
        ) as subq
    )
) as rscawbsNeedingProjects


insert into Reclamation.CostAuthorityProject (ReclamationCostAuthorityID, ProjectID, IsPrimaryProjectCawbs)
select
    ca.CostAuthorityID as ReclamationCostAuthorityID,
    p.ProjectID as ProjectID,
    case when(rank() over (partition by p.ProjectID order by ca.CostAuthorityID)) = 1 then 1 else 0 end as IsPrimaryProjectCawbs
from dbo.Project as p
join Reclamation.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList as rscawbs on p.ProjectName = rscawbs.PacificNorthActivityName
join Reclamation.CostAuthority as ca on ca.CostAuthorityWorkBreakdownStructure = rscawbs.CostAuthorityWorkBreakdownStructure
where p.ProjectID not in
(
    -- Projects which already have CostAuthorities, and which we can omit from hooking up to CostAuthorities with more permissive hooking.
    select p.ProjectID
    from dbo.Project as p
    join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
    join Reclamation.CostAuthority as ca on cap.ReclamationCostAuthorityID = ca.CostAuthorityID
)


--select * from Reclamation.CostAuthorityProject

/*
select p.*
from dbo.Project as p
join Reclamation.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList as rscawbs on p.ProjectName = rscawbs.PacificNorthActivityName
join Reclamation.CostAuthority as ca on ca.CostAuthorityWorkBreakdownStructure = rscawbs.CostAuthorityWorkBreakdownStructure
where p.ProjectID not in
(
    -- Projects which already have CostAuthorities, and which we can omit from hooking up to CostAuthorities with more permissive hooking.
    select p.ProjectID
    from dbo.Project as p
    join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
    join Reclamation.CostAuthority as ca on cap.ReclamationCostAuthorityID = ca.CostAuthorityID
)


-- Projects which already have CostAuthorities, and which we can omit from hooking up to CostAuthorities with more permissive hooking.
select p.ProjectID
from dbo.Project as p
join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
join Reclamation.CostAuthority as ca on cap.ReclamationCostAuthorityID = ca.CostAuthorityID

*/