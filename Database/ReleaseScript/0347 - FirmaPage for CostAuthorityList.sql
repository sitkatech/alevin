--select * from dbo.FirmaPageType

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values(66, 'CostAuthorityList', 'Cost Authority List', 1)
GO


insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
values (12, 66, null)

