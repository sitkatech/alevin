

update dbo.Organization
set PrimaryContactPersonID = null,
    LogoFileResourceInfoID = null
where TenantID not in (12)

/*
select * from dbo.TenantAttribute
where (TenantID != 1 and TenantID != 12)
*/

update dbo.TenantAttribute
set TenantSquareLogoFileResourceInfoID = null,
    TenantBannerLogoFileResourceInfoID = null,
    TenantStyleSheetFileResourceInfoID = null,
    TenantFactSheetLogoFileResourceInfoID = null,
    PrimaryContactPersonID = null
where TenantID not in (12)

--select * from dbo.FileResourceInfo
--where (TenantID != 1 and TenantID != 12)

delete from dbo.FileResourceInfo
where TenantID not in (12)

delete from dbo.Person
where TenantID not in (12)

delete from dbo.Organization
where TenantID not in (12)

delete from dbo.FirmaPage
where TenantID not in (12)

delete from dbo.TenantAttribute
where TenantID not in (12)

delete from dbo.OrganizationType
where TenantID not in (12)

-- Make sure we've disabled other tenants
update dbo.Tenant
set TenantEnabled = 0
where TenantID not in (12)

-- I think this could cause problems in C# at runtime, but it will execute if uncommented - everything else 
-- is cleaned up.

update dbo.Tenant
set CanonicalHostNameLocal = 'local.xxx',
    CanonicalHostNameQa = 'qa.xxx',
    CanonicalHostNameProd = 'prod.xxx',
    --UseFiscalYears = 0,
    --UsesTechnicalAssistanceParameters = 0,
    --ArePerformanceMeasuresExternallySourced = 0,
    --AreOrganizationsExternallySourced = 0,
    --AreFundingSourcesExternallySourced = 0,
    TenantEnabled = 0
where TenantID not in (12)

--select * from dbo.Tenant

--delete from dbo.Tenant
--where (TenantID != 12)



