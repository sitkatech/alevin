
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
                  )
  DROP FUNCTION dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString
GO

CREATE FUNCTION dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString(@fiscalYearPeriodString VARCHAR(MAX)) RETURNS int
AS
BEGIN
    return convert(int,substring(@fiscalYearPeriodString, 1, 3))
END
GO

/*

-- Yes, periods go from 1-16. 13-16 fall in September.

select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('001/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('002/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('003/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('004/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('005/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('006/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('007/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('008/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('009/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('010/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('011/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('012/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('013/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('014/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('015/2020')
select dbo.GetFiscalMonthPeriodFromFiscalYearPeriodString('016/2020')

*/
