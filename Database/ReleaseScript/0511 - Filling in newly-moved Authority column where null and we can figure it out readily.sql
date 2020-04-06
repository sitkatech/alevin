
--select * 
--from Reclamation.CostAuthority
--where Authority is not null


--select  CostAuthorityWorkBreakdownStructure,
--        Authority,
--        (SUBSTRING(CostAuthorityWorkBreakdownStructure, CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4) - 4, 4)) as ParsedOutAuthority,
--        Job,
--        Number
--from Reclamation.CostAuthority as ca
--where Authority is null and CostAuthorityWorkBreakdownStructure like 'R_.%'




-- Where null & appropriate (starts with "RX." type code), fill in Authority column
update Reclamation.CostAuthority
set Authority = (SUBSTRING(CostAuthorityWorkBreakdownStructure, CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4) - 4, 4))
where Authority is null and CostAuthorityWorkBreakdownStructure like 'R_.%'

-- There are some that we don't update, but they are old CostAuthority types, NOT WBS starting with 'RX.' or whatever.
--select  CostAuthorityWorkBreakdownStructure,
--        Authority,
--        (SUBSTRING(CostAuthorityWorkBreakdownStructure, CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4) - 4, 4)) as ParsedOutAuthority,
--        Job,
--        Number
--from Reclamation.CostAuthority as ca
--where Authority != (SUBSTRING(CostAuthorityWorkBreakdownStructure, CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4) - 4, 4))


