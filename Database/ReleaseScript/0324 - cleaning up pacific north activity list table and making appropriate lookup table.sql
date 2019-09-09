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



create table dbo.PacificNorthActivityStatus (
	PacificNorthActivityStatusID int identity(1,1) not null constraint PK_PacificNorthActivityStatus_PacificNorthActivityStatusID primary key,
	PacificNorthActivityStatusName varchar(100)
)


alter table dbo.PacificNorthActivityList
add PacificNorthActivityStatusID int null constraint FK_PacificNorthActivityList_PacificNorthActivityStatus_PacificNorthActivityStatusID foreign key references dbo.PacificNorthActivityStatus(PacificNorthActivityStatusID)
go

insert into PacificNorthActivityStatus(PacificNorthActivityStatusName)
select distinct pnal.PacificNorthActivityStatus
from dbo.PacificNorthActivityList as pnal
where pnal.PacificNorthActivityStatus is not null


update PacificNorthActivityList
set PacificNorthActivityStatusID = pnat.PacificNorthActivityStatusID
from PacificNorthActivityList
inner join dbo.PacificNorthActivityStatus as pnat on pnat.PacificNorthActivityStatusName = PacificNorthActivityList.PacificNorthActivityStatus
GO


alter table PacificNorthActivityList
drop column PacificNorthActivityStatus
