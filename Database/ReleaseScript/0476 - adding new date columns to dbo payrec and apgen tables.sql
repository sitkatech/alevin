/*
CreatedOnKey
DateOfUpdateKey
PostingDateKey
PostingDatePerSplKey
DocumentDateOfBlKey 

*/


alter table dbo.StageImpPayRecV3
add CreatedOnKey datetime null;

alter table dbo.StageImpPayRecV3
add DateOfUpdateKey datetime null;

alter table dbo.StageImpPayRecV3
add PostingDateKey datetime null;

alter table dbo.StageImpPayRecV3
add PostingDatePerSplKey datetime null;

alter table dbo.StageImpPayRecV3
add DocumentDateOfBlKey datetime null;

alter table dbo.StageImpPayRecV3
alter column GoodsReceipt float null;

--may want to consider removing the UnexpendedBalance column
--it is not included in the latest sheet, but could be calculated from (obligation - disbursed)

/*
CreatedOnKey;
PostingDateKey;
*/

alter table dbo.StageImpApGenSheet
add CreatedOnKey datetime null;

alter table dbo.StageImpApGenSheet
add PostingDateKey datetime null;