
--begin tran

CREATE TABLE [dbo].SubbasinLiason
(
	SubbasinLiasonID [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	GeospatialAreaID [int] NOT NULL,
	PersonID [int] NOT NULL
 CONSTRAINT [PK_SubbasinLiason_SubbasinLiasonID] PRIMARY KEY CLUSTERED 
(
	SubbasinLiasonID ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SubbasinLiason_SubbasinLiasonID_TenantID] UNIQUE NONCLUSTERED 
(
	SubbasinLiasonID ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SubbasinLiason]  WITH CHECK ADD  CONSTRAINT [FK_SubbasinLiason_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO

ALTER TABLE [dbo].[SubbasinLiason]  WITH CHECK ADD  CONSTRAINT [FK_SubbasinLiason_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO

ALTER TABLE [dbo].[SubbasinLiason]  WITH CHECK ADD  CONSTRAINT [FK_SubbasinLiason_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

--rollback tran


-- Add users to HUCs


declare @SteveKolkPersonID int;
set @SteveKolkPersonID = (select  PersonID from dbo.Person where FirstName = 'Steve' and LastName = 'Kolk')

declare @AlSimpson int;
set @AlSimpson = (select  PersonID from dbo.Person where FirstName = 'Al' and LastName = 'Simpson')

declare @BrianHamilton int;
set @BrianHamilton = (select  PersonID from dbo.Person where FirstName = 'Brian' and LastName = 'Hamilton')

declare @MarkCroghan int;
set @MarkCroghan = (select  PersonID from dbo.Person where FirstName = 'Mark' and LastName = 'Croghan')


insert into dbo.SubbasinLiason (TenantID, PersonID, GeospatialAreaID)
select 
	12 as TenantID,
	@SteveKolkPersonID as PersonID,
	ga.GeospatialAreaID 
from dbo.GeospatialArea as ga 
where 
	ga.GeospatialAreaTypeID = 20 
	and ga.TenantID = 12
	and (ga.GeospatialAreaName like '% - 17020008%' or ga.GeospatialAreaName like '% - 17020010%' or ga.GeospatialAreaName like '% - 17020011%')


insert into dbo.SubbasinLiason (TenantID, PersonID, GeospatialAreaID)
select 
	12 as TenantID,
	@AlSimpson as PersonID,
	ga.GeospatialAreaID 
from dbo.GeospatialArea as ga 
where 
	ga.GeospatialAreaTypeID = 20 
	and ga.TenantID = 12
	and (ga.GeospatialAreaName like '% - 170601%')


insert into dbo.SubbasinLiason (TenantID, PersonID, GeospatialAreaID)
select 
	12 as TenantID,
	@BrianHamilton as PersonID,
	ga.GeospatialAreaID 
from dbo.GeospatialArea as ga 
where 
	ga.GeospatialAreaTypeID = 20 
	and ga.TenantID = 12
	and (ga.GeospatialAreaName like '% - 17060201%' or ga.GeospatialAreaName like '% - 17060202%' or ga.GeospatialAreaName like '% - 17060204%')


insert into dbo.SubbasinLiason (TenantID, PersonID, GeospatialAreaID)
select 
	12 as TenantID,
	@MarkCroghan as PersonID,
	ga.GeospatialAreaID 
from dbo.GeospatialArea as ga 
where 
	ga.GeospatialAreaTypeID = 20 
	and ga.TenantID = 12
	and (ga.GeospatialAreaName like '% - 17070201%' or ga.GeospatialAreaName like '% - 17070202%' or ga.GeospatialAreaName like '% - 17070203%' or ga.GeospatialAreaName like '% - 17070204%')




--Steve Kolk	
--170200	Upper Columbia Basin, WA
--17020008	Methow
--17020010	Entiat
--17020011	Wenatchee
	
--Al Simpson	
--170601	Grande Ronde Basin, OR
	
--Brian Hamilton	
--170602	Salmon Basin, ID
--17060201	Upper Salmon
--17060202	Pahsimeroi
--17060204	Lemhi
	
--Mark Croghan	
--170702	John Day Basin, OR
--17070201	Upper Main JD
--17070202	North Fork JD
--17070203	Middle Fork JD
--17070204	Lower JD
	

