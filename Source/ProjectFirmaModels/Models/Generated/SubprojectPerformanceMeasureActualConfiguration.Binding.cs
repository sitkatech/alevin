//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureActual]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureActualConfiguration : EntityTypeConfiguration<SubprojectPerformanceMeasureActual>
    {
        public SubprojectPerformanceMeasureActualConfiguration() : this("dbo"){}

        public SubprojectPerformanceMeasureActualConfiguration(string schema)
        {
            ToTable("SubprojectPerformanceMeasureActual", schema);
            HasKey(x => x.SubprojectPerformanceMeasureActualID);
            Property(x => x.SubprojectPerformanceMeasureActualID).HasColumnName(@"SubprojectPerformanceMeasureActualID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectID).HasColumnName(@"SubprojectID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.ActualValue).HasColumnName(@"ActualValue").HasColumnType("float").IsRequired();
            Property(x => x.PerformanceMeasureReportingPeriodID).HasColumnName(@"PerformanceMeasureReportingPeriodID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.Subproject).WithMany(b => b.SubprojectPerformanceMeasureActuals).HasForeignKey(c => c.SubprojectID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActual_Subproject_SubprojectID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.SubprojectPerformanceMeasureActuals).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActual_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureReportingPeriod).WithMany(b => b.SubprojectPerformanceMeasureActuals).HasForeignKey(c => c.PerformanceMeasureReportingPeriodID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActual_PerformanceMeasureReportingPeriod_PerformanceMeasureReportingPeriodID
        }
    }
}