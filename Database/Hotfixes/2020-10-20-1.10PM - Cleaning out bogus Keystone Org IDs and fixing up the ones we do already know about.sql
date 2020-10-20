
-- All of the existing Alevin Org GUIDs were junk. I think we must not have understood what they were for and invented them on 
-- import. So, we'll clear them out for the BOR tenant, and then manually fix up the ones we do understand 

update AlevinDB.dbo.Organization
set OrganizationGuid = null
where TenantID = 12
GO


update AlevinDB.dbo.Organization set OrganizationGuid = '6E020A68-7277-41A2-B627-52046A3D5558' where OrganizationID = 6180 and TenantID = 12
update AlevinDB.dbo.Organization set OrganizationGuid = '79427B67-47BF-462A-B2F7-B7CBCA812233' where OrganizationID = 6160 and TenantID = 12
update AlevinDB.dbo.Organization set OrganizationGuid = 'DA54A2FC-95B9-4848-9AF3-AA84B018BE5F' where OrganizationID = 6319 and TenantID = 12

-- Code below used during investigation to create repair above
/*



update AlevinDB.dbo.Organization
set OrganizationGuid = fixedUpOrgGuid.ProjectFirmaKeystoneOrganizationGuid
from 
(
    select --pfo.OrganizationID as ProjectFirmaOrganizationID,
           distinct
           ao.OrganizationID as AlevinOrganizationID,
           pfo.OrganizationName,
           ao.OrganizationShortName,
           pfo.OrganizationGuid as ProjectFirmaKeystoneOrganizationGuid
    from ProjectFirma.dbo.Organization as pfo
    inner join AlevinDB.dbo.Organization as ao on pfo.OrganizationName = ao.OrganizationName and pfo.OrganizationShortName = ao.OrganizationShortName
    where pfo.OrganizationGuid is not null
    --order by OrganizationName
) as fixedUpOrgGuid
where OrganizationID = fixedUpOrgGuid.AlevinOrganizationID


select * from dbo.Organization
where FullName like '%biomark%'

select ao.OrganizationID as AlevinOrganizationID,
       ao.OrganizationGuid as AlevinOrganizationGuid,
       ko.OrganizationGuid as KeystoneOrganizationGuid
from AlevinDB.dbo.Organization as ao
left join Keystone.dbo.Organization as ko on ao.OrganizationGuid = ko.OrganizationGuid
where TenantID = 12
and   ko.OrganizationGuid is not null


select * 
from ProjectFirma.dbo.Organization as pfo
inner join Keystone.dbo.Organization as ko on pfo.OrganizationGuid = ko.OrganizationGuid

select pfo.OrganizationGuid as ProjectFirmaOrganizationGuid,
       ko.OrganizationGuid as KeystoneOrganizationGuid
from ProjectFirma.dbo.Organization as pfo
left join Keystone.dbo.Organization as ko on pfo.OrganizationGuid = ko.OrganizationGuid
--where TenantID = 12
and   ko.OrganizationGuid is not null and pfo.OrganizationGuid is not null


select pfo.*
from ProjectFirma.dbo.Organization as pfo






select * from AlevinDB.dbo.Organization
where TenantID = 12 
and OrganizationGuid is not null

select * from ProjectFirma.dbo.Organization where OrganizationName like '%bio%'
select * from AlevinDB.dbo.Organization where OrganizationName like '%bio%'

*/


select ao.OrganizationID as AlevinOrganizationID,
       ao.OrganizationGuid as AlevinOrganizationGuid,
       ko.OrganizationGuid as KeystoneOrganizationGuid,
       ao.OrganizationName,
       ao.OrganizationShortName,
       ko.ShortName
from AlevinDB.dbo.Organization as ao
left join Keystone.dbo.Organization as ko on ao.OrganizationGuid = ko.OrganizationGuid
where TenantID = 12
and ko.OrganizationGuid is not null