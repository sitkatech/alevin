
CREATE TABLE [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
(
	[BOC_Category] [nvarchar](50) NULL,
	[BOC_Item] [nvarchar](100) NULL,
	[Group] [float] NULL,
	[2004] [nvarchar](50) NULL,
	[2005] [nvarchar](50) NULL,
	[2006] [nvarchar](50) NULL,
	[2010] [nvarchar](50) NULL,
	[2011] [nvarchar](50) NULL,
	[FBMS_2014] [nvarchar](50) NULL,
	[FBMS_2015] [nvarchar](50) NULL,
	[FBMS_2016] [nvarchar](50) NULL,
	[FBMS_2017] [nvarchar](50) NULL,
	[Definitions] [nvarchar](450) NULL,
	[1099_Reportable] [nvarchar](50) NULL,
	[1099_Explanation] [nvarchar](50) NULL,
	[Expired] [nvarchar](50) NULL,
	[Closed] [nvarchar](200) NOT NULL,
	[Column1] [nvarchar](50) NULL
) ON [PRIMARY]
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1]) 
VALUES (N'Personnel Compensation and Benefits', NULL, 10, NULL, NULL, NULL, NULL, NULL, N'100000', N'100000', N'100000', N'100000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1]) 
VALUES (N'Personnel Compensation', NULL, 11, NULL, NULL, NULL, NULL, NULL, N'110000', N'110000', N'110000', N'110000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Full-Time Permanent', NULL, 11.1, NULL, NULL, NULL, NULL, NULL, N'111000', N'111000', N'111000', N'111000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Other Than Full-Time Permanent', NULL, 11.3, NULL, NULL, NULL, NULL, NULL, N'113000', N'113000', N'113000', N'113000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Other Personnel Compensation', NULL, 11.5, NULL, NULL, NULL, NULL, NULL, N'115000', N'115000', N'115000', N'115000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Special Personal Services Payments', NULL, 11.8, NULL, NULL, NULL, NULL, NULL, N'118000', N'118000', N'118000', N'118000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Total Personnel Compensation ', NULL, 11.9, NULL, NULL, NULL, NULL, NULL, N'119000', N'119000', N'119000', N'119000', NULL, NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Personnel Benefits', NULL, 12, NULL, NULL, NULL, NULL, NULL, N'120000', N'120000', N'120000', N'120000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Civilian Personnel Benefits', NULL, 12.1, NULL, NULL, NULL, NULL, NULL, N'121000', N'121000', N'121000', N'121000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Contractual Services and Supplies', NULL, 20, NULL, NULL, NULL, NULL, NULL, N'200000', N'200000', N'200000', N'200000', NULL, NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Travel and Transportation of Persons', NULL, 21, NULL, NULL, NULL, NULL, NULL, N'210000', N'210000', N'210000', N'210000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Non-Foreign Travel', NULL, 21.1, NULL, NULL, NULL, NULL, NULL, N'211000', N'211000', N'211000', N'211000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Non-Foreign Travel', NULL, NULL, NULL, N'2110', N'2110', N'2110', N'2110', N'211O00', NULL, NULL, N'Use of contracts to transport employees from place to place by land, air, or water.  Deleted.', NULL, NULL, N'12/31/2014', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Non-Foreign TDY Local Travel 11/16/2017 voted to delete.', NULL, N'211L', N'211L', N'211L', N'211L', N'211L', N'211L00', N'211L00', N'211L00', N'211L00', N'Local travel and transportation of persons by local transit systems (e.g. subway, bus, light rail) in and around the TDY location of a traveler.  Only for official TDY travel.  See BOC 214L00 for Local Travel at Official Duty Station. Deleted.', N'No', N'Employee Travel - will never be 1099 eligible', N'11/27/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Foreign - TDY Local Travel 11/16/2017 voted to delete.', NULL, N'212L', N'212L', N'212L', N'212L', N'212L', N'212L00', N'212L00', N'212L00', N'212L00', N'Local travel and transportation of persons in and around the TDY location of an employee. Deleted.', N'No', N'Employee Travel - will never be 1099 eligible', N'11/27/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Foreign Travel', NULL, 21.2, NULL, NULL, NULL, NULL, NULL, N'212000', N'212000', N'212000', N'212000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Non-Foreign Relocation', NULL, 21.3, NULL, NULL, NULL, NULL, NULL, N'213000', N'213000', N'213000', N'213000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Non-Foreign Local Travel', NULL, N'213L', N'213L', N'213L', N'213L', N'213L', N'213L', N'213L00', NULL, NULL, N'This BOC will be deleted during 2013. Deleted', NULL, NULL, N'10/24/2014', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Local Business Travel Official Station', NULL, 21.4, NULL, NULL, NULL, NULL, NULL, N'214000', N'214000', N'214000', N'214000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Student Travel', NULL, 21.9, NULL, NULL, NULL, NULL, NULL, N'219000', N'219000', N'219000', N'219000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Transportation of Things', NULL, 22, NULL, NULL, NULL, NULL, NULL, N'220000', N'220000', N'220000', N'220000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'GSA Shipping Surcharges', NULL, N'221C', N'221C', N'221C', N'221C', N'221C', N'221C00', N'221C00', N'221C00', N'221C00', N'This BOC will be deleted in FY 2017. ', N'No', NULL, N'9/30/2017', N'GL not blocked', N'will need to delete on this tab at year-end.')
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Truck Transport - Bureau Owned', NULL, N'222D', N'222D', N'222D', N'222D', N'222D', N'222D00', N'222D00', N'222D00', N'222D00', N'This BOC will be deleted in FY 2017. ', N'No', NULL, N'9/30/2017', N'GL not blocked', N'will need to delete on this tab at year-end.')
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'GSA Truck Transportation', NULL, N'222E', N'222E', N'222E', N'222E', N'222E', N'222E', N'222E00', NULL, NULL, N'GSA provided motor vehicles in class G41 - G92 (light trucks, medium trucks, and heavy trucks); see 233L for motor vehicle in classes G10 thru G32 (passenger vehicles and buses).  FBMS system generated.', NULL, NULL, N'9/30/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Truck Transportation - GSA Accrual', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'222EA0', NULL, NULL, N'GSA provided motor vehicles in class G41 - G92 (light trucks, medium trucks, and heavy trucks); see 233L for motor vehicle in classes G10 thru G32 (passenger vehicles and buses).  FBMS system generated.  Deleted.', NULL, NULL, N'9/30/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Rent, Communications, and Utilities', NULL, 23, NULL, NULL, NULL, NULL, NULL, N'230000', N'230000', N'230000', N'230000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Rental Payments to GSA', NULL, 23.1, NULL, NULL, NULL, NULL, NULL, N'231000', N'231000', N'231000', N'231000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Rental Payments to Others', NULL, 23.2, NULL, NULL, NULL, NULL, NULL, N'232000', N'232000', N'232000', N'232000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Communications, Utilities and Misc. Charges', NULL, 23.3, NULL, NULL, NULL, NULL, NULL, N'233000', N'233000', N'233000', N'233000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Printing and Reproducation', NULL, 24, NULL, NULL, NULL, NULL, NULL, N'240000', N'240000', N'240000', N'240000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Other Services From Non-Federal Sources', NULL, 25.2, NULL, NULL, NULL, NULL, NULL, N'252000', N'252000', N'252000', N'252000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Contracts - Development of Data Sets', NULL, N'252C', N'252C', N'252C', N'252C', N'252C', N'252C00', N'252C00', N'252C00', NULL, N'Non-Federal contracts issued for development of data in any format that will be manipulated by automated means.', N'Yes', NULL, N'9/30/2015', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Contracts - Mapping', NULL, N'252M', N'252M', N'252M', N'252M', N'252M', N'252M', N'252M00', N'252M00', NULL, N'Report contractual services with non-Federal sources for mapping.', N'Yes', NULL, N'9/30/2015', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Contracts - Aerial Photography', NULL, N'252Q', N'252Q', N'252Q', N'252Q', N'252Q', N'252Q', N'252Q00', N'252Q00', NULL, N'Contractual services for the collection of data through aerial photography and the related mapping.', N'Yes', NULL, N'9/30/2015', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Advertising - Commercial', NULL, N'252X', N'252X', N'252X', N'252X', N'252X', N'252X', N'252X00', N'252X00', NULL, N'Includes newspaper advertisements and notices.', N'Yes', NULL, N'9/30/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Other Goods and Services from Federal Sources', NULL, 25.3, NULL, NULL, NULL, NULL, NULL, N'253000', N'253000', N'253000', N'253000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Overhead on Obligations - Manual Posting', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'253GN0', N'Deleted in FY 2013 but was never expired in FBMS.', NULL, NULL, N'9/22/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'WCF Fixed Ownership Rate', NULL, N'253P', N'253P', N'253P', N'253P', N'253P', N'253P', N'253P00', N'253P00', NULL, N'Purchases such as WCF-Heavy Equipment fixed charges  via a rate for non-fleet equipment.', NULL, NULL, N'9/30/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Operation and Maintenance of Facilities', NULL, 25.4, NULL, NULL, NULL, NULL, NULL, N'254000', N'254000', N'254000', N'254000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Research and Development Contracts', NULL, 25.5, NULL, NULL, NULL, NULL, NULL, N'255000', N'255000', N'255000', N'255000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Medical Care', NULL, 25.6, NULL, NULL, NULL, NULL, NULL, N'256000', N'256000', N'256000', N'256000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Operation and Maintenance of Equipment', NULL, 25.7, NULL, NULL, NULL, NULL, NULL, N'257000', N'257000', N'257000', N'257000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Maintenance - Voice Communications Equipment', NULL, N'257L', N'257L', N'257L', N'257L', N'257L', N'257L', N'257L00', N'257L00', NULL, N'Operation, maintenance, and repair of voice telecommunications equipment, when done by contract with the private sector or another Federal Government agency.', N'Yes', NULL, N'9/30/2015', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Maintenance - Data Communications Equipment', NULL, N'257M', N'257M', N'257M', N'257M', N'257M', N'257M', N'257M00', N'257M00', NULL, N'Operation, maintenance, and repair of data  telecommunications equipment, when done by contract with the private sector or another Federal Government agency, including the installation of equipment.', N'Yes', NULL, N'9/30/2015', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Subsistence and Support of Persons', NULL, 25.8, NULL, NULL, NULL, NULL, NULL, N'258000', N'258000', N'258000', N'258000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Applied Overhead', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'2597', N'This BOC was never on the PFM BOC Listing but was in FBMS.  ', NULL, NULL, N'259700 expired 9/22/17', N'No GL', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Supplies and Materials', NULL, 26, NULL, NULL, NULL, NULL, NULL, N'260000', N'260000', N'260000', N'260000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Acquisition of Assets', NULL, 30, NULL, NULL, NULL, NULL, NULL, N'300000', N'300000', N'300000', N'300000', NULL, NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Equipment', NULL, 31, NULL, NULL, NULL, NULL, NULL, N'310000', N'310000', N'310000', N'310000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Capitalized - Equipment On Loan', NULL, N'311B', N'311B', N'311B', N'311B', N'311B', N'311B', N'311B00', N'311B00', NULL, N'Long term lease contract of equipment when performed under contract such as transportation equipment, furniture and fixtures, tools and implements, machinery, instruments and apparatus. Lease-contract price is above the capitalization threshold.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Motor Vehicle Proceeds Expended', NULL, N'311Z', N'311Z', N'311Z', N'311Z', N'311Z', N'311Z', N'311Z00', N'311Z00', NULL, N'Purchase of equipment with proceeds from motor vehicle sales.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Non-Captl-Radio Comm Equip, Cntrl Abv Cap Thresh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'312i00', NULL, NULL, N'Will be deleted in FY 2014.', NULL, NULL, N'9/30/2014', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Discount - Equipment', NULL, N'3198', N'3198', N'3198', N'3198', N'3198', N'3198', N'319800', NULL, NULL, N'Discounts on purchase or lease of equipment.  Deleted.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Interest - Equipment', NULL, N'3199', N'3199', N'3199', N'3199', N'3199', N'3199', N'319900', NULL, NULL, N'Interest on purchase or lease of equipment.  Deleted.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Land and Structures', NULL, 32, NULL, NULL, NULL, NULL, NULL, N'320000', N'320000', N'320000', N'320000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Land and Land Rights', NULL, NULL, NULL, NULL, NULL, NULL, N'321000', N'321000', N'321000', N'321000', N'Deleted in FY 2017.', N'No', NULL, N'9/30/2017', N'No GL', N'will need to delete on this tab at year-end.')
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Non-Capitalized - Improvements', NULL, N'327H', N'327H', N'327H', N'327H', N'327H', N'327H00', N'327H00', N'327H00', N'327H00', N'Includes costs to maintain, acquire, construct, reconstruct, rehabilitate, or improve heritage assets that have significant historical, natural, cultural or educational characteristics.  Also includes non-labor costs when work is done by bureau force account crew.', N'Yes', N'Vendorss are providing services', NULL, N'Delete (voted in FY 2017  to delete).  BOC was only being used for Heritage items which are tracked via WBS not BOC.  Will require deactivating existing UPCs', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Discount - Lands & Structures', NULL, N'3298', N'3298', N'3298', N'3298', N'3298', N'3298', N'329800', NULL, NULL, N'Discount on purchase or construction costs for land and structures.  Deleted.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Interest - Lands & Structures', NULL, N'3299', N'3299', N'3299', N'3299', N'3299', N'3299', N'329900', NULL, NULL, N'Interest on purchase or construction costs for land and structures.  Deleted.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Building Improvement Renovation', NULL, 32.3, NULL, NULL, NULL, NULL, NULL, N'323000', N'323000', N'323000', N'323000', NULL, NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Investments and Loans', NULL, 33, NULL, NULL, NULL, NULL, NULL, N'330000', N'330000', N'330000', N'330000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Grants and Fixed Charges', NULL, 40, NULL, NULL, NULL, NULL, NULL, N'400000', N'400000', N'400000', N'400000', NULL, NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Grants, Subsidies, and Contributions', NULL, 41, NULL, NULL, NULL, NULL, NULL, N'410000', N'410000', N'410000', N'410000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Insurance claims and indemnities', NULL, 42, NULL, NULL, NULL, NULL, NULL, N'420000', N'420000', N'420000', N'420000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Tort Claims - Other', NULL, N'421E', N'421E', N'421E', N'421E', N'421E', N'421E', N'421E00', N'421E00', NULL, N'Payments made for non-vehicle related tort claims.', NULL, NULL, N'9/30/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Payments under NO FEAR Act', NULL, NULL, NULL, N'421F', N'421F', N'421F', N'421F', N'421F00', N'421F00', NULL, N'Benefit payments from social insurance.', NULL, NULL, N'9/30/2017', N'GL not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (NULL, N'Indemnities & Other Claims - Nontaxable', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'421K00', NULL, N'For non-taxable payments to veterans and former civilian employees or their survivors for death or disability; claims and judgments arising from court decisions or abrogation of contracts.  Also includes court ordered employee settlements and payments related to personal physical injuries or physical sickness and any attorney fees and costs associated with the recovery of nontaxable personal physical injuries or physical sickness payments.', N'No', NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Interest and Dividends', NULL, 43, NULL, NULL, NULL, NULL, NULL, N'430000', N'430000', N'430000', N'430000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Refunds', NULL, 44, NULL, NULL, NULL, NULL, NULL, N'440000', N'440000', N'440000', N'440000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Other', NULL, 90, NULL, NULL, NULL, NULL, NULL, N'900000', N'900000', N'900000', N'900000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Unvouchered', NULL, 91, NULL, NULL, NULL, NULL, NULL, N'910000', N'910000', N'910000', N'910000', N'This major object class covers object classes 91.0 through 99.5.', NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Undistributed', NULL, 92, NULL, NULL, NULL, NULL, NULL, N'920000', N'920000', N'920000', N'920000', NULL, NULL, NULL, N'not expired', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Limitation on Expenses', NULL, 93, NULL, NULL, NULL, NULL, NULL, N'930000', N'930000', N'930000', N'930000', N'Used when there is an annual limitation in administrative or other expenses for revolving and trust funds.  Deleted.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Financial Transfers', NULL, 94, NULL, NULL, NULL, NULL, NULL, N'940000', N'940000', N'940000', N'940000', N'For obligations that represent financial interchanges between Federal government accounts that are not in exchange for goods and services.  Reserved for PFM''s use.  This BOC requires prior OMB approval.', NULL, NULL, N'7/9/2015', N'5760.94000 not blocked', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Subtotal Obligations', NULL, 99, NULL, NULL, NULL, NULL, NULL, N'990000', N'990000', N'990000', N'990000', N'This entry is generated automatically by MAX.  Reserved for PFM''s use.  This BOC requires prior OMB approval.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Adjustments for Rounding', NULL, 99.5, NULL, NULL, NULL, NULL, NULL, N'995000', N'995000', N'995000', N'995000', N'Used only if object class entry is $500 thousand or less.  Reserved for PFM''s use.  This BOC requires prior OMB approval.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO
INSERT [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] ([BOC_Category], [BOC_Item], [Group], [2004], [2005], [2006], [2010], [2011], [FBMS_2014], [FBMS_2015], [FBMS_2016], [FBMS_2017], [Definitions], [1099_Reportable], [1099_Explanation], [Expired], [Closed], [Column1])
VALUES (N'Total new Obligations', NULL, 99.9, NULL, NULL, NULL, NULL, NULL, N'999000', N'999000', N'999000', N'999000', N'This entry is generated automatically by MAX.  Reserved for PFM''s use.  This BOC requires prior OMB approval.', NULL, NULL, N'doesn''t exist', N'n/a', NULL)
GO


select * from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]

select * from Reclamation.BudgetObjectCode