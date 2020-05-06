--begin tran

--select * from ImportFinancial.WbsElementPnBudget 

update ImportFinancial.WbsElementPnBudget 
set ImportFinancial.WbsElementPnBudget.BudgetObjectCodeID = boc.BudgetObjectCodeID
from ImportFinancial.WbsElementPnBudget as wepb
left join ImportFinancial.CommitmentItem as ci on wepb.CommitmentItemID = ci.CommitmentItemID
left join Reclamation.BudgetObjectCode as boc on boc.BudgetObjectCodeName = ci.CommitmentItemName
GO

alter table ImportFinancial.WbsElementPnBudget
drop constraint FK_WbsElementPnBudget_CommitmentItem_CommitmentItemID
GO

alter table ImportFinancial.WbsElementPnBudget
drop column CommitmentItemID
GO

drop table ImportFinancial.CommitmentItem
GO
--select * from ImportFinancial.WbsElementPnBudget 

--select distinct ci.CommitmentItemID,
--       ci.CommitmentItemName
----       pnb.*
--from ImportFinancial.WbsElementPnBudget as pnb
--inner join ImportFinancial.CommitmentItem as ci on pnb.CommitmentItemID = ci.CommitmentItemID
--where pnb.BudgetObjectCodeID is null

--select *  
--from ImportFinancial.WbsElementPnBudget as pnb
--where pnb.CommitmentItemID in (2,12, 48, 52,59)

--rollback tran

