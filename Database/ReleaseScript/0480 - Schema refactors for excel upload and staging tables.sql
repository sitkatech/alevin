--begin tran

CREATE SCHEMA Staging
GO

ALTER SCHEMA Staging
TRANSFER dbo.StageImpApGenSheet
GO

ALTER SCHEMA Staging
TRANSFER dbo.StageImpPayRecV3
GO

--exec sp_rename 'Staging.StageImpApGenSheet', 'Staging.ImpApGenSheet'
--GO

--exec sp_rename 'Staging.StageImpPayRecV3', 'Staging.ImpPayRecV3'
--GO

--rollback tran