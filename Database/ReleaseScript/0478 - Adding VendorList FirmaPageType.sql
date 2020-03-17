INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(10009, 'VendorList', 'Vendor List', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
10009,
'<p>Vendor List</p>'
FROM [dbo].[Tenant]

