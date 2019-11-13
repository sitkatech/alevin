delete from dbo.ReclamationCostAuthorityProject 

go

insert into dbo.ReclamationCostAuthorityProject (ProjectID, ReclamationCostAuthorityID) 
select distinct p.projectID, rca.ReclamationCostAuthorityID 
from Project p
join ReclamationAgreementProject rap on p.ProjectID = rap.ProjectID
join ReclamationAgreement ra on rap.ReclamationAgreementID = ra.ReclamationAgreementID
join ReclamationAgreementReclamationCostAuthority rarca on ra.ReclamationAgreementID = rarca.ReclamationAgreementID
join ReclamationCostAuthority rca on rarca.ReclamationCostAuthorityID = rca.ReclamationCostAuthorityID
order by rca.ReclamationCostAuthorityID, p.ProjectID

go

drop table dbo.ReclamationAgreementProject

go