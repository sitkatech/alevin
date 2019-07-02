SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PacificNorthActivityList](
	[PacificNorthActivityListID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SortOrder] [int] NULL,
	[PacificNorthActivityTypeID] [int] NULL,
	[PacificNorthActivityStatusID] [int] NULL,
 CONSTRAINT [PK_PacificNorthActivityList_PacificNorthActivityListID] PRIMARY KEY CLUSTERED 
(
	[PacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PacificNorthActivityList]  WITH CHECK ADD  CONSTRAINT [FK_PacificNorthActivityList_PacificNorthActivityStatus_PacificNorthActivityStatusID] FOREIGN KEY([PacificNorthActivityStatusID])
REFERENCES [dbo].[PacificNorthActivityStatus] ([PacificNorthActivityStatusID])
GO
ALTER TABLE [dbo].[PacificNorthActivityList] CHECK CONSTRAINT [FK_PacificNorthActivityList_PacificNorthActivityStatus_PacificNorthActivityStatusID]
GO
ALTER TABLE [dbo].[PacificNorthActivityList]  WITH CHECK ADD  CONSTRAINT [FK_PacificNorthActivityList_PacificNorthActivityType_PacificNorthActivityTypeID] FOREIGN KEY([PacificNorthActivityTypeID])
REFERENCES [dbo].[PacificNorthActivityType] ([PacificNorthActivityTypeID])
GO
ALTER TABLE [dbo].[PacificNorthActivityList] CHECK CONSTRAINT [FK_PacificNorthActivityList_PacificNorthActivityType_PacificNorthActivityTypeID]