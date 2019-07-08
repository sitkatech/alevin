-- Prefix of "reclamation" indicates a BOR sourced table, but one we think can likely stay in the format is it now
-- Prefix of "ReclamationStaging indicates a BOR source table, but one we think will likely need to be re-worked in terms of schema design

exec sp_rename 'dbo.WorkOrder', 'ReclamationWorkOrder'

exec sp_rename 'dbo.WorkBreakdownStructure', 'ReclamationWorkBreakdownStructure'

exec sp_rename 'dbo.Agreement', 'ReclamationAgreement'

exec sp_rename 'dbo.ContractType', 'ReclamationContractType'

exec sp_rename 'dbo.Basin', 'ReclamationBasin'

exec sp_rename 'dbo.CostAuthority', 'ReclamationCostAuthority'

exec sp_rename 'dbo.HabitatCategory', 'ReclamationHCategory'

exec sp_rename 'dbo.Subbasin', 'ReclamationSubbasin'

exec sp_rename 'dbo.DeliverableType', 'ReclamationDeliverableType'

exec sp_rename 'dbo.Deliverable', 'ReclamationDeliverable'

exec sp_rename 'dbo.CostAuthorityAgreement', 'ReclamationStagingCostAuthorityAgreement'

exec sp_rename 'dbo.CostAuthorityWorkBreakdownStructurePacificNorthActivityList', 'ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList'

exec sp_rename 'dbo.PacificNorthActivityType', 'ReclamationPacificNorthActivityType'

exec sp_rename 'dbo.PacificNorthActivityStatus', 'ReclamationPacificNorthActivityStatus'

exec sp_rename 'dbo.PacificNorthActivityList', 'ReclamationPacificNorthActivityList'


EXECUTE sp_rename N'dbo.ReclamationAgreement.ReclamationAgreementID', N'Original_ReclamationAgreementID', 'COLUMN' 
EXECUTE sp_rename N'dbo.ReclamationAgreement.AgreementID', N'ReclamationAgreementID', 'COLUMN' 
EXECUTE sp_rename N'dbo.ReclamationBasin.BasinID', N'ReclamationBasinID', 'COLUMN' 
EXECUTE sp_rename N'ReclamationContractType.ContractTypeID', N'ReclamationContractTypeID', 'COLUMN'
EXECUTE sp_rename N'ReclamationCostAuthority.CostAuthorityID', N'ReclamationCostAuthorityID', 'COLUMN'

EXECUTE sp_rename N'dbo.ReclamationDeliverable.ReclamationDeliverableID', N'Original_ReclamationDeliverableID', 'COLUMN' 
EXECUTE sp_rename N'dbo.ReclamationDeliverable.DeliverableID', N'ReclamationDeliverableID', 'COLUMN'
EXECUTE sp_rename N'dbo.ReclamationDeliverableType.DeliverableTypeID', N'ReclamationDeliverableTypeID', 'COLUMN'
EXECUTE sp_rename N'dbo.ReclamationHCategory.HabitatCategoryID', N'ReclamationHabitatCategoryID', 'COLUMN'
EXECUTE sp_rename N'dbo.ReclamationPacificNorthActivityList.PacificNorthActivityListID', N'ReclamationPacificNorthActivityListID', 'COLUMN'

EXECUTE sp_rename N'dbo.ReclamationPacificNorthActivityStatus.PacificNorthActivityStatusID', N'ReclamationPacificNorthActivityStatusID', 'COLUMN'
EXECUTE sp_rename N'dbo.ReclamationPacificNorthActivityType.PacificNorthActivityTypeID', N'ReclamationPacificNorthActivityTypeID', 'COLUMN'

execute sp_rename 'dbo.ReclamationPersonsTable', 'ReclamationStagingPersonsTable'

execute sp_rename 'dbo.ReclamationStagingCostAuthorityAgreement.ReclamationCostAuthorityAgreementID', 'OriginalReclamationCostAuthorityAgreementID'

EXECUTE sp_rename N'dbo.ReclamationStagingCostAuthorityAgreement.CostAuthorityAgreementID', N'ReclamationCostAuthorityAgreementID', 'COLUMN'


EXECUTE sp_rename N'dbo.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID', N'ReclamationCostAuthorityWorkBreakdownStructurePacificNorthActivityListID', 'COLUMN'


EXECUTE sp_rename N'dbo.ReclamationSubbasin.SubbasinID', N'ReclamationSubbasinID', 'COLUMN'

EXECUTE sp_rename N'dbo.ReclamationWorkBreakdownStructure.WorkBreakdownStructureID', N'ReclamationWorkBreakdownStructureID', 'COLUMN'

EXECUTE sp_rename N'dbo.ReclamationWorkOrder.WorkOrderID', N'ReclamationWorkOrderID', 'COLUMN'


exec sp_rename 'ReclamationHCategory.ReclamationHabitatCategoryID', 'ReclamationHCategoryID'
exec sp_rename 'ReclamationStagingCostAuthorityAgreement.ReclamationCostAuthorityAgreementID', 'ReclamationStagingCostAuthorityAgreementID'
exec sp_rename 'ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList.ReclamationCostAuthorityWorkBreakdownStructurePacificNorthActivityListID', 'ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID'
exec sp_rename 'ReclamationStagingPersonsTable.ReclamationPersonsTableID', 'ReclamationStagingPersonsTableID'




