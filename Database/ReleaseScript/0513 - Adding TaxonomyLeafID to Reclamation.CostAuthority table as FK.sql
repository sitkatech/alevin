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
-- It turns out that the except doesn't remove anything; everything we care about is covered in the top expression.

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
-- Problematic, duplicate leaves. We need to consolidate these.
select  substring(tl.TaxonomyLeafName, 0, 9) as AuthorityJob,
        count(*) as AuthorityJobCount
from dbo.TaxonomyLeaf as tl
where TenantID = 12 
group by  substring(tl.TaxonomyLeafName, 0, 9) 
having count(*) > 1
order by count(*) desc



-- What do these potentially duplicate leaves look like?
-- Hmm. Unsure exactly what's going on here...
select tl.*
from dbo.TaxonomyLeaf as tl
where substring(tl.TaxonomyLeafName, 0, 9) in ('6921.200', '6922.100', '6921.100')


*/