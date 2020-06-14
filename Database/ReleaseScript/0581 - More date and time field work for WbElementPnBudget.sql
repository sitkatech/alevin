--select * from ImportFinancial.WbsElementPnBudget

--alter table [ImportFinancial].[FiscalQuarter]

-- Renames for clarity
sp_rename '[ImportFinancial].[FiscalQuarter].[FiscalQuarterStartMonth]', 'FiscalQuarterStartCalendarMonth'
GO
sp_rename '[ImportFinancial].[FiscalQuarter].[FiscalQuarterStartDay]', 'FiscalQuarterStartCalendarDay'
GO

