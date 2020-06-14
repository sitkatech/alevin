
-- Drop if already exists
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetCalendarDateForStartOfFiscalYearPeriod')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
                  )
  DROP FUNCTION dbo.GetCalendarDateForStartOfFiscalYearPeriod
GO

-- Get the Calendar DateTime for the *START* of a given FiscalYearPeriod, where FiscalYearPeriod is described as a string "003/2020"
CREATE FUNCTION dbo.GetCalendarDateForStartOfFiscalYearPeriod(@fiscalYearPeriodString VARCHAR(10)) RETURNS datetime
AS
BEGIN
    declare @fiscalMonth int;
    declare @fiscalYear int;

    set @fiscalMonth = cast(substring(@fiscalYearPeriodString, 1, 3) as int)
    set @fiscalYear = cast(substring(@fiscalYearPeriodString, 5, 4) as int)

    declare @calendarMonth int;
    declare @calendarYear int;

    -- Hard wired for Reclamation for the moment!
    if (@fiscalMonth >=1 and @fiscalMonth <= 3)
    begin
        set @calendarMonth = 9 + @fiscalMonth;
        set @calendarYear = @fiscalYear;
    end
    else
    if (@fiscalMonth >= 4 and @fiscalMonth <= 12)
    begin
        set @calendarMonth = @fiscalMonth -3;
        set @calendarYear = @fiscalYear + 1;
    end
    else
    -- Periods 12-16 all happen during the month of September
    if (@fiscalMonth >= 12 and @fiscalMonth <= 16)
    begin
        set @calendarMonth = 9;
        set @calendarYear = @fiscalYear + 1;
    end

    -- If we get this far without setting proper @calendarYear and @calendarMonth, we'll return null, which
    -- helps us see something is wrong. We can't throw an exception or raise an error in a proc.
    declare @returnCalendarDate datetime;
    set @returnCalendarDate = DATEFROMPARTS(@calendarYear, @calendarMonth, 1)

    return @returnCalendarDate
END
GO

/*

select dbo.GetCalendarDateForStartOfFiscalYearPeriod('001/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('002/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('003/2020') as CalendarDate

select dbo.GetCalendarDateForStartOfFiscalYearPeriod('004/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('005/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('006/2020') as CalendarDate

select dbo.GetCalendarDateForStartOfFiscalYearPeriod('007/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('008/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('009/2020') as CalendarDate

select dbo.GetCalendarDateForStartOfFiscalYearPeriod('010/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('011/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('012/2020') as CalendarDate

-- Bonus, accounting-only periods. These all happen during the month of september,
-- according to Dorothy.
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('013/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('014/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('015/2020') as CalendarDate
select dbo.GetCalendarDateForStartOfFiscalYearPeriod('016/2020') as CalendarDate



*/

/*
    declare @fiscalYearPeriodString varchar(max)
    set @fiscalYearPeriodString = '010/2020'

    declare @fiscalMonth int;
    declare @fiscalYear int;

    select (substring(@fiscalYearPeriodString, 1, 3)) as fiscalMonthString
    select (substring(@fiscalYearPeriodString, 5, 4)) as fiscalYearString


    set @fiscalMonth = cast(substring(@fiscalYearPeriodString, 0, 3) as int)
    set @fiscalYear = cast(substring(@fiscalYearPeriodString, 5, 4) as int)

    select @fiscalMonth as FiscalMonth
    select @fiscalYear as FiscalYear

    declare @calendarMonth int;
    declare @calendarYear int;

    -- Hard wired for Reclamation for the moment!
    if (@fiscalMonth >=1 and @fiscalMonth <= 3)
    begin
        set @calendarMonth = 9 + @fiscalMonth;
        set @calendarYear = @fiscalYear;
    end
    else
    if (@fiscalMonth >= 4 and @fiscalMonth <= 12)
    begin
        set @calendarMonth = @fiscalMonth -3;
        set @calendarYear = @fiscalYear + 1;
    end

    select @calendarMonth as CalendarMonth
    select @calendarYear as CalendarYear

    declare @returnCalendarDate datetime;
    set @returnCalendarDate = DATEFROMPARTS(@calendarYear, @calendarMonth, 1)

    select @returnCalendarDate
*/