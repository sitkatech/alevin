update Reclamation.CostAuthority
set CostAuthorityNumber = null
where CostAuthorityWorkBreakdownStructure = CostAuthorityNumber and CostAuthorityWorkBreakdownStructure like 'R_.%'
GO

-- Noticed in passing as just flat-out wrong. Was an unwanted space in the original CAWBS field.
update Reclamation.CostAuthority
set  CostAuthorityWorkBreakdownStructure = 'RX.16786820.3000100'
where CostAuthorityID = 201
GO

-- Fill in null AgencyProjectTypes
update Reclamation.CostAuthority
set AgencyProjectType = SUBSTRING(CostAuthorityWorkBreakdownStructure, 1, 2)
where AgencyProjectType is null and CostAuthorityWorkBreakdownStructure like 'R_.%'
GO

/*
-- Where null & appropriate (starts with "RX." type code), fill in JobNumber column
select (SUBSTRING(CostAuthorityWorkBreakdownStructure, CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4) + 1, 7)) as JobNumberCalculated, 
       (CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4)) as substringStartPos,
       CostAuthorityWorkBreakdownStructure,
       JobNumber
from Reclamation.CostAuthority
where JobNumber is null and CostAuthorityWorkBreakdownStructure like 'R_.%'
*/


-- Where null & appropriate (starts with "RX." type code), fill in JobNumber column
update Reclamation.CostAuthority
set JobNumber = (SUBSTRING(CostAuthorityWorkBreakdownStructure, CHARINDEX('.', CostAuthorityWorkBreakdownStructure, 4) + 1, 7))
where JobNumber is null and CostAuthorityWorkBreakdownStructure like 'R_.%'

-- Fill in our new Job and Number columns from the existing (& just updated for some) JobNumber column.
update Reclamation.CostAuthority
set Job = SUBSTRING(JobNumber, 1, 3),
    Number = SUBSTRING(JobNumber, 4, 4)





/*
select * from Reclamation.CostAuthority
where CostAuthorityWorkBreakdownStructure = CostAuthorityNumber and CostAuthorityWorkBreakdownStructure like 'R_.%'
*/
