INSERT [dbo].[FirmaPageType] ([FirmaPageTypeID], [FirmaPageTypeName], [FirmaPageTypeDisplayName], [FirmaPageRenderTypeID])
VALUES
(10010, 'PnBudgetList', 'PnBudget Import List', 1)

INSERT [dbo].[FirmaPage] ([TenantID], [FirmaPageTypeID], [FirmaPageContent])SELECT TenantID,
10010,
'<p>PnBudget Import</p>'
FROM [dbo].[Tenant]

