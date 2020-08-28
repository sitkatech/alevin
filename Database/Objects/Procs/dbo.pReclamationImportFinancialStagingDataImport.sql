IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pReclamationImportFinancialStagingDataImport'))
    drop procedure dbo.pReclamationImportFinancialStagingDataImport
go

create procedure dbo.pReclamationImportFinancialStagingDataImport

as
begin
    -- These empty table checks also appear in the individual procs, but
    -- it seemed important enough to double check at this level as well. 
    --
    -- I can't imagine a time we want a half run of the import, but if I
    -- turn out to be wrong about that, feel free to remove these checks in favor
    -- of the ones in the individual procs. -- SLG 7/21/2020

    if (
        (not EXISTS(SELECT 1 FROM Staging.StageImpUnexpendedBalancePayRecV3))
        )
    begin
       raiserror('dbo.pReclamationImportFinancialStagingDataImport: There is no data in the Staging.StageImpUnexpendedBalancePayRecV3 table. Publishing halted.', 16,1)
       return -1
    end

    if (
        (not EXISTS(SELECT 1 FROM Staging.StageImpPnBudget))
        )
    begin
       raiserror('dbo.pReclamationImportFinancialStagingDataImport: There is no data in the Staging.StageImpPnBudget table. Publishing halted.', 16,1)
       return -1
    end

    -- Do each import
    ---------------------------------------------------------------------
    exec dbo.pReclamationImportUnexpendedBalancePayRecV3
    exec dbo.pReclamationImportPnBudget

end
GO


/*

exec dbo.pReclamationImportFinancialStagingDataImport

*/