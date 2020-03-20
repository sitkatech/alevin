
IF EXISTS (
           SELECT *
           FROM   sys.objects
           WHERE  object_id = OBJECT_ID(N'dbo.StripFundPrefixFromFundName')
                  --AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )
           )
  DROP FUNCTION dbo.StripFundPrefixFromFundName
GO


CREATE FUNCTION dbo.StripFundPrefixFromFundName(@fundNameToClean NVARCHAR(16)) RETURNS NVARCHAR(11)
AS
BEGIN
        -- Strip off "1400/" prefix if present, otherwise return original code
        return  REPLACE(@fundNameToClean, '1400/', ''); 
END
GO

/*

select dbo.StripFundPrefixFromFundName('1400/XXXR0680G3')
select dbo.StripFundPrefixFromFundName('1400/16XR0680G3')
select dbo.StripFundPrefixFromFundName('16XR0680G3')
-- And even this should work, since we don't care about anything but the prefix. Truncation desired here.
select dbo.StripFundPrefixFromFundName('BannaananaMango')

*/