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

--- Noticed we have blank ProjectNumber where they seem obvious & knowable. Fix them up.
update Reclamation.CostAuthority
set ProjectNumber = SUBSTRING(rca.CostAuthorityWorkBreakdownStructure, 4, 4)
from Reclamation.CostAuthority as rca
where
    rca.CostAuthorityWorkBreakdownStructure like 'R_.%'
    and
    rca.ProjectNumber is null


/*
-- What's left that we haven't hooked up?
select * from Reclamation.CostAuthority where TaxonomyLeafID is null

-- Problems with Authority column? Nope!
select * from Reclamation.CostAuthority where Authority is null
*/

-- Make nullable labels for Taxonomy for Reclamation
alter table Dbo.TaxonomyLeaf
add ReclamationAuthority nvarchar(4) null
GO

alter table Dbo.TaxonomyLeaf
add ReclamationJob nvarchar(3) null
GO

alter table Dbo.TaxonomyLeaf
add ReclamationAuthorityJob nvarchar(8) null
GO

/*
select tpm.MissingTaxonmyPrefixes as TaxonmyPrefix
from
(
    select
    distinct
    (rca.Authority + '.' + rca.Job) as MissingTaxonmyPrefixes,
    '>' + (rca.Authority + '.' + rca.Job)  + '<' as SpaceCheck
    from Reclamation.CostAuthority as rca
    --inner join
    where rca.TaxonomyLeafID is null
    --order by (rca.Authority + '.' + rca.Job)
) as tpm

except

select tpae.AlreadyExistingTaxonmyPrefixes as TaxonmyPrefix
from
(
    select 
    distinct
    (SUBSTRING(tl.TaxonomyLeafName, 1, 8)) as AlreadyExistingTaxonmyPrefixes,
    '>' + (SUBSTRING(tl.TaxonomyLeafName, 1, 8))  + '<' as SpaceCheck
    from dbo.TaxonomyLeaf as tl
    where TenantID = 12
) as tpae
*/

--select * from Reclamation.CostAuthority where TaxonomyLeafID is null


--select * from dbo.TaxonomyLeaf where TenantID = 12
--select * from dbo.TaxonomyBranch where TenantID = 12

IF OBJECT_ID('tempdb..#YetMoreTaxonomyLeavesWeNeedToCreate') IS NOT NULL DROP table #YetMoreTaxonomyLeavesWeNeedToCreate

select
    y.TenantID,
    (select tb.TaxonomyBranchID from dbo.TaxonomyBranch as tb where tb.TaxonomyBranchName like y.Authority + '%') as TaxonomyBranchID,
    case when y.Job = '120' then y.MissingTaxonomyPrefix + ' Subbasin Service Contracts'
         when y.Job = '130' then y.MissingTaxonomyPrefix + ' Technical Site Visit'
         when y.Job = '140' then y.MissingTaxonomyPrefix + ' Reimbursable Service Agreement Team Coordination'
         else y.MissingTaxonomyPrefix + ' unknown'
         end
         as TaxonomyLeafName,
    case when y.Job = '120' then y.MissingTaxonomyPrefix + ' Subbasin Service Contracts'
         when y.Job = '130' then y.MissingTaxonomyPrefix + ' Technical Site Visit'
         when y.Job = '140' then y.MissingTaxonomyPrefix + ' Reimbursable Service Agreement Team Coordination'
         else y.MissingTaxonomyPrefix + ' unknown' 
         end
         as TaxonomyLeafDescription,
    '#000000' as ThemeColor,
    y.MissingTaxonomyPrefix,
    y.Authority,
    y.Job
into #YetMoreTaxonomyLeavesWeNeedToCreate
from
(
    select
    distinct
    12 as TenantID,
    (rca.Authority + '.' + rca.Job) as MissingTaxonomyPrefix,
    rca.Authority as Authority,
    rca.Job as Job
    from Reclamation.CostAuthority as rca
    where rca.TaxonomyLeafID is null
) as y

--select * from #YetMoreTaxonomyLeavesWeNeedToCreate

-- Some of these will lack branches. Figure out what branches we'll need to create before we can insert the above leaves.
-------------------------------------------------------------------------------------------------------------------------

--select * from dbo.TaxonomyBranch where TenantID = 12

IF OBJECT_ID('tempdb..#YetMoreTaxonomyBranchesWeNeedToCreate') IS NOT NULL DROP table #YetMoreTaxonomyBranchesWeNeedToCreate

select
    12 as TenantID,
    (select tt.TaxonomyTrunkID from dbo.TaxonomyTrunk as tt where tt.TaxonomyTrunkName = 'Unknown') as TaxonomyTrunkID,
    (y.Authority /*+ '.' + y.Job */ + ' unknown') as TaxonomyBranchName,
    (y.Authority /*+ '.' + y.Job */+ ' unknown') as TaxonomyBranchDescription,
    '#000000' as ThemeColor,
    y.MissingTaxonomyPrefix,
    y.Authority,
    y.Job
