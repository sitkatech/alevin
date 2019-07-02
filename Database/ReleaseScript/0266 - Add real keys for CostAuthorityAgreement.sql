--select 
--caa.CostAuthorityWorkBreakdownStructure as CAA_WBS,
--ca.CostAuthorityWorkBreakdownStructure as CA_WBS,
--* from 
--dbo.CostAuthorityAgreement as caa
--full outer join dbo.CostAuthority as ca on caa.CostAuthorityWorkBreakdownStructure = ca.CostAuthorityWorkBreakdownStructure
--where (ca.CostAuthorityWorkBreakdownStructure is null and caa.CostAuthorityWorkBreakdownStructure is not null) or (caa.CostAuthorityWorkBreakdownStructure is null and ca.CostAuthorityWorkBreakdownStructure is not null)

exec sp_rename 'dbo.CostAuthorityAgreement.CostAuthority', 'CostAuthorityNumber'

alter table dbo.CostAuthorityAgreement
add AgreementID int null constraint FK_CostAuthorityAgreement_Agreement_AgreementID foreign key references dbo.Agreement(AgreementID),
CostAuthorityID int null constraint FK_CostAuthorityAgreement_CostAuthority_CostAuthorityID foreign key references dbo.CostAuthority(CostAuthorityID)
GO

update dbo.CostAuthorityAgreement 
set AgreementID = a.AgreementID
from dbo.CostAuthorityAgreement as caa
inner join dbo.Agreement as a on caa.AgreementNumber = a.AgreementNumber

-- Match on CostAuthority
update dbo.CostAuthorityAgreement 
set CostAuthorityID = a.CostAuthorityID
from dbo.CostAuthorityAgreement as caa
inner join dbo.CostAuthority as a on caa.CostAuthorityNumber = a.CostAuthorityNumber

-- Also attempt match on CAWBS
update dbo.CostAuthorityAgreement 
set CostAuthorityID = a.CostAuthorityID
from dbo.CostAuthorityAgreement as caa
inner join dbo.CostAuthority as a on caa.CostAuthorityWorkBreakdownStructure = a.CostAuthorityWorkBreakdownStructure


--select * from dbo.CostAuthorityAgreement where AgreementID is null
--select * from dbo.CostAuthorityAgreement where CostAuthorityID is null

-- These are rows that don't match quite right, and which we aren't certain about
--select caa.CostAuthority as CAA_CostAuthorityNumber,
--       ca.CostAuthorityNumber as CA_CostAuthorityNumber
--from dbo.CostAuthorityAgreement caa
--inner join CostAuthority as ca on caa.CostAuthorityID = ca.CostAuthorityID
--where caa.CostAuthorityNumber != ca.CostAuthorityNumber


-- Setting these not-quite-right CostAuthorityNumber matches back to null
update dbo.CostAuthorityAgreement
set CostAuthorityID = null
where CostAuthorityAgreementID in 
(
	select caa.CostAuthorityAgreementID
	from dbo.CostAuthorityAgreement caa
	inner join CostAuthority as ca on caa.CostAuthorityID = ca.CostAuthorityID
	where caa.CostAuthorityNumber != ca.CostAuthorityNumber
)

-- Is empty, so this is ok.
--select caa.AgreementNumber as CAA_AgreementNumber,
--       a.AgreementNumber as A_AgreementNumber
--from dbo.CostAuthorityAgreement caa
--inner join Agreement as a on caa.AgreementID = a.AgreementID
--where caa.AgreementNumber != a.AgreementNumber

-- We still have some problems with nulls, so we can't drop the original label columns, and we can't tighten up the new IDs. 
-- We should ask Dorothy about these.

/*
select * from dbo.CostAuthorityAgreement where AgreementID is null
select * from dbo.CostAuthorityAgreement where CostAuthorityID is null 
select * from dbo.CostAuthorityAgreement where CostAuthorityID is null or AgreementID is null

select * from dbo.CostAuthorityAgreement where AgreementID is null
select * from dbo.Agreement where AgreementNumber like '%R14PD00437%'
*/

