
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetFiscalYearFromFiscalYearPeriodString')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
                  )
  DROP FUNCTION dbo.GetFiscalYearFromFiscalYearPeriodString
GO

CREATE FUNCTION dbo.GetFiscalYearFromFiscalYearPeriodString(@fiscalYearPeriodString VARCHAR(MAX)) RETURNS int
AS
BEGIN
    return convert(int,substring(@fiscalYearPeriodString, 5, 4))
END
GO

/*

select dbo.GetFiscalYearFromFiscalYearPeriodString('002/2019')
select dbo.GetFiscalYearFromFiscalYearPeriodString('001/2020')

*/
