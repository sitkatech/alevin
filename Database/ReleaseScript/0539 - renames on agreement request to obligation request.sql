
EXECUTE sp_rename N'Reclamation.AgreementRequest.AgreementRequestID', N'Tmp_ObligationRequestID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.AgreementRequest.AgreementRequestStatusID', N'Tmp_ObligationRequestStatusID_1', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.AgreementRequest.ReclamationAgreementRequestFundingPriorityID', N'Tmp_ReclamationObligationRequestFundingPriorityID_2', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.AgreementRequest.Tmp_ObligationRequestID', N'ObligationRequestID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.AgreementRequest.Tmp_ObligationRequestStatusID_1', N'ObligationRequestStatusID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.AgreementRequest.Tmp_ReclamationObligationRequestFundingPriorityID_2', N'ReclamationObligationRequestFundingPriorityID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.AgreementRequest', N'ObligationRequest', 'OBJECT' 
GO


EXECUTE sp_rename N'Reclamation.AgreementRequestFundingPriority', N'ObligationRequestFundingPriority', 'OBJECT' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestFundingPriority.AgreementRequestFundingPriorityID', N'Tmp_ObligationRequestFundingPriorityID_3', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestFundingPriority.AgreementRequestFundingPriorityName', N'Tmp_ObligationRequestFundingPriorityName_4', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestFundingPriority.AgreementRequestFundingPriorityDisplayName', N'Tmp_ObligationRequestFundingPriorityDisplayName_5', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestFundingPriority.Tmp_ObligationRequestFundingPriorityID_3', N'ObligationRequestFundingPriorityID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestFundingPriority.Tmp_ObligationRequestFundingPriorityName_4', N'ObligationRequestFundingPriorityName', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestFundingPriority.Tmp_ObligationRequestFundingPriorityDisplayName_5', N'ObligationRequestFundingPriorityDisplayName', 'COLUMN' 
GO


EXECUTE sp_rename N'Reclamation.AgreementRequestStatus', N'ObligationRequestStatus', 'OBJECT' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestStatus.AgreementRequestStatusID', N'Tmp_ObligationRequestStatusID_6', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestStatus.AgreementRequestStatusName', N'Tmp_ObligationRequestStatusName_7', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestStatus.AgreementRequestStatusDisplayName', N'Tmp_ObligationRequestStatusDisplayName_8', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestStatus.Tmp_ObligationRequestStatusID_6', N'ObligationRequestStatusID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestStatus.Tmp_ObligationRequestStatusName_7', N'ObligationRequestStatusName', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestStatus.Tmp_ObligationRequestStatusDisplayName_8', N'ObligationRequestStatusDisplayName', 'COLUMN' 
GO


EXECUTE sp_rename N'Reclamation.AgreementRequestSubmissionNote', N'ObligationRequestSubmissionNote', 'OBJECT' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestSubmissionNote.AgreementRequestSubmissionNoteID', N'Tmp_ObligationRequestSubmissionNoteID_9', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestSubmissionNote.ReclamationAgreementRequestID', N'Tmp_ObligationRequestID_10', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestSubmissionNote.Tmp_ObligationRequestSubmissionNoteID_9', N'ObligationRequestSubmissionNoteID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.ObligationRequestSubmissionNote.Tmp_ObligationRequestID_10', N'ObligationRequestID', 'COLUMN' 
GO


EXECUTE sp_rename N'Reclamation.CostAuthorityAgreementRequest', N'CostAuthorityObligationRequest', 'OBJECT' 
GO
EXECUTE sp_rename N'Reclamation.CostAuthorityObligationRequest.CostAuthorityAgreementRequestID', N'Tmp_CostAuthorityObligationRequestID_11', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.CostAuthorityObligationRequest.AgreementRequestID', N'Tmp_ObligationRequestID_12', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.CostAuthorityObligationRequest.Tmp_CostAuthorityObligationRequestID_11', N'CostAuthorityObligationRequestID', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.CostAuthorityObligationRequest.Tmp_ObligationRequestID_12', N'ObligationRequestID', 'COLUMN' 
GO


EXECUTE sp_rename N'Reclamation.CostAuthorityObligationRequest.ReclamationCostAuthorityAgreementRequestNote', N'Tmp_CostAuthorityObligationRequestNote_13', 'COLUMN' 
GO
EXECUTE sp_rename N'Reclamation.CostAuthorityObligationRequest.Tmp_CostAuthorityObligationRequestNote_13', N'CostAuthorityObligationRequestNote', 'COLUMN' 
GO
