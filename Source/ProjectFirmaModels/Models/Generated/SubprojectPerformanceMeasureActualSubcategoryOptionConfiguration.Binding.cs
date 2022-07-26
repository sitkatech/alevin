//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectPerformanceMeasureActualSubcategoryOption]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectPerformanceMeasureActualSubcategoryOptionConfiguration : EntityTypeConfiguration<SubprojectPerformanceMeasureActualSubcategoryOption>
    {
        public SubprojectPerformanceMeasureActualSubcategoryOptionConfiguration() : this("dbo"){}

        public SubprojectPerformanceMeasureActualSubcategoryOptionConfiguration(string schema)
        {
            ToTable("SubprojectPerformanceMeasureActualSubcategoryOption", schema);
            HasKey(x => x.SubprojectPerformanceMeasureActualSubcategoryOptionID);
            Property(x => x.SubprojectPerformanceMeasureActualSubcategoryOptionID).HasColumnName(@"SubprojectPerformanceMeasureActualSubcategoryOptionID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectPerformanceMeasureActualID).HasColumnName(@"SubprojectPerformanceMeasureActualID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryOptionID).HasColumnName(@"PerformanceMeasureSubcategoryOptionID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureID).HasColumnName(@"PerformanceMeasureID").HasColumnType("int").IsRequired();
            Property(x => x.PerformanceMeasureSubcategoryID).HasColumnName(@"PerformanceMeasureSubcategoryID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.SubprojectPerformanceMeasureActual).WithMany(b => b.SubprojectPerformanceMeasureActualSubcategoryOptionsWhereYouAreTheSubprojectPerformanceMeasureActual).HasForeignKey(c => c.SubprojectPerformanceMeasureActualID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureActual_SubprojectPerformanceMeasureActualID_Performance
            HasRequired(a => a.PerformanceMeasureSubcategoryOption).WithMany(b => b.SubprojectPerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryOptionID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategoryOption_PerformanceMeasureSubcategoryOptionID
            HasRequired(a => a.PerformanceMeasure).WithMany(b => b.SubprojectPerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasure_PerformanceMeasureID
            HasRequired(a => a.PerformanceMeasureSubcategory).WithMany(b => b.SubprojectPerformanceMeasureActualSubcategoryOptions).HasForeignKey(c => c.PerformanceMeasureSubcategoryID).WillCascadeOnDelete(false); // FK_SubprojectPerformanceMeasureActualSubcategoryOption_PerformanceMeasureSubcategory_PerformanceMeasureSubcategoryID
        }
    }
}