//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ImpProcessing]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ImpProcessingConfiguration : EntityTypeConfiguration<ImpProcessing>
    {
        public ImpProcessingConfiguration() : this("ImportFinancial"){}

        public ImpProcessingConfiguration(string schema)
        {
            ToTable("ImpProcessing", schema);
            HasKey(x => x.ImpProcessingID);
            Property(x => x.ImpProcessingID).HasColumnName(@"ImpProcessingID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ImpProcessingTableTypeID).HasColumnName(@"ImpProcessingTableTypeID").HasColumnType("int").IsRequired();
            Property(x => x.UploadDate).HasColumnName(@"UploadDate").HasColumnType("datetime").IsOptional();
            Property(x => x.LastProcessedDate).HasColumnName(@"LastProcessedDate").HasColumnType("datetime").IsOptional();

            // Foreign keys

        }
    }
}