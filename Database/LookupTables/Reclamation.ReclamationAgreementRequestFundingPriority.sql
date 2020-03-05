delete from Reclamation.ReclamationAgreementRequestFundingPriority

SET IDENTITY_INSERT Reclamation.ReclamationAgreementRequestFundingPriority ON


insert Reclamation.ReclamationAgreementRequestFundingPriority (ReclamationAgreementRequestFundingPriorityID, ReclamationAgreementRequestFundingPriorityName, AgreementRequestFundingPriorityDisplayName) 
values 
(1, 'Low', 'Low'),
(2, 'Medium', 'Medium'),
(3, 'High', 'High')


SET IDENTITY_INSERT Reclamation.ReclamationAgreementRequestFundingPriority OFF