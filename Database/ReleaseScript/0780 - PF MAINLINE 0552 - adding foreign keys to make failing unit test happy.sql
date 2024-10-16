

alter table dbo.ExternalMapLayer 
add constraint FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID foreign key (MapLegendImageFileResourceInfoID, TenantID) references dbo.FileResourceInfo(FileResourceInfoID, TenantID)


alter table dbo.GeospatialAreaType add constraint FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID foreign key (MapLegendImageFileResourceInfoID, TenantID) references dbo.FileResourceInfo(FileResourceInfoID, TenantID)


alter table dbo.ProjectCustomGridConfiguration add constraint FK_ProjectCustomGridConfiguration_ClassificationSystem_ClassificationSystemID_TenantID foreign key (ClassificationSystemID, TenantID) references dbo.ClassificationSystem(ClassificationSystemID, TenantID)

--exec sp_rename 'dbo.FK__ExternalM__MapLe__5A7B181B', 'FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_FileResourceInfoID', 'OBJECT'

--exec sp_rename 'dbo.FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID', 'FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID_FileResourceInfoID_TenantID', 'OBJECT'

--exec sp_rename 'dbo.FK__Geospatia__MapLe__5B6F3C54', 'FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_FileResourceInfoID', 'OBJECT'

--exec sp_rename 'dbo.FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID', 'FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID_FileResourceInfoID_TenantID', 'OBJECT'

