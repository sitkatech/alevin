
CREATE TABLE [dbo].[ContractorList]
(
	[ContractorListID] [int] IDENTITY(1,1) NOT NULL constraint PK_ContractorList_ContractorListID primary key,
	[ReclamationContractorID] [float] NULL,
	[ContractorName] [nvarchar](255) NULL,
	[CompanyName] [nvarchar](255) NULL,
	[VendorNumber] [float] NULL,
	[Address1] [nvarchar](255) NULL,
	[Address2] [nvarchar](255) NULL,
	[City] [nvarchar](255) NULL,
	[State] [nvarchar](255) NULL,
	[Zip] [nvarchar](255) NULL,
	[ContactFirstName] [nvarchar](255) NULL,
	[ContactLastName] [nvarchar](255) NULL,
	[ContactPhone] [nvarchar](255) NULL,
	[ContactEmail] [nvarchar](255) NULL
) ON [PRIMARY]
GO


INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (1, N'A & K Investment', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (2, N'AES, An Employment Source', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (3, N'Anchor QEA, LLC', NULL, 71303357, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (4, N'Anderson Perry & Associates, Inc.', NULL, 70183665, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (5, N'BioMark, Inc', NULL, 70245730, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (6, N'Bonneville Power Administration', NULL, 20143697, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (7, N'Cascadia Conservation District', NULL, 70209207, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (8, N'CenturyTel Acquisition LLC', NULL, 70378087, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (9, N'CenturyTel of Washington, Inc', NULL, 70261240, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (10, N'CH2M Hill, Inc.', NULL, 71316803, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (11, N'Chelan County NRD', NULL, 70124754, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (12, N'Cross Agency Detail Agreement BPA & BOR', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (13, N'CTUIR', NULL, 70126751, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (14, N'Custer SWCD', NULL, 71345102, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (15, N'David Evans & Associates', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (16, N'Dell', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (17, N'DJ & A, P.C.', NULL, 71305031, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (18, N'DOI Solicitors Off Travel IA', NULL, 20143690, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (19, N'Express Services Inc', NULL, 70116820, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (20, N'Falcon Cable Communication, LLC / Charter Communications', NULL, 71343939, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (21, N'Frontier Communications Co', NULL, 70086371, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (22, N'Geographic Information Systems, Inc', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (23, N'GMR Ariel Surveys', NULL, 70194559, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (24, N'Grant SWCD', NULL, 70008285, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (25, N'Hach Company', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (26, N'ICF Jones & Stokes', NULL, 70148916, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (27, N'Idaho Power', NULL, 70410126, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (28, N'Idaho Power EF Flow Monitoring', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (29, N'Infrared Baron, INC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (30, N'Jude Trapani', NULL, 40003639, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (31, N'LARSON SKYLINE FARMS', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (32, N'LEMOYNE APRAISAL, LLC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (33, N'Lotek Wireless, Inc.', NULL, 70302684, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (34, N'Lucy Littlejohn', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (35, N'MBO Partners', NULL, 71344523, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (36, N'Meckel Engineering & Survey', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (37, N'MSRF', NULL, 70068577, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (38, N'NOAA', N'Dept of Commerce', 20143609, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (39, N'North Wind, Inc.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (40, N'ODFW', NULL, 70237131, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (41, N'Omnii Controls, Inc', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (42, N'Oregon State University', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (43, N'Oval Peak, LLC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (44, N'Pacific Geomatic Services, Inc.', NULL, 70317253, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (45, N'Pam Baldwin', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (46, N'Portage, Inc', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (47, N'Portland State Univerisity', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (48, N'DOJ - Horton', NULL, 20143560, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (105, N'Salmon Environmental Services', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (106, N'Sanborn Map Company, Inc.', NULL, 70093001, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (107, N'SHI International Corp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (108, N'Water District 1, State of Idaho', NULL, 71317328, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (109, N'Water District 65, State of Idaho', NULL, 71344682, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (110, N'Sue Camp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (111, N'Summation - US GPO - Data One', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (112, N'Synergy Northwest, LLC', NULL, 71344445, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (113, N'Terraqua, Inc.', NULL, 71344146, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (114, N'Trimble Navigation Ltd,', NULL, 70056381, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (115, N'Trout Unlimited', NULL, 70005640, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (152, N'Twisp Public Development Authority', NULL, 71343862, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (153, N'Union County 4H & Extension Service', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (154, N'Union SWCD', NULL, 70651494, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (155, N'University of Idaho', NULL, 70178905, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (156, N'US ARMY CORP of ENGINEERS', NULL, 20143575, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (157, N'US FOREST SERVICE', NULL, 20146708, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (158, N'US FISH AND WILDLIFE', NULL, 20143653, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (159, N'US GEOLOGICAL SURVEY', NULL, 20143632, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (160, N'Verizon California Inc.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (161, N'Virtural Enterprises, Pam Massey', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (162, N'Water District 63, State of Idaho', NULL, 71345196, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (163, N'Idaho Department of Water Resources', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (164, N'Watershed Resource Solutions', NULL, 70452674, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (165, N'Wenatchee Office Lease', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (166, N'WH Pacific, Inc', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (167, N'WoolPert, Inc.', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (168, N'Xerox Corporation', NULL, 70388658, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (169, N'Yakama Nation', NULL, 70038935, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (170, N'YSI Incorporated', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (171, N'Zeffi Corp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (172, N'Tetra Tech', N'Dick', 71339852, N'19803 N CREEK PKWY', NULL, N'BOTHELL', N'WA', NULL, N'Vance', N'McGowan', NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (173, N'Cardno-Entrix', NULL, 71305031, N'200 1st Ave W', N'STE 500', N'Seattle', N'WA', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (175, N'Inter-Fluve, Inc.', NULL, 70427047, N'1020 Wasco St', N'STE 1', N'Hood River', N'OR', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (176, N'ProPeople Staffing Services, Inc', NULL, 70188725, N'10148 Emerald St.', N'#100', N'Boise', N'ID', N'83704-0676', N'Ann', N'McGregor', N'208-345-5747', NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (179, N'TSC - Denver Technical Services Center', N'Denver Technical Service Center', 20143610, NULL, NULL, N'Denver', N'CO', NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (180, N'CDW Governmet LLC', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'800-800-4239', NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (181, N'Chelan Douglas Land Trust', N'Chelan Douglas Land Trust', 70382924, N'P.O. Box 4461', N'18 North Wenatchee Avenue', N'Wenatchee', N'WA', N'98807', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (182, N'NPS', N'National Park Service', NULL, N'Structural Fire', N'3800 S Development Way', N'Boise', N'ID', N'83705', N'Harold', N'Spencer', NULL, N'Harold_Spencer@nps.gov')
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (183, N'CCFEG', N'CASCADE COLUMBIA FISHERIES ENHANCEMENT GRP', 70190659, N'25 N Wenatchee Ave', N'Suite 206', N'Wenatchee', N'WA', N'98801', N'Matt', N'Shales', N'509-888-7268', N'mshales@ccfeg.org')
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (184, N'DLT Solutions LLC', NULL, 70391206, NULL, NULL, N'Herndon', N'VA', N'20171-6126', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (185, N'Frankie Friend & Associates, Inc', NULL, 70145708, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (186, N'Softree Technical Systems, Inc', NULL, 70305305, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (187, N'Washington Water Trust', NULL, 71355538, N'1530 Westlake Ave N #400', NULL, N'Seattle', N'WA', N'98109', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (188, N'DOI Solicitor BOI', NULL, 20000337, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (189, N'Sitka Technology Group, LLC', N'Sitka Technology Group, LLC', 70976821, N'309 SW 6th Ave', N'Suite 575', N'Portland', N'OR', N'97204-1763', N'Damon', N'Hess', NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (190, N'Qcoherent Software, LLC', NULL, 70469787, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (191, N'Arrow Enterprise Corp', NULL, 70784602, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (193, N'Washington State University', N'School of the Environment', 70401297, N'PO Box 641025', N'Fulmer Hall Rm 204C', N'Pullman', N'WA', N'99164', N'Alex', N'Fremier, Dr', N'509-335-8689', N'alex.fremier@wsu.edu')
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (194, N'RTS - PNR Resource and Technical Services Grp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (195, N'US DEPT OF JUSTICE', NULL, 20143560, N'601 D Street NW', NULL, N'Washington', N'DC', N'20530', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (196, N'Relocation Management', NULL, 70096017, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (197, N'John Simpson', NULL, 40073486, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (198, N'Krohn, Nate', NULL, 40128366, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (199, N'Northwest Marine Technology, Inc.', N'Northwest Marine Technology, Inc.', 70110342, N'976 Ben Nevis Loop', NULL, N'Shaw Island', N'WA', N'98286', NULL, NULL, N'360-468-3375', NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (200, N'Better Direct, LLC', NULL, 70344986, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (201, N'Idaho State University', NULL, 70197620, N'921 S. 8th Ave, Stop 8046', NULL, N'Pocatello', N'ID', N'83209-8046', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (202, N'US Dept of Agriculture', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (203, N'Office of Species Conservation', N'OSC', 70237665, N'304 N 8th Street', N'Suite 149', N'Boise', N'ID', N'83702', N'Mike', N'Edmondson', N'208-334-2189', N'mike.edmondson@osc.idaho.gov')
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (204, N'University of Washington', NULL, 70414043, N'4333 Brooklyn Ave NE', NULL, N'Seattle', N'WA', N'98195-9472', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (205, N'Cartridge Technologies, Inc.', NULL, NULL, N'15738 Crabbs Branch Way', NULL, N'Rockville', N'MD', N'20855-2620', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (206, N'Sterling Computers Corportation', NULL, 70208544, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (207, N'Tesla Energy Solutions, Inc.', NULL, 71363665, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (208, N'CounterTrade Products, Inc.', NULL, 70263832, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (209, N'Northwest Rescue, Inc.', NULL, 71388845, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (210, N'DOI Solicitor BOI Jeremiah', NULL, 2000337, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (211, N'STERLING COMPUTERS CORPORATION', NULL, 70208544, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (212, N'AXXON INTERNATIONAL, LLC', NULL, 71309142, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (213, N'J.C. TECHNOLOGY, INC.', NULL, 70011344, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (214, N'CDW GOVERNMENT LLC', NULL, 70281644, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (216, N'Washington Dept. of Fish & Wildlife', N'Washington Dept. of Fish & Wildlife', 70061201, N'600 CAPITAL WAY N', NULL, N'Olympia', N'WA', N'98501-1076', N'Jeremy', N'Cram', NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (217, N'Alamo City Engineering Services, Inc.', N'Alamo City Engineering Services, Inc.', 70259873, N'4115 Medical Drive', N'Suite 203', N'San Antonio', N'TX', N'78229-5635', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[ContractorList] ([ReclamationContractorID], [ContractorName], [CompanyName], [VendorNumber], [Address1], [Address2], [City], [State], [Zip], [ContactFirstName], [ContactLastName], [ContactPhone], [ContactEmail]) VALUES (218, N'B&H International', NULL, 71362697, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
