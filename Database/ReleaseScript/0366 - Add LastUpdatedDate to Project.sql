alter table dbo.Project add LastUpdatedDate Datetime
GO

update p
set p.LastUpdatedDate = als.LastUpdatedDate
from dbo.Project as p
join 
(
    select ProjectID, MAX(AuditLogDate) as LastUpdatedDate
    from dbo.AuditLog as al 
    group by ProjectID
) als on p.ProjectID = als.ProjectID
GO

-- hack needed just for AlevinDB, we don't have all the audit log records that ProjectFirma has so make up some dates to fill in gaps (tenant 11)
update dbo.Project set LastUpdatedDate = '1/1/' + cast(ImplementationStartYear as varchar) where LastUpdatedDate is null

alter table dbo.Project alter column LastUpdatedDate Datetime not null
GO


