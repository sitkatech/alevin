
--create FKs to FundingSource on the ObligationItem Budget/Invoice
alter table ImportFinancial.WbsElementObligationItemBudget
add FundingSourceID int null constraint FK_WbsElementObligationItemBudget_FundingSource_FundingSourceID foreign key references dbo.FundingSource(FundingSourceID);
go

alter table ImportFinancial.WbsElementObligationItemInvoice
add FundingSourceID int null constraint FK_WbsElementObligationItemInvoice_FundingSource_FundingSourceID foreign key references dbo.FundingSource(FundingSourceID);
go


--copy description from single matching Fund to the Funding Source
update fs
set fs.FundingSourceDescription = f.[Description]
from
    dbo.FundingSource as fs
    join Reclamation.Fund as f on fs.FundingSourceName = f.ReclamationFundNumber

--migrate rest of Fund data to FundingSource
insert into dbo.FundingSource(TenantID, OrganizationID, FundingSourceName, IsActive, FundingSourceDescription)
select
    12 as TenantID, --Reclamation TenantID
    6160 as OrganizationID, --Reclamaiton org
    f.ReclamationFundNumber as FundingSourceName,
    1 as IsActive,
    f.[Description] as FundingSourceDescription
from
    Reclamation.Fund as f
where
    f.FundID not in (select innerf.FundID from Reclamation.Fund as innerf join dbo.FundingSource as fs on innerf.ReclamationFundNumber = fs.FundingSourceName)

/*
select
    *
from
    Reclamation.Fund as f
    join dbo.FundingSource as fs on f.ReclamationFundNumber = fs.FundingSourceName

*/
