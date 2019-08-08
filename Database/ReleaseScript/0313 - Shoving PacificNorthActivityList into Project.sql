

--select * from dbo.TaxonomyLeaf
--where TenantID = 12

--select * from dbo.Tenant
--select * from dbo.ProjectLocationSimpleType
--select * from dbo.ProjectApprovalStatus

--select * from ProjectStage








insert into dbo.Project
(
    TenantID,
    TaxonomyLeafID,
    ProjectStageID,
    CompletionYear,
    ProjectName,
    ProjectDescription,
    IsFeatured,
    ProjectLocationSimpleTypeID,
    ProjectApprovalStatusID
)
select
    12 as TenantID, -- Reclamation TenantID
    2337 as TaxonomyLeafID, -- Random (but valid) TaxonmyLeafID for Reclamation TenantID
    -- 'Active' => Implementation & 'Inactive' => Completed
    -- This may well be wrong, or simplistic.
    case pna.PacificNorthActivityStatusID when 1 then 3 else 4 end as ProjectStageID,
 -- 2222 for the completion year to make it clear it's nonsense data.
 -- There's no such idea yet that I can see in PNA.
    case pna.PacificNorthActivityStatusID when 1 then null else 2222 end as CompletionYear,
    pna.PacificNorthActivityName as ProjectName,
    -- I'd rather leave this description null, but that's not permitted by the schema
    ' ' as ProjectDescription,
    0 as IsFeatured,
    3 as ProjectLocationSimpleTypeID, -- "None" for location, at least to start. Can correct later.
    3 as ProjectApprovalStatusID -- Assuming all projects are approved, at least to start.
from dbo.ReclamationPacificNorthActivityList as pna

-- Clean up embedded double spaces in ProjectNames??