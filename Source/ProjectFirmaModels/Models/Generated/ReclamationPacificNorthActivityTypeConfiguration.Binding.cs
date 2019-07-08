//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationPacificNorthActivityType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPacificNorthActivityTypeConfiguration : EntityTypeConfiguration<ReclamationPacificNorthActivityType>
    {
        public ReclamationPacificNorthActivityTypeConfiguration() : this("dbo"){}

        public ReclamationPacificNorthActivityTypeConfiguration(string schema)
        {
            ToTable("ReclamationPacificNorthActivityType", schema);
            HasKey(x => x.ReclamationPacificNorthActivityTypeID);
            Property(x => x.ReclamationPacificNorthActivityTypeID).HasColumnName(@"ReclamationPacificNorthActivityTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PacificNorthActivityTypeName).HasColumnName(@"PacificNorthActivityTypeName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}