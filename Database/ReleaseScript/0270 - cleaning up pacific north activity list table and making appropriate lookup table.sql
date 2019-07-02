select * from dbo.PacificNorthActivityList

create table dbo.PacificNorthActivityType (
	PacificNorthActivityTypeID int identity(1,1) not null constraint PK_PacificNorthActivityType_PacificNorthActivityTypeID primary key,
	PacificNorthActivityTypeName varchar(100)
)


alter table dbo.PacificNorthActivityList
add PacificNorthActivityTypeID int null constraint FK_PacificNorthActivityList_PacificNorthActivityType_PacificNorthActivityTypeID foreign key references dbo.PacificNorthActivityType(PacificNorthActivityTypeID)
go

insert into PacificNorthActivityType(PacificNorthActivityTypeName)
select distinct pnal.PacificNorthActivityType
from dbo.PacificNorthActivityList as pnal
where pnal.PacificNorthActivityType is not null


update PacificNorthActivityList
set PacificNorthActivityTypeID = pnat.PacificNorthActivityTypeID
from PacificNorthActivityList
inner join dbo.PacificNorthActivityType as pnat on pnat.PacificNorthActivityTypeName = PacificNorthActivityList.PacificNorthActivityType
GO


alter table PacificNorthActivityList
drop column PacificNorthActivityType
