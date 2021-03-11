

update dbo.Organization
set PrimaryContactPersonID = null,
    LogoFileResourceInfoID = null
where (TenantID != 1 and TenantID != 12)

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
where (TenantID != 1 and TenantID != 12)

--select * from dbo.FileResourceInfo
--where (TenantID != 1 and TenantID != 12)

delete from dbo.FileResourceInfo
where (TenantID != 1 and TenantID != 12)

delete from dbo.Person
where (TenantID != 1 and TenantID != 12)

delete from dbo.Organization
where (TenantID != 1 and TenantID != 12)

delete from dbo.FirmaPage
where (TenantID != 1 and TenantID != 12)

delete from dbo.TenantAttribute
where (TenantID != 1 and TenantID != 12)

delete from dbo.OrganizationType
where (TenantID != 1 and TenantID != 12)

-- Make sure we've disabled other tenants
update dbo.Tenant
set TenantEnabled = 0
where (TenantID != 1 and TenantID != 12)

-- I think this could cause problems in C# at runtime, but it will execute if uncommented - everything else 
-- is cleaned up.
/*
delete from dbo.Tenant
where (TenantID != 1 and TenantID != 12)
*/
