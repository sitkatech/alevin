--What's left? These are projects which are still associated with the 'Unknown xx.xxxxx' category. Some of these can definitely be moved.

/*

select p.*
from dbo.Project as p
where p.TenantID = 12
and p.TaxonomyLeafID = 2680

*/

---- We now have unknown codes with no projects in them. Figure out which ones they are...
IF OBJECT_ID('tempdb..#UnusedUnknownTaxonomyLeaves') IS NOT NULL DROP table #UnusedUnknownTaxonomyLeaves

select 
    tl.TaxonomyLeafID,
    tl.TenantID,
    tl.TaxonomyLeafName
into #UnusedUnknownTaxonomyLeaves
from dbo.TaxonomyLeaf as tl
where tl.TaxonomyLeafID not in
(
    -- All TaxononmyLeafIDs used by Projects
    select 
        distinct 
        p.TaxonomyLeafID
    from dbo.Project as p 
    where p.TenantID = 12
)
and tl.TenantID = 12
and
TaxonomyLeafName like '%unknown%'

-- The below is a nice idea, but it takes us deep into the staging tables, so is impractical for the moment.
-- We need to get more disciplined about distinguishing between staging (not hooked to FKs) and real data (hooked to FKs).
-- Once we do that, something like this should be possible.
--
-- SLG 4/6/2020

-- ...Then delete them

/*
delete from Reclamation.CostAuthority
where TaxonomyLeafID in 
(
    select tlu.TaxonomyLeafID from #UnusedUnknownTaxonomyLeaves as tlu
)

delete from dbo.TaxonomyLeaf 
where TaxonomyLeafID in
(
    select tlu.TaxonomyLeafID from #UnusedUnknownTaxonomyLeaves as tlu
)
*/

