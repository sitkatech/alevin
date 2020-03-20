
IF EXISTS (
           SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetMostAppropriateFbmsYearForBudgetObjectCodeName')
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
