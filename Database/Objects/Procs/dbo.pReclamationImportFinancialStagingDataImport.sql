IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportFinancialStagingDataImport'))
    drop procedure dbo.pReclamationImportFinancialStagingDataImport
go

create procedure dbo.pReclamationImportFinancialStagingDataImport

as
begin

    exec dbo.pReclamationImportApGenAndPayrecV3
    exec dbo.pReclamationImportPnBudget

end
GO


/*

exec dbo.pReclamationImportFinancialStagingDataImport

*/