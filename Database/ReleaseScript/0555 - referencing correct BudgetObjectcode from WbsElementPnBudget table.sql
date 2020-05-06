
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

