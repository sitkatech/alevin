delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, FiscalYearStartDate, UseFiscalYears, ArePerformanceMeasuresExternallySourced, AreOrganizationsExternallySourced, AreFundingSourcesExternallySourced, TenantEnabled)
values 
(1, 'SitkaTechnologyGroup', 'sitka.localhost.projectfirma.com', 'sitka.qa.projectfirma.com', 'sitka.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 1),
(2, 'ClackamasPartnership', 'clackamaspartnership.localhost.projectfirma.com', 'qa.clackamaspartnership.org', 'www.clackamaspartnership.org', '1/1/1990', 0, 0, 0, 0, 1),
(3, 'RCDProjectTracker', 'rcdprojects.localhost.projectfirma.com', 'qa.rcdprojects.org', 'www.rcdprojects.org', '1/1/1990', 0, 0, 0, 0, 1),
(4, 'NCRPProjectTracker', 'ncrp.localhost.projectfirma.com', 'qa.northcoastresourcepartnershipprojects.org', 'www.northcoastresourcepartnershipprojects.org', '1/1/1990', 0, 0, 0, 0, 1),
(5, 'DemoProjectFirma', 'demo.localhost.projectfirma.com', 'demo.qa.projectfirma.com', 'demo.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 1),
(6, 'PeaksToPeople', 'peakstopeople.localhost.projectfirma.com', 'qa-outcomes.peakstopeople.org', 'outcomes.peakstopeople.org', '1/1/1990', 0, 0, 0, 0, 0),
(7, 'JohnDayBasinPartnership', 'johndaybasinpartnership.localhost.projectfirma.com', 'qa.johndaybasinpartnership.org', 'www.johndaybasinpartnership.org', '1/1/1990', 0, 0, 0, 0, 1),
(8, 'AshlandForestAllLandsRestorationInitiative', 'ashlanddemo.localhost.projectfirma.com', 'ashlanddemo.qa.projectfirma.com', 'ashlanddemo.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 0),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'swcdemo.localhost.projectfirma.com', 'swcdemo.qa.projectfirma.com', 'conservation.idaho.gov', '7/1/1990', 1, 0, 0, 0, 0),
(11, 'ActionAgendaForPugetSound', 'actionagendatracker.localhost.projectfirma.com', 'qa-actionagendatracker.pugetsoundinfo.wa.gov', 'actionagendatracker.pugetsoundinfo.wa.gov', '1/1/1990', 0, 1, 1, 1, 0),
-- This will work until the inevitable vanity URLs arrive:
(12, 'BureauOfReclamation', 'bor.localhost.projectfirma.com', 'bor.qa.projectfirma.com', 'ibrmazap001.bor.doi.net', '1990-10-01 00:00:00.000', 1, 0, 0, 0, 1),
(13, 'SSMPProjectTracker', 'SaltonSeaProjects.localhost.projectfirma.com', 'SaltonSeaProjects.qa.projectfirma.com', 'projects.saltonsea.ca.gov', '1/1/1990', 0, 0, 0, 0, 1),
(14, 'TCSProjectTracker', 'tcsprojecttracker.localhost.projectfirma.com', 'tcsprojecttracker.qa.projectfirma.com', 'projecttracker.tahoecentralsierra.org', '1/1/1990', 0, 0, 0, 0, 1)
