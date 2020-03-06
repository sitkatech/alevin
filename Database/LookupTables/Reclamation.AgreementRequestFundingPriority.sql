delete from Reclamation.AgreementRequestFundingPriority

SET IDENTITY_INSERT Reclamation.AgreementRequestFundingPriority ON


insert Reclamation.AgreementRequestFundingPriority (AgreementRequestFundingPriorityID, AgreementRequestFundingPriorityName, AgreementRequestFundingPriorityDisplayName) 
values 
(1, 'Low', 'Low'),
(2, 'Medium', 'Medium'),
(3, 'High', 'High')


SET IDENTITY_INSERT Reclamation.AgreementRequestFundingPriority OFF