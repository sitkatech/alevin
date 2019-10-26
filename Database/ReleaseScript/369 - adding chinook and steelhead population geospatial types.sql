--select * from dbo.tmpFishProject2PopulationDissolve





insert into dbo.GeospatialAreaType (TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, MapServiceUrl, GeospatialAreaLayerName)
values (12, 'Chinook, Salmon Population', 'Chinook, Salmon Populations', '<p>Below are the population spatial areas for Chinook salmon.</p>', 
	CASE @@SERVERNAME  
		WHEN 'kettle' THEN 'https://bor-qa-mapserver.projectfirma.com/geoserver/Reclamation/wms'
		WHEN 'deschutes' THEN 'https://bor-mapserver.projectfirma.com/geoserver/Reclamation/wms'  
		ELSE 'https://bor-localhost-mapserver.projectfirma.com/geoserver/Reclamation/wms'  
	END
	, 'Reclamation:ChinookPopulation');


insert into dbo.GeospatialArea (TenantID, GeospatialAreaTypeID, GeospatialAreaName, GeospatialAreaFeature)
select
	12 as TenantID,
	(select GeospatialAreaTypeID from dbo.GeospatialAreaType where GeospatialAreaLayerName = 'Reclamation:ChinookPopulation') as GeospatialAreaTypeID,
	concat(SUBSTRING(fp.DPS, CHARINDEX('(', fp.DPS) + 1, CHARINDEX(')', fp.DPS) - CHARINDEX('(', fp.DPS) - 1), ' - ', fp.[POPULATION], ' - ', CASE fp.RUN_TIMING  
																																					WHEN 'fa' THEN 'Fall'
																																					WHEN 'lf' THEN 'Late Fall'  
																																					WHEN 'su' THEN 'Summer'  
																																					WHEN 'sp' THEN 'Spring'  
																																					WHEN 'ss' THEN 'Spring/Summer'
																																					WHEN 'wi' THEN 'Winter'
																																					WHEN 'sw' THEN 'Spring/Winter' 
																																					ELSE fp.RUN_TIMING  
																																				END) as GeospatialAreaName,
	fp.GEOM as GeospatialAreaFeature
from
	dbo.tmpFishProject2PopulationDissolve as fp
where
	fp.DPS like '%chinook%' and fp.DPS not like '%outside legal area%' and fp.[POPULATION] is not null and fp.[STATUS] = 'EX' and fp.RUN_TIMING is not null





insert into dbo.GeospatialAreaType (TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, MapServiceUrl, GeospatialAreaLayerName)
values (12, 'Steelhead Population', 'Steelhead Populations', '<p>Below are the population spatial areas for Steelhead.</p>', 
	CASE @@SERVERNAME  
		WHEN 'kettle' THEN 'https://bor-qa-mapserver.projectfirma.com/geoserver/Reclamation/wms'
		WHEN 'deschutes' THEN 'https://bor-mapserver.projectfirma.com/geoserver/Reclamation/wms'  
		ELSE 'https://bor-localhost-mapserver.projectfirma.com/geoserver/Reclamation/wms'  
	END
	, 'Reclamation:SteelheadPopulation');


insert into dbo.GeospatialArea (TenantID, GeospatialAreaTypeID, GeospatialAreaName, GeospatialAreaFeature)
select
	12 as TenantID,
	(select GeospatialAreaTypeID from dbo.GeospatialAreaType where GeospatialAreaLayerName = 'Reclamation:SteelheadPopulation') as GeospatialAreaTypeID,
	concat(SUBSTRING(fp.DPS, CHARINDEX('(', fp.DPS) + 1, CHARINDEX(')', fp.DPS) - CHARINDEX('(', fp.DPS) - 1), ' - ', fp.[POPULATION], ' - ', CASE fp.RUN_TIMING  
																																					WHEN 'fa' THEN 'Fall'
																																					WHEN 'lf' THEN 'Late Fall'  
																																					WHEN 'su' THEN 'Summer'  
																																					WHEN 'sp' THEN 'Spring'  
																																					WHEN 'ss' THEN 'Spring/Summer'
																																					WHEN 'wi' THEN 'Winter'
																																					WHEN 'sw' THEN 'Spring/Winter' 
																																					ELSE fp.RUN_TIMING  
																																				END) as GeospatialAreaName,
	fp.GEOM as GeospatialAreaFeature
from
	dbo.tmpFishProject2PopulationDissolve as fp
where
	fp.DPS like '%steelhead%' and fp.DPS not like '%outside legal area%' and fp.[POPULATION] is not null and fp.[STATUS] = 'EX' and fp.RUN_TIMING is not null



