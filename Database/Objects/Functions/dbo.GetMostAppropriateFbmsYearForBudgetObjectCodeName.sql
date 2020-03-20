
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
    return COALESCE(
                    -- If found, use appropriate, matching year
                    (select distinct boc.FbmsYear from Reclamation.BudgetObjectCode as boc where boc.FbmsYear = YEAR(@dateOfTransaction)),
                    -- Otherwise, default to the latest year
                    (select MAX(boc.FbmsYear) from Reclamation.BudgetObjectCode as boc)
                    )
END
GO

/*

-- Has matching year
select dbo.GetMostAppropriateFbmsYearForBudgetObjectCodeName('111A00', '1/1/2004') as FbmsYearToUse
-- Does NOT have matching year (no 2013), so will return 2019 (or latest year)
select dbo.GetMostAppropriateFbmsYearForBudgetObjectCodeName('111A00', '1/1/2013') as FbmsYearToUse

-- SLG 3/19/2020

*/
