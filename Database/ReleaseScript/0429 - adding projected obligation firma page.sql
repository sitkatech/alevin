insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(10004, 'AddCostAuthorityToAgreementRequest', 'Add one or many CAWBS and their projected obligations to this Agreement Request.', 2)



insert into dbo.FirmaPage(TenantID,FirmaPageTypeID, FirmaPageContent)
values(12,10004, 'Add one or many CAWBS and their projected obligations to this Agreement Request.')