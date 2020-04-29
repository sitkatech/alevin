insert into dbo.ProjectNoFundingSourceIdentified (ProjectID, TenantID, NoFundingSourceIdentifiedYet)
select ProjectID, TenantID, NoFundingSourceIdentifiedYet
from dbo.Project
where NoFundingSourceIdentifiedYet is not null and TenantID not in (11, 12) and FundingTypeID = 1

update dbo.Project set NoFundingSourceIdentifiedYet = null
where NoFundingSourceIdentifiedYet is not null and TenantID not in (11, 12) and FundingTypeID = 1