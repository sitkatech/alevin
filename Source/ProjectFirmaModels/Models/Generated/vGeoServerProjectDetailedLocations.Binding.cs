//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[vGeoServerProjectDetailedLocations]
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public partial class vGeoServerProjectDetailedLocations
    {
        /// <summary>
        /// Needed by ModelBinder
        /// </summary>
        public vGeoServerProjectDetailedLocations()
        {
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public vGeoServerProjectDetailedLocations(int projectLocationID, int primaryKey, int projectID, string projectName, int tenantID, string tenantName) : this()
        {
            this.ProjectLocationID = projectLocationID;
            this.PrimaryKey = primaryKey;
            this.ProjectID = projectID;
            this.ProjectName = projectName;
            this.TenantID = tenantID;
            this.TenantName = tenantName;
        }

        /// <summary>
        /// Constructor for building a new simple object with the POCO class
        /// </summary>
        public vGeoServerProjectDetailedLocations(vGeoServerProjectDetailedLocations vGeoServerProjectDetailedLocations) : this()
        {
            this.ProjectLocationID = vGeoServerProjectDetailedLocations.ProjectLocationID;
            this.PrimaryKey = vGeoServerProjectDetailedLocations.PrimaryKey;
            this.ProjectID = vGeoServerProjectDetailedLocations.ProjectID;
            this.ProjectName = vGeoServerProjectDetailedLocations.ProjectName;
            this.TenantID = vGeoServerProjectDetailedLocations.TenantID;
            this.TenantName = vGeoServerProjectDetailedLocations.TenantName;
            CallAfterConstructor(vGeoServerProjectDetailedLocations);
        }

        partial void CallAfterConstructor(vGeoServerProjectDetailedLocations vGeoServerProjectDetailedLocations);

        public int ProjectLocationID { get; set; }
        public int PrimaryKey { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int TenantID { get; set; }
        public string TenantName { get; set; }
    }
}