--begin tran

alter table dbo.GeospatialAreaType add constraint FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID_TenantID foreign key (EsuDpsGeospatialAreaTypeID, TenantID) references dbo.GeospatialAreaType(GeospatialAreaTypeID, TenantID)
go

alter table dbo.GeospatialAreaType add constraint FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID_TenantID foreign key (MPGGeospatialAreaTypeID, TenantID) references dbo.GeospatialAreaType(GeospatialAreaTypeID, TenantID)
go

alter table dbo.GeospatialAreaType add constraint FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID_TenantID foreign key (PopulationGeospatialAreaTypeID, TenantID) references dbo.GeospatialAreaType(GeospatialAreaTypeID, TenantID)
go
--rollback tran