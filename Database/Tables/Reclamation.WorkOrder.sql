SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[WorkOrder](
	[ReclamationWorkOrderID] [int] IDENTITY(1,1) NOT NULL,
	[WorkOrderName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FiscalYear] [float] NULL,
	[WorkBreakdownStructureID] [int] NULL,
	[FUND] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FBMSSTATUS] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ETASSTATUS] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DEYSTATAUS] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_WorkOrder_ReclamationWorkOrderID] PRIMARY KEY CLUSTERED 
(
	[ReclamationWorkOrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
