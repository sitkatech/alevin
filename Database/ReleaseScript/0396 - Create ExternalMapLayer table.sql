
-- New table for External Map Layers
create table dbo.ExternalMapLayer(
	ExternalMapLayerID int not null identity(1,1) constraint PK_ExternalMapLayer_ExternalMapLayerID primary key,
	TenantID int not null constraint FK_ExternalMapLayer_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	DisplayName varchar(75) not null,
	LayerUrl varchar(500) not null,
	LayerDescription varchar(2000) null,
	FeatureNameField varchar(100) null,
	DisplayOnAllProjectMaps bit not null,
	LayerIsOnByDefault bit not null,
	IsActive bit not null,
	IsTiledMapService bit not null
);
go

alter table dbo.ExternalMapLayer
add constraint AK_ExternalMapLayer_TenantID_DisplayName unique(TenantID, DisplayName)

alter table dbo.ExternalMapLayer
add constraint AK_ExternalMapLayer_TenantID_LayerUrl unique(TenantID, LayerUrl)



