

alter table Reclamation.ObligationRequest
add ObligationNumberID int null constraint FK_ObligationRequest_ObligationNumber_ObligationNumberID foreign key references ImportFinancial.ObligationNumber(ObligationNumberID);

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values(10011, 'ObligationItemList', 'Obligation Item List', 1)

--(10011, 'ObligationItemList', 'Obligation Item List', 1)
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID) 
values(12, 10011)
