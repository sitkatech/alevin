
update dbo.FieldDefinitionDefault 
set DefaultDefinition = 'Is this request a modification to an existing Obligation'
where FieldDefinitionID = 10007


update dbo.FirmaPage 
set FirmaPageContent = 'Add one or many CAWBS and their projected obligations to this Obligation Request.'
where FirmaPageTypeID = 10004