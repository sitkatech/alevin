SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[CostAuthority](
	[CostAuthorityID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostAuthorityNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountStructureDescription] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CostCenter] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgencyProjectType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Authority] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Job] [nvarchar](3) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Number] [nvarchar](4) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[JobNumber] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[WBSStatus] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HCategoryLU] [float] NULL,
	[WBSNoDot] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HabitatCategoryID] [int] NULL,
	[BasinID] [int] NULL,
	[SubbasinID] [int] NULL,
	[TaxonomyLeafID] [int] NOT NULL,
 CONSTRAINT [PK_CostAuthority_CostAuthorityID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthority_Basin_BasinID] FOREIGN KEY([BasinID])
REFERENCES [Reclamation].[Basin] ([BasinID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_CostAuthority_Basin_BasinID]
GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthority_HCategory_HabitatCategoryID_HCategoryID] FOREIGN KEY([HabitatCategoryID])
REFERENCES [Reclamation].[HCategory] ([HCategoryID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_CostAuthority_HCategory_HabitatCategoryID_HCategoryID]
GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthority_Subbasin_SubbasinID] FOREIGN KEY([SubbasinID])
REFERENCES [Reclamation].[Subbasin] ([SubbasinID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_CostAuthority_Subbasin_SubbasinID]
GO
ALTER TABLE [Reclamation].[CostAuthority]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthority_TaxonomyLeaf_TaxonomyLeafID] FOREIGN KEY([TaxonomyLeafID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID])
GO
ALTER TABLE [Reclamation].[CostAuthority] CHECK CONSTRAINT [FK_CostAuthority_TaxonomyLeaf_TaxonomyLeafID]