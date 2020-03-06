SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthorityProject](
	[ReclamationCostAuthorityProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationCostAuthorityID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[IsPrimaryProjectCawbs] [bit] NOT NULL,
	[PrimaryProjectCawbsUniqueString]  AS (case when [IsPrimaryProjectCawbs]=(1) then CONVERT([varchar](500),('ProjectID:'+CONVERT([varchar](500),[ProjectID]))+'-') else CONVERT([varchar](500),((('ProjectID:'+CONVERT([varchar](500),[ProjectID]))+'-')+'ReclamationCostAuthorityID:')+CONVERT([varchar](500),[ReclamationCostAuthorityID])) end),
 CONSTRAINT [PK_CostAuthorityProject_ReclamationCostAuthorityProjectID] PRIMARY KEY CLUSTERED 
(
	[ReclamationCostAuthorityProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_CostAuthorityProject_ReclamationCostAuthorityID_ProjectID] UNIQUE NONCLUSTERED 
(
	[ReclamationCostAuthorityID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ReclamationCostAuthorityProject_PrimaryCawbsUniqueString] ON [Reclamation].[CostAuthorityProject]
(
	[PrimaryProjectCawbsUniqueString] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [Reclamation].[CostAuthorityProject]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityProject_CostAuthority_ReclamationCostAuthorityID] FOREIGN KEY([ReclamationCostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([ReclamationCostAuthorityID])
GO
ALTER TABLE [Reclamation].[CostAuthorityProject] CHECK CONSTRAINT [FK_CostAuthorityProject_CostAuthority_ReclamationCostAuthorityID]
GO
ALTER TABLE [Reclamation].[CostAuthorityProject]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityProject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [Reclamation].[CostAuthorityProject] CHECK CONSTRAINT [FK_CostAuthorityProject_Project_ProjectID]