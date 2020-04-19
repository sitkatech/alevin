DROP TABLE IF EXISTS #ProjectCostAuthorityTaxonomyLeafTemp
GO

create table #ProjectCostAuthorityTaxonomyLeafTemp
(
  ProjectName varchar(max) not null,
  CostAuthorityWorkBreakdownStructure varchar(max) not null,
  ProjectID int null,
  CostAuthorityID int null,
  TaxonomyLeafID int null
);
GO

insert into #ProjectCostAuthorityTaxonomyLeafTemp(ProjectName, CostAuthorityWorkBreakdownStructure)
values
('Coordination Hydro Operations Tech Services', 'RX.16786911.2000100'),
('Entiat General Subbasin Service Contract', 'RX.16786814.1200000'),
('FWS FCRPS BiOp HH Ramping Rate', 'RX.16786960.1002000'),
('Grande Ronde Gen Sub Serv Contracts', 'RX.16786808.1200000'),
('Hydrology Water Mgmt Plan Forecasting', 'RX.16786921.1100000'),
('Methow Barr Frazier Creek Culverts', 'RX.16786812.4001700'),
('Methow General Subbasin Service Contracts', 'RX.16786812.1200000'),
('Pahsimeroi General Subbasin Service Contracts', 'RX.16786811.1200000'),
('UMJD Barr Lower McHaley Diversion', 'RX.16786807.4007300'),
('Upper Salmon Barr Garden Creek Bridge', 'RX.16786802.4001900'),
('Upper Salmon Barr Garden Creek Flume', 'RX.16786802.4001800'),
('y Reimbursable BPA Joe Spinazola Detail', 'A1R167868214000000'),
('Y Reimbursable BPA Middle Entiat', 'RX.16786821.5000000'),
('y Reimbursable FWS Entiat nat fish hatchry', 'A1R167868221000000'),
('y Reimbursable WA ST MVID R13MR10705', 'A1R167868121300000')

update pcat
set
    ProjectID = p.ProjectID
from #ProjectCostAuthorityTaxonomyLeafTemp as pcat
inner join dbo.Project as p on pcat.ProjectName = p.ProjectName

update pcat
set
    CostAuthorityID = rca.CostAuthorityID,
    TaxonomyLeafID = rca.TaxonomyLeafID
from #ProjectCostAuthorityTaxonomyLeafTemp as pcat
inner join Reclamation.CostAuthority as rca on pcat.CostAuthorityWorkBreakdownStructure = rca.CostAuthorityWorkBreakdownStructure

-- This doesn't fix everything - still 6 records whose CAWBS are unknown to us.
update p
set 
    TaxonomyLeafID = pcat.TaxonomyLeafID
from dbo.Project as p
inner join #ProjectCostAuthorityTaxonomyLeafTemp as pcat on p.ProjectID = pcat.ProjectID
where pcat.TaxonomyLeafID is not null

-- These are the missing CAWBS we've never encountered before, and would need definitions to add.
-- We'll have to get back to these
/*
select * from #ProjectCostAuthorityTaxonomyLeafTemp
where CostAuthorityID is  null
*/
