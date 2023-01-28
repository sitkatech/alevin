insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(10014, 'SubprojectActionItemEditDialog', 'Subproject Action Item Edit Dialog', 2)

insert into dbo.FirmaPage (FirmaPageTypeID, TenantID,  FirmaPageContent)
values( 10014, 12, '')