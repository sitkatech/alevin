SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deliverable](
	[DeliverableID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationDeliverableID] [int] NULL,
	[ReclamationCostAuthorityAgreementID] [int] NULL,
	[ReclamationAgreementStatusID] [int] NULL,
	[ReclamationDeliverableTypeID] [int] NULL,
	[Description] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DueDate] [datetime] NULL,
	[DateDelivered] [datetime] NULL,
	[IsTaskCompleted] [bit] NOT NULL,
	[IsTaskCanceled] [bit] NOT NULL,
	[ReclamationPersonsTableID] [int] NULL,
 CONSTRAINT [PK_Deliverable_DeliverableID] PRIMARY KEY CLUSTERED 
(
	[DeliverableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
