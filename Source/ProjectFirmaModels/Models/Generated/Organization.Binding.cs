//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[Organization]
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    // Table [dbo].[Organization] is multi-tenant, so is attributed as IHaveATenantID
    [Table("[dbo].[Organization]")]
    public partial class Organization : IHavePrimaryKey, IHaveATenantID
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected Organization()
        {
            this.FundingSources = new HashSet<FundingSource>();
            this.OrganizationBoundaryStagings = new HashSet<OrganizationBoundaryStaging>();
            this.People = new HashSet<Person>();
            this.PersonStewardOrganizations = new HashSet<PersonStewardOrganization>();
            this.ProjectOrganizations = new HashSet<ProjectOrganization>();
            this.ProjectOrganizationUpdates = new HashSet<ProjectOrganizationUpdate>();
            this.Agreements = new HashSet<Agreement>();
            this.CostAuthorityObligationRequestsWhereYouAreTheRecipientOrganization = new HashSet<CostAuthorityObligationRequest>();
        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public Organization(int organizationID, Guid? organizationGuid, string organizationName, string organizationShortName, int? primaryContactPersonID, bool isActive, string organizationUrl, int? logoFileResourceInfoID, int organizationTypeID, DbGeometry organizationBoundary, string vendorNumber, int? reclamationContractorID, string organizationAddress1, string organizationAddress2, string organizationCity, string organizationState, string organizationZip) : this()
        {
            this.OrganizationID = organizationID;
            this.OrganizationGuid = organizationGuid;
            this.OrganizationName = organizationName;
            this.OrganizationShortName = organizationShortName;
            this.PrimaryContactPersonID = primaryContactPersonID;
            this.IsActive = isActive;
            this.OrganizationUrl = organizationUrl;
            this.LogoFileResourceInfoID = logoFileResourceInfoID;
            this.OrganizationTypeID = organizationTypeID;
            this.OrganizationBoundary = organizationBoundary;
            this.VendorNumber = vendorNumber;
            this.ReclamationContractorID = reclamationContractorID;
            this.OrganizationAddress1 = organizationAddress1;
            this.OrganizationAddress2 = organizationAddress2;
            this.OrganizationCity = organizationCity;
            this.OrganizationState = organizationState;
            this.OrganizationZip = organizationZip;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields in preparation for insert into database
        /// </summary>
        public Organization(string organizationName, bool isActive, int organizationTypeID) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            
            this.OrganizationName = organizationName;
            this.IsActive = isActive;
            this.OrganizationTypeID = organizationTypeID;
        }

        /// <summary>
        /// Constructor for building a new object with MinimalConstructor required fields, using objects whenever possible
        /// </summary>
        public Organization(string organizationName, bool isActive, OrganizationType organizationType) : this()
        {
            // Mark this as a new object by setting primary key with special value
            this.OrganizationID = ModelObjectHelpers.MakeNextUnsavedPrimaryKeyValue();
            this.OrganizationName = organizationName;
            this.IsActive = isActive;
            this.OrganizationTypeID = organizationType.OrganizationTypeID;
            this.OrganizationType = organizationType;
            organizationType.Organizations.Add(this);
        }

        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static Organization CreateNewBlank(OrganizationType organizationType)
        {
            return new Organization(default(string), default(bool), organizationType);
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return FundingSources.Any() || OrganizationBoundaryStagings.Any() || People.Any() || PersonStewardOrganizations.Any() || ProjectOrganizations.Any() || ProjectOrganizationUpdates.Any() || Agreements.Any() || CostAuthorityObligationRequestsWhereYouAreTheRecipientOrganization.Any();
        }

        /// <summary>
        /// Active Dependent type names of this object
        /// </summary>
        public List<string> DependentObjectNames() 
        {
            var dependentObjects = new List<string>();
            
            if(FundingSources.Any())
            {
                dependentObjects.Add(typeof(FundingSource).Name);
            }

            if(OrganizationBoundaryStagings.Any())
            {
                dependentObjects.Add(typeof(OrganizationBoundaryStaging).Name);
            }

            if(People.Any())
            {
                dependentObjects.Add(typeof(Person).Name);
            }

            if(PersonStewardOrganizations.Any())
            {
                dependentObjects.Add(typeof(PersonStewardOrganization).Name);
            }

            if(ProjectOrganizations.Any())
            {
                dependentObjects.Add(typeof(ProjectOrganization).Name);
            }

            if(ProjectOrganizationUpdates.Any())
            {
                dependentObjects.Add(typeof(ProjectOrganizationUpdate).Name);
            }

            if(Agreements.Any())
            {
                dependentObjects.Add(typeof(Agreement).Name);
            }

            if(CostAuthorityObligationRequestsWhereYouAreTheRecipientOrganization.Any())
            {
                dependentObjects.Add(typeof(CostAuthorityObligationRequest).Name);
            }
            return dependentObjects.Distinct().ToList();
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(Organization).Name, typeof(FundingSource).Name, typeof(OrganizationBoundaryStaging).Name, typeof(Person).Name, typeof(PersonStewardOrganization).Name, typeof(ProjectOrganization).Name, typeof(ProjectOrganizationUpdate).Name, typeof(Agreement).Name, typeof(CostAuthorityObligationRequest).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.AllOrganizations.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            DeleteChildren(dbContext);
            Delete(dbContext);
        }
        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public void DeleteChildren(DatabaseEntities dbContext)
        {

            foreach(var x in FundingSources.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in OrganizationBoundaryStagings.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in People.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in PersonStewardOrganizations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectOrganizations.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in ProjectOrganizationUpdates.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in Agreements.ToList())
            {
                x.DeleteFull(dbContext);
            }

            foreach(var x in CostAuthorityObligationRequestsWhereYouAreTheRecipientOrganization.ToList())
            {
                x.DeleteFull(dbContext);
            }
        }

        [Key]
        public int OrganizationID { get; set; }
        public int TenantID { get; set; }
        public Guid? OrganizationGuid { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationShortName { get; set; }
        public int? PrimaryContactPersonID { get; set; }
        public bool IsActive { get; set; }
        public string OrganizationUrl { get; set; }
        public int? LogoFileResourceInfoID { get; set; }
        public int OrganizationTypeID { get; set; }
        public DbGeometry OrganizationBoundary { get; set; }
        public string VendorNumber { get; set; }
        public int? ReclamationContractorID { get; set; }
        public string OrganizationAddress1 { get; set; }
        public string OrganizationAddress2 { get; set; }
        public string OrganizationCity { get; set; }
        public string OrganizationState { get; set; }
        public string OrganizationZip { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return OrganizationID; } set { OrganizationID = value; } }

        public virtual ICollection<FundingSource> FundingSources { get; set; }
        public virtual ICollection<OrganizationBoundaryStaging> OrganizationBoundaryStagings { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<PersonStewardOrganization> PersonStewardOrganizations { get; set; }
        public virtual ICollection<ProjectOrganization> ProjectOrganizations { get; set; }
        public virtual ICollection<ProjectOrganizationUpdate> ProjectOrganizationUpdates { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }
        public virtual ICollection<CostAuthorityObligationRequest> CostAuthorityObligationRequestsWhereYouAreTheRecipientOrganization { get; set; }
        public Tenant Tenant { get { return Tenant.AllLookupDictionary[TenantID]; } }
        public virtual Person PrimaryContactPerson { get; set; }
        public virtual FileResourceInfo LogoFileResourceInfo { get; set; }
        public virtual OrganizationType OrganizationType { get; set; }

        public static class FieldLengths
        {
            public const int OrganizationName = 200;
            public const int OrganizationShortName = 50;
            public const int OrganizationUrl = 200;
            public const int VendorNumber = 12;
            public const int OrganizationAddress1 = 500;
            public const int OrganizationAddress2 = 500;
            public const int OrganizationCity = 500;
            public const int OrganizationState = 20;
            public const int OrganizationZip = 20;
        }
    }
}