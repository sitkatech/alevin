delete from dbo.ProjectOrganizationUpdate where ProjectOrganizationUpdateID in 
 ( 
 select ProjectOrganizationUpdateID from (


select pub.ProjectOrganizationUpdateID,
 RANK () OVER ( 
 PARTITION BY pub.ProjectUpdateBatchID
 ORDER BY pub.ProjectOrganizationUpdateID DESC
 ) as ranking

 from dbo.ProjectOrganizationUpdate pub 
join 


(

select pou.ProjectUpdateBatchID, ort.OrganizationRelationshipTypeID from dbo.ProjectOrganizationUpdate pou
join dbo.OrganizationRelationshipType ort 
on pou.OrganizationRelationshipTypeID = ort.OrganizationRelationshipTypeID
where ort.CanOnlyBeRelatedOnceToAProject = 1
group by pou.ProjectUpdateBatchID, ort.OrganizationRelationshipTypeID having count(*) > 1

)

x on pub.ProjectUpdateBatchID = x.ProjectUpdateBatchID and pub.OrganizationRelationshipTypeID = x.OrganizationRelationshipTypeID) y  where y.ranking != 1)