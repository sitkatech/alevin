SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[AgreementRequest](
	[AgreementRequestID] [int] IDENTITY(1,1) NOT NULL,
	[IsModification] [bit] NOT NULL,
	[AgreementID] [int] NULL,
	[ContractTypeID] [int] NOT NULL,
	[AgreementRequestStatusID] [int] NOT NULL,
	[DescriptionOfNeed] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReclamationAgreementRequestFundingPriorityID] [int] NULL,
	[RecipientOrganizationID] [int] NULL,
	[TechnicalRepresentativePersonID] [int] NULL,
	[TargetAwardDate] [datetime] NULL,
	[PALT] [int] NULL,
	[TargetSubmittalDate] [datetime] NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreatePersonID] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[UpdatePersonID] [int] NULL,
	[RequisitionNumber] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RequisitionDate] [datetime] NULL,
	[ContractSpecialist] [nvarchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AssignedDate] [datetime] NULL,
	[DateSentForDeptReview] [datetime] NULL,
	[DCApprovalDate] [datetime] NULL,
	[ActualAwardDate] [datetime] NULL,
 CONSTRAINT [PK_AgreementRequest_AgreementRequestID] PRIMARY KEY CLUSTERED 
(
	[AgreementRequestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_Agreement_AgreementID] FOREIGN KEY([AgreementID])
REFERENCES [Reclamation].[Agreement] ([AgreementID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_Agreement_AgreementID]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_AgreementRequestFundingPriority_ReclamationAgreementRequestFundingPriorityID_AgreementRequestFundingPriority] FOREIGN KEY([ReclamationAgreementRequestFundingPriorityID])
REFERENCES [Reclamation].[AgreementRequestFundingPriority] ([AgreementRequestFundingPriorityID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_AgreementRequestFundingPriority_ReclamationAgreementRequestFundingPriorityID_AgreementRequestFundingPriority]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_AgreementRequestStatus_AgreementRequestStatusID] FOREIGN KEY([AgreementRequestStatusID])
REFERENCES [Reclamation].[AgreementRequestStatus] ([AgreementRequestStatusID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_AgreementRequestStatus_AgreementRequestStatusID]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_ContractType_ContractTypeID] FOREIGN KEY([ContractTypeID])
REFERENCES [Reclamation].[ContractType] ([ContractTypeID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_ContractType_ContractTypeID]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_Organization_RecipientOrganizationID_OrganizationID] FOREIGN KEY([RecipientOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_Organization_RecipientOrganizationID_OrganizationID]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_Person_CreatePersonID_PersonID]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_Person_TechnicalRepresentativePersonID_PersonID] FOREIGN KEY([TechnicalRepresentativePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_Person_TechnicalRepresentativePersonID_PersonID]
GO
ALTER TABLE [Reclamation].[AgreementRequest]  WITH CHECK ADD  CONSTRAINT [FK_AgreementRequest_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [Reclamation].[AgreementRequest] CHECK CONSTRAINT [FK_AgreementRequest_Person_UpdatePersonID_PersonID]