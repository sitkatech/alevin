--begin tran

ALTER TABLE dbo.ReclamationAgreementRequest
ADD 
RequisitionNumber int null,
RequisitionDate datetime null,
ContractSpecialist nvarchar(250) null,
AssignedDate datetime null,
DateSentForDeptReview datetime null,
DCApprovalDate datetime null,
ActualAwardDate datetime null;

-- field definition stuff

INSERT INTO dbo.FieldDefinition (FieldDefinitionID, FieldDefinitionName, FieldDefinitionDisplayName)
values
    (10018,N'RequisitionNumber', N'Requisition Number'),
    (10019,N'RequisitionDate', N'Requisition Date'),
    (10020,N'ContractSpecialist', N'Contract Specialist'),
    (10021,N'AssignedDate', N'Assigned Date'),
    (10022,N'DateSentForDeptReview', N'Date Sent for Dept. Review'),
    (10023,N'DCApprovalDate', N'DC Approval Date'),
    (10024,N'ActualAwardDate', N'Actual Award Date'),
    (10025,N'RequisitionInformation', N'Requisition Information'),
    (10026,N'RequisitionAge', N'Age'),
    (10027,N'RequisitionDeptReviewDays', N'Dept Review Days'),
    (10028,N'RequisitionDaysToAssign', N'Days to Assign'),
    (10029,N'RequisitionDaysToAward', N'Days to Award')

insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
values 
    (10018, N'<p>Requisition Number</p>'),
    (10019, N'<p>Requisition Date</p>'),
    (10020, N'<p>Contract Specialist</p>'),
    (10021, N'<p>Assigned Date</p>'),
    (10022, N'<p>Date Sent for Dept. Review</p>'),
    (10023, N'<p>DC Approval Date</p>'),
    (10024, N'<p>Actual Award Date</p>'),
    (10025, N'<p>Requisition Information</p>'),
    (10026, N'<p>Age</p>'),
    (10027, N'<p>Dept Review Days</p>'),
    (10028, N'<p>Days to Assign</p>'),
    (10029, N'<p>Days to Award</p>')

--rollback tran