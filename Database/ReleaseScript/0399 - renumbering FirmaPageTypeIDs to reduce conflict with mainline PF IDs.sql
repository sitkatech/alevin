


update dbo.FirmaPageType set FirmaPageTypeID = 10000 where FirmaPageTypeID = 65;
update dbo.FirmaPageType set FirmaPageTypeID = 10001 where FirmaPageTypeID = 66;

update dbo.FirmaPageType set FirmaPageTypeID = 65 where FirmaPageTypeID = 67;
update dbo.FirmaPageType set FirmaPageTypeID = 66 where FirmaPageTypeID = 68;
update dbo.FirmaPageType set FirmaPageTypeID = 67 where FirmaPageTypeID = 69;
update dbo.FirmaPageType set FirmaPageTypeID = 68 where FirmaPageTypeID = 70;
update dbo.FirmaPageType set FirmaPageTypeID = 69 where FirmaPageTypeID = 71;




update dbo.FirmaPage set FirmaPageTypeID = 10000 where FirmaPageTypeID = 65 and TenantID = 12;
update dbo.FirmaPage set FirmaPageTypeID = 10001 where FirmaPageTypeID = 66 and TenantID = 12;



update dbo.FirmaPage set FirmaPageTypeID = 65 where FirmaPageTypeID = 67 and TenantID = 12;
update dbo.FirmaPage set FirmaPageTypeID = 66 where FirmaPageTypeID = 68 and TenantID = 12;



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