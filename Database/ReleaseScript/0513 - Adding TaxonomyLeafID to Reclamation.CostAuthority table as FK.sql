begin tran

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

update Reclamation.CostAuthority
set TaxonomyLeafID = tl.TaxonomyLeafID
from dbo.TaxonomyLeaf as tl 
inner join Reclamation.CostAuthority as ca on substring(tl.TaxonomyLeafName, 1, 8) = (ca.Authority + '.' + ca.Job)
where tl.TenantID = 12

select * from Reclamation.CostAuthority where TaxonomyLeafID is null

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