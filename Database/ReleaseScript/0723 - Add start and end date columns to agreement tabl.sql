ALTER TABLE Reclamation.Agreement
Add StartDate datetime, EndDate datetime

Alter table Reclamation.ObligationRequest
Add ModNumber int 
go
CREATE UNIQUE NONCLUSTERED INDEX AK_ObligationRequest_AgreementID_ModNumber
ON Reclamation.ObligationRequest(ModNumber, AgreementID)
WHERE IsModification = 1 and 
ModNumber IS NOT NULL and 
AgreementID IS NOT NULL;