SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectUpdateSection](
	[ProjectUpdateSectionID] [int] NOT NULL,
	[ProjectUpdateSectionName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectUpdateSectionDisplayName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NOT NULL,
	[HasCompletionStatus] [bit] NOT NULL,
	[ProjectWorkflowSectionGroupingID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectUpdateSection_ProjectUpdateSectionID] PRIMARY KEY CLUSTERED 
(
	[ProjectUpdateSectionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateSection_ProjectUpdateSectionDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateSectionDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_ProjectUpdateSection_ProjectUpdateSectionName] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateSectionName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectUpdateSection]  WITH CHECK ADD  CONSTRAINT [FK_ProjectUpdateSection_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingID] FOREIGN KEY([ProjectWorkflowSectionGroupingID])
REFERENCES [dbo].[ProjectWorkflowSectionGrouping] ([ProjectWorkflowSectionGroupingID])
GO
ALTER TABLE [dbo].[ProjectUpdateSection] CHECK CONSTRAINT [FK_ProjectUpdateSection_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingID]