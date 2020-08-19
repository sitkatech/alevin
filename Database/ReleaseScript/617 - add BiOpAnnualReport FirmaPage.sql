INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(10012, 'BiOpAnnualReport', 'BiOp Annual Report', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
10012,
'<p>BiOp Annual Report</p>'
FROM [dbo].[Tenant]

