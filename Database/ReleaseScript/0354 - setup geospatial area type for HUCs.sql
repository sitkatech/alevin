


--select * from dbo.GeospatialAreaType

--select * from dbo.GeospatialArea

--select top 100 * from dbo.tmpHydrologic_Project

--select * from dbo.Tenant
--where TenantID = 12

drop table dbo.tmpHydrologic_Project
go

insert into dbo.GeospatialAreaType(TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, GeospatialAreaTypeDefinition, MapServiceUrl, GeospatialAreaLayerName)
values (12, 'Watershed', 'Watersheds', '<p>Below are all the HUC (12 digit) watersheds</p>', null, 'https://bor-localhost-mapserver.projectfirma.com/geoserver/Reclamation/wms', 'Reclamation:Watershed')

GO

INSERT INTO dbo.GeospatialArea (TenantID, GeospatialAreaName, GeospatialAreaFeature, GeospatialAreaTypeID)  
    SELECT 
			12 as TenantID,
			concat(huc.[Name], ' - ', huc.HUC12) as GeospatialAreaName,
			huc.GEOM as GeospatialAreaFeature,
			(select GeospatialAreaTypeID from dbo.GeospatialAreaType where TenantID = 12 and GeospatialAreaTypeName = 'Watershed') as GeospatialAreaTypeID
    FROM 
		dbo.tmpHuc12 as huc

	