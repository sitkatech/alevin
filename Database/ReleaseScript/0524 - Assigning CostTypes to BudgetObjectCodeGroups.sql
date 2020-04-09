

--select * from Reclamation.BudgetObjectCodeGroup
--where ParentBudgetObjectCodeGroupID is null


alter table Reclamation.BudgetObjectCodeGroup
add CostTypeID int null constraint FK_BudgetObjectCodeGroup_CostType_CostTypeID foreign key references dbo.CostType(CostTypeID);
GO

insert into dbo.CostType(TenantID, CostTypeName)
values
(12, 'Lands & Real Estate'),
(12, 'Grants & Agreements');


update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Personnel & Benefits') --15
where BudgetObjectCodeGroupID in (1);

update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Travel') --13 
where BudgetObjectCodeGroupID in (12, 18);

update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Other') --11 
where BudgetObjectCodeGroupID in (19, 23, 39, 44);

update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Contractual') --12 
where BudgetObjectCodeGroupID in (11,24);

update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Supplies') --14 
where BudgetObjectCodeGroupID in (33, 34);

update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Lands & Real Estate') --?? 
where BudgetObjectCodeGroupID in (36, 38);

update Reclamation.BudgetObjectCodeGroup 
set CostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Grants & Agreements') --?? 
where BudgetObjectCodeGroupID in (40);



alter table Reclamation.BudgetObjectCode
add OverrideCostTypeID int null constraint FK_BudgetObjectCode_CostType_OverrideCostTypeID_CostTypeID foreign key references dbo.CostType(CostTypeID);
GO

--253D00, 253I00, 253S00 and 253Z00 are part of personnel & Benefits
update Reclamation.BudgetObjectCode
set OverrideCostTypeID = (select CostTypeID from dbo.CostType where TenantID = 12 and CostTypeName = 'Personnel & Benefits')
where BudgetObjectCodeName in ('253D00', '253I00', '253S00', '253Z00');





/*


select * from Reclamation.BudgetObjectCodeGroup as bocg left join dbo.CostType as ct on bocg.CostTypeID = ct.CostTypeID



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