
CREATE TABLE [dbo].[ReclamationStagingContractStatus]
(
    [ReclamationStagingContractStatusID] [int] NOT NULL constraint PK_ReclamationStagingContractStatus_ReclamationStagingContractStatusID primary key,
    [ReclamationStagingContractStatusName] [nvarchar](255) NULL,
    [Steps] [int] NULL,
    [ReclamationStagingContractStatusType] [nvarchar](255) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (7, N'Closed / Completed', 8, N'Closed / Completed')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (6, N'Approved / Funds Obligated', 7, N'Approved / Awarded')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (5, N'Awaiting Contractor''s Signature', 6, N'In Process')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (4, N'Contract Review Completed', 5, N'In Process')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (2, N'Out for External Review', 4, N'In Process')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (20, N'Accquisition Package and Checklist submitted', 2, N'In Process')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (3, N'Requistion Created', 2, N'In Process')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (1, N'SOW & Budget Received CSRO', 1, N'In Process')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (19, N'Deobligation Requested', NULL, N'Awatining Action')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (18, N'Deobligation Completded', NULL, N'Closed / Completed')
GO
INSERT [dbo].[ReclamationStagingContractStatus] ([ReclamationStagingContractStatusID], [ReclamationStagingContractStatusName], [Steps], [ReclamationStagingContractStatusType]) VALUES (14, N'SA Approved', NULL, N'Approved / Awarded')
GO
