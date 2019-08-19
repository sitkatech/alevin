
--select * from dbo.Agreement


-- Changed our minds, need this later
--alter table dbo.Agreement
--drop column ContractorLU


create table dbo.ContractType(
    ContractTypeID int identity(1,1) not null constraint PK_ContractType_ContractTypeID primary key,
    ContractTypeName varchar(255),
    ContractTypeDisplayName varchar(255)
)


insert into dbo.ContractType (ContractTypeName, ContractTypeDisplayName)
select distinct REPLACE (a.ContractType, ' ', '') as ContractTypeName, a.ContractType as ContractTypeDisplayName from dbo.Agreement as a
go


alter table dbo.Agreement
add ContractTypeID int null constraint FK_Agreement_ContractType_ContractTypeID foreign key references dbo.ContractType(ContractTypeID)
go


update dbo.Agreement set 
ContractTypeID = (select ContractTypeID from dbo.ContractType as ct where ct.ContractTypeDisplayName = Agreement.ContractType)


alter table dbo.Agreement
drop column ContractType;
go

alter table dbo.Agreement
alter column ContractTypeID int not null
go