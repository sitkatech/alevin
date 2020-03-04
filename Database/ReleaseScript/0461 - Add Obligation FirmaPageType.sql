
--select * from dbo.FirmaPageType

--select * from dbo.FirmaPage

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values(10008, 'ObligationList', 'Obligation List', 1)

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values
(12, 10008, null)

--select * from FirmaPageRenderType

--select * from dbo.Tenant