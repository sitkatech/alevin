insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(10007, 'UploadBudgetAndInvoiceExcel', 'Upload Budget And Invoice Excel', 1)


insert into dbo.FirmaPage(TenantID,FirmaPageTypeID, FirmaPageContent)
values(12, 10007,'Upload Budget And Invoice Excel')