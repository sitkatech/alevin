
-- Drop if already exists
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetFiscalQuarterIDForCalendarDate')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
                  )
  DROP FUNCTION dbo.GetFiscalQuarterIDForCalendarDate
GO

-- Get the FiscalQuarterID for a given calendar date
CREATE FUNCTION dbo.GetFiscalQuarterIDForCalendarDate(@calendarDate datetime) RETURNS int
AS
BEGIN
    declare @calendarMonth int;

    set @calendarMonth = DATEPART(month, @calendarDate)
    
    -- Hardwired for Reclamation!
    if (@calendarMonth >=1 and @calendarMonth <= 3)
    begin
        return 2 -- FiscalQuarterID 2 = Fiscal Quarter Two
    end
    else if (@calendarMonth >=4 and @calendarMonth <= 6)
    begin
        return 3 -- FiscalQuarterID 3 = Fiscal Quarter Three
    end
    else if (@calendarMonth >=7 and @calendarMonth <= 9)
    begin
        return 4 -- FiscalQuarterID 2 = Fiscal Quarter Four
    end
    else if (@calendarMonth >=9 and @calendarMonth <= 12)
    begin
        return 1 -- FiscalQuarterID 2 = Fiscal Quarter One
    end

    -- Something went wrong
    return null
END
GO

/*

-- All should be FYQ 2
select dbo.GetFiscalQuarterIDForCalendarDate('01/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('02/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('03/01/2020') as cdfq

-- All should be FYQ 3
select dbo.GetFiscalQuarterIDForCalendarDate('04/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('05/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('06/01/2020') as cdfq

-- All should be FYQ 4
select dbo.GetFiscalQuarterIDForCalendarDate('07/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('08/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('09/01/2020') as cdfq

-- All should be FYQ 1
select dbo.GetFiscalQuarterIDForCalendarDate('10/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('11/01/2020') as cdfq
select dbo.GetFiscalQuarterIDForCalendarDate('12/01/2020') as cdfq
*/
