


--insert missing WBS elements into the Reclamation.CostAuthority table
insert into Reclamation.CostAuthority(CostAuthorityWorkBreakdownStructure, AccountStructureDescription)  
select wbs.WbsElementKey, wbs.WbsElementText
from 
	Reclamation.CostAuthority as ca
	right join ImportFinancial.WbsElement as wbs on ca.CostAuthorityWorkBreakdownStructure = wbs.WbsElementKey
where
	ca.CostAuthorityWorkBreakdownStructure is null



alter table ImportFinancial.WbsElementObligationItemBudget
add CostAuthorityID int null constraint FK_WbsElementObligationItemBudget_CostAuthority_CostAuthorityID foreign key references Reclamation.CostAuthority(CostAuthorityID);
go

update ImportFinancial.WbsElementObligationItemBudget 
	set CostAuthorityID = rca.CostAuthorityID
	from 
		Reclamation.CostAuthority as rca
		join ImportFinancial.WbsElement as wbs on rca.CostAuthorityWorkBreakdownStructure = wbs.WbsElementKey
		join ImportFinancial.WbsElementObligationItemBudget as bud on wbs.WbsElementID = bud.WbsElementID


alter table ImportFinancial.WbsElementObligationItemBudget
alter column CostAuthorityID int not null




alter table ImportFinancial.WbsElementObligationItemInvoice
add CostAuthorityID int null constraint FK_WbsElementObligationItemInvoice_CostAuthority_CostAuthorityID foreign key references Reclamation.CostAuthority(CostAuthorityID);
go

update ImportFinancial.WbsElementObligationItemInvoice 
	set CostAuthorityID = rca.CostAuthorityID
	from 
		Reclamation.CostAuthority as rca
		join ImportFinancial.WbsElement as wbs on rca.CostAuthorityWorkBreakdownStructure = wbs.WbsElementKey
		join ImportFinancial.WbsElementObligationItemInvoice as inv on wbs.WbsElementID = inv.WbsElementID


alter table ImportFinancial.WbsElementObligationItemInvoice
alter column CostAuthorityID int not null


-- Turns out we have some wonky data currently for VendorNumber, with 
update dbo.Organization
set VendorNumber = null
from ImportFinancial.Vendor as iv
where TenantID = 12



/*


select * from ImportFinancial.WbsElementObligationItemBudget
where CostAuthorityID is null


	select
		rca.CostAuthorityID as CostAuthorityID
		,rca.CostAuthorityWorkBreakdownStructure
		,wbs.*,bud.*
	from
		Reclamation.CostAuthority as rca
		join ImportFinancial.WbsElement as wbs on rca.CostAuthorityWorkBreakdownStructure = wbs.WbsElementKey
		join ImportFinancial.WbsElementObligationItemBudget as bud on wbs.WbsElementID = bud.WbsElementID

*/