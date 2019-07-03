//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthorityWorkBreakdownStructurePacificNorthActivityList]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityWorkBreakdownStructurePacificNorthActivityListConfiguration : EntityTypeConfiguration<CostAuthorityWorkBreakdownStructurePacificNorthActivityList>
    {
        public CostAuthorityWorkBreakdownStructurePacificNorthActivityListConfiguration() : this("dbo"){}

        public CostAuthorityWorkBreakdownStructurePacificNorthActivityListConfiguration(string schema)
        {
            ToTable("CostAuthorityWorkBreakdownStructurePacificNorthActivityList", schema);
            HasKey(x => x.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID);
            Property(x => x.CostAuthorityWorkBreakdownStructurePacificNorthActivityListID).HasColumnName(@"CostAuthorityWorkBreakdownStructurePacificNorthActivityListID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityWorkBreakdownStructure).HasColumnName(@"CostAuthorityWorkBreakdownStructure").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ActivityID).HasColumnName(@"ActivityID").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityName).HasColumnName(@"PacificNorthActivityName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ESABiOpIDNumber).HasColumnName(@"ESABiOpIDNumber").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityListID).HasColumnName(@"PacificNorthActivityListID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.PacificNorthActivityList).WithMany(b => b.CostAuthorityWorkBreakdownStructurePacificNorthActivityLists).HasForeignKey(c => c.PacificNorthActivityListID).WillCascadeOnDelete(false); // FK_CostAuthorityWorkBreakdownStructurePacificNorthActivityList_PacificNorthActivityList_PacificNorthActivityListID
        }
    }
}