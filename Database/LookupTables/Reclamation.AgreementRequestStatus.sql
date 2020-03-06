delete from Reclamation.AgreementRequestStatus

SET IDENTITY_INSERT Reclamation.AgreementRequestStatus ON


insert Reclamation.AgreementRequestStatus (AgreementRequestStatusID, AgreementRequestStatusName, AgreementRequestStatusDisplayName) 
values 
(1, 'Draft', 'Draft'),
(2, 'Submitted', 'Submitted'),
(3, 'Processing', 'Processing'),
(4, 'Awarded', 'Awarded')

SET IDENTITY_INSERT Reclamation.AgreementRequestStatus OFF