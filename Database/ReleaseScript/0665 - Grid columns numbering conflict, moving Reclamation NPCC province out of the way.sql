
-- None actually match when this script was written, but we'll want to move them if they appear in prod between now and next release.
-- SLG 12/18/2020
update dbo.ProjectCustomGridConfiguration
set ProjectCustomGridColumnID = 29
where ProjectCustomGridColumnID = 28