-- Because the release scripts are run before the lookup tables we 
-- need to also add the new firma page types here in order to build successfully - SMG
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(62, 'AgreementList', 'Agreement List', 1),
(63, 'CostAuthorityList', 'Cost Authority List', 1)


insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(12, 62, 'blah')