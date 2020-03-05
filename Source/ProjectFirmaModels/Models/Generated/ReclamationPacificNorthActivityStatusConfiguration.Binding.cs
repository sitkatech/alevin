//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationPacificNorthActivityStatus]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPacificNorthActivityStatusConfiguration : EntityTypeConfiguration<ReclamationPacificNorthActivityStatus>
    {
        public ReclamationPacificNorthActivityStatusConfiguration() : this("Reclamation"){}

        public ReclamationPacificNorthActivityStatusConfiguration(string schema)
        {
            ToTable("ReclamationPacificNorthActivityStatus", schema);
            HasKey(x => x.ReclamationPacificNorthActivityStatusID);
            Property(x => x.ReclamationPacificNorthActivityStatusID).HasColumnName(@"ReclamationPacificNorthActivityStatusID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PacificNorthActivityStatusName).HasColumnName(@"PacificNorthActivityStatusName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(100);

            // Foreign keys

        }
    }
}