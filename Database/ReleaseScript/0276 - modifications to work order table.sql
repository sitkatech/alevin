--select * from dbo.WorkOrder order by WorkBreakdownStructureID

--exec sp_rename 'dbo.WorkOrder.WOID', 'WorkOrderName';

--exec sp_rename 'dbo.WorkOrder.WBS', 'WorkBreakdownStructure';

--exec sp_rename 'dbo.WorkOrder.FY', 'FiscalYear';

--exec sp_rename 'dbo.WorkOrder.Key Description', 'Description';


create table dbo.WorkBreakdownStructure
(
    WorkBreakdownStructureID int identity(1,1) not null constraint PK_WorkBreakdownStructure_WorkBreakdownStructureID primary key,
    WorkBreakdownStructureNumber varchar(50) not null
)


insert into dbo.WorkBreakdownStructure(WorkBreakdownStructureNumber)
select distinct wo.WorkBreakdownStructure
from dbo.WorkOrder as wo


update dbo.WorkOrder set 
WorkBreakdownStructureID = (select WorkBreakdownStructureID from dbo.WorkBreakdownStructure as wbs where wbs.WorkBreakdownStructureNumber = WorkOrder.WorkBreakdownStructure)


alter table dbo.WorkOrder
drop column WorkBreakdownStructure