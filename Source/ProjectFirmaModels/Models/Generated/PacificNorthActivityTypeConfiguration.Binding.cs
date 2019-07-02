//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[PacificNorthActivityType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PacificNorthActivityTypeConfiguration : EntityTypeConfiguration<PacificNorthActivityType>
    {
        public PacificNorthActivityTypeConfiguration() : this("dbo"){}

        public PacificNorthActivityTypeConfiguration(string schema)
        {
            ToTable("PacificNorthActivityType", schema);
            HasKey(x => x.PacificNorthActivityTypeID);
            Property(x => x.PacificNorthActivityTypeID).HasColumnName(@"PacificNorthActivityTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PacificNorthActivityTypeName).HasColumnName(@"PacificNorthActivityTypeName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}