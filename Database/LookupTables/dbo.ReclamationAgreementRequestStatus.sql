delete from dbo.ReclamationAgreementRequestStatus

SET IDENTITY_INSERT dbo.ReclamationAgreementRequestStatus ON


insert dbo.ReclamationAgreementRequestStatus (ReclamationAgreementRequestStatusID, ReclamationAgreementRequestStatusName, AgreementRequestStatusDisplayName) 
values 
(1, 'Draft', 'Draft'),
(2, 'Submitted', 'Submitted'),
(3, 'Processing', 'Processing'),
(4, 'Awarded', 'Awarded')

SET IDENTITY_INSERT dbo.ReclamationAgreementRequestStatus OFF