
CREATE TABLE [dbo].[ReclamationAgreementRequest](
	[ReclamationAgreementRequestID] [int] IDENTITY(1,1) NOT NULL,
	[ContractTypeID] [int] NOT NULL,
	[AgreementRequestStatusID] [int] NOT NULL,
	[DescriptionOfNeed] [nvarchar](250) NOT NULL,
	[ReclamationAgreementRequestFundingPriorityID] [int] NULL,
    [RecipientOrganizationID] [int] NULL,
    [TechnicalRepresentativePersonID] [int] NULL,
	[TargetAwardDate] [datetime] NULL,
	[PALT] [int] NULL,
	[TargetSubmittalDate] [datetime] null,
	[CreateDate] [datetime] NOT NULL,
    [CreatePersonID] int not null,
    UpdateDate datetime null,
    UpdatePersonID int null

 CONSTRAINT [PK_ReclamationAgreementRequest_ReclamationAgreementRequestID] PRIMARY KEY CLUSTERED 
(
	[ReclamationAgreementRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

--contract type

ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_ReclamationContractType_ContractTypeID_ReclamationContractTypeID] FOREIGN KEY([ContractTypeID])
REFERENCES [dbo].[ReclamationContractType] ([ReclamationContractTypeID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_ReclamationContractType_ContractTypeID_ReclamationContractTypeID]
GO


-- status

ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_ReclamationAgreementRequestStatus_AgreementRequestStatusID_ReclamationAgreementRequestStatusID] FOREIGN KEY([AgreementRequestStatusID])
REFERENCES [dbo].[ReclamationAgreementRequestStatus] ([ReclamationAgreementRequestStatusID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_ReclamationAgreementRequestStatus_AgreementRequestStatusID_ReclamationAgreementRequestStatusID]
GO

-- funding priority

ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_ReclamationAgreementRequestFundingPriority_ReclamationAgreementRequestFundingPriorityID] FOREIGN KEY([ReclamationAgreementRequestFundingPriorityID])
REFERENCES [dbo].[ReclamationAgreementRequestFundingPriority] ([ReclamationAgreementRequestFundingPriorityID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_ReclamationAgreementRequestFundingPriority_ReclamationAgreementRequestFundingPriorityID]
GO



-- recipient organization

ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_Organization_RecipientOrganizationID_OrganizationID] FOREIGN KEY([RecipientOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_Organization_RecipientOrganizationID_OrganizationID]
GO

-- technical representative


ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_Person_TechnicalRepresentativePersonID_PersonID] FOREIGN KEY([TechnicalRepresentativePersonID])
REFERENCES [dbo].Person ([PersonID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_Person_TechnicalRepresentativePersonID_PersonID]
GO


-- create person


ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].Person ([PersonID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_Person_CreatePersonID_PersonID]
GO


-- update person

ALTER TABLE [dbo].ReclamationAgreementRequest  WITH CHECK ADD  CONSTRAINT [FK_ReclamationAgreementRequest_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].Person ([PersonID])
GO

ALTER TABLE [dbo].ReclamationAgreementRequest CHECK CONSTRAINT [FK_ReclamationAgreementRequest_Person_UpdatePersonID_PersonID]
GO



