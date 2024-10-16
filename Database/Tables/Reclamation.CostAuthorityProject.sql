SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthorityProject](
	[CostAuthorityProjectID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[IsPrimaryProjectCawbs] [bit] NOT NULL,
	[PrimaryProjectCawbsUniqueString]  AS (case when [IsPrimaryProjectCawbs]=(1) then CONVERT([varchar](500),('ProjectID:'+CONVERT([varchar](500),[ProjectID]))+'-') else CONVERT([varchar](500),((('ProjectID:'+CONVERT([varchar](500),[ProjectID]))+'-')+'CostAuthorityID:')+CONVERT([varchar](500),[CostAuthorityID])) end),
 CONSTRAINT [PK_CostAuthorityProject_CostAuthorityProjectID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_CostAuthorityProject_CostAuthorityID_ProjectID] UNIQUE NONCLUSTERED 
(
	[CostAuthorityID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [Reclamation].[CostAuthorityProject]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityProject_CostAuthority_CostAuthorityID] FOREIGN KEY([CostAuthorityID])
REFERENCES [Reclamation].[CostAuthority] ([CostAuthorityID])
GO
ALTER TABLE [Reclamation].[CostAuthorityProject] CHECK CONSTRAINT [FK_CostAuthorityProject_CostAuthority_CostAuthorityID]
GO
ALTER TABLE [Reclamation].[CostAuthorityProject]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityProject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [Reclamation].[CostAuthorityProject] CHECK CONSTRAINT [FK_CostAuthorityProject_Project_ProjectID]