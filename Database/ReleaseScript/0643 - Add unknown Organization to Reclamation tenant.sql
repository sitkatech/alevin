

declare @unknownOrganizationTypeForReclamation int
set @unknownOrganizationTypeForReclamation = (select ot.OrganizationTypeID from dbo.OrganizationType as ot where ot.TenantID = 12 and OrganizationTypeName = 'Unknown')

--select @unknownOrganizationTypeForReclamation

insert into dbo.Organization(TenantID, OrganizationName, OrganizationShortName, IsActive, OrganizationTypeID, UseOrganizationBoundaryForMatchmaker, IsUnknownOrUnspecified)
values
(12, '(Unknown or Unspecified Organization)', 'N/A', 1, @unknownOrganizationTypeForReclamation, 1, 1)
GO

/*
select * from dbo.Organization
where TenantID != 12
and OrganizationName = '(Unknown or Unspecified Organization)'

select * from dbo.Tenant

"(Unknown or Unspecified Organization)"

select * from OrganizationType 
where OrganizationTypeID in (8,23,11,3,27,59,35,43,1060,1076,12)

select * from dbo.OrganizationType
where TenantID = 12
*/