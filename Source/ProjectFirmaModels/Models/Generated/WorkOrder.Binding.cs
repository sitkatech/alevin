//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[WorkOrder]
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
    // Table [Reclamation].[WorkOrder] is NOT multi-tenant, so is attributed as ICanDeleteFull
    [Table("[Reclamation].[WorkOrder]")]
    public partial class WorkOrder : IHavePrimaryKey, ICanDeleteFull
    {
        /// <summary>
        /// Default Constructor; only used by EF
        /// </summary>
        protected WorkOrder()
        {

        }

        /// <summary>
        /// Constructor for building a new object with MaximalConstructor required fields in preparation for insert into database
        /// </summary>
        public WorkOrder(int workOrderID, string workOrderName, double? fiscalYear, int? workBreakdownStructureID, string fUND, string fBMSSTATUS, string eTASSTATUS, string dEYSTATAUS, string description) : this()
        {
            this.WorkOrderID = workOrderID;
            this.WorkOrderName = workOrderName;
            this.FiscalYear = fiscalYear;
            this.WorkBreakdownStructureID = workBreakdownStructureID;
            this.FUND = fUND;
            this.FBMSSTATUS = fBMSSTATUS;
            this.ETASSTATUS = eTASSTATUS;
            this.DEYSTATAUS = dEYSTATAUS;
            this.Description = description;
        }



        /// <summary>
        /// Creates a "blank" object of this type and populates primitives with defaults
        /// </summary>
        public static WorkOrder CreateNewBlank()
        {
            return new WorkOrder();
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
        public static readonly List<string> DependentEntityTypeNames = new List<string> {typeof(WorkOrder).Name};


        /// <summary>
        /// Delete just the entity 
        /// </summary>
        public void Delete(DatabaseEntities dbContext)
        {
            dbContext.WorkOrders.Remove(this);
        }
        
        /// <summary>
        /// Delete entity plus all children
        /// </summary>
        public void DeleteFull(DatabaseEntities dbContext)
        {
            
            Delete(dbContext);
        }

        [Key]
        public int WorkOrderID { get; set; }
        public string WorkOrderName { get; set; }
        public double? FiscalYear { get; set; }
        public int? WorkBreakdownStructureID { get; set; }
        public string FUND { get; set; }
        public string FBMSSTATUS { get; set; }
        public string ETASSTATUS { get; set; }
        public string DEYSTATAUS { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public int PrimaryKey { get { return WorkOrderID; } set { WorkOrderID = value; } }



        public static class FieldLengths
        {
            public const int WorkOrderName = 255;
            public const int FUND = 255;
            public const int FBMSSTATUS = 255;
            public const int ETASSTATUS = 255;
            public const int DEYSTATAUS = 255;
            public const int Description = 255;
        }
    }
}