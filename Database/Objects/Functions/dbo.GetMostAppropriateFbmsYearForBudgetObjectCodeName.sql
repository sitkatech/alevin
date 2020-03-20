
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetMostAppropriateFbmsYearForBudgetObjectCodeName')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
                  )
  DROP FUNCTION dbo.GetMostAppropriateFbmsYearForBudgetObjectCodeName
GO


CREATE FUNCTION dbo.GetMostAppropriateFbmsYearForBudgetObjectCodeName(@budgetObjectCodename VARCHAR(MAX), @dateOfTransaction datetime) RETURNS int
AS
BEGIN
    -- HACK to start with 
    return 2019
END
GO

/*


*/