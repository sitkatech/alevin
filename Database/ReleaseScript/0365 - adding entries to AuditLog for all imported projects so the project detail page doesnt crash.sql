
/*
	TenantID = 12
	PersonID = ?? -Tom=5634   SLG=5519
	AuditLogDate = 9/9/2019
	TableName = Project
	RecordID = [ProjectID]
	ColumnName = [ProjectID]
	OriginalValue = 0
	NewValue = [ProjectID]
	AuditDescription = [Importing Project Data]
	ProjectID = [ProjectID]




	select * from dbo.Project where TenantID = 12

	select distinct ProjectID from dbo.AuditLog where ProjectID in (select ProjectID from dbo.Project where TenantID = 12) and TenantID = 12 order by ProjectID


	SELECT pm.id FROM r2r.partmaster pm
WHERE pm.id NOT IN (SELECT pd.part_num FROM wpsapi4.product_details pd)

*/

insert into dbo.AuditLog(TenantID, PersonID, AuditLogDate, AuditLogEventTypeID, TableName, RecordID, ColumnName, OriginalValue, NewValue, AuditDescription, ProjectID)
select 
	12 as TenantID, 
	5634 as PersonID,
	'2019/09/09' as AuditLogDate,
	1 as AuditLogEventTypeID,
	'Project' as TableName,
	p.ProjectID as RecordID,
	'ProjectID' as ColumnName,
	null as OriginalValue,
	p.ProjectID as NewValue,
	'Importing Project Data' as AuditDescription,
	p.ProjectID as ProjectID
from 
	dbo.Project as p
where p.TenantID = 12 and p.ProjectID NOT IN (SELECT distinct al.ProjectID FROM dbo.AuditLog as al where al.TenantID = 12 and al.ProjectID is not null)





