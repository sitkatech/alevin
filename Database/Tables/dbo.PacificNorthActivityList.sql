SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PacificNorthActivityList](
	[PacificNorthActivityListID] [int] IDENTITY(1,1) NOT NULL,
	[ActivityID] [int] NULL,
	[PacificNorthActivityName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PacificNorthActivityType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PacificNorthActivityStatus] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_PacificNorthActivityList_PacificNorthActivityListID] PRIMARY KEY CLUSTERED 
(
	[PacificNorthActivityListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
