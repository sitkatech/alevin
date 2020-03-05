SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationPacificNorthActivityList](
	[ReclamationPacificNorthActivityListID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SortOrder] [int] NULL,
	[PacificNorthActivityTypeID] [int] NULL,
	[PacificNorthActivityStatusID] [int] NULL,
 CONSTRAINT [PK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityListID] PRIMARY KEY CLUSTERED 
(
	[ReclamationPacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [Reclamation].[ReclamationPacificNorthActivityList]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityStatus_PacificNorthActivityStatusID_ReclamationPacificNort] FOREIGN KEY([PacificNorthActivityStatusID])
REFERENCES [Reclamation].[ReclamationPacificNorthActivityStatus] ([ReclamationPacificNorthActivityStatusID])
GO
ALTER TABLE [Reclamation].[ReclamationPacificNorthActivityList] CHECK CONSTRAINT [FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityStatus_PacificNorthActivityStatusID_ReclamationPacificNort]
GO
ALTER TABLE [Reclamation].[ReclamationPacificNorthActivityList]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityType_PacificNorthActivityTypeID_ReclamationPacificNorthAct] FOREIGN KEY([PacificNorthActivityTypeID])
REFERENCES [Reclamation].[ReclamationPacificNorthActivityType] ([ReclamationPacificNorthActivityTypeID])
GO
ALTER TABLE [Reclamation].[ReclamationPacificNorthActivityList] CHECK CONSTRAINT [FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityType_PacificNorthActivityTypeID_ReclamationPacificNorthAct]