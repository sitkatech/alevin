
IF OBJECT_ID('tempdb..#ProjectsWithCawbs') IS NOT NULL DROP table #ProjectsWithCawbs

select 
    z.TaxonomyPrefix
into #ProjectsWithCawbs
from
(
    select distinct
        --p.ProjectID as ProjectID,
        --p.ProjectName as ProjectName,
        --cap.ReclamationCostAuthorityID as CostAuthorityID,
        --ca.CostAuthorityWorkBreakdownStructure as CostAuthorityWorkBreakdownStructure,
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

/*
select pcawbs.*
from #ProjectsWithCawbs as pcawbs
*/

IF OBJECT_ID('tempdb..#TaxonomyBranchesWeNeedToCreate') IS NOT NULL DROP table #TaxonomyBranchesWeNeedToCreate

select
    distinct
    --y.TaxonomyPrefix,
    y.TaxonomyBranch
into #TaxonomyBranchesWeNeedToCreate
from
(
select
    pcawbs.TaxonomyPrefix,
    substring(pcawbs.TaxonomyPrefix, 1, 4) as TaxonomyBranch
from 
    #ProjectsWithCawbs as pcawbs
where
    pcawbs.TaxonomyPrefix is not null
    and substring(pcawbs.TaxonomyPrefix, 1, 4) not in ( select left(tb.TaxonomyBranchName, 4) from dbo.TaxonomyBranch as tb where tb.TenantID = 12 )
) as y


--select * from dbo.TaxonomyTrunk

--begin tran

insert into dbo.TaxonomyTrunk(TenantID, TaxonomyTrunkName, TaxonomyTrunkDescription, ThemeColor)
values (12, 'Unknown', 'This is an authority to hold values that we are unsure of where they should go.', '#000000')

declare @unknownTaxonomyTrunkID int
set @unknownTaxonomyTrunkID = SCOPE_IDENTITY()

insert into dbo.TaxonomyBranch(TenantID, TaxonomyTrunkID, TaxonomyBranchName, TaxonomyBranchDescription, ThemeColor)
select 
    12 as TenantID,
    @unknownTaxonomyTrunkID as TaxonomyTrunkID,
    tbwnc.TaxonomyBranch + ' unknown' as TaxonomyBranchName,
    tbwnc.TaxonomyBranch + ' unknown' as TaxonomyBranchDescription,
    '#000000' as ThemeColor
from 
    #TaxonomyBranchesWeNeedToCreate as tbwnc

-- Insert taxonomy leaves we need to create
-------------------------------------------

select * from dbo.TaxonomyLeaf

IF OBJECT_ID('tempdb..#TaxonomyLeavesWeNeedToCreate') IS NOT NULL DROP table #TaxonomyLeavesWeNeedToCreate

select
    distinct
    y.TaxonomyPrefix,
    y.TaxonomyBranchID,
    y.TaxonomyLeaf
into #TaxonomyLeavesWeNeedToCreate
from
(
    select
        pcawbs.TaxonomyPrefix,
        (select tb.TaxonomyBranchID from dbo.TaxonomyBranch as tb where TenantID = 12 and left(tb.TaxonomyBranchName, 4) = substring(pcawbs.TaxonomyPrefix, 1, 4)) as TaxonomyBranchID,
        substring(pcawbs.TaxonomyPrefix, 6, 3) as TaxonomyLeaf
    from 
        #ProjectsWithCawbs as pcawbs
    where
        pcawbs.TaxonomyPrefix is not null
        and pcawbs.TaxonomyPrefix not in ( select left(tb.TaxonomyLeafName, 8) from dbo.TaxonomyLeaf as tb where tb.TenantID = 12 )
) as y



insert into dbo.TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription, ThemeColor)
select
    12 as TenantID,
    tlwbc.TaxonomyBranchID as TaxonomyBranchID,
    case when tlwbc.TaxonomyLeaf = '120' then tlwbc.TaxonomyPrefix + ' Subbasin Service Contracts'
         when tlwbc.TaxonomyLeaf = '130' then tlwbc.TaxonomyPrefix + ' Technical Site Visit'
         when tlwbc.TaxonomyLeaf = '140' then tlwbc.TaxonomyPrefix + ' Reimbursable Service Agreement Team Coordination'
         else tlwbc.TaxonomyPrefix + ' unknown' 
         end
         as TaxonomyLeafName,
    case when tlwbc.TaxonomyLeaf = '120' then tlwbc.TaxonomyPrefix + ' Subbasin Service Contracts'
         when tlwbc.TaxonomyLeaf = '130' then tlwbc.TaxonomyPrefix + ' Technical Site Visit'
         when tlwbc.TaxonomyLeaf = '140' then tlwbc.TaxonomyPrefix + ' Reimbursable Service Agreement Team Coordination'
         else tlwbc.TaxonomyPrefix + ' unknown' 
         end
         as TaxonomyLeafDescription,
    '#000000' as ThemeColor
from
    #TaxonomyLeavesWeNeedToCreate as tlwbc


/*
    .120 Subbasin Service Contracts (ie RX.16786801.1200000)
    .130 Technical Site Visit (ie. RX.16786807.1300000)
    .140 Reimbursable Service Agreement Team Coordination (RX.16786800.1400000)

select * from dbo.TaxonomyLeaf

*/



--select * from dbo.TaxonomyBranch

--rollback tran

--select * from dbo.TaxonomyBranch

/*
,
    substring(pcawbs.TaxonomyPrefix, 6, 3) as TaxonomyLeaf

--LEAF temp table potential:
select
    pcawbs.TaxonomyPrefix,
    substring(pcawbs.TaxonomyPrefix, 1, 4) as TaxonomyBranch,
    substring(pcawbs.TaxonomyPrefix, 6, 3) as TaxonomyLeaf
from 
    #ProjectsWithCawbs as pcawbs

where
    pcawbs.TaxonomyPrefix is not null
    --and pcawbs.TaxonomyPrefix not in ( select left(tl.TaxonomyLeafName, 8) from dbo.TaxonomyLeaf as tl where tl.TenantID = 12 )


    .120 Subbasin Service Contracts (ie RX.16786801.1200000)
    .130 Technical Site Visit (ie. RX.16786807.1300000)
    .140 Reimbursable Service Agreement Team Coordination (RX.16786800.1400000)

*/