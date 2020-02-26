/*

select
	*
from
	dbo.Project as proj
	join dbo.Person as p on p.PersonID = proj.PrimaryContactPersonID
where
	p.TenantID = 12
	and p.Email like '%@example.com'

*/


--Need to align Steven Kolks first name so we can match on the record with a valid email address
update dbo.Person set FirstName = 'Steven' where PersonID = 5916;

--setup objects for fixing bad FKs in ReclamationDeliverable table
with bad_emails as
(
	select PersonID, FirstName, LastName, Email
	from dbo.Person
	where Email like '%@example.com' and TenantID = 12
),
good_emails as
(
	select PersonID, FirstName, LastName, Email
	from dbo.Person
	where Email not like '%@example.com' and TenantID = 12
),
combined_emails as
(
	select be.PersonID as BadPersonID, be.Email as BadEmail, ge.PersonID as GoodPersonID, ge.Email as GoodEmail, ge.FirstName as FirstName, ge.LastName as LastName
	from bad_emails as be
		 join good_emails as ge on be.FirstName = ge.FirstName and be.LastName = ge.LastName
)
--select * from combined_emails
update rd
set rd.PersonID = ce.GoodPersonID
from
	dbo.ReclamationDeliverable as rd 
	join combined_emails as ce on rd.PersonID = ce.BadPersonID;

--setup objects for fixing bad FKs in Notification
with bad_emails as
(
	select PersonID, FirstName, LastName, Email
	from dbo.Person
	where Email like '%@example.com' and TenantID = 12
),
good_emails as
(
	select PersonID, FirstName, LastName, Email
	from dbo.Person
	where Email not like '%@example.com' and TenantID = 12
),
combined_emails as
(
	select be.PersonID as BadPersonID, be.Email as BadEmail, ge.PersonID as GoodPersonID, ge.Email as GoodEmail, ge.FirstName as FirstName, ge.LastName as LastName
	from bad_emails as be
		 join good_emails as ge on be.FirstName = ge.FirstName and be.LastName = ge.LastName
)
update noti
set noti.PersonID = ce.GoodPersonID
from
	dbo.[Notification] as noti 
	join combined_emails as ce on noti.PersonID = ce.BadPersonID;


--setup objects for fixing bad FKs in SubbasinLiason 
with bad_emails as
(
	select PersonID, FirstName, LastName, Email
	from dbo.Person
	where Email like '%@example.com' and TenantID = 12
),
good_emails as
(
	select PersonID, FirstName, LastName, Email
	from dbo.Person
	where Email not like '%@example.com' and TenantID = 12
),
combined_emails as
(
	select be.PersonID as BadPersonID, be.Email as BadEmail, ge.PersonID as GoodPersonID, ge.Email as GoodEmail, ge.FirstName as FirstName, ge.LastName as LastName
	from bad_emails as be
		 join good_emails as ge on be.FirstName = ge.FirstName and be.LastName = ge.LastName
)
update sub
set sub.PersonID = ce.GoodPersonID
from
	dbo.SubbasinLiason as sub 
	join combined_emails as ce on sub.PersonID = ce.BadPersonID;

--Remove FKs to bad users
update rd
set rd.PersonID = null
from
	dbo.ReclamationDeliverable as rd
	join dbo.Person as p on p.PersonID = rd.PersonID
where
	p.TenantID = 12
	and p.Email like '%@example.com'



update dbo.Organization set PrimaryContactPersonID = null
where OrganizationID in (select  
								o.OrganizationID
						from
							dbo.Organization as o 
							join dbo.Person as p on p.PersonID = o.PrimaryContactPersonID
						where
							p.TenantID = 12
							and p.Email like '%@example.com')



--6016 Correct Mike Knutson ID
update dbo.Project set PrimaryContactPersonID = 6016 where ProjectID = 14188
-- same for project update
update dbo.ProjectUpdate set PrimaryContactPersonID = 6016 where ProjectUpdateID = 6530

delete from dbo.[Notification] where NotificationID in (
														select noti.NotificationID
														from
															dbo.[Notification] as noti
															join dbo.Person as p on p.PersonID = noti.PersonID
														where
															p.TenantID = 12
															and p.Email like '%@example.com');




delete from dbo.SubbasinLiason where SubbasinLiasonID in (
														select
															sub.SubbasinLiasonID
														from
															dbo.SubbasinLiason as sub
															join dbo.Person as p on p.PersonID = sub.PersonID
														where
															p.TenantID = 12
															and p.Email like '%@example.com');


delete from dbo.ProjectContact where ProjectContactID in (
														select
															pc.ProjectContactID
														from
															dbo.ProjectContact as pc
															join dbo.Person as p on p.PersonID = pc.ContactID
														where
															p.TenantID = 12
															and p.Email like '%@example.com');


delete from dbo.ProjectContactUpdate where ProjectContactUpdateID in (
														select
															pcu.ProjectContactUpdateID
														from
															dbo.ProjectContactUpdate as pcu
															join dbo.Person as p on p.PersonID = pcu.ContactID
														where
															p.TenantID = 12
															and p.Email like '%@example.com');


delete from dbo.Person
where Email like '%@example.com' and TenantID = 12






--SITKA LLC save: 6180
--delete: 6400
update dbo.Person set OrganizationID = 6180 where OrganizationID = 6400
update dbo.ReclamationAgreement set OrganizationID = 6180 where OrganizationID = 6400

delete from dbo.Organization
where OrganizationID = 6400

--STERLING COMPUTERS CORPORATION save: 6403	
-- delete: 6402
update dbo.ReclamationAgreement set OrganizationID = 6403 where OrganizationID = 6402

delete from dbo.Organization
where OrganizationID = 6402

--US FOREST SERVICE save: 6310 
-- delete: 6419
update dbo.ReclamationAgreement set OrganizationID = 6310 where OrganizationID = 6419

delete from dbo.Organization
where OrganizationID = 6419

--CDW GOVERNMENT LLC save: 6337	
-- delete: 6336
update dbo.ReclamationAgreement set OrganizationID = 6337 where OrganizationID = 6336

delete from dbo.Organization
where OrganizationID = 6336

update dbo.Organization set OrganizationName = 'CDW Government LLC' where OrganizationID = 6337





/*



select * from dbo.Person
where TenantID = 12


select  OrganizationID, OrganizationName from dbo.Organization
where TenantID = 12 and OrganizationID in (6336,6337,6180,6400,6402,6403,6310,6419)

select * from dbo.Organization
where TenantID = 12
ORDER BY OrganizationName


*/