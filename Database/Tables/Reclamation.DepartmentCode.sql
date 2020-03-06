SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Reclamation].[DepartmentCode](
	[ReclamationDepartmentCodeID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationDepartmentCodeName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ReclamationDepartmentCode_ReclamationDepartmentCodeID] PRIMARY KEY CLUSTERED 
(
	[ReclamationDepartmentCodeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
