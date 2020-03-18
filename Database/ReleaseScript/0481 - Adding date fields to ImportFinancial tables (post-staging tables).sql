/*
dbo.StampImpApGenSheet

[CreatedOnKey]
[PostingDateKey]

datetimenull

dbo.StageImpPayRecv3

[CreatedOnKey]
[DateOfUpdateKey]
[PostingDateKey]
[PostingDatePerSplKey]
[DocumentDateOfBlKey]

-----------------
*/

-- ItemBudget
-------------
alter table ImportFinancial.WbsElementObligationItemBudget
add CreatedOnKey datetime null
GO

 alter table ImportFinancial.WbsElementObligationItemBudget
add DateOfUpdateKey datetime null
GO

alter table ImportFinancial.WbsElementObligationItemBudget
add PostingDateKey datetime null
GO

alter table ImportFinancial.WbsElementObligationItemBudget
add PostingDatePerSplKey datetime null
GO

alter table ImportFinancial.WbsElementObligationItemBudget
add DocumentDateOfBlKey datetime null
GO

-- ItemInvoice
--------------

alter table ImportFinancial.WbsElementObligationItemInvoice
add CreatedOnKey datetime null
GO

alter table ImportFinancial.WbsElementObligationItemInvoice
add PostingDateKey datetime null
GO