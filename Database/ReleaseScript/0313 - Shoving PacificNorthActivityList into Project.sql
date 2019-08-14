
--begin tran


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

--select * from dbo.ProjectStage
--select * from dbo.ReclamationPacificNorthActivityStatus

--select * from dbo.Project
--where TenantID = 12

--select * from dbo.ReclamationPacificNorthActivityList


-- Linking Table
-----------------

-- Linking table for ReclamationAgreement <=> PacificNorthActivity
CREATE TABLE [dbo].ReclamationAgreementPacificNorthActivity
(
    ReclamationAgreementPacificNorthActivityID [int] IDENTITY(1,1) NOT NULL,
    ReclamationAgreementID int not null,
    ReclamationPacificNorthActivityListID int not null
)

-- Primary Key for Linking Table
ALTER TABLE [dbo].ReclamationAgreementPacificNorthActivity ADD  CONSTRAINT [PK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementPacificNorthActivityID] PRIMARY KEY CLUSTERED 
(
    ReclamationAgreementPacificNorthActivityID ASC
) ON [PRIMARY]
GO

-- FK ReclamationAgreement for linking table
ALTER TABLE [dbo].ReclamationAgreementPacificNorthActivity  WITH CHECK ADD CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY(ReclamationAgreementID)
REFERENCES [dbo].ReclamationAgreement (ReclamationAgreementID)
GO

-- FK ReclamationPacificNorthActivityListID for linking table
ALTER TABLE [dbo].ReclamationAgreementPacificNorthActivity  WITH CHECK ADD CONSTRAINT [FK_ReclamationAgreementPacificNorthActivity_ReclamationPacificNorthActivityListID_ReclamationPacificNorthActivityListID] FOREIGN KEY(ReclamationPacificNorthActivityListID)
REFERENCES [dbo].ReclamationPacificNorthActivityList (ReclamationPacificNorthActivityListID)
GO


-- AK for uniqueness
ALTER TABLE [dbo].ReclamationAgreementPacificNorthActivity ADD  CONSTRAINT [AK_ReclamationAgreementPacificNorthActivity_ReclamationAgreementID_ReclamationPacificNorthActivityListID] UNIQUE NONCLUSTERED 
(
    ReclamationAgreementID ASC,
    ReclamationPacificNorthActivityListID ASC
) ON [PRIMARY]
GO





insert into dbo.ReclamationAgreementPacificNorthActivity(ReclamationAgreementID, ReclamationPacificNorthActivityListID)
-- This mostly works, but there are some dropouts. What are we losing?
select distinct
    --rsca.AgreementNumber,
       ra.ReclamationAgreementID,
       --rsca.PacificNorthActivityNumber,
       rpna.ReclamationPacificNorthActivityListID
from [dbo].[ReclamationStagingCostAuthorityAgreement] as rsca
inner join dbo.ReclamationAgreement as ra on rsca.AgreementNumber = ra.AgreementNumber
inner join dbo.ReclamationPacificNorthActivityList as rpna on rsca.PacificNorthActivityName = rpna.PacificNorthActivityName

--select * from dbo.ReclamationAgreementPacificNorthActivity

-- Parallel linking table
---------------------------


-- Linking table for ReclamationAgreement <=> Project
CREATE TABLE [dbo].ReclamationAgreementProject
(
    ReclamationAgreementProjectID [int] IDENTITY(1,1) NOT NULL,
    ReclamationAgreementID int not null,
    ProjectID int not null
)

-- Primary Key for Linking Table
ALTER TABLE [dbo].ReclamationAgreementProject ADD  CONSTRAINT [PK_ReclamationAgreementProject_ReclamationAgreementProjectID] PRIMARY KEY CLUSTERED 
(
    ReclamationAgreementProjectID ASC
) ON [PRIMARY]
GO

