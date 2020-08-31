 --begin tran
 
 
 alter table dbo.GeospatialAreaType 
 add IsPopulation bit null;
 
 go

 update dbo.GeospatialAreaType
 set IsPopulation = 0;

 go

 update dbo.GeospatialAreaType
 set IsPopulation = 1 where GeospatialAreaTypeID in (23, 24);

 go

 alter table dbo.GeospatialAreaType
 alter column IsPopulation bit not null;

 go
 --rollback tran