//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[impPayRecV3]
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
    // Table [dbo].[impPayRecV3] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[impPayRecV3]")]
    public partial class impPayRecV3 : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected impPayRecV3()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public impPayRecV3(int impPayRecV3ID, string business area - Key, string fA Budget Activity - Key, string functional area - Text, string obligation Number - Key, string obligation Item - Key, string fund - Key, string funded Program - Key (Not Compounded), string wBS Element - Key, string wBS Element - Text, string budget Object Class - Key, string vendor - Key, string vendor - Text, double? obligation, string goods Receipt, double? invoiced, double? disbursed, double? unexpended Balance) : this()
        {
            this.impPayRecV3ID = impPayRecV3ID;
            this.Business area - Key = business area - Key;
            this.FA Budget Activity - Key = fA Budget Activity - Key;
            this.Functional area - Text = functional area - Text;
            this.Obligation Number - Key = obligation Number - Key;
            this.Obligation Item - Key = obligation Item - Key;
            this.Fund - Key = fund - Key;
            this.Funded Program - Key (Not Compounded) = funded Program - Key (Not Compounded);
            this.WBS Element - Key = wBS Element - Key;
            this.WBS Element - Text = wBS Element - Text;
            this.Budget Object Class - Key = budget Object Class - Key;
            this.Vendor - Key = vendor - Key;
            this.Vendor - Text = vendor - Text;
            this.Obligation = obligation;
            this.Goods Receipt = goods Receipt;
            this.Invoiced = invoiced;
            this.Disbursed = disbursed;
            this.Unexpended Balance = unexpended Balance;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static impPayRecV3 CreateNewBlank()
        {
            return new impPayRecV3();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(impPayRecV3).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.impPayRecV3s.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int impPayRecV3ID { get; set; }
        public string Business area - Key { get; set; }
        public string FA Budget Activity - Key { get; set; }
        public string Functional area - Text { get; set; }
        public string Obligation Number - Key { get; set; }
        public string Obligation Item - Key { get; set; }
        public string Fund - Key { get; set; }
        public string Funded Program - Key (Not Compounded) { get; set; }
        public string WBS Element - Key { get; set; }
        public string WBS Element - Text { get; set; }
        public string Budget Object Class - Key { get; set; }
        public string Vendor - Key { get; set; }
        public string Vendor - Text { get; set; }
        public double? Obligation { get; set; }
        public string Goods Receipt { get; set; }
        public double? Invoiced { get; set; }
        public double? Disbursed { get; set; }
        public double? Unexpended Balance { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return impPayRecV3ID; } set { impPayRecV3ID = value; } }



        public static class FieldLengths
        {
            public const int Business area - Key = 255;
            public const int FA Budget Activity - Key = 255;
            public const int Functional area - Text = 255;
            public const int Obligation Number - Key = 255;
            public const int Obligation Item - Key = 255;
            public const int Fund - Key = 255;
            public const int Funded Program - Key (Not Compounded) = 255;
            public const int WBS Element - Key = 255;
            public const int WBS Element - Text = 255;
            public const int Budget Object Class - Key = 255;
            public const int Vendor - Key = 255;
            public const int Vendor - Text = 255;
            public const int Goods Receipt = 255;
        }
    }
}