exec sp_rename 'PK_Agreement_AgreementID', 'PK_ReclamationAgreement_ReclamationAgreementID', 'OBJECT'
exec sp_rename 'PK_Basin_BasinID', 'PK_ReclamationBasin_ReclamationBasinID', 'OBJECT'
exec sp_rename 'PK_ContractType_ContractTypeID', 'PK_ReclamationContractType_ReclamationContractTypeID', 'OBJECT'
exec sp_rename 'PK_CostAuthority_CostAuthorityID', 'PK_ReclamationCostAuthority_ReclamationCostAuthorityID', 'OBJECT'
exec sp_rename 'PK_Deliverable_DeliverableID', 'PK_ReclamationDeliverable_ReclamationDeliverableID', 'OBJECT'
exec sp_rename 'PK_DeliverableType_DeliverableTypeID', 'PK_ReclamationDeliverableType_ReclamationDeliverableTypeID', 'OBJECT'
exec sp_rename 'PK_HabitatCategory_HabitatCategoryID', 'PK_ReclamationHCategory_ReclamationHCategoryID', 'OBJECT'
exec sp_rename 'PK_PacificNorthActivityList_PacificNorthActivityListID', 'PK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityListID', 'OBJECT'
exec sp_rename 'PK_PacificNorthActivityStatus_PacificNorthActivityStatusID', 'PK_ReclamationPacificNorthActivityStatus_ReclamationPacificNorthActivityStatusID', 'OBJECT'
exec sp_rename 'PK_PacificNorthActivityType_PacificNorthActivityTypeID', 'PK_ReclamationPacificNorthActivityType_ReclamationPacificNorthActivityTypeID', 'OBJECT'
exec sp_rename 'PK_CostAuthorityAgreement_CostAuthorityAgreementID', 'PK_ReclamationStagingCostAuthorityAgreement_ReclamationStagingCostAuthorityAgreementID', 'OBJECT'
exec sp_rename 'PK_CostAuthorityWorkBreakdownStructurePacificNorthActivityList_CostAuthorityWorkBreakdownStructurePacificNorthActivityListID', 'PK_ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList_ReclamationStagingCostAuthorityWorkBreakdownStr', 'OBJECT'
exec sp_rename 'PK_ReclamationPersonsTable_ReclamationPersonsTableID', 'PK_ReclamationStagingPersonsTable_ReclamationStagingPersonsTableID', 'OBJECT'
exec sp_rename 'PK_Subbasin_SubbasinID', 'PK_ReclamationSubbasin_ReclamationSubbasinID', 'OBJECT'
exec sp_rename 'PK_WorkBreakdownStructure_WorkBreakdownStructureID', 'PK_ReclamationWorkBreakdownStructure_ReclamationWorkBreakdownStructureID', 'OBJECT'
exec sp_rename 'PK_WorkOrder_WorkOrderID', 'PK_ReclamationWorkOrder_ReclamationWorkOrderID', 'OBJECT'


exec sp_rename 'FK_Agreement_Organization_OrganizationID', 'FK_ReclamationAgreement_Organization_OrganizationID', 'OBJECT'
exec sp_rename 'FK_CostAuthorityAgreement_Agreement_AgreementID', 'FK_ReclamationStagingCostAuthorityAgreement_ReclamationAgreement_AgreementID_ReclamationAgreementID', 'OBJECT'
exec sp_rename 'FK_CostAuthority_Basin_BasinID', 'FK_ReclamationCostAuthority_ReclamationBasin_BasinID_ReclamationBasinID', 'OBJECT'
exec sp_rename 'FK_Agreement_ContractType_ContractTypeID', 'FK_ReclamationAgreement_ReclamationContractType_ContractTypeID_ReclamationContractTypeID', 'OBJECT'
exec sp_rename 'FK_CostAuthorityAgreement_CostAuthority_CostAuthorityID', 'FK_ReclamationStagingCostAuthorityAgreement_ReclamationCostAuthority_CostAuthorityID_ReclamationCostAuthorityID', 'OBJECT'
exec sp_rename 'FK_Deliverable_DeliverableType_DeliverableTypeID', 'FK_ReclamationDeliverable_ReclamationDeliverableType_DeliverableTypeID_ReclamationDeliverableTypeID', 'OBJECT'
exec sp_rename 'FK_CostAuthority_HabitatCategory_HabitatCategoryID', 'FK_ReclamationCostAuthority_ReclamationHCategory_HabitatCategoryID_ReclamationHCategoryID', 'OBJECT'
exec sp_rename 'FK_CostAuthorityWorkBreakdownStructurePacificNorthActivityList_PacificNorthActivityList_PacificNorthActivityList', 'FK_ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList_ReclamationPacificNorthActivityList_PacificNort', 'OBJECT'
exec sp_rename 'FK_PacificNorthActivityList_PacificNorthActivityStatus_PacificNorthActivityStatusID', 'FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityStatus_PacificNorthActivityStatusID_ReclamationPacificNort', 'OBJECT'
exec sp_rename 'FK_PacificNorthActivityList_PacificNorthActivityType_PacificNorthActivityTypeID', 'FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityType_PacificNorthActivityTypeID_ReclamationPacificNorthAct', 'OBJECT'
exec sp_rename 'FK_Deliverable_CostAuthorityAgreement_CostAuthorityAgreementID', 'FK_ReclamationDeliverable_ReclamationStagingCostAuthorityAgreement_CostAuthorityAgreementID_ReclamationStagingCostAuthorityAgree', 'OBJECT'
exec sp_rename 'FK_CostAuthority_Subbasin_SubbasinID', 'FK_ReclamationCostAuthority_ReclamationSubbasin_SubbasinID_ReclamationSubbasinID', 'OBJECT'

