//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationWorkBreakdownStructure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationWorkBreakdownStructureConfiguration : EntityTypeConfiguration<ReclamationWorkBreakdownStructure>
    {
        public ReclamationWorkBreakdownStructureConfiguration() : this("Reclamation"){}

        public ReclamationWorkBreakdownStructureConfiguration(string schema)
        {
            ToTable("ReclamationWorkBreakdownStructure", schema);
            HasKey(x => x.ReclamationWorkBreakdownStructureID);
            Property(x => x.ReclamationWorkBreakdownStructureID).HasColumnName(@"ReclamationWorkBreakdownStructureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkBreakdownStructureNumber).HasColumnName(@"WorkBreakdownStructureNumber").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);

        }
    }
}