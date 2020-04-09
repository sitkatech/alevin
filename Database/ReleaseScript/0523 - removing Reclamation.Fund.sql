

alter table ImportFinancial.WbsElementObligationItemBudget drop constraint FK_WbsElementObligationItemBudget_Fund_FundID

alter table ImportFinancial.WbsElementObligationItemBudget
drop column FundID


alter table ImportFinancial.WbsElementObligationItemInvoice drop constraint FK_WbsElementObligationItemInvoice_Fund_FundID

alter table ImportFinancial.WbsElementObligationItemInvoice
drop column FundID

drop table Reclamation.Fund