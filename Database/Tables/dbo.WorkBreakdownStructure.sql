SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkBreakdownStructure](
	[WorkBreakdownStructureID] [int] IDENTITY(1,1) NOT NULL,
	[WorkBreakdownStructureNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_WorkBreakdownStructure_WorkBreakdownStructureID] PRIMARY KEY CLUSTERED 
(
	[WorkBreakdownStructureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
