/*
CreatedOnKey
DateOfUpdateKey
PostingDateKey
PostingDatePerSplKey
DocumentDateOfBlKey 

*/

alter table ImportFinancial.impPayRecV3
add CreatedOnKey datetime null;

alter table ImportFinancial.impPayRecV3
add DateOfUpdateKey datetime null;

alter table ImportFinancial.impPayRecV3
add PostingDateKey datetime null;

alter table ImportFinancial.impPayRecV3
add PostingDatePerSplKey datetime null;

alter table ImportFinancial.impPayRecV3
add DocumentDateOfBlKey datetime null;

alter table ImportFinancial.impPayRecV3
alter column [Goods Receipt] float null;

--may want to consider removing the UnexpendedBalance column
--it is not included in the latest sheet, but could be calculated from (obligation - disbursed)

/*
CreatedOnKey;
PostingDateKey;
*/

alter table ImportFinancial.impApGenSheet
add CreatedOnKey datetime null;

alter table ImportFinancial.impApGenSheet
add PostingDateKey datetime null;
