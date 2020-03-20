
IF EXISTS (SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.CleanBudgetObjectCode')
                  AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ))
  DROP FUNCTION dbo.CleanBudgetObjectCode
GO


CREATE FUNCTION dbo.CleanBudgetObjectCode(@bocToClean VARCHAR(MAX)) RETURNS NVARCHAR(6)
AS
BEGIN
    if (LEN(@bocToClean) < 6)
    begin
        return @bocToClean + Replicate('0',6 - Len(@bocToClean))
    end

    return @bocToClean
END
GO