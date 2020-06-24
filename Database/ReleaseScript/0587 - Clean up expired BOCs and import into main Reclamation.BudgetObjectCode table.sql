--select * from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]

-- Delete grouping entries in this import
delete from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
where [Group] in (10,11,11.1,11.3,11.5,11.8,11.9,12,12.1,20,21, 43, 44, 90, 91, 93, 94, 99, 99.5, 99.9, 33, 40, 41, 32.3, 26, 30, 92)

-- Delete more grouping entries in this import
delete from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
where [Group] in (21.1, 21.2, 21.3, 21.4, 22, 23, 23.1, 23.2, 23.3, 24, 25.2, 25.3, 25.4, 25.6, 25.7, 25.8, 31, 32, 42, 21.9, 25.5)

-- Manual fixup
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = '259700' where FBMS_2017 = '2597'

-- Now we are left with only actual leaves - real BOC entries, not groups.
-- Fill in the BOC Names
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = FBMS_2015
where FBMS_2015 is not null and BudgetObjectCodeName is null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = FBMS_2016
where FBMS_2016 is not null and BudgetObjectCodeName is null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set BudgetObjectCodeName = FBMS_2017
where FBMS_2017 is not null and BudgetObjectCodeName is null

-- Now we can reconstruct our Group column, with BudgetObjectCodeName fully filled in
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [Group] = SUBSTRING(BudgetObjectCodeName, 1, 2) + '.' + SUBSTRING(BudgetObjectCodeName, 3, 1)


-- Now that we have the BudgetObjectCodeName safely tucked
-- away in, we can get the year columns ready for an unpivot, and
-- put the FbmsYear values into them.
update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2004] = 2004 
where [2004] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2005] = 2005 
where [2005] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2006] = 2006 
where [2006] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2010] = 2010 
where [2010] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [2011] = 2011 
where [2011] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2014] = 2014
where [FBMS_2014] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2015] = 2015
where [FBMS_2015] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2016] = 2016
where [FBMS_2016] is not null

update [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]
set [FBMS_2017] = 2017
where [FBMS_2017] is not null


--select * from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW]

select eboc.BudgetObjectCodeName,
       eboc.BOC_item,
       eboc.Definitions,
       eboc.[1099_Reportable],
       eboc.[1099_Explanation]
from 
[ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] as eboc

-- Temp table to help with BOC FBMS year reconstruction
DROP TABLE IF EXISTS #UnpivotedExpiredBudgetObjectCodes

-- Attempting unpivot
select
       unpiv.BudgetObjectCodeName,
       unpiv.[Group] as PossibleBudgetObjectCodeGroupPrefix,
       -1 as BudgetObjectCodeGroupID,
       unpiv.BOC_item,
       unpiv.Definitions,
       unpiv.[1099_Reportable],
       unpiv.[1099_Explanation],
       unpiv.FbmsYear
into #UnpivotedExpiredBudgetObjectCodes
from
(select
       ebocx.BudgetObjectCodeName,
       ebocx.[Group],
       ebocx.BOC_item,
       ebocx.Definitions,
       ebocx.[1099_Reportable],
       ebocx.[1099_Explanation],
       ebocx.[2004],
       ebocx.[2005],
       ebocx.[2006],
       ebocx.[2010],
       ebocx.[2011],
       ebocx.[FBMS_2014],
       ebocx.[FBMS_2015],
       ebocx.[FBMS_2016],
       ebocx.[FBMS_2017]
  from [ReclamationOneTimeImport].[EXPIRED_BOCS_RAW] as ebocx) as piv
unpivot
    (FbmsYear for FmbsYear in ([2004],
                               [2005],
                               [2006],
                               [2010],
                               [2011],
                               [FBMS_2014],
                               [FBMS_2015],
                               [FBMS_2016],
                               [FBMS_2017])
    )as unpiv

--select * from #UnpivotedExpiredBudgetObjectCodes

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
from  #UnpivotedExpiredBudgetObjectCodes as unpiv
inner join Reclamation.BudgetObjectCodeGroup as bocg on  unpiv.PossibleBudgetObjectCodeGroupPrefix = bocg.BudgetObjectCodeGroupPrefix

