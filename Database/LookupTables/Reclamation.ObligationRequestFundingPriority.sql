delete from Reclamation.ObligationRequestFundingPriority

SET IDENTITY_INSERT Reclamation.ObligationRequestFundingPriority ON


insert Reclamation.ObligationRequestFundingPriority (ObligationRequestFundingPriorityID, ObligationRequestFundingPriorityName, ObligationRequestFundingPriorityDisplayName) 
values 
(1, 'Low', 'Low'),
(2, 'Medium', 'Medium'),
(3, 'High', 'High')


SET IDENTITY_INSERT Reclamation.ObligationRequestFundingPriority OFF