-- ReclamationAgreement => ObligatioNumber
/*
select * from dbo.ReclamationAgreement
select * from ImportFinancial.ObligationNumber


select rca.*,
       onum.*
from dbo.ReclamationAgreement as rca
inner join ImportFinancial.ObligationNumber as onum on rca.AgreementNumber = onum.ObligationNumberKey


select rca.*,
       onum.*
from dbo.ReclamationAgreement as rca
inner join ImportFinancial.ObligationNumber as onum on rca.OldAgreementNumber = onum.ObligationNumberKey
*/


alter table ImportFinancial.ObligationNumber
add  ReclamationAgreementID int null
GO

ALTER TABLE ImportFinancial.ObligationNumber  WITH CHECK ADD  CONSTRAINT 
[FK_ObligationNumber_ReclamationAgreement_ReclamationAgreementID] FOREIGN KEY(ReclamationAgreementID)
REFERENCES [dbo].ReclamationAgreement (ReclamationAgreementID)
GO

update ImportFinancial.ObligationNumber
set ReclamationAgreementID = rca.ReclamationAgreementID
from dbo.ReclamationAgreement as rca
inner join ImportFinancial.ObligationNumber as onum on rca.AgreementNumber = onum.ObligationNumberKey
GO






--select * from ImportFinancial.ObligationNumber
