//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[WorkOrder]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class WorkOrderConfiguration : EntityTypeConfiguration<WorkOrder>
    {
        public WorkOrderConfiguration() : this("Reclamation"){}

        public WorkOrderConfiguration(string schema)
        {
            ToTable("WorkOrder", schema);
            HasKey(x => x.ReclamationWorkOrderID);
            Property(x => x.ReclamationWorkOrderID).HasColumnName(@"ReclamationWorkOrderID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkOrderName).HasColumnName(@"WorkOrderName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FiscalYear).HasColumnName(@"FiscalYear").HasColumnType("float").IsOptional();
            Property(x => x.WorkBreakdownStructureID).HasColumnName(@"WorkBreakdownStructureID").HasColumnType("int").IsOptional();
            Property(x => x.FUND).HasColumnName(@"FUND").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FBMSSTATUS).HasColumnName(@"FBMSSTATUS").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ETASSTATUS).HasColumnName(@"ETASSTATUS").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.DEYSTATAUS).HasColumnName(@"DEYSTATAUS").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Description).HasColumnName(@"Description").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}