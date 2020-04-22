/*

Test WarnAboutAnyTenantOverridesThatCollideWithDifferentSystemFieldDefinitions

tells us:

fieldDefinitionDefinitionID	DefaultSystemFieldDefinitionDisplayName	dataFieldDefinitionID	FieldDefinitionDataID	TenantID	TenantOverriddenFieldDefinitionDisplayName
25	Primary Contact	252	1661	11	Primary Contact
10050	Projected Funding	248	1817	12	Projected Funding
10051	Obligated Funding	35	1816	12	Obligated Funding


So, we'll delete the ones for Reclamation. Tom's made all this native named in Reclamation, so we don't have to think this way any more
-- SLG 4/21/2020.

*/

delete from dbo.FieldDefinitionData
where FieldDefinitionDataID in (1817, 1816)
