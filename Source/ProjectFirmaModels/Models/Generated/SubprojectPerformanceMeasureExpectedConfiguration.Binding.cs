//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureExpected]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureExpectedConfiguration : EntityTypeConfiguration<SubprojectPerformanceMeasureExpected>
    {
        public SubprojectPerformanceMeasureExpectedConfiguration() : this("dbo"){}

        public SubprojectPerformanceMeasureExpectedConfiguration(string schema)
        {
            ToTable("SubprojectPerformanceMeasureExpected", schema);
            HasKey(x => x.SubprojectPerformanceMeasureExpectedID);
            Property(x => x.SubprojectPerformanceMeasureExpectedID).HasColumnName(@"SubprojectPerformanceMeasureExpectedID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectID).HasColumnName(@"SubprojectID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.ExpectedValue).HasColumnName(@"ExpectedValue").HasColumnType("float").IsOptional();

            // Foreign keys
            HasRequired(a => a.Subproject).WithMany(b => b.SubprojectPerformanceMeasureExpecteds).HasForeignKey(c => c.SubprojectID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureExpected_Subproject_SubprojectID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.SubprojectPerformanceMeasureExpecteds).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureExpected_PerformanceMeasure_PerformanceMeasureID
        }
    }
}