--begin tran


UPDATE dbo.FieldDefinition 
set FieldDefinitionDisplayName = 'Recent Activities' where FieldDefinitionID = 10034
GO

UPDATE dbo.FieldDefinition 
set FieldDefinitionDisplayName = 'Upcoming Activities' where FieldDefinitionID = 10035
GO

UPDATE dbo.FieldDefinition 
set FieldDefinitionDisplayName = 'Risks/Issues' where FieldDefinitionID = 10036
GO

UPDATE dbo.FieldDefinition 
set FieldDefinitionDisplayName = 'Notes' where FieldDefinitionID = 10037
GO


UPDATE dbo.FieldDefinitionDefault 
set DefaultDefinition = 'Recent Activities' where FieldDefinitionID = 10034

UPDATE dbo.FieldDefinitionDefault 
set DefaultDefinition = 'Upcoming Activities' where FieldDefinitionID = 10035

UPDATE dbo.FieldDefinitionDefault 
set DefaultDefinition = 'Risks/Issues' where FieldDefinitionID = 10036

UPDATE dbo.FieldDefinitionDefault 
set DefaultDefinition = 'Notes' where FieldDefinitionID = 10037



--rollback tran