



exec dbo.pReclamationImportCreateFinancialStagingSchema



exec dbo.pReclamationImportFinancialStagingDataImport






--testing for creates and inserts
--select * from dbo.impPayRecV3

--select 
--	distinct
--		coalesce(pr.[Obligation Number - Key] , ap.[PO Number - Key]) as ObligationNumberKey,
--		coalesce(pr.[Obligation Item - Key] , ap.[Purch Ord Line Itm - Key]) as ObligationItemKey,
--		(select ObligationNumberID from ImportFinancial.ObligationNumber as ob where ob.ObligationNumberKey = pr.[Obligation Number - Key]) as ObligationNumberID
--from
--	dbo.impPayRecV3 as pr
--	full outer join dbo.impApGenSheet as ap on pr.[Obligation Number - Key] = ap.[PO Number - Key]



--where
--	pr.[Vendor - Text] = ap.[Vendor - Text] and pr.[Vendor - Key] != '#'

