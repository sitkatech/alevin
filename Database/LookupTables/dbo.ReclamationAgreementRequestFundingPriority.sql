delete from dbo.ReclamationAgreementRequestFundingPriority

SET IDENTITY_INSERT dbo.ReclamationAgreementRequestFundingPriority ON


insert dbo.ReclamationAgreementRequestFundingPriority (ReclamationAgreementRequestFundingPriorityID, ReclamationAgreementRequestFundingPriorityName, AgreementRequestFundingPriorityDisplayName) 
values 
(1, 'Low', 'Low'),
(2, 'Medium', 'Medium'),
(3, 'High', 'High')


SET IDENTITY_INSERT dbo.ReclamationAgreementRequestFundingPriority OFF