
CREATE TABLE ReclamationOneTimeImport.Tmp_EXPIRED_BOCS_RAW
	(
	BudgetObjectCodeName nvarchar(50) NULL,
	BOC_Category nvarchar(50) NULL,
	BOC_Item nvarchar(100) NULL,
	[Group] float(53) NULL,
	[2004] nvarchar(50) NULL,
	[2005] nvarchar(50) NULL,
	[2006] nvarchar(50) NULL,
	[2010] nvarchar(50) NULL,
	[2011] nvarchar(50) NULL,
	FBMS_2014 nvarchar(50) NULL,
	FBMS_2015 nvarchar(50) NULL,
	FBMS_2016 nvarchar(50) NULL,
	FBMS_2017 nvarchar(50) NULL,
	Definitions nvarchar(450) NULL,
	[1099_Reportable] nvarchar(50) NULL,
	[1099_Explanation] nvarchar(50) NULL,
	Expired nvarchar(50) NULL,
	Closed nvarchar(200) NOT NULL,
	Column1 nvarchar(50) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE ReclamationOneTimeImport.Tmp_EXPIRED_BOCS_RAW SET (LOCK_ESCALATION = TABLE)
GO
IF EXISTS(SELECT * FROM ReclamationOneTimeImport.EXPIRED_BOCS_RAW)
	 EXEC('INSERT INTO ReclamationOneTimeImport.Tmp_EXPIRED_BOCS_RAW (BOC_Category, BOC_Item, [Group], [2004], [2005], [2006], [2010], [2011], FBMS_2014, FBMS_2015, FBMS_2016, FBMS_2017, Definitions, [1099_Reportable], [1099_Explanation], Expired, Closed, Column1)
		SELECT BOC_Category, BOC_Item, [Group], [2004], [2005], [2006], [2010], [2011], FBMS_2014, FBMS_2015, FBMS_2016, FBMS_2017, Definitions, [1099_Reportable], [1099_Explanation], Expired, Closed, Column1 FROM ReclamationOneTimeImport.EXPIRED_BOCS_RAW WITH (HOLDLOCK TABLOCKX)')
GO
DROP TABLE ReclamationOneTimeImport.EXPIRED_BOCS_RAW
GO
EXECUTE sp_rename N'ReclamationOneTimeImport.Tmp_EXPIRED_BOCS_RAW', N'EXPIRED_BOCS_RAW', 'OBJECT' 
