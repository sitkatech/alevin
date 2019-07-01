-- Temporary lookup column to be used during import, and deleted afterwards
alter table dbo.Organization
add ReclamationContractorID int null
GO

-- Now migrate address information
alter table dbo.Organization
add OrganizationAddress1 varchar(500) null,
    OrganizationAddress2 varchar(500) null,
    OrganizationCity varchar(500) null,
    OrganizationState varchar(20) null,
    OrganizationZip varchar(20) null
GO

insert into dbo.Organization (TenantID, 
                              ReclamationContractorID,
                              OrganizationGuid,
                              OrganizationName,
                              OrganizationShortName,
                              PrimaryContactPersonID,
                              IsActive,
                              OrganizationUrl,
                              LogoFileResourceID,
                              OrganizationTypeID,
                              OrganizationBoundary,
                              VendorNumber,
                              OrganizationAddress1,
                              OrganizationAddress2,
                              OrganizationCity,
                              OrganizationState,
                              OrganizationZip)
select 
    12 as TenantID,
    cl.ReclamationContractorID as ReclamationContractorID,
    NEWID() as OrganizationGuid,
    cl.ContractorName as OrganizationName,
    null as OrganizationShortName,
    -- we will need to fill this in, but we'll do it on another pass
    null as PrimaryContactPersonID, 
    -- Assume everything is active
    1 as IsActive, 
    null as OrganizationUrl,
    null as LogoFileResourceID,
    -- We haven't actually figured these out, so set as Unknown for the moment.
    1081 as OrganizationTypeID,
    null as OrganizationBoundary,
    cl.VendorNumber as VendorNumber,
    cl.Address1 as OrganizationAddress1,
    cl.Address2 as OrganizationAddress2,
    cl.City as  OrganizationCity,
    cl.[State] as  OrganizationState,
    cl.Zip as  OrganizationZip
from dbo.ContractorList as cl
GO

-- Import people

insert into dbo.Person (TenantID, PersonGuid, FirstName, LastName, Email, Phone, RoleID, CreateDate, IsActive, OrganizationID, ReceiveSupportEmails, LoginName)
select 12 as TenantID,
       NEWID() as PersonGuid,
       cl.ContactFirstName as FirstName,
       cl.ContactLastName as LastName,
       isnull(cl.ContactEmail, 'unknown_'+ cast(cl.ReclamationContractorID as varchar) +'@example.com') as Email,
       cl.ContactPhone as Phone,
       -- 7 == Unassigned Role. These are not necessarily - in fact, likely not - users who can log in to the system.
       7 as RoleID,
       GETDATE() as CreateDate,
       1 as IsActive,
       --null as OrganizationID,
       (select o.OrganizationID from dbo.Organization as o where o.ReclamationContractorID = cl.ReclamationContractorID) as OrganizationID,
       -- Again, they likely aren't real users
       0 as ReceiveSupportEmails,
       isnull(cl.ContactEmail, 'unknown_'+ cast(cl.ReclamationContractorID as varchar) +'@example.com') as LoginName
from dbo.ContractorList as cl
where cl.ContactFirstName is not null

-- Update people to be primary contacts. This is an assumption.
update dbo.Organization
set PrimaryContactPersonID = p.PersonID
from Person as p
inner join dbo.Organization as o on o.OrganizationID = p.OrganizationID
where o.ReclamationContractorID is not null

-- Assuming we are done here, drop original temp table
drop table dbo.ContractorList
GO