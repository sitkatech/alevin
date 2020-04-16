

insert into dbo.GeospatialAreaType (TenantID, GeospatialAreaTypeName, GeospatialAreaTypeNamePluralized, GeospatialAreaIntroContent, GeospatialAreaTypeDefinition, GeospatialAreaLayerName)
values (12, 'NPCC Subbasin', 'NPCC Subbasins', '<p>Below are NPCC Subbasins.</p>', NULL, 'Reclamation:NPCCSubbasin')


insert into dbo.NpccProvince(TenantID, NpccProvinceName, NpccProvinceFeature)
select 12, x.name, x.ogr_geometry  from dbo.newprovince x

insert into dbo.GeospatialArea(TenantID, GeospatialAreaName, GeospatialAreaFeature, GeospatialAreaTypeID, GeospatialAreaDescriptionContent)
select 12, x.name, x.ogr_geometry , 25, NULL from dbo.newsubbasin x



insert into dbo.NpccSubbasinProvince(TenantID, SubbasinID, NpccProvinceID)
select 12, ga.GeospatialAreaID, y.NpccProvinceID from 
dbo.GeospatialArea ga
join dbo.newsubbasin x on x.name = ga.GeospatialAreaName
join dbo.NpccProvince y on x.province = y.NpccProvinceName
where ga.GeospatialAreaTypeID = 25

drop table dbo.newprovince
drop table dbo.newsubbasin