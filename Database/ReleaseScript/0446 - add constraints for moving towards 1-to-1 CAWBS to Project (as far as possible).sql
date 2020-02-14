
alter table dbo.ReclamationCostAuthorityProject add IsPrimaryCawbs bit null
GO
ALTER TABLE dbo.Products ADD RetailValue AS (QtyAvailable * UnitPrice * 1.5)

update dbo.ReclamationCostAuthorityProject
set IsPrimaryCawbs = 1
where ReclamationCostAuthorityID in 
(
	select rcap.ReclamationCostAuthorityID
	from dbo.ReclamationCostAuthorityProject as rcap
	group by ReclamationCostAuthorityID, ProjectID 
	having count(*) = 1
)




-- What's left to work on? Nothing.
select rcap.ReclamationCostAuthorityID,
		count(*)
from dbo.ReclamationCostAuthorityProject as rcap
group by ReclamationCostAuthorityID, ProjectID 
having count(*) > 1





select rcap.*
from dbo.ReclamationCostAuthorityProject as rcap


ALTER TABLE [dbo].ReclamationCostAuthorityProject ADD CONSTRAINT
      [CK_ReclamationCostAuthorityProject_Only_One_PrimaryCAWBS_per_project_cawbs_combo] CHECK 
	  (
		  -- Can have any number of secondary CAWBS
		  (IsPrimaryCawbs = 0)
		  OR 
		    -- But only one primary CAWBS
			(
			select count(*)
			from dbo.ReclamationCostAuthorityProject as rcap
			where rcap.ProjectID = ProjectID and rcap.ReclamationCostAuthorityID = ReclamationCostAuthorityID 
			group by ReclamationCostAuthorityID, ProjectID 
			) = 1 
	 )

ALTER TABLE [dbo].ReclamationCostAuthorityProject 
ADD  CONSTRAINT [AK_ReclamationCostAuthorityProject_PerformanceMeasureReportingPeriodID_TenantID] UNIQUE NONCLUSTERED 
(
	ReclamationCostAuthorityID ASC,
	ProjectID ASC
)
GO







alter table dbo.ReclamationCostAuthorityProject alter column IsPrimaryCawbs bit not null