--select * from dbo.ReclamationAgreement

--select * from dbo.Organization
--select * from  dbo.ContractorList

--update dbo.ReclamationAgreement
--set OrganizationID = 

--select o.OrganizationID, *
--from dbo.Organization as o
--inner join dbo.ContractorList as cl on o.OrganizationName = cl.ContractorName
--where o.TenantID = 12

--update dbo.ReclamationAgreement
--set OrganizationID = o.OrganizationID

--select *
--from dbo.ReclamationAgreement as ra
--inner join dbo.ContractorList as cl on ra.ContractorLU = cl.ReclamationContractorID
--inner join dbo.Organization as o on o.OrganizationName = cl.ContractorName


-- Fix up ReclamationAgreement OrganizationIDs
-- This should prove durable if more orgIDs are added from mainline data before we branch (er, ahem, if we fork)
UPDATE
    dbo.ReclamationAgreement
SET
    OrganizationID = o.OrganizationID
from dbo.ReclamationAgreement as ra
inner join dbo.ContractorList as cl on ra.ContractorLU = cl.ReclamationContractorID
inner join dbo.Organization as o on o.OrganizationName = cl.ContractorName
WHERE
    o.TenantID = 12


--select * from ReclamationAgreement



select * from dbo.ReclamationAgreement
select * from ContractorList as cl



select * 
from dbo.Organization as o
inner join dbo.ContractorList as cl on o.OrganizationName = cl.ContractorName
where o.TenantID = 12

