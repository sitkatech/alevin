﻿using System;
using System.Linq;
using LtInfo.Common;

namespace ProjectFirmaModels.Models
{
    public partial class OrganizationRelationshipType : IAuditableEntity
    {
        public bool CanDelete()
        {
            return !ProjectOrganizations.Any();
        }

        public string GetAuditDescriptionString() => OrganizationRelationshipTypeName;

        public bool HasOrganizationsWithSpatialBoundary()
        {
            return OrganizationTypeOrganizationRelationshipTypes.Any(x =>
                x.OrganizationType.Organizations.Any(y => y.OrganizationBoundary != null));            
        }

        public Organization GetOrganizationContainingProjectSimpleLocation(IProject project, bool userCanViewPrivateLocations)
        {
            if (!(HasOrganizationsWithSpatialBoundary() && IsOrganizationRelationshipTypeRequired))
            {
                return null;
            }

            if (project.HasProjectLocationPoint(userCanViewPrivateLocations))
            {
                return null;
            }

            var organizationsInThisRelatonshipTypeWithBoundary = OrganizationTypeOrganizationRelationshipTypes.SelectMany(x =>
                x.OrganizationType.Organizations.Where(y => y.OrganizationBoundary != null));

            return organizationsInThisRelatonshipTypeWithBoundary.FirstOrDefault(x =>
            {
                try
                {
                    var projectLocationPoint = project.GetProjectLocationPoint(userCanViewPrivateLocations);
                    var contains = projectLocationPoint != null && x.OrganizationBoundary.Contains(projectLocationPoint);
                    return contains;
                }
                catch (Exception e)
                {
                    SitkaLogger.Instance.LogDetailedErrorMessage(e); //This typically trips if there are geometries with no SRID
                    return false;
                }
                
            });
            
        }

        public bool IsAssociatedWithOrganizationType(OrganizationType organizationType)
        {
            return OrganizationTypeOrganizationRelationshipTypes.Select(x => x.OrganizationType).Contains(organizationType);
        }
    }
}