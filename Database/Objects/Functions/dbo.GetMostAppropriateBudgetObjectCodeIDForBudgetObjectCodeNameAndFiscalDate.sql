
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalDate')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
                  )
  DROP FUNCTION dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalDate
GO


CREATE FUNCTION dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalDate(
                                            @budgetObjectCodeName VARCHAR(MAX),
                                            @fiscalYear int
                                            ) RETURNS int
AS
BEGIN
    return COALESCE(
                    -- **ASSUMING** FbmsYear is fiscal year. Key assumption!

                    -- If found, use appropriate, matching year
                    (select boc.BudgetObjectCodeID from Reclamation.BudgetObjectCode as boc where boc.BudgetObjectCodeName = @budgetObjectCodeName and boc.FbmsYear = @fiscalYear ),
                    -- Otherwise, default to the latest year
                    (select top 1 boc.BudgetObjectCodeID from Reclamation.BudgetObjectCode as boc where boc.BudgetObjectCodeName = @budgetObjectCodeName order by boc.FbmsYear desc)
                    )
END
GO



/*

-- Has matching year
select dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalDate('111A00', 2004) as BudgetObjectCodeID
-- Does NOT have matching year (no 2013), so will return 2019 (or latest year)
select dbo.GetMostAppropriateBudgetObjectCodeIDForBudgetObjectCodeNameAndFiscalDate('111A00', 2013) as BudgetObjectCodeID
-- SLG + SMG 5/05/2020

*/
