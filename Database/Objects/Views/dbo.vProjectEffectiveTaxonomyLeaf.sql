if exists (select * from dbo.sysobjects where id = object_id('dbo.vProjectEffectiveTaxonomyLeaf'))
    drop view dbo.vProjectEffectiveTaxonomyLeaf
go

create view dbo.vProjectEffectiveTaxonomyLeaf
as
select p.ProjectID,
       p.ProjectID as PrimaryKey,
       tl.TaxonomyLeafID as tlTaxLeafID,
       ca.TaxonomyLeafID as caTaxLeafID,
       coalesce(tl.TaxonomyLeafID, ca.TaxonomyLeafID) as EffectiveTaxonomyLeafID
from dbo.Project p
left join dbo.TaxonomyLeaf as tl on p.OverrideTaxonomyLeafID = tl.TaxonomyLeafID
left join Reclamation.CostAuthorityProject as cap on p.ProjectID = cap.ProjectID
left join Reclamation.CostAuthority as ca on cap.CostAuthorityID = ca.CostAuthorityID
where
tl.TaxonomyLeafID is not null
or
cap.IsPrimaryProjectCawbs = 1

go

/*

select * from dbo.vProjectEffectiveTaxonomyLeaf
order by ProjectID

select * from dbo.vProjectEffectiveTaxonomyLeaf
where ProjectID = 13698

select * from dbo.Project

*/