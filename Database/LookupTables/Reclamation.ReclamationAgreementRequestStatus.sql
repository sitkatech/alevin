delete from Reclamation.ReclamationAgreementRequestStatus

SET IDENTITY_INSERT Reclamation.ReclamationAgreementRequestStatus ON


insert Reclamation.ReclamationAgreementRequestStatus (ReclamationAgreementRequestStatusID, ReclamationAgreementRequestStatusName, AgreementRequestStatusDisplayName) 
values 
(1, 'Draft', 'Draft'),
(2, 'Submitted', 'Submitted'),
(3, 'Processing', 'Processing'),
(4, 'Awarded', 'Awarded')

SET IDENTITY_INSERT Reclamation.ReclamationAgreementRequestStatus OFF