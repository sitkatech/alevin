//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityStatus]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PacificNorthActivityStatusConfiguration : EntityTypeConfiguration<PacificNorthActivityStatus>
    {
        public PacificNorthActivityStatusConfiguration() : this("Reclamation"){}

        public PacificNorthActivityStatusConfiguration(string schema)
        {
            ToTable("PacificNorthActivityStatus", schema);
            HasKey(x => x.ReclamationPacificNorthActivityStatusID);
            Property(x => x.ReclamationPacificNorthActivityStatusID).HasColumnName(@"ReclamationPacificNorthActivityStatusID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PacificNorthActivityStatusName).HasColumnName(@"PacificNorthActivityStatusName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}