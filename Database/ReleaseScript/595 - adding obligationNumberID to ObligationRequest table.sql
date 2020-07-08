

alter table Reclamation.ObligationRequest
add ObligationNumberID int null constraint FK_ObligationRequest_ObligationNumber_ObligationNumberID foreign key references ImportFinancial.ObligationNumber(ObligationNumberID);


