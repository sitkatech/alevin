
-- Is this CAWBS the Primary CAWBS for this Project?
alter table dbo.ReclamationCostAuthorityProject add IsPrimaryProjectCawbs bit null
GO

update dbo.ReclamationCostAuthorityProject
set IsPrimaryProjectCawbs = 1
where ReclamationCostAuthorityID in 
(
    select rcap.ReclamationCostAuthorityID
    from dbo.ReclamationCostAuthorityProject as rcap
    group by ReclamationCostAuthorityID
    having count(*) = 1
)
GO

update  dbo.ReclamationCostAuthorityProject
set IsPrimaryProjectCawbs = 0
where IsPrimaryProjectCawbs is null
GO

alter table dbo.ReclamationCostAuthorityProject alter column IsPrimaryProjectCawbs bit not null
GO

-- A unique key we use as as a speedier version of a constraint where we
-- would otherwise use a UDF.
ALTER TABLE dbo.ReclamationCostAuthorityProject
ADD PrimaryProjectCawbsUniqueString AS (case when IsPrimaryProjectCawbs = 1 then CAST (('ProjectID:' + CAST(ProjectID as varchar(500)) + '-') as varchar(500))  ELSE CAST(('ProjectID:' + CAST(ProjectID as varchar(500)) + '-' + 'ReclamationCostAuthorityID:' + (CAST(ReclamationCostAuthorityID as varchar(500)))) as varchar(500)) END)

-- Create a non-clustered index on the computed column
CREATE UNIQUE NONCLUSTERED INDEX IX_ReclamationCostAuthorityProject_PrimaryCawbsUniqueString
ON dbo.ReclamationCostAuthorityProject (PrimaryProjectCawbsUniqueString)
GO


--alter table dbo.ReclamationCostAuthorityProject
--add CONSTRAINT [AK_ReclamationCostAuthorityProject_PrimaryCawbsUniqueString] UNIQUE NONCLUSTERED 
--(
--    PrimaryCawbsUniqueString ASC
--)




select rcap.ReclamationCostAuthorityProjectID,
       rcap.ProjectID,
       rcap.ReclamationCostAuthorityID,
       rcap.IsPrimaryProjectCawbs,
       rcap.PrimaryProjectCawbsUniqueString
from dbo.ReclamationCostAuthorityProject as rcap
order by PrimaryProjectCawbsUniqueString

-- From here, we'd need to pick Primary CAWBS for ProjectIDs.
-- But we can also work on bulding a UI for that, and for 



---- What's left to work on? Nothing.
--select rcap.ReclamationCostAuthorityID,
--       count(*)
--from dbo.ReclamationCostAuthorityProject as rcap
--group by ReclamationCostAuthorityID, ProjectID 
--having count(*) > 1



--ALTER TABLE dbo.ReclamationCostAuthorityProject
--ADD PrimaryCawbsUniqueString6 AS (case when IsPrimaryCawbs is null then ( CAST(ProjectID as varchar(max)) + '-') END)



--select rcap.*
--from dbo.ReclamationCostAuthorityProject as rcap


--ALTER TABLE [dbo].ReclamationCostAuthorityProject ADD CONSTRAINT
--      [CK_ReclamationCostAuthorityProject_Only_One_PrimaryCAWBS_per_project_cawbs_combo] CHECK 
--	  (
--		  -- Can have any number of secondary CAWBS
--		  (IsPrimaryCawbs = 0)
--		  OR 
--		    -- But only one primary CAWBS
--			(
--			select count(*)
--			from dbo.ReclamationCostAuthorityProject as rcap
--			where rcap.ProjectID = ProjectID and rcap.ReclamationCostAuthorityID = ReclamationCostAuthorityID 
--			group by ReclamationCostAuthorityID, ProjectID 
--			) = 1 
--	 )

--ALTER TABLE [dbo].ReclamationCostAuthorityProject 
--ADD  CONSTRAINT [AK_ReclamationCostAuthorityProject_PerformanceMeasureReportingPeriodID_TenantID] UNIQUE NONCLUSTERED 
--(
--	ReclamationCostAuthorityID ASC,
--	ProjectID ASC
--)
--GO







--alter table dbo.ReclamationCostAuthorityProject alter column IsPrimaryCawbs bit not null