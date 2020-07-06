
-- Removing 'XXXXX this is a new project' (sic) string
update dbo.Project
set ProjectDescription = ''
where ProjectDescription like 'XXXX%'
