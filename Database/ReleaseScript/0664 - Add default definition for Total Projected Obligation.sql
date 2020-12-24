
--CREATE TABLE [dbo].[FieldDefinitionDefault](
--	[FieldDefinitionDefaultID] [int] IDENTITY(1,1) NOT NULL,
--	[FieldDefinitionID] [int] NOT NULL,
--	[DefaultDefinition] [dbo].[html] NOT NULL,
-- CONSTRAINT [PK_FieldDefinitionDefault_FieldDefinitionDefaultID] PRIMARY KEY CLUSTERED 

-- Alevin only field definitions always start after ProjectFirma field defitions and begin at 10000
INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(10058, N'TotalProjectedObligation', N'Total Projected Obligation')
GO

insert into dbo.FieldDefinitionDefault([FieldDefinitionID], [DefaultDefinition])
values (10058, '<p>Total value of all Projected Obligations for this Obligation Request</p>')
GO

-- select * from dbo.FieldDefinitionDefault