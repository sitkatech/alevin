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
        case when (charindex('.', ca.CostAuthorityWorkBreakdownStructure) > 0) then
                SUBSTRING ( ca.CostAuthorityWorkBreakdownStructure, CHARINDEX('.', ca.CostAuthorityWorkBreakdownStructure, 4) - 4, 8)
            when charindex('1678', ca.CostAuthorityWorkBreakdownStructure) > 0 then
                SUBSTRING (ca.CostAuthorityWorkBreakdownStructure, CHARINDEX('1678', ca.CostAuthorityWorkBreakdownStructure, 4) + 4, 4) + '.' + SUBSTRING (ca.CostAuthorityWorkBreakdownStructure, CHARINDEX('1678', ca.CostAuthorityWorkBreakdownStructure, 4) + 8, 3)
            else 
                null
            end as TaxonomyPrefix 
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
	pcawbs.TaxonomyPrefix is not null


