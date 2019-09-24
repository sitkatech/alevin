


--select * from dbo.GeospatialAreaType

--select * from dbo.GeospatialArea

--select top 100 * from dbo.tmpHydrologic_Project

--select * from dbo.Tenant
--where TenantID = 12

drop table dbo.tmpHydrologic_Project
go

alter table dbo.tmpHuc12 add tmpHuc12ID int not null identity(1,1) constraint PK_tmpHuc12_tmpHuc12ID primary key

declare @hostName varchar(255); 
set @hostName = 
    case 
        when @@SERVERNAME = 'kettle' then 'bor-qa-mapserver.projectfirma.com' 
        when @@SERVERNAME = 'deschutes' then 'bor-mapserver.projectfirma.com'
        else 'bor-localhost-mapserver.projectfirma.com' 
    end;

insert into dbo.GeospatialAreaType(TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, GeospatialAreaTypeDefinition, MapServiceUrl, GeospatialAreaLayerName)
values (12, 'Watershed', 'Watersheds', '<p>Below are all the HUC (12 digit) watersheds</p>', null, 'https://' + @hostName + '/geoserver/Reclamation/wms', 'Reclamation:Watershed')

GO

INSERT INTO dbo.GeospatialArea (TenantID, GeospatialAreaName, GeospatialAreaFeature, GeospatialAreaTypeID)  
    SELECT 
			12 as TenantID,
			concat(huc.[Name], ' - ', huc.HUC12) as GeospatialAreaName,
			huc.GEOM as GeospatialAreaFeature,
			(select GeospatialAreaTypeID from dbo.GeospatialAreaType where TenantID = 12 and GeospatialAreaTypeName = 'Watershed') as GeospatialAreaTypeID
    FROM 
		dbo.tmpHuc12 as huc
