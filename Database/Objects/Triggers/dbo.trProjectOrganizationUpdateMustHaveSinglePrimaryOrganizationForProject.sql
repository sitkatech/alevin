CREATE TRIGGER dbo.trProjectOrganizationUpdateMustHaveSinglePrimaryOrganizationForProject ON dbo.ProjectOrganizationUpdate
AFTER INSERT, UPDATE
AS


DECLARE @returnCount int


set @returnCount =  (

select count(*)

from(
select po.ProjectUpdateBatchID 
from dbo.ProjectOrganizationUpdate po 
join dbo.OrganizationRelationshipType ort on po.OrganizationRelationshipTypeID = ort.OrganizationRelationshipTypeID
where ort.CanOnlyBeRelatedOnceToAProject = 1
group by po.ProjectUpdateBatchID, ort.OrganizationRelationshipTypeID
having count(*) > 1)
x
)


if(@returnCount > 0)
BEGIN
RAISERROR ('Non unique primary organization on a project update', 16, 1);
ROLLBACK TRANSACTION;
RETURN 
END;