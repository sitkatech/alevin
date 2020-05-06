--begin tran

Update Reclamation.CostAuthority 
set 
    WBSNoDot = 'RX167868203000100',
    BasinID = 5
    where CostAuthorityID = 201
GO

Update Reclamation.ReclamationStagingCostAuthorityAgreement set CostAuthorityID = 201 where CostAuthorityID = 455
GO

update ImportFinancial.WbsElementObligationItemInvoice  set CostAuthorityID = 201 where CostAuthorityID = 455
GO

update ImportFinancial.WbsElementObligationItemBudget  set CostAuthorityID = 201 where CostAuthorityID = 455
GO

Delete from Reclamation.CostAuthority where CostAuthorityID = 455
GO

ALTER TABLE [Reclamation].[CostAuthority] ADD  CONSTRAINT [AK_CostAuthority_CostAuthorityWorkBreakdownStructure] UNIQUE NONCLUSTERED 
(
    [CostAuthorityWorkBreakdownStructure] ASC
) ON [PRIMARY]
GO

--rollback tran

--select * from Reclamation.CostAuthority where CostAuthorityWorkBreakdownStructure = 'RX.16786820.3000100'