-- We still have some groups unmatched.
--select * from #UnpivotedExpiredBudgetObjectCodes
--where BudgetObjectCodeGroupID = -1

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '22')
where PossibleBudgetObjectCodeGroupPrefix in( '22.1', '22.2')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '25')
where PossibleBudgetObjectCodeGroupPrefix in( '25.9')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '31')
where PossibleBudgetObjectCodeGroupPrefix in( '31.1', '31.2', '31.9')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '32')
where PossibleBudgetObjectCodeGroupPrefix in( '32.1', '32.7', '32.9')

update #UnpivotedExpiredBudgetObjectCodes
set BudgetObjectCodeGroupID = (select BudgetObjectCodeGroupID from Reclamation.BudgetObjectCodeGroup where BudgetObjectCodeGroupPrefix = '42')
where PossibleBudgetObjectCodeGroupPrefix in( '42.1')

-- Should be no more groups unmatched.
--select * from #UnpivotedExpiredBudgetObjectCodes
--where BudgetObjectCodeGroupID = -1

/* 
-- Double check visually

select bocg.BudgetObjectCodeGroupID,
       bocg.BudgetObjectCodeGroupPrefix as boc_prefix,
       unpiv.PossibleBudgetObjectCodeGroupPrefix as unpiv_prefix,
       bocg.BudgetObjectCodeGroupName
from #UnpivotedExpiredBudgetObjectCodes as unpiv
inner join Reclamation.BudgetObjectCodeGroup as bocg on unpiv.BudgetObjectCodeGroupID = bocg.BudgetObjectCodeGroupID
*/

-- Insert the new BudgetObjectCodes
insert into Reclamation.BudgetObjectCode(BudgetObjectCodeName, 
                                         BudgetObjectCodeItemDescription, 
                                         BudgetObjectCodeDefinition, 
                                         BudgetObjectCodeGroupID, 
                                         FbmsYear, 
                                         Reportable1099, 
                                         Explanation1099, 
                                         IsExpiredOrDeleted)
select newBocs.BudgetObjectCodeName,
       '' as BudgetObjectCodeItemDescription,
       newBocs.Definitions,
       newBocs.BudgetObjectCodeGroupID,
       newBocs.FbmsYear,
       CASE when newBocs.[1099_Reportable] = 'Yes' then 1
            when newBocs.[1099_Reportable] = 'No' then 0
            else null end as Reportable1099,
       newBocs.[1099_Explanation],
       -- All the ones we are importing now are expired/deleted
       1 as IsExpiredOrDeleted
from #UnpivotedExpiredBudgetObjectCodes as newBocs


-- And there's more. These are missing years that didn't come across
-- cleanly in original imports I believe. -- SLG 6/23/2020
insert into Reclamation.BudgetObjectCode(BudgetObjectCodeName, 
                                         BudgetObjectCodeItemDescription, 
                                         BudgetObjectCodeDefinition, 
                                         BudgetObjectCodeGroupID, 
                                         FbmsYear, 
                                         Reportable1099, 
                                         Explanation1099, 
                                         IsExpiredOrDeleted)
