--select * from dbo.Deliverable


alter table dbo.Deliverable
add CostAuthorityAgreementID int null constraint FK_Deliverable_CostAuthorityAgreement_CostAuthorityAgreementID foreign key references dbo.CostAuthorityAgreement(CostAuthorityAgreementID)
go


update Deliverable
set CostAuthorityAgreementID = caa.CostAuthorityAgreementID
from Deliverable
inner join dbo.CostAuthorityAgreement as caa on caa.ReclamationCostAuthorityAgreementID = Deliverable.ReclamationCostAuthorityAgreementID
go



EXEC sp_rename 'dbo.Deliverable.ReclamationDeliverableTypeID', 'DeliverableTypeID', 'COLUMN';
go


ALTER TABLE dbo.Deliverable
ADD CONSTRAINT FK_Deliverable_DeliverableType_DeliverableTypeID FOREIGN KEY (DeliverableTypeID) REFERENCES dbo.DeliverableType(DeliverableTypeID)
go

alter table dbo.Deliverable
drop column ReclamationCostAuthorityAgreementID
go
