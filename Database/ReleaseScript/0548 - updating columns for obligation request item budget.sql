

ALTER TABLE Reclamation.CostAuthorityObligationRequest ADD TechnicalRepresentativePersonID int

ALTER TABLE Reclamation.CostAuthorityObligationRequest ADD RecipientOrganizationID int

ALTER TABLE Reclamation.CostAuthorityObligationRequest ADD BudgetObjectCodeID int



ALTER TABLE [Reclamation].[ObligationRequest] DROP CONSTRAINT [FK_ObligationRequest_Person_TechnicalRepresentativePersonID_PersonID]
GO

ALTER TABLE [Reclamation].[ObligationRequest] DROP CONSTRAINT [FK_ObligationRequest_Organization_RecipientOrganizationID_OrganizationID]
GO

ALTER TABLE Reclamation.ObligationRequest drop column TechnicalRepresentativePersonID 



ALTER TABLE Reclamation.ObligationRequest drop column RecipientOrganizationID 


ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_Person_TechnicalRepresentativePersonID_PersonID] FOREIGN KEY([TechnicalRepresentativePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] CHECK CONSTRAINT [FK_CostAuthorityObligationRequest_Person_TechnicalRepresentativePersonID_PersonID]
GO


ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_BudgetObjectCode_BudgetObjectCodeID] FOREIGN KEY([BudgetObjectCodeID])
REFERENCES [Reclamation].[BudgetObjectCode] ([BudgetObjectCodeID])
GO

ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] CHECK CONSTRAINT [FK_CostAuthorityObligationRequest_BudgetObjectCode_BudgetObjectCodeID]
GO





ALTER TABLE [Reclamation].[CostAuthorityObligationRequest]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityObligationRequest_Organization_RecipientOrganizationID_OrganizationID] FOREIGN KEY([RecipientOrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO

ALTER TABLE [Reclamation].[CostAuthorityObligationRequest] CHECK CONSTRAINT [FK_CostAuthorityObligationRequest_Organization_RecipientOrganizationID_OrganizationID]
GO


INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
select 10053, N'BudgetObjectCode', N'Budget Object Code'
go

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
select 10053, N'Budget Object Code'