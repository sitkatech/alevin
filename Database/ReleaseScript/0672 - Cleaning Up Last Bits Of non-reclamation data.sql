

-- START
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


/*



select * from dbo.Tenant

select * from dbo.Project
where TenantID != 12

select * from dbo.ActionItem
where TenantID != 12

select * from dbo.Person
where TenantID != 12

delete from dbo.Person 
where (TenantID != 2 or TenantID != 12)

select * from dbo.Organization
where (TenantID != 2 and TenantID != 12)

select * from dbo.Tenant

delete from dbo.Organization
where (TenantID != 2 and TenantID != 12)

*/