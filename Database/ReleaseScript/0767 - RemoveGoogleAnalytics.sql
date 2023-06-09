-- Remove google Analytics from Reclamation for now, not working properly
update dbo.TenantAttribute set GoogleAnalyticsTrackingCode = null where TenantID = 12
