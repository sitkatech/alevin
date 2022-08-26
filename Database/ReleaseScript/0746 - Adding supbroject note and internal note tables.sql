CREATE TABLE [dbo].[SubprojectNote](
	[SubprojectNoteID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[Note] [varchar](8000) NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SubprojectNote_SubprojectNoteID] PRIMARY KEY CLUSTERED 
(
	[SubprojectNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Person_CreatePersonID_PersonID]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Person_CreatePersonID_TenantID_PersonID_TenantID]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Person_UpdatePersonID_PersonID]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Person_UpdatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([UpdatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Person_UpdatePersonID_TenantID_PersonID_TenantID]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Subproject_SubprojectID] FOREIGN KEY([SubprojectID])
REFERENCES [dbo].[Subproject] ([SubprojectID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Subproject_SubprojectID]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID])
REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Subproject_SubprojectID_TenantID]
GO

ALTER TABLE [dbo].[SubprojectNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectNote_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[SubprojectNote] CHECK CONSTRAINT [FK_SubprojectNote_Tenant_TenantID]
GO


CREATE TABLE [dbo].[SubprojectInternalNote](
	[SubprojectInternalNoteID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SubprojectID] [int] NOT NULL,
	[Note] [varchar](8000) NOT NULL,
	[CreatePersonID] [int] NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdatePersonID] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_SubprojectInternalNote_SubprojectInternalNoteID] PRIMARY KEY CLUSTERED 
(
	[SubprojectInternalNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Person_CreatePersonID_PersonID] FOREIGN KEY([CreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Person_CreatePersonID_PersonID]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Person_CreatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([CreatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Person_CreatePersonID_TenantID_PersonID_TenantID]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Person_UpdatePersonID_PersonID] FOREIGN KEY([UpdatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Person_UpdatePersonID_PersonID]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Person_UpdatePersonID_TenantID_PersonID_TenantID] FOREIGN KEY([UpdatePersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Person_UpdatePersonID_TenantID_PersonID_TenantID]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Subproject_SubprojectID] FOREIGN KEY([SubprojectID])
REFERENCES [dbo].[Subproject] ([SubprojectID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Subproject_SubprojectID]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Subproject_SubprojectID_TenantID] FOREIGN KEY([SubprojectID], [TenantID])
REFERENCES [dbo].[Subproject] ([SubprojectID], [TenantID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Subproject_SubprojectID_TenantID]
GO

ALTER TABLE [dbo].[SubprojectInternalNote]  WITH CHECK ADD  CONSTRAINT [FK_SubprojectInternalNote_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

ALTER TABLE [dbo].[SubprojectInternalNote] CHECK CONSTRAINT [FK_SubprojectInternalNote_Tenant_TenantID]
GO



Alter table dbo.Subproject
drop column Notes

