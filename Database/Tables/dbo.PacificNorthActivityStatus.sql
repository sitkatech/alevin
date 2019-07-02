SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PacificNorthActivityStatus](
	[PacificNorthActivityStatusID] [int] IDENTITY(1,1) NOT NULL,
	[PacificNorthActivityStatusName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_PacificNorthActivityStatus_PacificNorthActivityStatusID] PRIMARY KEY CLUSTERED 
(
	[PacificNorthActivityStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
