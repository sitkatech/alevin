IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportCreateSchema'))
    drop procedure dbo.pReclamationImportCreateSchema
go



create procedure dbo.pReclamationImportCreateSchema

as
begin

	IF OBJECT_ID('dbo.impApGenSheet', 'U') IS NOT NULL 
	begin
		DROP TABLE dbo.impApGenSheet;
	end
	

	CREATE TABLE dbo.impApGenSheet(
		impApGenSheetID int identity(1,1) not null constraint PK_impApGenSheet_impApGenSheetID primary key,
		[PO Number - Key] [nvarchar](255) NULL,
		[Purch Ord Line Itm - Key] [nvarchar](255) NULL,
		[Reference - Key] [nvarchar](255) NULL,
		[Vendor - Key] [nvarchar](255) NULL,
		[Vendor - Text] [nvarchar](255) NULL,
		[Fund - Key] [nvarchar](255) NULL,
		[Funded Program - Key] [nvarchar](255) NULL,
		[WBS Element - Key] [nvarchar](255) NULL,
		[WBS Element - Text] [nvarchar](255) NULL,
		[Budget Object Class - Key] [nvarchar](255) NULL,
		[Debit Amount] [float] NULL,
		[Credit Amount] [float] NULL,
		[Debit/Credit Total] [float] NULL
	) ON [PRIMARY]

	IF OBJECT_ID('dbo.impPayRecV3', 'U') IS NOT NULL 
	begin
		DROP TABLE dbo.impPayRecV3;
	end


	CREATE TABLE dbo.impPayRecV3(
		impPayRecV3ID int identity(1,1) not null constraint PK_impPayRecV3_impPayRecV3ID primary key,
		[Business area - Key] [nvarchar](255) NULL,
		[FA Budget Activity - Key] [nvarchar](255) NULL,
		[Functional area - Text] [nvarchar](255) NULL,
		[Obligation Number - Key] [nvarchar](255) NULL,
		[Obligation Item - Key] [nvarchar](255) NULL,
		[Fund - Key] [nvarchar](255) NULL,
		[Funded Program - Key (Not Compounded)] [nvarchar](255) NULL,
		[WBS Element - Key] [nvarchar](255) NULL,
		[WBS Element - Text] [nvarchar](255) NULL,
		[Budget Object Class - Key] [nvarchar](255) NULL,
		[Vendor - Key] [nvarchar](255) NULL,
		[Vendor - Text] [nvarchar](255) NULL,
		[Obligation] [float] NULL,
		[Goods Receipt] [nvarchar](255) NULL,
		[Invoiced] [float] NULL,
		[Disbursed] [float] NULL,
		[Unexpended Balance] [float] NULL
	) ON [PRIMARY]

end
GO


/*

exec dbo.pReclamationImportCreateSchema


*/