values
('252U00', 'Contracts - Studies', 'Contracts for studies or inventories which involve the procurement of definitive information or data in support of mission oriented tasks, e.g., archeological inventories, soil-vegetative inventories, wildlife habitat analysis, minerals surveys, geologic ', 26, 2013, 1, '1099 Eligible - payment for service', 0),
('253H00', 'Reimbursable Agreements - Other Agency', 'Interagency agreements for contractual services with non-DOI bureaus/offices (including the Economy Act).', 27, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('252R00', 'Contracts - Professional Services', 'Contracts for professional services such as for cadastral surveys, veterinarian services, and work of a similar nature.  (Excludes architectural and engineering services that is classified in Object Class 25.2A).', 26, 2013, 1, '1099 Eligible - payment for service', 0),
('233C00', 'Commercial Communications Charges - Local', 'Payments for local voice carrier telecommunications services.', 22, 2014, 1, '1099 Eligible - payment for service', 0),
('251A00', 'Contracts - Professional Consultants', 'Professional Consultants including Scientific Studies.  IT services are not included under this BOC.', 25, 2013, 1, '1099 Eligible - payment for service', 0),
('213P00', 'Non-Foreign POV Mileage Allowance', 'Travel allowance for mileage based on the current allowable mileage rates for permanent change of station moves while the employee is traveling enroute to the new duty station.', 15, 2015, 0, 'Employee Travel - will never be 1099 eligible', 0),
('253H00', 'Reimbursable Agreements - Other Agency', 'Interagency agreements for contractual services with non-DOI bureaus/offices (including the Economy Act).', 27, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('251B00', 'Information Technology & Telecom Professional Services', 'IT Professional & Support Services from Federal & non-Federal sources.  Professional services are those which require specialized expertise related to improving organizational performance & the development of plans for that improvement.  Examples include:', 25, 2020, 1, '1099 Eligible - payment for service', 0),
('253L00', 'Intra-bureau funded agreements for Science and Engineering Services', 'Specific to BOR for intra-bureau funded agreements for Science and Engineering Services.', 27, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('253G00', 'Reimbursable Agreements - Internal', 'RSAs with other DOI bureaus/offices.', 27, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('252Z00', 'Other', 'Report contractual services with non-Federal sources that are not otherwise classified under object class 25.0.', 26, 2015, 1, '1099 Eligible - payment for service', 0),
('312B00', 'Non-Capitalized - Non-Controlled Equipment', 'Purchase of Non-Capitalized - Non-Controlled Equipment not subject to special handling or control.', 35, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('264B00', 'Field Supplies', 'Supplies for field use.', 33, 2013, 0, 'This is considered a good.', 0),
('253H00', 'Reimbursable Agreements - Other Agency', 'Interagency agreements for contractual services with non-DOI bureaus/offices (including the Economy Act).', 27, 2020, 0, 'Determined to be NOT 1099 Eligible', 0),
('252U00', 'Contracts - Studies', 'Contracts for studies or inventories which involve the procurement of definitive information or data in support of mission oriented tasks, e.g., archeological inventories, soil-vegetative inventories, wildlife habitat analysis, minerals surveys, geologic ', 26, 2020, 1, '1099 Eligible - payment for service', 0),
('121300', 'Relocation - Real Estate Transactions (Direct Reimb)', 'Allowable closing costs for direct reimbursement of the sale or purchase of real estate in association with an approved permanent change of station (PCS) move.', 9, 2013, 0, 'Agency Non-1099 activity', 0),
('213D00', 'Non-Foreign Employee Per Diem', 'Travel allowance for lodging and M&IE for the employee to travel enroute to the new duty station.', 15, 2015, 0, 'Employee Travel - will never be 1099 eligible', 0),
('252U00', 'Contracts - Studies', 'Contracts for studies or inventories which involve the procurement of definitive information or data in support of mission oriented tasks, e.g., archeological inventories, soil-vegetative inventories, wildlife habitat analysis, minerals surveys, geologic ', 26, 2015, 1, '1099 Eligible - payment for service', 0),
('252R00', 'Contracts - Professional Services', 'Contracts for professional services such as for cadastral surveys, veterinarian services, and work of a similar nature.  (Excludes architectural and engineering services that is classified in Object Class 25.2A).', 26, 2015, 1, '1099 Eligible - payment for service', 0),
('121600', 'Relocation - Miscellaneous Moving Allowance', 'Set amount based on marital status, paid to an employee related to an approved  permanent change of station (PCS) move, for Miscellaneous Expenses not covered by any other relocation allowance.', 9, 2015, 0, 'Agency Non-1099 activity', 0),
('312D00', 'Non-Capitalized - Information Technology Software', 'Purchase of information technology software, custom or commercial off-the-shelf. Purchase price is under the bureaus capitalization threshold that is reported in the property system.', 35, 2020, 0, 'Determined to be NOT 1099 Eligible', 0),
('312E00', 'Non-Capitalized - Information Technology Equipment, Controlled', 'Purchase of information technology hardware, custom or commercial off-the-shelf. Price is below the capitalization threshold but controlled.', 35, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('257P00', 'Storage of Household Goods under PCS', 'Storage and care of household goods. For storage less than 120 days see Object Class 22.4F.', 31, 2015, 1, 'Vendors are providing a service', 0),
('121500', 'Relocation - Income Tax Allowance and Withholding', 'Relocation Income Tax allowance (RITA) and Withholding Tax Allowance (WTA) related to an approved  permanent change of station (PCS) move.', 9, 2014, 0, 'Agency Non-1099 activity', 0),
('233U00', 'Commercial Data Communications Services', 'Payments for commercial data communication services.', 22, 2013, 1, '1099 Eligible - payment for service', 0),
('257C00', 'Repairs & Maintenance - IT Equipment & Software', 'Repairs and maintenance of IT equipment and software when done by contract with the private sector or another Federal Government agency.', 31, 2015, 1, 'Vendors are providing operations and maintenance', 0),
('252A00', 'Contracts - Architectural & Engineering', 'Contracts for professional services of architects and engineers.', 26, 2020, 1, '1099 Eligible - payment for service', 0),
('413A00', 'Indian Tribal Government Grant', 'Cash payments to Indian tribes.', 40, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('213W00', 'Non-Foreign Transportation - Advance House Hunting', 'Travel allowance for transportation costs for approved house hunting trip on an approved permanent change of station move.', 15, 2015, 0, 'Employee Travel - will never be 1099 eligible', 0),
('241A00', 'Printing & Reproduction - GPO', 'Printing and reproduction obtained from GPO.', 23, 2015, 0, 'Determined to be NOT 1099 Eligible - payment to other Govt Agencies', 0),
('411C00', 'Cooperative Agreements', 'Cooperative Agreements.', 40, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('252K00', 'Contracts - On Site Contractor', 'Non-Federal contract personnel.', 26, 2015, 1, '1099 Eligible - payment for service', 0),
('213V00', 'Non-Foreign Per Diem - House Hunting', 'Travel allowance for lodging and M&IE for approved house hunting trip on an approved permanent change of station move.', 15, 2015, 0, 'Employee Travel - will never be 1099 eligible', 0),
('413A00', 'Indian Tribal Government Grant', 'Cash payments to Indian tribes.', 40, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('233K00', 'Utilities', 'Utility services include water, gas, and electricity.', 22, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('411C00', 'Cooperative Agreements', 'Cooperative Agreements.', 40, 2020, 0, 'Determined to be NOT 1099 Eligible', 0),
('232A00', 'Space Rental Payments To Others', 'Payments to a non-Federal source for rental of space, land, and structures.', 21, 2020, 1, '1099 Eligible bc payment to a non-Federal source', 0),
('312D00', 'Non-Capitalized - Information Technology Software', 'Purchase of information technology software, custom or commercial off-the-shelf. Purchase price is under the bureau''s capitalization threshold that is reported in the property system.', 35, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('233C00', 'Commercial Communications Charges - Local', 'Payments for local voice carrier telecommunications services.', 22, 2013, 1, '1099 Eligible - payment for service', 0),
('253G00', 'Reimbursable Agreements - Internal', 'RSA''s with other DOI bureaus/offices.', 27, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('121300', 'Relocation - Real Estate Transactions (Direct Reimb)', 'Allowable closing costs for direct reimbursement of the sale or purchase of real estate in association with an approved permanent change of station (PCS) move.', 9, 2015, 0, 'Agency Non-1099 activity', 0),
('312J00', 'Non-Capitalized - Copier/Duplicator', 'Copier that is not capitalized.', 35, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('411C00', 'Cooperative Agreements', 'Cooperative Agreements.', 40, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('252A00', 'Contracts - Architectural & Engineering', 'Contracts for professional services of architects and engineers.', 26, 2015, 1, '1099 Eligible - payment for service', 0),
('224F00', 'Transportation - Household Goods - GBL', 'PCS related moving expenses including temporary storage of household goods of less than 120 days; for longer term storage, see Object Class 25.7P.', 18, 2015, 0, 'PCS Expenses - determined to be not 1099 eligible', 0),
('251V00', 'Geospatial Services', 'Geospatial Services that are completed by Federal or non-federal sources.  Examples include land surveys, cadastral services, and aerial photographic services, among others.  Operations and maintenance of Geospatial equipment and facilties is not captured', 25, 2020, 1, 'Vendors are providing a service which includes renting', 0),
('241A00', 'Printing & Reproduction - GPO', 'Printing and reproduction obtained from GPO.', 23, 2013, 0, 'Determined to be NOT 1099 Eligible - payment to other Govt Agencies', 0),
('312B00', 'Non-Capitalized - Non-Controlled Equipment', 'Purchase of Non-Capitalized - Non-Controlled Equipment not subject to special handling or control.', 35, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('253L00', 'Intra-bureau funded agreements for Science and Engineering Services', 'Specific to BOR for intra-bureau funded agreements for Science and Engineering Services.', 27, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('252R00', 'Contracts - Professional Services', 'Contracts for professional services such as for cadastral surveys, veterinarian services, and work of a similar nature.  (Excludes architectural and engineering services that is classified in Object Class 25.2A).', 26, 2014, 1, '1099 Eligible - payment for service', 0),
('257C00', 'Repairs & Maintenance - IT Equipment & Software', 'Repairs and maintenance of IT equipment and software when done by contract with the private sector or another Federal Government agency.', 31, 2014, 1, 'Vendors are providing operations and maintenance', 0),
('251A00', 'Contracts - Professional Consultants', 'Professional Consultants including Scientific Studies.  IT services are not included under this BOC.', 25, 2014, 1, '1099 Eligible - payment for service', 0),
('252U00', 'Contracts - Studies', 'Contracts for studies or inventories which involve the procurement of definitive information or data in support of mission oriented tasks, e.g., archeological inventories, soil-vegetative inventories, wildlife habitat analysis, minerals surveys, geologic ', 26, 2014, 1, '1099 Eligible - payment for service', 0),
('312J00', 'Non-Capitalized - Copier/Duplicator', 'Copier that is not capitalized.', 35, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('253G00', 'Reimbursable Agreements - Internal', 'RSA''s with other DOI bureaus/offices.', 27, 2020, 0, 'Determined to be NOT 1099 Eligible', 0),
('121500', 'Relocation - Income Tax Allowance and Withholding', 'Relocation Income Tax allowance (RITA) and Withholding Tax Allowance (WTA) related to an approved  permanent change of station (PCS) move.', 9, 2013, 0, 'Agency Non-1099 activity', 0),
('232A00', 'Space Rental Payments To Others', 'Payments to a non-Federal source for rental of space, land, and structures.', 21, 2015, 1, '1099 Eligible bc payment to a non-Federal source', 0),
('253L00', 'Intra-bureau funded agreements for Science and Engineering Services', 'Specific to BOR for intra-bureau funded agreements for Science and Engineering Services.', 27, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('253H00', 'Reimbursable Agreements - Other Agency', 'Interagency agreements for contractual services with non-DOI bureaus/offices (including the Economy Act).', 27, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('233C00', 'Commercial Communications Charges - Local', 'Payments for local voice carrier telecommunications services.', 22, 2015, 1, '1099 Eligible - payment for service', 0),
('211I00', 'Non-Foreign Other Miscellaneous Expenses', 'Miscellaneous travel expenses which are other expenses directly related to official travel such as baggage transfers and telephone and telegraph services.', 13, 2020, 0, 'Employee Travel - will never be 1099 eligible', 0),
('252Z00', 'Other', 'Report contractual services with non-Federal sources that are not otherwise classified under object class 25.0.', 26, 2014, 1, '1099 Eligible - payment for service', 0),
('252A00', 'Contracts - Architectural & Engineering', 'Contracts for professional services of architects and engineers.', 26, 2013, 1, '1099 Eligible - payment for service', 0),
('253G00', 'Reimbursable Agreements - Internal', 'RSA''s with other DOI bureaus/offices.', 27, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('233U00', 'Commercial Data Communications Services', 'Payments for commercial data communication services.', 22, 2015, 1, '1099 Eligible - payment for service', 0),
('312A00', 'Non-Capitalized - Controlled Equipment', 'Armaments including special and miscellaneous military equipment.', 35, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('224F00', 'Transportation - Household Goods - GBL', 'PCS related moving expenses including temporary storage of household goods of less than 120 days; for longer term storage, see Object Class 25.7P.', 18, 2013, 0, 'PCS Expenses - determined to be not 1099 eligible', 0),
('413A00', 'Indian Tribal Government Grant', 'Cash payments to Indian tribes.', 40, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('121200', 'Relocation - Subsistence in Temporary Quarters', 'Per diem for employees in an approved Temporary Quarters status relating to an approved permanent change of station (PCS) and Temporary Change of Station (TCS) move.', 9, 2015, 0, 'Agency Non-1099 activity', 0),
('312D00', 'Non-Capitalized - Information Technology Software', 'Purchase of information technology software, custom or commercial off-the-shelf. Purchase price is under the bureau''s capitalization threshold that is reported in the property system.', 35, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('252A00', 'Contracts - Architectural & Engineering', 'Contracts for professional services of architects and engineers.', 26, 2014, 1, '1099 Eligible - payment for service', 0),
('233K00', 'Utilities', 'Utility services include water, gas, and electricity.', 22, 2015, 0, 'Determined to be NOT 1099 Eligible', 0),
('312E00', 'Non-Capitalized - Information Technology Equipment, Controlled', 'Purchase of information technology hardware, custom or commercial off-the-shelf. Price is below the capitalization threshold but controlled.', 35, 2020, 0, 'Determined to be NOT 1099 Eligible', 0),
('252K00', 'Contracts - On Site Contractor', 'Non-Federal contract personnel.', 26, 2014, 1, '1099 Eligible - payment for service', 0),
('213P00', 'Non-Foreign POV Mileage Allowance', 'Travel allowance for mileage based on the current allowable mileage rates for permanent change of station moves while the employee is traveling enroute to the new duty station.', 15, 2013, 0, 'Employee Travel - will never be 1099 eligible', 0),
('232A00', 'Space Rental Payments To Others', 'Payments to a non-Federal source for rental of space, land, and structures.', 21, 2014, 1, '1099 Eligible bc payment to a non-Federal source', 0),
('411C00', 'Cooperative Agreements', 'Cooperative Agreements.', 40, 2014, 0, 'Determined to be NOT 1099 Eligible', 0),
('253C00', 'Rental Agreements for Other Federal Agencies', 'Rental agreements from other Federal Government agencies other than GSA.', 27, 2013, 0, 'Determined to be NOT 1099 Eligible', 0),
('121500', 'Relocation - Income Tax Allowance and Withholding', 'Relocation Income Tax allowance (RITA) and Withholding Tax Allowance (WTA) related to an approved  permanent change of station (PCS) move.', 9, 2015, 0, 'Agency Non-1099 activity', 0)

-- A few hand jams
insert into Reclamation.BudgetObjectCode(BudgetObjectCodeName, 
                                         BudgetObjectCodeItemDescription, 
                                         BudgetObjectCodeDefinition, 
                                         BudgetObjectCodeGroupID, 
                                         FbmsYear, 
                                         Reportable1099, 
                                         Explanation1099, 
                                         IsExpiredOrDeleted)
values
('252Q00', '', 'Contractual services for the collection of data through aerial photography and the related mapping.', 26, 2012, 1, null, 1),
('252Q00', '', 'Contractual services for the collection of data through aerial photography and the related mapping.', 26, 2013, 1, null, 1)



