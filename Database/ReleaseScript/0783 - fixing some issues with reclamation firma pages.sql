
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(91, 'ProgressDashboardIntro', 'Progress Dashboard Intro', 1),
(92, 'ProgressDashboardAcresConstructedByTheNumbers', 'Acres Constructed By The Numbers', 1),
(93, 'ProgressDashboardAcresConstructedPieCharts', 'Acres Constructed Pie Charts', 1)






insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values (12,91) --Could Not find Firma Page Type 'ProgressDashboardIntro'(91) in Firma Pages for Tenant BureauOfReclamation(12)
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values (12,92) --Could Not find Firma Page Type 'ProgressDashboardAcresConstructedByTheNumbers'(92) in Firma Pages for Tenant BureauOfReclamation(12)
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values (12,93) --Could Not find Firma Page Type 'ProgressDashboardAcresConstructedPieCharts'(93) in Firma Pages for Tenant BureauOfReclamation(12)





--exec sp_rename 'dbo.FK__ExternalM__MapLe__3A8349D5', 'FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_FileResourceInfoID', 'OBJECT'
--exec sp_rename 'dbo.FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID', 'FK_ExternalMapLayer_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID_FileResourceInfoID_TenantID', 'OBJECT'
--exec sp_rename 'dbo.FK__Geospatia__MapLe__3B776E0E', 'FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_FileResourceInfoID', 'OBJECT'
--exec sp_rename 'dbo.FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID', 'FK_GeospatialAreaType_FileResourceInfo_MapLegendImageFileResourceInfoID_TenantID_FileResourceInfoID_TenantID', 'OBJECT'