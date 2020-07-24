
create table Reclamation.CostAuthorityObligationRequestPotentialObligationNumberMatch
(
    CostAuthorityObligationRequestPotentialObligationNumberMatchID int not null identity(1,1) constraint PK_CostAuthorityObligationRequestPotentialObligationNumberMatch_CostAuthorityObligationRequestPotentialObligationNumberMatchID primary key,
    CostAuthorityObligationRequestID int not null,
    ObligationNumberID int not null
)
GO

-- FK - CostAuthorityObligationRequest
ALTER TABLE Reclamation.CostAuthorityObligationRequestPotentialObligationNumberMatch  WITH CHECK 
ADD  CONSTRAINT [FK_CostAuthorityObligationRequestPotentialObligationNumberMatch_CostAuthorityObligationRequest_CostAuthorityObligationRequestID] FOREIGN KEY(CostAuthorityObligationRequestID)
REFERENCES Reclamation.CostAuthorityObligationRequest (CostAuthorityObligationRequestID)
GO

-- FK - ObligationNumber
ALTER TABLE Reclamation.CostAuthorityObligationRequestPotentialObligationNumberMatch  WITH CHECK 
ADD  CONSTRAINT [FK_CostAuthorityObligationRequestPotentialObligationNumberMatch_ObligationNumber_ObligationNumberID] FOREIGN KEY(ObligationNumberID)
REFERENCES ImportFinancial.ObligationNumber (ObligationNumberID)
GO

-- AK -- CostAuthorityObligationRequestID / ObligationNumberID pair
ALTER TABLE [Reclamation].CostAuthorityObligationRequestPotentialObligationNumberMatch ADD
 CONSTRAINT [AK_CostAuthorityObligationRequestPotentialObligationNumberMatch_CostAuthorityObligationRequestID_ObligationNumberID] UNIQUE NONCLUSTERED 
(
    CostAuthorityObligationRequestID ASC,
    ObligationNumberID ASC
) ON [PRIMARY]
GO

