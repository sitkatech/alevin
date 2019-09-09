
-- Fix up ReclamationAgreement OrganizationIDs
-- This should prove durable if more orgIDs are added from mainline data before we fork (er, ahem, *if* we fork)
UPDATE
    dbo.ReclamationAgreement
SET
    OrganizationID = o.OrganizationID
from dbo.ReclamationAgreement as ra
inner join dbo.ContractorList as cl on ra.ContractorLU = cl.ReclamationContractorID
inner join dbo.Organization as o on o.OrganizationName = cl.ContractorName
WHERE
    o.TenantID = 12


-- RE-FK this
ALTER TABLE [dbo].[ReclamationAgreement]  WITH CHECK ADD  CONSTRAINT FK_ReclamationAgreement_Organization_OrganizationID FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[ReclamationAgreement] CHECK CONSTRAINT FK_ReclamationAgreement_Organization_OrganizationID
GO


-- We hope we can actually drop this, but if we need this again, I think we should give up and just keep it around -- SLG 7/23/2019
drop table dbo.ContractorList