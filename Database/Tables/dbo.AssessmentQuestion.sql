SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssessmentQuestion](
	[AssessmentQuestionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AssessmentSubGoalID] [int] NOT NULL,
	[AssessmentQuestionText] [varchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ArchiveDate] [date] NULL,
 CONSTRAINT [PK_AssessmentQuestion_AssessmentQuestionID] PRIMARY KEY CLUSTERED 
(
	[AssessmentQuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentQuestion_AssessmentQuestionID_TenantID] UNIQUE NONCLUSTERED 
(
	[AssessmentQuestionID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_AssessmentQuestion_AssessmentQuestionText_TenantID] UNIQUE NONCLUSTERED 
(
	[AssessmentQuestionText] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID] FOREIGN KEY([AssessmentSubGoalID])
REFERENCES [dbo].[AssessmentSubGoal] ([AssessmentSubGoalID])
GO
ALTER TABLE [dbo].[AssessmentQuestion] CHECK CONSTRAINT [FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID]
GO
ALTER TABLE [dbo].[AssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID_TenantID] FOREIGN KEY([AssessmentSubGoalID], [TenantID])
REFERENCES [dbo].[AssessmentSubGoal] ([AssessmentSubGoalID], [TenantID])
GO
ALTER TABLE [dbo].[AssessmentQuestion] CHECK CONSTRAINT [FK_AssessmentQuestion_AssessmentSubGoal_AssessmentSubGoalID_TenantID]
GO
ALTER TABLE [dbo].[AssessmentQuestion]  WITH CHECK ADD  CONSTRAINT [FK_AssessmentQuestion_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AssessmentQuestion] CHECK CONSTRAINT [FK_AssessmentQuestion_Tenant_TenantID]