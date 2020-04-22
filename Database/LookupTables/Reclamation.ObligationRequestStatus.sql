delete from Reclamation.ObligationRequestStatus

SET IDENTITY_INSERT Reclamation.ObligationRequestStatus ON


insert Reclamation.ObligationRequestStatus (ObligationRequestStatusID, ObligationRequestStatusName, ObligationRequestStatusDisplayName) 
values 
(1, 'Draft', 'Draft'),
(2, 'Submitted', 'Submitted'),
(3, 'Processing', 'Processing'),
(4, 'Awarded', 'Awarded')

SET IDENTITY_INSERT Reclamation.ObligationRequestStatus OFF