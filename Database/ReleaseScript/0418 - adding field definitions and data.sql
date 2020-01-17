insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10030,N'CostAuthorityNumber', N'Cost Authority Number')

 go

 insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10031,N'AccountStructureDescription', N'Account Structure Description')

 go


  insert into dbo.FieldDefinition([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])

 values (10032,N'CostAuthorityAgreementRequestNote', N'Note on projected obligation from a CAWBS to an Agreement')

 go




  insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10030,N'Cost Authority Number')

   insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10031,N'Account Structure Description')


     insert into dbo.FieldDefinitionDefault(FieldDefinitionID, DefaultDefinition)
 values(10032,N'Note on projected obligation from a CAWBS to an Agreement')