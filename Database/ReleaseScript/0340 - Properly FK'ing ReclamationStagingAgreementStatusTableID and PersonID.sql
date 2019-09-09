

-- Add ReclamationStagingAgreementStatusTableID
-------------------------------------------------
alter table dbo.ReclamationDeliverable
add ReclamationStagingAgreementStatusTableID int null  constraint FK_ReclamationDeliverable_ReclamationStagingAgreementStatusTable_ReclamationStagingAgreementStatusTableID foreign key references dbo.ReclamationStagingAgreementStatusTable(ReclamationStagingAgreementStatusTableID) 
GO

update dbo.ReclamationDeliverable
set dbo.ReclamationDeliverable.ReclamationStagingAgreementStatusTableID = rst.ReclamationStagingAgreementStatusTableID
from ReclamationStagingAgreementStatusTable as rst
inner join dbo.ReclamationDeliverable as rd on rd.OriginalReclamationAgreementStatusID = rst.OriginalAgreementStatusID
GO

alter table dbo.ReclamationDeliverable
drop column OriginalReclamationAgreementStatusID

-- Add PersonID; moving away from Reclamation Persons table
-------------------------------------------------


alter table dbo.ReclamationDeliverable
add PersonID int null  constraint FK_ReclamationDeliverable_Person_PersonID foreign key references dbo.Person(PersonID) 
GO

update dbo.ReclamationDeliverable
set dbo.ReclamationDeliverable.PersonID = p.PersonID
from dbo.ReclamationDeliverable as rd
-- Yes, these are the same we believe
inner join dbo.Person as p on rd.OriginalReclamationPersonsTableID = p.ReclamationStaffID

alter table dbo.ReclamationDeliverable
drop column OriginalReclamationPersonsTableID

-- Since everything is keyed, we should be able to do this

alter table dbo.ReclamationDeliverable
drop column Original_ReclamationDeliverableID

-- We want to drop ReclamationStagingPersonsTable, but we aren't 100% sure we're ready to do that. 
-- We'll see.

--select * from dbo.ReclamationStagingPersonsTable

--select * from dbo.Person



