SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonGuid] [uniqueidentifier] NOT NULL,
	[FirstName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Email] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Phone] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PasswordPdfK2SaltHash] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RoleID] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[LastActivityDate] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[ReceiveSupportEmails] [bit] NOT NULL,
	[WebServiceAccessToken] [uniqueidentifier] NULL,
	[LoginName] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ReclamationStaffID] [int] NULL,
	[ReclamationLocationID] [int] NULL,
	[ReclamationDepartmentCodeID] [int] NULL,
	[ReclamationRTSContact] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Person_PersonID] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_Person_Email_TenantID] UNIQUE NONCLUSTERED 
(
	[Email] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_Person_PersonGuid_TenantID] UNIQUE NONCLUSTERED 
(
	[PersonGuid] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_Person_PersonID_TenantID] UNIQUE NONCLUSTERED 
(
	[PersonID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_DepartmentCode_ReclamationDepartmentCodeID_DepartmentCodeID] FOREIGN KEY([ReclamationDepartmentCodeID])
REFERENCES [Reclamation].[DepartmentCode] ([DepartmentCodeID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_DepartmentCode_ReclamationDepartmentCodeID_DepartmentCodeID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Location_ReclamationLocationID_LocationID] FOREIGN KEY([ReclamationLocationID])
REFERENCES [Reclamation].[Location] ([LocationID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Location_ReclamationLocationID_LocationID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Role_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Role_RoleID]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Tenant_TenantID]