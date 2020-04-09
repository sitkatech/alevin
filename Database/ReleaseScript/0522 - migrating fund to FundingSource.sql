
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
update oib
set oib.FundingSourceID = fs.FundingSourceID
from
    ImportFinancial.WbsElementObligationItemBudget as oib
    join Reclamation.Fund as f on oib.FundID = f.FundID
    join dbo.FundingSource as fs on f.ReclamationFundNumber = fs.FundingSourceName 
*/

-- create temp mapping table to aid in update statement
IF OBJECT_ID('tempdb..#FundIdToFundingSourceIdMapping') IS NOT NULL DROP table #FundIdToFundingSourceIdMapping
select 
    f.FundID,
    f.ReclamationFundNumber,
    fs.FundingSourceID,
    fs.FundingSourceName
into #FundIdToFundingSourceIdMapping
from 
    Reclamation.Fund as f
    join dbo.FundingSource as fs on f.ReclamationFundNumber = fs.FundingSourceName 

update oib
set oib.FundingSourceID = map.FundingSourceID
from
    ImportFinancial.WbsElementObligationItemBudget as oib
    join #FundIdToFundingSourceIdMapping as map on oib.FundID = map.FundID

update oii
set oii.FundingSourceID = map.FundingSourceID
from
    ImportFinancial.WbsElementObligationItemInvoice as oii
    join #FundIdToFundingSourceIdMapping as map on oii.FundID = map.FundID


alter table ImportFinancial.WbsElementObligationItemBudget
alter column FundingSourceID int not null;
go

alter table ImportFinancial.WbsElementObligationItemInvoice
alter column FundingSourceID int not null;
go

/*
select
    *
from
    Reclamation.Fund as f
    join dbo.FundingSource as fs on f.ReclamationFundNumber = fs.FundingSourceName

*/
