declare @agreementListDummy int = 22222;
declare @agreementListOriginal int = 65;
declare @agreementListNew int = 10000;

declare @costAuthorityListDummy int = 33333;

declare @attrGroupInstructionsDummy int = 44444;

declare @attrGroupListDummy int = 55555;


--insert dummy records for data shift
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(@agreementListDummy, 'DUMMY FOR DATA SHIFT', 'DUMMY FOR DATA SHIFT', 1)
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(@costAuthorityListDummy, 'DUMMY FOR DATA SHIFT2', 'DUMMY FOR DATA SHIFT2', 1)
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(@attrGroupInstructionsDummy, 'DUMMY FOR DATA SHIFT3', 'DUMMY FOR DATA SHIFT3', 1)
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(@attrGroupListDummy, 'DUMMY FOR DATA SHIFT4', 'DUMMY FOR DATA SHIFT4', 1)


--point records to dummy page types
update dbo.FirmaPage set FirmaPageTypeID = 22222 where FirmaPageTypeID = 65 and TenantID = 12;
update dbo.FirmaPage set FirmaPageTypeID = 33333 where FirmaPageTypeID = 66 and TenantID = 12;
update dbo.FirmaPage set FirmaPageTypeID = 44444 where FirmaPageTypeID = 67;
update dbo.FirmaPage set FirmaPageTypeID = 55555 where FirmaPageTypeID = 68;


--shift page types
update dbo.FirmaPageType set FirmaPageTypeID = 10000 where FirmaPageTypeID = 65;
update dbo.FirmaPageType set FirmaPageTypeID = 10001 where FirmaPageTypeID = 66;
update dbo.FirmaPageType set FirmaPageTypeID = 65 where FirmaPageTypeID = 67;
update dbo.FirmaPageType set FirmaPageTypeID = 66 where FirmaPageTypeID = 68;


--point records to correct page types
update dbo.FirmaPage set FirmaPageTypeID = 10000 where FirmaPageTypeID = 22222 and TenantID = 12;
update dbo.FirmaPage set FirmaPageTypeID = 10001 where FirmaPageTypeID = 33333 and TenantID = 12;
update dbo.FirmaPage set FirmaPageTypeID = 65 where FirmaPageTypeID = 44444;
update dbo.FirmaPage set FirmaPageTypeID = 66 where FirmaPageTypeID = 55555;




--shift other page types
update dbo.FirmaPage set FirmaPageTypeID = 33333 where FirmaPageTypeID = 69;
update dbo.FirmaPage set FirmaPageTypeID = 44444 where FirmaPageTypeID = 70;
update dbo.FirmaPage set FirmaPageTypeID = 55555 where FirmaPageTypeID = 71;

update dbo.FirmaPageType set FirmaPageTypeID = 67 where FirmaPageTypeID = 69;
update dbo.FirmaPageType set FirmaPageTypeID = 68 where FirmaPageTypeID = 70;
update dbo.FirmaPageType set FirmaPageTypeID = 69 where FirmaPageTypeID = 71;

update dbo.FirmaPage set FirmaPageTypeID = 67 where FirmaPageTypeID = 33333;
update dbo.FirmaPage set FirmaPageTypeID = 68 where FirmaPageTypeID = 44444;
update dbo.FirmaPage set FirmaPageTypeID = 69 where FirmaPageTypeID = 55555;

--delete dummy records
delete from dbo.FirmaPageType where FirmaPageTypeID in (22222, 33333, 44444, 55555);








-- Add Firma Page content to External map layers page
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(70, 'ExternalMapLayers', 'External Map Layers', 1)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(1, 70, '<p>External map layers to add to maps.</p>'),
(2, 70, '<p>External map layers to add to maps.</p>'),
(3, 70, '<p>External map layers to add to maps.</p>'),
(4, 70, '<p>External map layers to add to maps.</p>'),
(5, 70, '<p>External map layers to add to maps.</p>'),
(6, 70, '<p>External map layers to add to maps.</p>'),
(7, 70, '<p>External map layers to add to maps.</p>'),
(8, 70, '<p>External map layers to add to maps.</p>'),
(9, 70, '<p>External map layers to add to maps.</p>'),
(11, 70, '<p>External map layers to add to maps.</p>'),
(12, 70, '<p>External map layers to add to maps.</p>')

--select * from FirmaPage order by FirmaPageID desc