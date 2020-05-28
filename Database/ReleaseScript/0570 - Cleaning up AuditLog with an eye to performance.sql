-- Remove all non-BOR AuditLog entries
delete from dbo.AuditLog
where TenantID != 12

/*
select count(*) from dbo.AuditLog
select * from dbo.AuditLog


select * from dbo.Tenant
*/