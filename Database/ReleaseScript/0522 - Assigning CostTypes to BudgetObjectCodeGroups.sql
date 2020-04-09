

--select * from Reclamation.BudgetObjectCodeGroup
--where ParentBudgetObjectCodeGroupID is null


alter table Reclamation.BudgetObjectCodeGroup
add CostTypeID int null constraint FK_BudgetObjectCodeGroup_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID);
GO

update Reclamation.BudgetObjectCodeGroup set CostTypeID = 15 where BudgetObjectCodeGroupID = 1;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 13 where BudgetObjectCodeGroupID = 12;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 13 where BudgetObjectCodeGroupID = 18;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 11 where BudgetObjectCodeGroupID = 19;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 11 where BudgetObjectCodeGroupID = 23;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 12 where BudgetObjectCodeGroupID = 24;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 11 where BudgetObjectCodeGroupID = 33;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 14 where BudgetObjectCodeGroupID = 34;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 11 where BudgetObjectCodeGroupID = 39;
update Reclamation.BudgetObjectCodeGroup set CostTypeID = 11 where BudgetObjectCodeGroupID = 44;




/*

1	10	Personnel Compensation and Benefits	NULL	15	Personnel & Benefits	
12	21	Travel and Transportation of Persons	11	13	Travel	
18	22	Transportation of Things	11	13		
19	23	Rent, Communications, and Utilities	11	11	Other	
23	24	Printing and Reproducation	11	11		
24	25	Other Contractural Services	11	12	Contractual	
33	26	Supplies and Materials	11	11	Other	
34	30	Acquisition of Assets	NULL	14	Supplies	
39	40	Grants and Fixed Charges	NULL	11	Other	
44	90	Other	NULL	11		





12	Contractual
11	Other
15	Personnel & Benefits
14	Supplies
13	Travel

*/