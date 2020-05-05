Update Reclamation.CostAuthority 
set 
    WBSNoDot = 'RX167868203000100',
    BasinID = 5
    where CostAuthorityID = 201

Update Reclamation.ReclamationStagingCostAuthorityAgreement set CostAuthorityID = 201 where CostAuthorityID = 455

Delete from Reclamation.CostAuthority where CostAuthorityID = 455

--select * from Reclamation.CostAuthority where CostAuthorityWorkBreakdownStructure = 'RX.16786820.3000100'