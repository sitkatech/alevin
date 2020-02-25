


delete from dbo.ReclamationCostAuthorityProject 


insert into dbo.ReclamationCostAuthorityProject (ProjectID, ReclamationCostAuthorityID, IsPrimaryProjectCawbs)
select distinct 
	p.projectID, rscaa.CostAuthorityID, 0
from 
	dbo.ReclamationStagingCostAuthorityAgreement as rscaa
	join dbo.Project as p on rscaa.PacificNorthActivityName = p.ProjectName
where
	rscaa.CostAuthorityID is not null
order by rscaa.CostAuthorityID, p.ProjectID



update dbo.ReclamationCostAuthorityProject
set IsPrimaryProjectCawbs = 1
where ProjectID in 
(
    select rcap.ProjectID
    from dbo.ReclamationCostAuthorityProject as rcap
    group by ProjectID
    having count(*) = 1
)



/*

card 1943 has some good info

select * from dbo.ReclamationCostAuthorityProject
order by ProjectID

*/