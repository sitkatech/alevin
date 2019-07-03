SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CostAuthorityWorkBreakdownStructurePacificNorthActivityList](
	[CostAuthorityWorkBreakdownStructurePacificNorthActivityListID] [int] IDENTITY(1,1) NOT NULL,
	[CostAuthorityWorkBreakdownStructure] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ActivityID] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ESABiOpIDNumber] [int] NULL,
	[PacificNorthActivityListID] [int] NULL,
 CONSTRAINT [PK_CostAuthorityWorkBreakdownStructurePacificNorthActivityList_CostAuthorityWorkBreakdownStructurePacificNorthActivityListID] PRIMARY KEY CLUSTERED 
(
	[CostAuthorityWorkBreakdownStructurePacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CostAuthorityWorkBreakdownStructurePacificNorthActivityList]  WITH CHECK ADD  CONSTRAINT [FK_CostAuthorityWorkBreakdownStructurePacificNorthActivityList_PacificNorthActivityList_PacificNorthActivityList] FOREIGN KEY([PacificNorthActivityListID])
REFERENCES [dbo].[PacificNorthActivityList] ([PacificNorthActivityListID])
GO
ALTER TABLE [dbo].[CostAuthorityWorkBreakdownStructurePacificNorthActivityList] CHECK CONSTRAINT [FK_CostAuthorityWorkBreakdownStructurePacificNorthActivityList_PacificNorthActivityList_PacificNorthActivityList]