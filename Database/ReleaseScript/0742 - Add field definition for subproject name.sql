INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName])
VALUES
(10061, N'SubprojectName', N'Subproject Name')

INSERT [dbo].[FieldDefinitionDefault] ([FieldDefinitionID], [DefaultDefinition])
VALUES
(10061, N'The name of a subproject given by the organization responsible for reporting. Subproject names should generally include a reference to 1) the location of the subproject, 2) the primary implementation activity, and 3) the subproject phase (if a multi-phase subproject).')

