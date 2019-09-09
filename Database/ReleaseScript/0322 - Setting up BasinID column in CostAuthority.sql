

--begin tran
CREATE TABLE [dbo].Basin
(
	BasinID [int] IDENTITY(1,1) NOT NULL,
	BasinAbbreviation [varchar](255) NULL,
	BasinName [varchar](255) NULL,
	CONSTRAINT [PK_Basin_BasinID] PRIMARY KEY CLUSTERED 
	(
		BasinID ASC
	)ON [PRIMARY]
) ON [PRIMARY]
GO
--rollback tran

SET IDENTITY_INSERT dbo.Basin ON
insert into dbo.Basin (BasinID, BasinAbbreviation, BasinName)
values (1, 'GR', 'Grande Ronde'),
       (2, 'JD', 'John Day'),
       (3, 'UC', 'Upper Columbia'),
       (4, 'US', 'Upper Salmon'),
       (5, 'Undefined', 'Undefined')
SET IDENTITY_INSERT dbo.Basin OFF


--BasinID	Basin
--1	GR
--2	JD
--3	UC
--4	US
--5	Undefined


alter table CostAuthority
add BasinID int null constraint FK_CostAuthority_Basin_BasinID foreign key references dbo.Basin(BasinID)
GO


/*
select * from CostAuthority
*/

update CostAuthority
set BasinID = cajb.BasinNumber
from CostAuthority
inner join dbo.CostAuthorityTable_JUST_BASIN as cajb on cajb.CostAuthorityWorkBreakdownStructure = CostAuthority.CostAuthorityWorkBreakdownStructure
where cajb.BasinNumber is not null
GO

alter table dbo.CostAuthority
drop column BasinNumber
GO

drop table dbo.CostAuthorityTable_JUST_BASIN;




create table dbo.Subbasin (
	SubbasinID int identity(1,1) not null constraint PK_Subbasin_SubbasinID primary key,
	SubbasinName varchar(100)
)
go

alter table dbo.CostAuthority
add SubbasinID int null constraint FK_CostAuthority_Subbasin_SubbasinID foreign key references dbo.Subbasin(SubbasinID);
go


insert into Subbasin (SubbasinName)
select distinct ca.Subbasin
from dbo.CostAuthority as ca
where ca.Subbasin is not null and ca.Subbasin != 'Undefined'


update CostAuthority
set SubbasinID = sb.SubbasinID
from CostAuthority
inner join dbo.Subbasin as sb on sb.SubbasinName = CostAuthority.Subbasin
GO


alter table dbo.CostAuthority
drop column Subbasin
--select * from dbo.CostAuthority
--select * from dbo.Subbasin


