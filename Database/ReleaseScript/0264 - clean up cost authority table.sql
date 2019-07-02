--select * from dbo.CostAuthority

--select distinct HCategory from dbo.CostAuthority



 create table dbo.HabitatCategory(
	HabitatCategoryID int identity(1,1) not null constraint PK_HabitatCategory_HabitatCategoryID primary key,
	HabitatCategoryName varchar(50)
 )



insert into dbo.HabitatCategory(HabitatCategoryName)
select distinct ca.HCategory as HabitatCategoryName from dbo.CostAuthority as ca where ca.HCategory is not null
go


alter table dbo.CostAuthority
add HabitatCategoryID int null constraint FK_CostAuthority_HabitatCategory_HabitatCategoryID foreign key references dbo.HabitatCategory(HabitatCategoryID)
go

update dbo.CostAuthority set 
HabitatCategoryID = (select HabitatCategoryID from dbo.HabitatCategory as hc where hc.HabitatCategoryName = CostAuthority.HCategory)

alter table dbo.CostAuthority
drop column HCategory


exec sp_rename 'dbo.CostAuthority.CostAuthority', 'CostAuthorityNumber'