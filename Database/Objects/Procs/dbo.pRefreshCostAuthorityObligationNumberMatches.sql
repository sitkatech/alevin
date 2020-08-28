IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pRefreshCostAuthorityObligationNumberMatches'))
    drop procedure dbo.pRefreshCostAuthorityObligationNumberMatches
go

create procedure dbo.pRefreshCostAuthorityObligationNumberMatches
as
begin

    -- Temp table for potential Cost Authority / Obligation Number matches
    DROP TABLE IF EXISTS #NewCandidatesFor_CostAuthorityObligationRequestPotentialObligationNumberMatch
    select
       distinct
        caor.CostAuthorityObligationRequestID,
        obnum.ObligationNumberID,
        ca.CostAuthorityID,
        obnum.ObligationNumberKey,
        ca.CostAuthorityWorkBreakdownStructure
    into #NewCandidatesFor_CostAuthorityObligationRequestPotentialObligationNumberMatch
    from Reclamation.CostAuthorityObligationRequest as caor
    inner join Reclamation.CostAuthority as ca on caor.CostAuthorityID = ca.CostAuthorityID
    inner join ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr on ca.CostAuthorityWorkBreakdownStructure = pr.WBSElement
    inner join ImportFinancial.ObligationNumber as obnum on obnum.ObligationNumberKey = pr.ObligationNumber
    inner join Reclamation.ObligationRequest as obreq on caor.ObligationRequestID = obreq.ObligationRequestID
    -- This attempts to identify ObligationRequests that haven't been matched yet
    where 
          obreq.AgreementID is null
    and
          obnum.ReclamationAgreementID is null

    -- Insert new potential match records
    insert into Reclamation.CostAuthorityObligationRequestPotentialObligationNumberMatch(CostAuthorityObligationRequestID, ObligationNumberID)
    select
        ncm.CostAuthorityObligationRequestID,
        ncm.ObligationNumberID
    from #NewCandidatesFor_CostAuthorityObligationRequestPotentialObligationNumberMatch as ncm
    left join Reclamation.CostAuthorityObligationRequestPotentialObligationNumberMatch as exist_match on ncm.CostAuthorityObligationRequestID = exist_match.CostAuthorityObligationRequestID and ncm.ObligationNumberID = exist_match.ObligationNumberID
    where
        exist_match.CostAuthorityObligationRequestID is null and exist_match.ObligationNumberID is null

--select * from Reclamation.CostAuthority as ca where ca.CostAuthorityID = 487
/*
select *
from Reclamation.CostAuthority as ca 
inner join ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr on ca.CostAuthorityWorkBreakdownStructure = pr.WBSElement
where ca.CostAuthorityID in (2, 261)

select * from  Reclamation.CostAuthorityObligationRequest
select * from Reclamation.CostAuthority as ca where ca.CostAuthorityWorkBreakdownStructure = 'RX.16786940.20R0813'
select * from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr where pr.WBSElement = 'RX.16786940.20R0813'

select * from ImportFinancial.ImportFinancialImpPayRecUnexpendedV3 as pr where pr.WBSElement in ('RX.16786806.5000900','123167868315000300' )
*/

end

/*

exec dbo.pRefreshCostAuthorityObligationNumberMatches

*/