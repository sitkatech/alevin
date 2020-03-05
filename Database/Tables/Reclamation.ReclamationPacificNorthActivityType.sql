SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[ReclamationPacificNorthActivityType](
	[ReclamationPacificNorthActivityTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PacificNorthActivityTypeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationPacificNorthActivityType_ReclamationPacificNorthActivityTypeID] PRIMARY KEY CLUSTERED 
(
	[ReclamationPacificNorthActivityTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
