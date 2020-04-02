--begin tran

-- This is a very junky record, just deleting it. It has no active FKs.
-- Keeping it around makes it impossible to tighten down the FKs after we are done adding TaxonmyLeafID
delete from Reclamation.CostAuthority
where CostAuthorityID = 128

-- Add new TaxonomyLeafID column
alter table Reclamation.CostAuthority
add TaxonomyLeafID int null
GO

-- Add FK for TaxonomyLeafID
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthority_TaxonomyLeaf_TaxonomyLeafID] FOREIGN KEY(TaxonomyLeafID)
REFERENCES dbo.TaxonomyLeaf (TaxonomyLeafID)
GO

-- Make the bulk of the associations
update Reclamation.CostAuthority
set TaxonomyLeafID = tl.TaxonomyLeafID
from dbo.TaxonomyLeaf as tl 
inner join Reclamation.CostAuthority as ca on substring(tl.TaxonomyLeafName, 1, 8) = (ca.Authority + '.' + ca.Job)
where tl.TenantID = 12

-- What's left that we haven't hooked up?
select * from Reclamation.CostAuthority where TaxonomyLeafID is null

-- What's left with non-goofy Authority numbers (only numeric)
select * from Reclamation.CostAuthority where TaxonomyLeafID is null and ISNUMERIC(Authority) != 1

-- Numeric, non-controversial
select * from Reclamation.CostAuthority where TaxonomyLeafID is null and    ISNUMERIC(Authority) = 1 and ISNUMERIC(Job) = 1 and Job != '1D4'

-- Here we need to make another batch of Unknown TB & TLs to attach these last ~18 lingering CostAuthorities to.
IF OBJECT_ID('tempdb..#TaxonomyBranchesWeNeedToCreate') IS NOT NULL DROP table #TaxonomyBranchesWeNeedToCreate

select
    distinct
    y.TaxonomyBranch
into #TaxonomyBranchesWeNeedToCreate
from
(
    select
        --pcawbs.TaxonomyPrefix,
        --substring(pcawbs.TaxonomyPrefix, 1, 4) as TaxonomyBranch
        rca.Authority as TaxonomyBranch
    from 
       Reclamation.CostAuthority as rca
    where
       TaxonomyLeafID is null 
       and 
       CostAuthorityWorkBreakdownStructure like 'R_.%'
       --and 
       --ISNUMERIC(Authority) = 1
       --and
       --ISNUMERIC(Job) = 1 
       --and
       ---- Passes ISNUMERIC, but we don't think this is numeric for our purposes.
       --Job != '1D4'
) as y

--select * from #TaxonomyBranchesWeNeedToCreate

-- 2nd pass on branches to create to eliminate ones we actually already have created
delete from #TaxonomyBranchesWeNeedToCreate
where TaxonomyBranch in 
(
    -- Which BranchIDs actually already exist?
    select TaxonomyBranch
    from #TaxonomyBranchesWeNeedToCreate as tbtc
    left join dbo.TaxonomyBranch as tb on tbtc.TaxonomyBranch + ' unknown' = tb.TaxonomyBranchName
    where tb.TaxonomyBranchID is not null
)

-- Retrieve root of the new "Unknown" part of the Taxonmy Trunk
declare @unknownTaxonomyTrunkID int
set @unknownTaxonomyTrunkID = 
(
    select tt.TaxonomyTrunkID
    from dbo.TaxonomyTrunk as tt 
    where 
        tt.TaxonomyTrunkName = 'Unknown' 
        and
        tt.TaxonomyTrunkDescription = 'This is an authority to hold values that we are unsure of where they should go.'
)

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

select * from Reclamation.CostAuthority where TaxonomyLeafID is null
select * from #TaxonomyBranchesWeNeedToCreate

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
        rca.Authority + '.' + rca.Job as TaxonomyPrefix,
        (select tb.TaxonomyBranchID from dbo.TaxonomyBranch as tb where TenantID = 12 and left(tb.TaxonomyBranchName, 4) = rca.Authority and tb.TaxonomyBranchName like '%unknown%') as TaxonomyBranchID,
        substring(rca.Authority + '.' + rca.Job, 6, 3) as TaxonomyLeaf
    from 
        Reclamation.CostAuthority as rca
    where 
        TaxonomyLeafID is null 
        --and 
        --ISNUMERIC(Authority) = 1
        --and 
        --ISNUMERIC(Job) = 1 
        --and
        ---- Passes ISNUMERIC, but we don't think this is numeric for our purposes.
        --Job != '1D4'
) as y

select * from #TaxonomyLeavesWeNeedToCreate


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
where
    TaxonomyBranchID is not null

-- Try to make these final associations with the new Unknowns we've rreated

-- What are we left with?
select * from Reclamation.CostAuthority where TaxonomyLeafID is null


select * from TaxonomyLeaf
where TenantID = 12

alter table Reclamation.CostAuthority
alter column TaxonomyLeafID int not null
GO

rollback tran

/*
select ca.Job + '.' + ca.Number as JobNumberWithDot
from Reclamation.CostAuthority as ca
join Tax
*/


--select * from dbo.TaxonomyLeaf where TenantID = 12
--select * from Reclamation.CostAuthority
--where JobNumber is null



/*
select * from dbo.TaxonomyLeaf
where TenantID = 12

select * from Reclamation.CostAuthority

select JobNumber,
       count(*) JobNumberCount
from Reclamation.CostAuthority
group by JobNumber
order by count(*) desc

-- So, multiple 





/*
select (ca.Job + '.' + ca.Number)
from Reclamation.CostAuthority as ca

select substring(tl.TaxonomyLeafName, 1, 8)
from dbo.TaxonomyLeaf as tl
where tl.TenantID = 12


select * from dbo.TaxonomyLeaf where TenantID = 12
select * from Reclamation.CostAuthority
*/



    --select tl.TaxonomyLeafID,
    --       ca.CostAuthorityID,
    --       (ca.Authority + '.' + ca.Job) as MatchingBit
    --from dbo.TaxonomyLeaf as tl 
    --inner join Reclamation.CostAuthority as ca on substring(tl.TaxonomyLeafName, 1, 8) = (ca.Authority + '.' + ca.Job)
    --where tl.TenantID = 12
*/