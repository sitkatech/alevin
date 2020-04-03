

-- Yes, this one is goofy. Should we kill it? Might want to do that up front since it is distracting.
delete
from Reclamation.CostAuthority
where Authority is null and CostAuthorityWorkBreakdownStructure not like 'R_.%'

