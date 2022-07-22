//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureExpectedSubcategoryOption]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureExpectedSubcategoryOptionConfiguration : EntityTypeConfiguration<SubprojectPerformanceMeasureExpectedSubcategoryOption>
    {
        public SubprojectPerformanceMeasureExpectedSubcategoryOptionConfiguration() : this("dbo"){}

        public SubprojectPerformanceMeasureExpectedSubcategoryOptionConfiguration(string schema)
        {
            ToTable("SubprojectPerformanceMeasureExpectedSubcategoryOption", schema);
            HasKey(x => x.SubprojectPerformanceMeasureExpectedSubcategoryOptionID);
            Property(x => x.SubprojectPerformanceMeasureExpectedSubcategoryOptionID).HasColumnName(@"SubprojectPerformanceMeasureExpectedSubcategoryOptionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectPerformanceMeasureExpectedID).HasColumnName(@"SubprojectPerformanceMeasureExpectedID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.SubprojectPerformanceMeasureExpected).WithMany(b => b.SubprojectPerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.SubprojectPerformanceMeasureExpectedID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_SubprojectPerformanceMeasureExpected_SubprojectPerformanceMeasureExpect
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.SubprojectPerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOption
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.SubprojectPerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.SubprojectPerformanceMeasureExpectedSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureExpectedSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}