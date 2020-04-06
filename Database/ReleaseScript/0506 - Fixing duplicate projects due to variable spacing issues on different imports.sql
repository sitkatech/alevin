--select 
--count(*) as ProjectNameCount,
--p.TenantID,
--p.ProjectName
--from dbo.Project as p
--group by p.ProjectName, TenantID
--order by count(*) desc, TenantID

--select * from dbo.TaxonomyLeaf
--where TaxonomyLeafID = 2680

--select p.*
--from dbo.Project as p
--where p.ProjectName like '%U M J D Barrier Ricco Diversion Ditch%'

--select p.*
--from dbo.Project as p
--where p.ProjectName like '%U M J D Barrier Ricco%'

--select p.*
--from dbo.Project as p
--where p.ProjectID in (14304, 14029)

---- 14304
---- 'U M J D Barrier Ricco Diversion Ditch'


--begin tran

-- Turn off constraint long enough to create duplicate names by making spacing consistent.
ALTER TABLE [dbo].[Project] DROP CONSTRAINT [AK_Project_ProjectName_TenantID]
GO

update dbo.Project
-- Replace multiple spaces with single space. This is diabolically clever and insane.
set Project.ProjectName = replace(replace(replace(Project.ProjectName,' ','<>'),'><',''),'<>',' ')
where TenantID = 12

/*
-- Did the replace work? Check.
select p.*
from dbo.Project as p
where p.ProjectID in (14304, 14029)
*/

-- Find all Project which have an Unknown TaxonomyLeaf AND have a duplicate name,
-- then delete them
delete from dbo.Project
where dbo.Project.ProjectID in
(
    select p.ProjectID
    from dbo.Project as p
    where p.TaxonomyLeafID = 2680
    and p.ProjectName in (select px.ProjectName from dbo.Project as px where px.ProjectName = p.ProjectName and px.TaxonomyLeafID != 2680)
    --and p.ProjectID in (14304, 14029)
)

-- do after we resolve dupe issues
ALTER TABLE [dbo].[Project] ADD  CONSTRAINT [AK_Project_ProjectName_TenantID] UNIQUE NONCLUSTERED 
(
    [ProjectName] ASC,
    [TenantID] ASC
) ON [PRIMARY]
GO

--rollback tran

-- select string = replace(replace(replace(' select   single       spaces',' ','<>'),'><',''),'<>',' ')