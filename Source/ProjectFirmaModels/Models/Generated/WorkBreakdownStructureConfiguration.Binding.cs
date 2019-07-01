//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[WorkBreakdownStructure]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class WorkBreakdownStructureConfiguration : EntityTypeConfiguration<WorkBreakdownStructure>
    {
        public WorkBreakdownStructureConfiguration() : this("dbo"){}

        public WorkBreakdownStructureConfiguration(string schema)
        {
            ToTable("WorkBreakdownStructure", schema);
            HasKey(x => x.WorkBreakdownStructureID);
            Property(x => x.WorkBreakdownStructureID).HasColumnName(@"WorkBreakdownStructureID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.WorkBreakdownStructureNumber).HasColumnName(@"WorkBreakdownStructureNumber").HasColumnType("varchar").IsRequired().IsUnicode(false).HasMaxLength(50);

        }
    }
}