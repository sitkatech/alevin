SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList](
	[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActivityID] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ESABiOpIDNumber] [int] NULL,
	[PacificNorthActivityListID] [int] NULL,
 CONSTRAINT [PK_ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList_ReclamationStagingCostAuthorityWorkBreakdownStr] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList_ReclamationPacificNorthActivityList_PacificNort] FOREIGN KEY([PacificNorthActivityListID])
REFERENCES [Reclamation].[ReclamationPacificNorthActivityList] ([ReclamationPacificNorthActivityListID])
GO
ALTER TABLE [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList] CHECK CONSTRAINT [FK_ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList_ReclamationPacificNorthActivityList_PacificNort]