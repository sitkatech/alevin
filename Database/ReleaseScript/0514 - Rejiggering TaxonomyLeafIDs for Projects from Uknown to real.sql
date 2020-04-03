

-- More important than those dupes though, is the long list of unknowns we can migrate elsewhere.


--select * from Reclamation.CostAuthority as rca where rca.TaxonomyLeafID = 2680

-- Potential projects to move to other TaxonomyLeaves
select p.*
from dbo.Project as p
where p.TenantID = 12
and p.TaxonomyLeafID = 2680

/*

    case when y.Job = '120' then y.MissingTaxonomyPrefix + ' Subbasin Service Contracts'
         when y.Job = '130' then y.MissingTaxonomyPrefix + ' Technical Site Visit'
         when y.Job = '140' then y.MissingTaxonomyPrefix + ' Reimbursable Service Agreement Team Coordination'

*/

-- Set up temp table to represent known mappings of Projects we previously assigned to Unknown TaxonomyLeaves. 
-- Devin prompted us to fix these up.
IF OBJECT_ID('tempdb..#ProjectNamePrefixToTaxonomyLeafNamePrefixMap') IS NOT NULL DROP table #ProjectNamePrefixToTaxonomyLeafNamePrefixMap

CREATE TABLE #ProjectNamePrefixToTaxonomyLeafNamePrefixMap
(
    TaxonomyLeafNamePrefix nvarchar(max),
    ProjectNamePrefix nvarchar(max),
    TaxonomyLeafID int null,
);

insert into #ProjectNamePrefixToTaxonomyLeafNamePrefixMap(TaxonomyLeafNamePrefix, ProjectNamePrefix)
values
('6814.200', 'Entiat Flow'),
('6814.300', 'Entiat Screen'),
('6814.400', 'Entiat Barrier'),
('6814.500', 'Entiat Geom'),

('6808.200', 'Grand Ronde Flow'),
('6808.300', 'Grand Ronde Screen'),
('6808.400', 'Grand Ronde Barrier'),
('6808.500', 'Grand Ronde Geom'),

-- Handle alternate spelling of Grand Ronde..
('6808.200', 'Grande Ronde Flow'),
('6808.300', 'Grande Ronde Screen'),
('6808.400', 'Grande Ronde Barrier'),
('6808.500', 'Grande Ronde Geom'),

('6810.200', 'Imnaha Flow'),
('6810.300', 'Imnaha Screen'),
('6810.400', 'Imnaha Barrier'),
('6810.500', 'Imnaha Geom'),

('6801.200', 'Lemhi Flow'),
('6801.300', 'Lemhi Screen'),
('6801.400', 'Lemhi Barrier'),
('6801.500', 'Lemhi Geom'),

('6804.200', 'Little Salmon Flow'),
('6804.300', 'Little Salmon Screen'),
('6804.400', 'Little Salmon Barrier'),
('6804.500', 'Little Salmon Geom'),

-- Middle Fork John Day
('6806.200', 'M F J D Flow'),
('6806.300', 'M F J D Screen'),
('6806.400', 'M F J D Barrier'),
('6806.500', 'M F J D Geom'),

('6806.200', 'Middle Fork John Day Flow'),
('6806.300', 'Middle Fork John Day Screen'),
('6806.400', 'Middle Fork John Day Barrier'),
('6806.500', 'Middle Fork John Day Geom'),

-- North Fork John Day 
('6805.200', 'N F J D Flow'),
('6805.300', 'N F J D Screen'),
('6805.400', 'N F J D Barrier'),
('6805.500', 'N F J D Geom'),

('6805.200', 'North Fork John Day Flow'),
('6805.300', 'North Fork John Day Screen'),
('6805.400', 'North Fork John Day Barrier'),
('6805.500', 'North Fork John Day Geom'),

-- Upper Middle John Day 
('6807.200', 'U M J D Flow'),
('6807.300', 'U M J D Screen'),
('6807.400', 'U M J D Barrier'),
('6807.500', 'U M J D Geom'),

('6807.200', 'Upper Middle John Day Flow'),
('6807.300', 'Upper Middle John Day Screen'),
('6807.400', 'Upper Middle John Day Barrier'),
('6807.500', 'Upper Middle John Day Geom'),

-- Upper Salmon
('6802.200', 'Upper Salmon Flow'),
('6802.300', 'Upper Salmon Screen'),
('6802.400', 'Upper Salmon Barrier'),
('6802.500', 'Upper Salmon Geom'),

('6802.200', 'Upper Main Salmon Flow'),
('6802.300', 'Upper Main Salmon Screen'),
('6802.400', 'Upper Main Salmon Barrier'),
('6802.500', 'Upper Main Salmon Geom'),

('6813.200', 'Wenatchee Flow'),
('6813.300', 'Wenatchee Screen'),
('6813.400', 'Wenatchee Barrier'),
('6813.500', 'Wenatchee Geom'),

('6812.200', 'Methow Flow'),
('6812.300', 'Methow Screen'),
('6812.400', 'Methow Barrier'),
('6812.500', 'Methow Geom'),

('6811.200', 'Pashimeroi Flow'),
('6811.300', 'Pashimeroi Screen'),
('6811.400', 'Pashimeroi Barrier'),
('6811.500', 'Pashimeroi Geom'),

-- Alternate spelling of Pashimerioi
('6811.200', 'Pahsimeroi Flow'),
('6811.300', 'Pahsimeroi Screen'),
('6811.400', 'Pahsimeroi Barrier'),
('6811.500', 'Pahsimeroi Geom')

-- Complete the mapping by filling in the TaxonomyLeaf IDs
update
    pm
set 
    pm.TaxonomyLeafID = tl.TaxonomyLeafID
from 
    #ProjectNamePrefixToTaxonomyLeafNamePrefixMap as pm
    inner join dbo.TaxonomyLeaf as tl on pm.TaxonomyLeafNamePrefix = SUBSTRING(tl.TaxonomyLeafName,0,10)
where
    tl.TaxonomyLeafID != 2680 -- Just in case I screw up

--select * from #ProjectNamePrefixToTaxonomyLeafNamePrefixMap

-- Use the mapping to re-jigger our ProjectFirma mappings
update
    p
set
    p.TaxonomyLeafID = pm.TaxonomyLeafID
from
    dbo.Project as p
    inner join #ProjectNamePrefixToTaxonomyLeafNamePrefixMap as pm on p.ProjectName like pm.ProjectNamePrefix + '%'



-- What's left?
select p.*
from dbo.Project as p
where p.TenantID = 12
and p.TaxonomyLeafID = 2680


/*
-- For testing the above update

select *
from
    dbo.Project as p
    inner join #ProjectNamePrefixToTaxonomyLeafNamePrefixMap as pm on p.ProjectName like pm.ProjectNamePrefix + '%'

-- Why aren't we seeing Grand Ronde flow?
select * from dbo.Project as p where p.ProjectName like 'Grand
*/


/*
select * 
from
    dbo.Project as p
    inner join #ProjectNamePrefixToTaxonomyLeafNamePrefixMap as pm on p.ProjectName like pm.ProjectNamePrefix + '%'
where
    p.TenantID = 12
    and
    p.TaxonomyLeafID = 2680 -- xxx.xxxx 'Unknown'



select p.*
from dbo.Project as p
where p.TenantID = 12
and p.TaxonomyLeafID = 2680
and p.ProjectName like 'Entiat Flow%' -- 6814.200

select * from dbo.TaxonomyLeaf where SUBSTRING(TaxonomyLeafName,0,10) = '6814.200' and TenantID = 12
*/


