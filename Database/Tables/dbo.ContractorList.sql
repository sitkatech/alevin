SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractorList](
	[ContractorListID] [int] IDENTITY(1,1) NOT NULL,
	[ReclamationContractorID] [float] NULL,
	[ContractorName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CompanyName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[VendorNumber] [float] NULL,
	[Address1] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address2] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[State] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Zip] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactFirstName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactLastName] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactPhone] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactEmail] [nvarchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ContractorList_ContractorListID] PRIMARY KEY CLUSTERED 
(
	[ContractorListID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
