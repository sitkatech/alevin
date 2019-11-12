SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationCostAuthorityProject](
	[ReclamationCostAuthorityProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationCostAuthorityID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
 CONSTRAINT [PK_ReclamationCostAuthorityProject_ReclamationCostAuthorityProjectID] PRIMARY KEY CLUSTERED 
(
	[ReclamationCostAuthorityProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ReclamationCostAuthorityProject_ReclamationCostAuthorityID_ProjectID] UNIQUE NONCLUSTERED 
(
	[ReclamationCostAuthorityID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ReclamationCostAuthorityProject]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthorityProject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ReclamationCostAuthorityProject] CHECK CONSTRAINT [FK_ReclamationCostAuthorityProject_Project_ProjectID]
GO
ALTER TABLE [dbo].[ReclamationCostAuthorityProject]  WITH CHECK ADD  CONSTRAINT [FK_ReclamationCostAuthorityProject_ReclamationCostAuthority_ReclamationCostAuthorityID] FOREIGN KEY([ReclamationCostAuthorityID])
REFERENCES [dbo].[ReclamationCostAuthority] ([ReclamationCostAuthorityID])
GO
ALTER TABLE [dbo].[ReclamationCostAuthorityProject] CHECK CONSTRAINT [FK_ReclamationCostAuthorityProject_ReclamationCostAuthority_ReclamationCostAuthorityID]