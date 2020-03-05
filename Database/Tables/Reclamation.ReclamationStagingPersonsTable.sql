SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationStagingPersonsTable](
	[ReclamationStagingPersonsTableID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationStaffID] [int] NULL,
	[FirstName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Location] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DeptartmentCode] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RTSContact] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationStagingPersonsTable_ReclamationStagingPersonsTableID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingPersonsTableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
