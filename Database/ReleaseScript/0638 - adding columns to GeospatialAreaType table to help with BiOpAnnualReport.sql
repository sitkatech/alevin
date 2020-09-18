alter table dbo.GeospatialAreaType
add EsuDpsGeospatialAreaTypeID int null
go

ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID] FOREIGN KEY([EsuDpsGeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO

ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_EsuDpsGeospatialAreaTypeID]
GO



alter table dbo.GeospatialAreaType
add MPGGeospatialAreaTypeID int null
go

ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID] FOREIGN KEY([MPGGeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO

ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_MPGGeospatialAreaTypeID]
GO


alter table dbo.GeospatialAreaType
add PopulationGeospatialAreaTypeID int null
go

ALTER TABLE [dbo].[GeospatialAreaType]  WITH CHECK ADD  CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID] FOREIGN KEY([PopulationGeospatialAreaTypeID])
REFERENCES [dbo].[GeospatialAreaType] ([GeospatialAreaTypeID])
GO

ALTER TABLE [dbo].[GeospatialAreaType] CHECK CONSTRAINT [FK_GeospatialAreaType_GeospatialAreaType_PopulationGeospatialAreaTypeID]
GO

update dbo.GeospatialAreaType 
set EsuDpsGeospatialAreaTypeID = 21, MPGGeospatialAreaTypeID = 26, PopulationGeospatialAreaTypeID = 23
where GeospatialAreaTypeID = 23
go

update dbo.GeospatialAreaType 
set EsuDpsGeospatialAreaTypeID = 22, MPGGeospatialAreaTypeID = 27, PopulationGeospatialAreaTypeID = 24
where GeospatialAreaTypeID = 24
go


alter table dbo.GeospatialAreaType
add IncludeInBiOpAnnualReport bit null
go

update dbo.GeospatialAreaType set IncludeInBiOpAnnualReport = 0 where GeospatialAreaTypeID not in (20,25)
go
update dbo.GeospatialAreaType set IncludeInBiOpAnnualReport = 1 where GeospatialAreaTypeID in (20,25)
go

alter table dbo.GeospatialAreaType
alter column IncludeInBiOpAnnualReport bit not null


-- select * from GeospatialAreaType where TenantID = 12