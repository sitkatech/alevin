//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[impApGenSheet]
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
    // Table [dbo].[impApGenSheet] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[dbo].[impApGenSheet]")]
    public partial class impApGenSheet : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected impApGenSheet()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public impApGenSheet(int impApGenSheetID, string pO Number - Key, string purch Ord Line Itm - Key, string reference - Key, string vendor - Key, string vendor - Text, string fund - Key, string funded Program - Key, string wBS Element - Key, string wBS Element - Text, string budget Object Class - Key, double? debit Amount, double? credit Amount, double? debit/Credit Total) : this()
        {
            this.impApGenSheetID = impApGenSheetID;
            this.PO Number - Key = pO Number - Key;
            this.Purch Ord Line Itm - Key = purch Ord Line Itm - Key;
            this.Reference - Key = reference - Key;
            this.Vendor - Key = vendor - Key;
            this.Vendor - Text = vendor - Text;
            this.Fund - Key = fund - Key;
            this.Funded Program - Key = funded Program - Key;
            this.WBS Element - Key = wBS Element - Key;
            this.WBS Element - Text = wBS Element - Text;
            this.Budget Object Class - Key = budget Object Class - Key;
            this.Debit Amount = debit Amount;
            this.Credit Amount = credit Amount;
            this.Debit/Credit Total = debit/Credit Total;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static impApGenSheet CreateNewBlank()
        {
            return new impApGenSheet();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(impApGenSheet).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.impApGenSheets.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int impApGenSheetID { get; set; }
        public string PO Number - Key { get; set; }
        public string Purch Ord Line Itm - Key { get; set; }
        public string Reference - Key { get; set; }
        public string Vendor - Key { get; set; }
        public string Vendor - Text { get; set; }
        public string Fund - Key { get; set; }
        public string Funded Program - Key { get; set; }
        public string WBS Element - Key { get; set; }
        public string WBS Element - Text { get; set; }
        public string Budget Object Class - Key { get; set; }
        public double? Debit Amount { get; set; }
        public double? Credit Amount { get; set; }
        public double? Debit/Credit Total { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return impApGenSheetID; } set { impApGenSheetID = value; } }



        public static class FieldLengths
        {
            public const int PO Number - Key = 255;
            public const int Purch Ord Line Itm - Key = 255;
            public const int Reference - Key = 255;
            public const int Vendor - Key = 255;
            public const int Vendor - Text = 255;
            public const int Fund - Key = 255;
            public const int Funded Program - Key = 255;
            public const int WBS Element - Key = 255;
            public const int WBS Element - Text = 255;
            public const int Budget Object Class - Key = 255;
        }
    }
}