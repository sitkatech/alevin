--select * from dbo.FirmaPageType

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values(65, 'AgreementList', 'Agremeement List', 1)
GO

-- AgreementList
insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values (12, 65, null)
GO

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values(66, 'CostAuthorityList', 'Cost Authority List', 1)
GO

-- Cost Authority
insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values (12, 66, null)




--select * from dbo.FirmPage