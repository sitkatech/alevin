SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthority](
	[ReclamationCostAuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostAuthorityNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountStructureDescription] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostCenter] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgencyProjectType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JobNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authority] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSStatus] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HCategoryLU] [float] NULL,
	[WBSNoDot] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HabitatCategoryID] [int] NULL,
	[BasinID] [int] NULL,
	[SubbasinID] [int] NULL,
 CONSTRAINT [PK_ReclamationCostAuthority_ReclamationCostAuthorityID] PRIMARY KEY CLUSTERED 
(
	[ReclamationCostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthority_ReclamationBasin_BasinID_ReclamationBasinID] FOREIGN KEY([BasinID])
REFERENCES [Reclamation].[Basin] ([ReclamationBasinID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_ReclamationCostAuthority_ReclamationBasin_BasinID_ReclamationBasinID]
GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthority_ReclamationHCategory_HabitatCategoryID_ReclamationHCategoryID] FOREIGN KEY([HabitatCategoryID])
REFERENCES [Reclamation].[HCategory] ([ReclamationHCategoryID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_ReclamationCostAuthority_ReclamationHCategory_HabitatCategoryID_ReclamationHCategoryID]
GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthority_ReclamationSubbasin_SubbasinID_ReclamationSubbasinID] FOREIGN KEY([SubbasinID])
REFERENCES [Reclamation].[Subbasin] ([ReclamationSubbasinID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_ReclamationCostAuthority_ReclamationSubbasin_SubbasinID_ReclamationSubbasinID]