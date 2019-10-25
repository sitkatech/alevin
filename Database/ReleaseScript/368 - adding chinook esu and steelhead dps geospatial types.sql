/*
--10393 total rows
select * from dbo.tmpFishProject1


--5214 distinct HUCs
select distinct hydrologic_HUC_12 from dbo.tmpFishProject1

--4269 distinct HUC names
select distinct hydrologic_HU_12_Name from dbo.tmpFishProject1

--
select distinct hydrologic_HUC_12, DPS from dbo.tmpFishProject1




select * from  dbo.tmpFishProject1 where DPS like '%chinook%'

select * from dbo.GeospatialAreaType 


alter table dbo.tmpFishProject1 
add tmpFishProject1ID int not null identity(1,1) constraint PK_tmpFishProject1_OBJECTID primary key 

alter table dbo.tmpFishProject2Dissolve 
add tmpFishProject2DissolveID int not null identity(1,1) constraint PK_tmpFishProject2Dissolve_tmpFishProject2DissolveID primary key

*/

exec sp_rename 'PK_tmpFishProject1_OBJECTID', 'PK_tmpFishProject1_tmpFishProject1ID', 'OBJECT'

insert into dbo.GeospatialAreaType (TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, MapServiceUrl, GeospatialAreaLayerName)
values (12, 'Chinook, Salmon ESU', 'Chinook, Salmon ESU', '<p>Below are the evolutionarily significant units(ESU) for Chinook salmon.</p>', 'https://bor-localhost-mapserver.projectfirma.com/geoserver/Reclamation/wms', 'Reclamation:ChinookESU');


insert into dbo.GeospatialArea (TenantID, GeospatialAreaTypeID, GeospatialAreaName, GeospatialAreaFeature)
select
	12 as TenantID,
	(select GeospatialAreaTypeID from dbo.GeospatialAreaType where GeospatialAreaLayerName = 'Reclamation:ChinookESU') as GeospatialAreaTypeID,
	fp.DPS as GeospatialAreaName,
	fp.GEOM as GeospatialAreaFeature
from
	dbo.tmpFishProject2Dissolve as fp
where
	fp.DPS like '%chinook%' and fp.DPS not like '%outside legal area%'




insert into dbo.GeospatialAreaType (TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, MapServiceUrl, GeospatialAreaLayerName)
values (12, 'Steelhead DPS', 'Steelhead DPS', '<p>Below are the distinct population segments(DPS) for Steelhead.</p>', 'https://bor-localhost-mapserver.projectfirma.com/geoserver/Reclamation/wms', 'Reclamation:SteelheadDPS');


insert into dbo.GeospatialArea (TenantID, GeospatialAreaTypeID, GeospatialAreaName, GeospatialAreaFeature)
select
	12 as TenantID,
	(select GeospatialAreaTypeID from dbo.GeospatialAreaType where GeospatialAreaLayerName = 'Reclamation:SteelheadDPS') as GeospatialAreaTypeID,
	fp.DPS as GeospatialAreaName,
	fp.GEOM as GeospatialAreaFeature
from
	dbo.tmpFishProject2Dissolve as fp
where
	fp.DPS like '%steelhead%' and fp.DPS not like '%outside legal area%'

