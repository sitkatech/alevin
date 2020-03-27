/*

goal: assign correct TaxonomyLeafID to the Project based on the Projects Primary CostAuthority.CAWBS

*/

IF OBJECT_ID('tempdb..#ProjectsWithCawbs') IS NOT NULL DROP table #ProjectsWithCawbs

select 
	z.ProjectID,
	z.ProjectName,
	z.CostAuthorityID,
	z.CostAuthorityWorkBreakdownStructure,
	z.TaxonomyPrefix
into #ProjectsWithCawbs
from
(
	select 
		p.ProjectID as ProjectID,
		p.ProjectName as ProjectName,
		cap.ReclamationCostAuthorityID as CostAuthorityID,
		ca.CostAuthorityWorkBreakdownStructure as CostAuthorityWorkBreakdownStructure,
		SUBSTRING ( ca.CostAuthorityWorkBreakdownStructure, CHARINDEX('.', ca.CostAuthorityWorkBreakdownStructure, 4) - 4, 8) as TaxonomyPrefix 
	from 
		dbo.Project as p
		join Reclamation.CostAuthorityProject as cap on cap.ProjectID = p.ProjectID
		join Reclamation.CostAuthority as ca on cap.ReclamationCostAuthorityID = ca.CostAuthorityID
	where 
		p.TenantID = 12
		and cap.IsPrimaryProjectCawbs = 1
) as z



UPDATE
  dbo.Project
SET
  dbo.Project.TaxonomyLeafID = tl.TaxonomyLeafID
from 
	#ProjectsWithCawbs as pcawbs
	join dbo.TaxonomyLeaf as tl on left(tl.TaxonomyLeafName, 8) = pcawbs.TaxonomyPrefix
	join dbo.Project as p on pcawbs.ProjectID = p.ProjectID
where
	pcawbs.TaxonomyPrefix like '____.___'




/*


select
	*
from 
	#ProjectsWithCawbs as pcawbs
	join dbo.TaxonomyLeaf as tl on left(tl.TaxonomyLeafName, 8) = pcawbs.TaxonomyPrefix
	join dbo.Project as p on pcawbs.ProjectID = p.ProjectID
where
	pcawbs.TaxonomyPrefix like '____.___'





	select * from dbo.TaxonomyLeaf where TenantID = 12


select 
	p.ProjectID,
	p.ProjectName,
	p.TaxonomyLeafID,
	scawbs.CostAuthorityWorkBreakdownStructure,
	--tl.TaxonomyLeafName,
	--tl.TaxonomyLeafDescription,
	--tl.TaxonomyLeafCode,
	--cap.IsPrimaryProjectCawbs,
	--cap.ReclamationCostAuthorityID,
	--ca.CostAuthorityNumber,
	--ca.CostAuthorityWorkBreakdownStructure,
	* 
from 
	dbo.Project as p
	join [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList] as scawbs on p.ProjectName = scawbs.PacificNorthActivityName
where 
	p.TenantID = 12
	and cap.IsPrimaryProjectCawbs = 1




*/