into #YetMoreTaxonomyBranchesWeNeedToCreate
from
(
    select
    tltc.Authority,
    tltc.Job,
    tltc.MissingTaxonomyPrefix
    from
    #YetMoreTaxonomyLeavesWeNeedToCreate as tltc
    where TaxonomyBranchID is null
) as y

--select * from #YetMoreTaxonomyBranchesWeNeedToCreate

-- Insert these TaxonomyBranches we need to create
insert into dbo.TaxonomyBranch(TenantID, TaxonomyTrunkID, TaxonomyBranchName, TaxonomyBranchDescription, ThemeColor)
select btc.TenantID, btc.TaxonomyTrunkID, btc.TaxonomyBranchName, btc.TaxonomyBranchDescription, btc.ThemeColor
from #YetMoreTaxonomyBranchesWeNeedToCreate as btc

-- We can now look up and repair the missing TaxonomyBranchIDs on our leaves to be inserted, since
-- They should all now have corresponding branches.

update #YetMoreTaxonomyLeavesWeNeedToCreate
set TaxonomyBranchID = (select TaxonomyBranchID from dbo.TaxonomyBranch as tb where tb.TaxonomyBranchName like Authority + ' %')
where TaxonomyBranchID is null

-- Now we can insert the missing leaves. They should all now have corresponding branches
--select * from dbo.TaxonomyLeaf where TenantID = 12
--select * from #YetMoreTaxonomyLeavesWeNeedToCreate

insert into dbo.TaxonomyLeaf(TenantID, TaxonomyBranchID, TaxonomyLeafName, TaxonomyLeafDescription, ThemeColor)
select  tltc.TenantID,
        tltc.TaxonomyBranchID,
        tltc.TaxonomyLeafName,
        tltc.TaxonomyLeafDescription,
        tltc.ThemeColor
from #YetMoreTaxonomyLeavesWeNeedToCreate as tltc



/*
select * from  #YetMoreTaxonomyLeavesWeNeedToCreate


begin tran

select * from Reclamation.CostAuthority where TaxonomyLeafID is null

-- At last, we can attempt to fill in the missing ~18 TaxonomyLeafIDs for these CostAuthorities
update Reclamation.CostAuthority
set TaxonomyLeafID = (select tl.TaxonomyLeafID from TaxonomyLeaf as tl where tl.TaxonomyLeafName like Authority + '.' + Job + '%')
where Reclamation.CostAuthority.TaxonomyLeafID is null

-- ^^ Not working, try again

update
    rca
set 
    rca.TaxonomyLeafID = tl.TaxonomyLeafID
from 
    Reclamation.CostAuthority as rca
    inner join dbo.TaxonomyLeaf as tl on  (select SUBSTRING(tl.TaxonomyLeafName, 0, 9) from dbo.TaxonomyLeaf as tl where tl.TenantID = 12) = (rca.Authority + '.' + rca.Job)
    where tl.TenantID = 12
    and
    rca.TaxonomyLeafID is null

select *
from 
    Reclamation.CostAuthority as rca
    inner join dbo.TaxonomyLeaf as tl on (select SUBSTRING(tl.TaxonomyLeafName, 0, 9) from dbo.TaxonomyLeaf as tl where tl.TenantID = 12) = (rca.Authority + '.' + rca.Job)
    where tl.TenantID = 12
    and
    rca.TaxonomyLeafID is null
*/

-- Splayed matcher driven update
update
    rca
set 
    rca.TaxonomyLeafID = splay.TaxonomyLeafID
from
    Reclamation.CostAuthority as rca
    inner join
    (
        -- Splay out the choices
        select rca.CostAuthorityID,
               tl.TaxonomyLeafID,
               (rca.Authority + '.' + rca.Job) as RcaSide,
               SUBSTRING(tl.TaxonomyLeafName, 0, 9) as TaxonomySide
               --*
        from 
            Reclamation.CostAuthority as rca
            join dbo.TaxonomyLeaf as tl on SUBSTRING(tl.TaxonomyLeafName, 0, 9) =  (rca.Authority + '.' + rca.Job)
        where
            rca.TaxonomyLeafID is null
        --order by 
        --  rca.CostAuthorityID, tl.TaxonomyLeafID
    ) as splay on (rca.Authority + '.' + rca.Job) = splay.RcaSide
    where rca.TaxonomyLeafID is null

-- At last, we can lock this down
alter table Reclamation.CostAuthority
alter column TaxonomyLeafID int not null
GO


