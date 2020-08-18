
/*
select * from dbo.GeospatialArea
where TenantID = 12 and GeospatialAreaTypeID in (select GeospatialAreaTypeID from dbo.GeospatialAreaType where GeospatialAreaTypeName in ('Steelhead MPG', 'Chinook, Salmon MPG'))
*/


update dbo.GeospatialArea
set GeospatialAreaShortName = GeospatialAreaName
where TenantID = 12 and GeospatialAreaTypeID in (select GeospatialAreaTypeID from dbo.GeospatialAreaType where GeospatialAreaTypeName in ('Steelhead MPG', 'Chinook, Salmon MPG'))


