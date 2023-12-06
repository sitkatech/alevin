
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(91, 'ProgressDashboardIntro', 'Progress Dashboard Intro', 1),
(92, 'ProgressDashboardAcresConstructedByTheNumbers', 'Acres Constructed By The Numbers', 1),
(93, 'ProgressDashboardAcresConstructedPieCharts', 'Acres Constructed Pie Charts', 1)






insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values (12,91) --Could Not find Firma Page Type 'ProgressDashboardIntro'(91) in Firma Pages for Tenant BureauOfReclamation(12)
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values (12,92) --Could Not find Firma Page Type 'ProgressDashboardAcresConstructedByTheNumbers'(92) in Firma Pages for Tenant BureauOfReclamation(12)
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) values (12,93) --Could Not find Firma Page Type 'ProgressDashboardAcresConstructedPieCharts'(93) in Firma Pages for Tenant BureauOfReclamation(12)