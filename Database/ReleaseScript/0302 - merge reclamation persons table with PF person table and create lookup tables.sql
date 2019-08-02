

create table  dbo.ReclamationLocation(
	ReclamationLocationID int identity(1,1) not null constraint PK_ReclamationLocation_ReclamationLocationID primary key,
	ReclamationLocationName varchar(255),
	ReclamationLocationAbbreviation varchar(255)
)
go

insert into dbo.ReclamationLocation (ReclamationLocationName, ReclamationLocationAbbreviation)
select distinct [Location] as ReclamationLocationName, [Location] as ReclamationLocationAbbreviation from dbo.ReclamationPersonsTable
where [Location] is not null
go





create table dbo.ReclamationDepartmentCode (
	ReclamationDepartmentCodeID int identity(1,1) not null constraint PK_ReclamationDepartmentCode_ReclamationDepartmentCodeID primary key,
	ReclamationDepartmentCodeName varchar(255)
)
go

insert into dbo.ReclamationDepartmentCode (ReclamationDepartmentCodeName)
select distinct [DeptartmentCode] from dbo.ReclamationPersonsTable where DeptartmentCode is not null
go


alter table dbo.Person
add 
	ReclamationStaffID int null,
	ReclamationLocationID int null constraint FK_Person_ReclamationLocation_ReclamationLocationID foreign key references dbo.ReclamationLocation(ReclamationLocationID),
	ReclamationDepartmentCodeID int null constraint FK_Person_ReclamationDepartmentCode_ReclamationDepartmentCodeID foreign key references dbo.ReclamationDepartmentCode(ReclamationDepartmentCodeID),
	ReclamationRTSContact varchar(255)

go

--select * from dbo.Organization where TenantID = 12
--select * from dbo.[Role]
--select * from dbo.Person where TenantID = 12

insert into dbo.Person (TenantID, PersonGuid, FirstName, LastName, Email, Phone, RoleID, CreateDate, IsActive, OrganizationID, ReceiveSupportEmails, LoginName, ReclamationStaffID, ReclamationLocationID, ReclamationDepartmentCodeID, ReclamationRTSContact)
select 
	12 as TenantID,
	NEWID() as PersonGuid,
	rpt.FirstName as FirstName,
	rpt.LastName as LastName,
	'unknown' + cast(rpt.ReclamationStaffID as varchar) + '@example.com' as Email,
	rpt.Phone as Phone,
	7 as RoleID,
	GETDATE() as CreateDate,
	1 as IsActive,
	CASE substring(rpt.RTSContact, 0, 4)  
        WHEN 'BOR' THEN 6160   
        ELSE 6161  
    END as OrganizationID,
	0 as ReceiveSupportEmails,
	'unknown' + cast(rpt.ReclamationStaffID as varchar) + '@example.com' as LoginName,
	rpt.ReclamationStaffID as ReclamationStaffID,
	(select ReclamationLocationID from dbo.ReclamationLocation as rl where rl.ReclamationLocationName = rpt.[Location]) as ReclamationLocationID,
	(select ReclamationDepartmentCodeID from dbo.ReclamationDepartmentCode as rdp where rdp.ReclamationDepartmentCodeName = rpt.DeptartmentCode) as ReclamationDepartmentCodeID,
	rpt.RTSContact as ReclamationRTSContact
from
	dbo.ReclamationPersonsTable as rpt
