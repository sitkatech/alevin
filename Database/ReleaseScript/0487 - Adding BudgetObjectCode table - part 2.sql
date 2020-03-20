CREATE TABLE Reclamation.BudgetObjectCode(
	BudgetObjectCodeID int not null identity(1,1) constraint PK_BudgetObjectCode_BudgetObjectCodeID primary key,
	BudgetObjectCodeName nvarchar(6) not null,
	BudgetObjectCodeItemDescription nvarchar(1000) not null,
	BudgetObjectCodeDefinition nvarchar(1000),
	FbmsYear int not null,
	Reportable1099 bit null,
	Explanation1099 nvarchar(1000) null
) ON [PRIMARY]
GO

IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.CleanBudgetObjectCode')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
  DROP FUNCTION dbo.CleanBudgetObjectCode
GO

CREATE FUNCTION [dbo].CleanBudgetObjectCode(@bocToClean VARCHAR(MAX)) RETURNS NVARCHAR(6)
AS
BEGIN
    if (LEN(@bocToClean) < 6)
	begin
		 return @bocToClean + Replicate('0',6 - Len(@bocToClean))
	end

	return @bocToClean
END
GO

--select dbo.CleanBudgetObjectCode('253EC0')
--select dbo.CleanBudgetObjectCode('253F')
--select dbo.CleanBudgetObjectCode('25')

CREATE UNIQUE INDEX UQ
  ON Reclamation.BudgetObjectCode(BudgetObjectCodeName, FbmsYear);


delete from Reclamation.BudgetObjectCode

INSERT INTO Reclamation.BudgetObjectCode
SELECT dbo.CleanBudgetObjectCode(BudgetObjectCode) as BudgetObjectCodeName, BocItem as BocItemDescription, Definitions as  BocDefinition, REPLACE(FbmsYear, 'Fbms', '') as FbmsYear, (select case when Reportable1099 = 'Yes' then 1 when Reportable1099 = 'No' then 0 else null end) as Reportable1099, Explanation1099
FROM   
   (SELECT BocItem, Definitions, [2004], [2005], [2006], [2010], [2011], [Fbms2016],[Fbms2017], [Fbms2018], [Fbms2019] , Reportable1099, Explanation1099
   FROM dbo.BocCleaned) p  
UNPIVOT  
   (BudgetObjectCode FOR FbmsYear IN   
      ([2004], [2005], [2006], [2010], [2011], [Fbms2016],[Fbms2017], [Fbms2018], [Fbms2019])  
)AS unpvt;  



/*

select * from Reclamation.BudgetObjectCode where BudgetObjectCodeDefinition like '%Manual%'

*/