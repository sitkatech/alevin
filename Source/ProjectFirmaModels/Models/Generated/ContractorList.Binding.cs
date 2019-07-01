//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContractorList]
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
    // Table [dbo].[ContractorList] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[ContractorList]")]
    public partial class ContractorList : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected ContractorList()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public ContractorList(int contractorListID, double? reclamationContractorID, string contractorName, string companyName, double? vendorNumber, string address1, string address2, string city, string state, string zip, string contactFirstName, string contactLastName, string contactPhone, string contactEmail) : this()
        {
            this.ContractorListID = contractorListID;
            this.ReclamationContractorID = reclamationContractorID;
            this.ContractorName = contractorName;
            this.CompanyName = companyName;
            this.VendorNumber = vendorNumber;
            this.Address1 = address1;
            this.Address2 = address2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.ContactFirstName = contactFirstName;
            this.ContactLastName = contactLastName;
            this.ContactPhone = contactPhone;
            this.ContactEmail = contactEmail;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static ContractorList CreateNewBlank()
        {
            return new ContractorList();
        }

        /// <summary>
        /// Does this object have any dependent objects? (If it does have dependent objects, these would need to be deleted before this object could be deleted.)
        /// </summary>
        /// <returns></returns>
        public bool HasDependentObjects()
        {
            return false;
        }

        /// <summary>
        /// Dependent type names of this entity
        /// </summary>
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(ContractorList).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.ContractorLists.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int ContractorListID { get; set; }
        public double? ReclamationContractorID { get; set; }
        public string ContractorName { get; set; }
        public string CompanyName { get; set; }
        public double? VendorNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return ContractorListID; } set { ContractorListID = value; } }



        public static class FieldLengths
        {
            public const int ContractorName = 255;
            public const int CompanyName = 255;
            public const int Address1 = 255;
            public const int Address2 = 255;
            public const int City = 255;
            public const int State = 255;
            public const int Zip = 255;
            public const int ContactFirstName = 255;
            public const int ContactLastName = 255;
            public const int ContactPhone = 255;
            public const int ContactEmail = 255;
        }
    }
}