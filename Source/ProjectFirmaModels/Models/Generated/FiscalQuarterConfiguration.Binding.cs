//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[FiscalQuarter]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class FiscalQuarterConfiguration : EntityTypeConfiguration<FiscalQuarter>
    {
        public FiscalQuarterConfiguration() : this("ImportFinancial"){}

        public FiscalQuarterConfiguration(string schema)
        {
            ToTable("FiscalQuarter", schema);
            HasKey(x => x.FiscalQuarterID);
            Property(x => x.FiscalQuarterID).HasColumnName(@"FiscalQuarterID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.FiscalQuarterNumber).HasColumnName(@"FiscalQuarterNumber").HasColumnType("int").IsRequired();
            Property(x => x.FiscalQuarterName).HasColumnName(@"FiscalQuarterName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FiscalQuarterDisplayName).HasColumnName(@"FiscalQuarterDisplayName").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(100);
            Property(x => x.FiscalQuarterStartCalendarMonth).HasColumnName(@"FiscalQuarterStartCalendarMonth").HasColumnType("int").IsRequired();
            Property(x => x.FiscalQuarterStartCalendarDay).HasColumnName(@"FiscalQuarterStartCalendarDay").HasColumnType("int").IsRequired();

            // Foreign keys

        }
    }
}