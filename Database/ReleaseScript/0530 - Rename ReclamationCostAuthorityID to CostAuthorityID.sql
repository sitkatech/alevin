--select * from Reclamation.CostAuthority
--select * from Reclamation.CostAuthorityProject

--begin tran

DROP INDEX [IX_ReclamationCostAuthorityProject_PrimaryCawbsUniqueString] ON [Reclamation].[CostAuthorityProject]
GO

alter table Reclamation.CostAuthorityProject
drop column [PrimaryProjectCawbsUniqueString]
GO

sp_rename 'Reclamation.CostAuthorityProject.ReclamationCostAuthorityID', 'CostAuthorityID'
GO

select * from Reclamation.CostAuthorityProject
GO

ALTER TABLE Reclamation.CostAuthorityProject 
ADD [PrimaryProjectCawbsUniqueString]  AS 
(case when [IsPrimaryProjectCawbs]=(1) then CONVERT([varchar](500),('ProjectID:'+CONVERT([varchar](500),[ProjectID]))+'-') else CONVERT([varchar](500),((('ProjectID:'+CONVERT([varchar](500),[ProjectID]))+'-')+'CostAuthorityID:')+CONVERT([varchar](500),[CostAuthorityID])) end)
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_ReclamationCostAuthorityProject_PrimaryCawbsUniqueString] ON [Reclamation].[CostAuthorityProject]
(
    [PrimaryProjectCawbsUniqueString] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

--rollback tran