/*
select * from dbo.TaxonomyLeaf where TaxonomyL

select *
from 
    Reclamation.CostAuthority as rca
    inner join dbo.TaxonomyLeaf as tl on (select SUBSTRING(tl.TaxonomyLeafName, 0, 9) from dbo.TaxonomyLeaf as tl where tl.TenantID = 12) = (rca.Authority + '.' + rca.Job)
    where tl.TenantID = 12
    and
    rca.TaxonomyLeafID is null
    and  SUBSTRING(tl.TaxonomyLeafName, 0, 9) not in ('6921.200','6922.100','6921.100')

-- So yeah we have overlaps. Can we punt for just a second on them?





    select SUBSTRING(tl.TaxonomyLeafName, 0, 9) from dbo.TaxonomyLeaf as tl where TenantID = 12

    select * 
    from Reclamation.CostAuthority as rca
    where (rca.Authority + '.' + rca.Job) = '6950.100'
    and rca.TaxonomyLeafID is null


    select * from dbo.TaxonomyLeaf as tl
    where TenantID = 12
    and tl.TaxonomyLeafID is null
    and SUBSTRING(tl.TaxonomyLeafName, 0, 9) = '6950.100'

    -- 6950	100


select * from Reclamation.CostAuthority where TaxonomyLeafID is null
select * from dbo.TaxonomyLeaf where TenantID = 12

rollback tran

--select * from Reclamation.CostAuthority where TaxonomyLeafID is null
*/

/*
-- Problematic, duplicate leaves. We need to consolidate these.
select  substring(tl.TaxonomyLeafName, 0, 9) as AuthorityJob,
        count(*) as AuthorityJobCount
from dbo.TaxonomyLeaf as tl
where TenantID = 12 
group by  substring(tl.TaxonomyLeafName, 0, 9) 
having count(*) > 1
order by count(*) desc
*/



/*
select
    pcawbs.TaxonomyPrefix,
    substring(pcawbs.TaxonomyPrefix, 1, 4) as TaxonomyBranch
from 
    #ProjectsWithCawbs as pcawbs
where
    pcawbs.TaxonomyPrefix is not null
    and substring(pcawbs.TaxonomyPrefix, 1, 4) not in ( select left(tb.TaxonomyBranchName, 4) from dbo.TaxonomyBranch as tb where tb.TenantID = 12 )
*/
) as y






/*
ALTER TABLE dbo.TaxonomyLeaf
ADD ReclamationAuthorityJobComputedForAK_NEW2 AS (CASE WHEN ReclamationAuthorityJob IS NULL THEN CAST('PK_' + CAST(TaxonomyLeafID AS NVARCHAR(10)) as NVARCHAR(MAX)) ELSE 'RAJ:' + ReclamationAuthorityJob + '_' + 'TEN:' + CAST(TenantID AS NVARCHAR(10)) END) PERSISTED;

select * from dbo.TaxonomyLeaf
where ReclamationAuthorityJob is not null

ALTER  TABLE  dbo.TaxonomyLeaf WITH CHECK 
ADD CONSTRAINT UQ_TaxonomyLeaf_ReclamationAuthorityJobComputedForAK_NEW UNIQUE (ReclamationAuthorityJobComputedForAK_NEW2)

CREATE UNIQUE INDEX TEST_UQ_IND_1 ON TaxonomyLeaf (ReclamationAuthorityJobComputedForAK_NEW2)

CREATE NONCLUSTERED INDEX IX_CompanyEmployees_BirthMonth
ON dbo.TaxonomyLeaf (ReclamationAuthorityJobComputedForAK_NEW2)
GO
 


/****** Object:  Index [AK_TaxonomyLeaf_TaxonomyLeafID_TenantID]    Script Date: 4/2/2020 9:34:18 AM ******/
ALTER TABLE [dbo].[TaxonomyLeaf] ADD  CONSTRAINT [AK_TaxonomyLeaf_ReclamationAuthorityJobComputedForAK_NEW] UNIQUE NONCLUSTERED 
(
    ReclamationAuthorityJobComputedForAK_NEW ASC
) ON [PRIMARY]
GO

/****** Object:  Index [AK_TaxonomyLeaf_TaxonomyLeafID_TenantID]    Script Date: 4/2/2020 9:34:18 AM ******/
ALTER TABLE [dbo].[TaxonomyLeaf] ADD  CONSTRAINT [AK_TaxonomyLeaf_ReclamationAuthorityJob_TenantID] UNIQUE NONCLUSTERED 
(
    ReclamationAuthorityJobComputedForAK_NEW ASC,
    [TenantID] ASC
) ON [PRIMARY]
GO

*/



select * from dbo.TaxonomyLeaf
where TenantID = 12








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