-- FK ReclamationAgreement for parallel linking table
ALTER TABLE [dbo].ReclamationAgreementProject  WITH CHECK ADD CONSTRAINT [FK_ReclamationAgreementProject_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY(ReclamationAgreementID)
REFERENCES [dbo].ReclamationAgreement (ReclamationAgreementID)
GO

-- FK ProjectID for parallel linking table
ALTER TABLE [dbo].ReclamationAgreementProject  WITH CHECK ADD CONSTRAINT [FK_ReclamationAgreementProject_ProjectID_ProjectID] FOREIGN KEY(ProjectID)
REFERENCES [dbo].Project (ProjectID)
GO

-- AK for uniqueness
ALTER TABLE [dbo].ReclamationAgreementProject ADD  CONSTRAINT [AK_ReclamationAgreementProject_ReclamationAgreementID_ProjectID] UNIQUE NONCLUSTERED 
(
    ReclamationAgreementID ASC,
    ProjectID ASC
) ON [PRIMARY]
GO





insert into dbo.ReclamationAgreementProject(ReclamationAgreementID, ProjectID)
-- This mostly works, but there are some dropouts. What are we losing?
select distinct
       --rsca.AgreementNumber,
       ra.ReclamationAgreementID,
       --rsca.PacificNorthActivityNumber,
       p.ProjectID
from [dbo].[ReclamationStagingCostAuthorityAgreement] as rsca
inner join dbo.ReclamationAgreement as ra on rsca.AgreementNumber = ra.AgreementNumber
-- We just made this work above when we loaded the PNA name into Project as ProjectName.
inner join dbo.Project as p on rsca.PacificNorthActivityName = p.ProjectName

/*
select * from dbo.ReclamationAgreementProject

select * from dbo.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList

select * from dbo.ReclamationStagingCostAuthorityAgreement

-- This is the real table
select * from ReclamationCostAuthority

*/

-- Linking table for ReclamationAgreement <=> ReclamationCostAuthority
CREATE TABLE [dbo].ReclamationAgreementReclamationCostAuthority
(
    ReclamationAgreementReclamationCostAuthorityID [int] IDENTITY(1,1) NOT NULL,
    ReclamationAgreementID int not null,
    ReclamationCostAuthorityID int not null
)

-- Primary Key for Linking Table
ALTER TABLE [dbo].ReclamationAgreementReclamationCostAuthority ADD  CONSTRAINT [PK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreementReclamationCostAuthorityID] PRIMARY KEY CLUSTERED 
(
    ReclamationAgreementReclamationCostAuthorityID ASC
) ON [PRIMARY]
GO

-- FK ReclamationAgreement 
ALTER TABLE [dbo].ReclamationAgreementReclamationCostAuthority  WITH CHECK ADD CONSTRAINT [FK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreementID_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY(ReclamationAgreementID)
REFERENCES [dbo].ReclamationAgreement (ReclamationAgreementID)
GO

-- FK ReclamationCostAuthorityID
ALTER TABLE [dbo].ReclamationAgreementReclamationCostAuthority  WITH CHECK ADD CONSTRAINT [FK_ReclamationAgreementReclamationCostAuthority_ReclamationCostAuthorityID_ReclamationCostAuthorityID] FOREIGN KEY(ReclamationCostAuthorityID)
REFERENCES [dbo].ReclamationCostAuthority (ReclamationCostAuthorityID)
GO

-- AK for uniqueness
ALTER TABLE [dbo].ReclamationAgreementReclamationCostAuthority ADD  CONSTRAINT [AK_ReclamationAgreementReclamationCostAuthority_ReclamationAgreementID_ReclamationCostAuthorityID] UNIQUE NONCLUSTERED 
(
    ReclamationAgreementID ASC,
    ReclamationCostAuthorityID ASC
) ON [PRIMARY]
GO



-- Fill up the linking table
insert into dbo.ReclamationAgreementReclamationCostAuthority(ReclamationAgreementID, ReclamationCostAuthorityID)
select distinct x.ReclamationAgreementID, x.ReclamationCostAuthorityID
from
(
    -- There's some extra stuff here for diagnostics, but we don't use it above. 
    select
        p.ProjectID,
        p.ProjectName,
        ra.ReclamationAgreementID,
        rca.ReclamationCostAuthorityID,
        rca.CostAuthorityWorkBreakdownStructure
    from dbo.ReclamationAgreement as ra
    inner join dbo.ReclamationAgreementProject as rap on ra.ReclamationAgreementID = rap.ReclamationAgreementID
    inner join dbo.Project as p on rap.ProjectID = p.ProjectID
    inner join dbo.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList as rcawsb on rcawsb.PacificNorthActivityName = p.ProjectName
    inner join dbo.ReclamationCostAuthority as rca on rcawsb.CostAuthorityWorkBreakdownStructure = rca.CostAuthorityWorkBreakdownStructure
)
as x

--rollback tran


--
--select * from dbo.ReclamationAgreementReclamationCostAuthority

/*
-- So, how does the day-to-day join look now?
-- Not too bad!
-- ===========================================

select 
    p.ProjectID,
    p.ProjectName,
    ra.ReclamationAgreementID,
    ra.AgreementNumber,
    rca.ReclamationCostAuthorityID,
    rca.CostAuthorityWorkBreakdownStructure
from dbo.Project as p
inner join dbo.ReclamationAgreementProject as rap on p.ProjectID = rap.ProjectID
inner join dbo.ReclamationAgreement as ra on rap.ReclamationAgreementID = ra.ReclamationAgreementID
inner join dbo.ReclamationAgreementReclamationCostAuthority as rapca on ra.ReclamationAgreementID = rapca.ReclamationAgreementID
inner join dbo.ReclamationCostAuthority as rca on rapca.ReclamationCostAuthorityID = rca.ReclamationCostAuthorityID
order by ProjectName, AgreementNumber, CostAuthorityWorkBreakdownStructure
*/


--select
--       ra.ReclamationAgreementID,
--       p.ProjectID
--from [dbo].[ReclamationStagingCostAuthorityAgreement] as rsca
--inner join dbo.ReclamationAgreement as ra on rsca.AgreementNumber = ra.AgreementNumber
---- We just made this work above when we loaded the PNA name into Project as ProjectName.
--inner join dbo.Project as p on rsca.PacificNorthActivityName = p.ProjectName

--select * from dbo.ReclamationCostAuthority

--select * from dbo.ReclamationAgreementProject
--select * from dbo.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList
-- 