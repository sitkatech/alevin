SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReclamationStagingContractStatus](
	[ReclamationStagingContractStatusID] [int] NOT NULL,
	[ReclamationStagingContractStatusName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Steps] [int] NULL,
	[ReclamationStagingContractStatusType] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationStagingContractStatus_ReclamationStagingContractStatusID] PRIMARY KEY CLUSTERED 
(
	[ReclamationStagingContractStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
