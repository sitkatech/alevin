insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10006,N'AgreementRequest', N'Agreement Request')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10006,N'Agreement Request')

 go

 insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
 (10002, 'AgreementRequestList', 'Agreement Request List', 1),
 (10003, 'AgreementRequestFromGridDialog', 'Agreement Request Grid Dialog', 2)
 go

 insert into dbo.FirmaPage(TenantID,FirmaPageTypeID, FirmaPageContent)
 values(12,10002,null),
        (12,10003,null)

 go

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10007,N'IsModification', N'Is this request a modification to an existing Agreement')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10007,N'Is this request a modification to an existing Agreement')

 go

  insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10008,N'RequestStatus', N'Request Status')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10008,N'Request Status')

 go

insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10009,N'DescriptionOfNeed', N'Description of Need')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10009,N'Description of Need')

 go

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10010,N'FundingPriority', N'Funding Priority')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10010,N'Funding Priority')

 go

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10011,N'RecipientOrganization', N'Recipient Organization')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10011,N'Recipient Organization')

 go


  insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10012,N'TechnicalRepresentative', N'Technical Representative')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10012,N'Technical Representative')

 go

   insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10013,N'TargetAwardDate', N'Target Award Date')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10013,N'Target Award Date')

 go

    insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10014,N'PALT', N'PALT')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10014,N'PALT')

 go


insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10015,N'TargetSubmittalDate', N'Target Submittal Date')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10015,N'Target Submittal Date')

 go

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10016,N'AgreementRequestID', N'Agreement Request ID')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10016,N'Agreement Request ID')

 go


  insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10017,N'ProjectedObligation', N'Projected Obligation')

 go

 insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10017,N'Projected Obligation')

 go




 