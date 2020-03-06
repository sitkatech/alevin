//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListConfiguration : EntityTypeConfiguration<ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList>
    {
        public ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListConfiguration() : this("Reclamation"){}

        public ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListConfiguration(string schema)
        {
            ToTable("ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList", schema);
            HasKey(x => x.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID);
            Property(x => x.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID).HasColumnName(@"ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityWorkBreakdownStructure).HasColumnName(@"CostAuthorityWorkBreakdownStructure").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ActivityID).HasColumnName(@"ActivityID").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityName).HasColumnName(@"PacificNorthActivityName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ESABiOpIDNumber).HasColumnName(@"ESABiOpIDNumber").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityListID).HasColumnName(@"PacificNorthActivityListID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.PacificNorthActivityList).WithMany(b => b.ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityListsWhereYouAreThePacificNorthActivityList).HasForeignKey(c => c.PacificNorthActivityListID).WillCascadeOnDelete(false); // FK_ReclamationStagingCostAuthorityWorkBreakdownStructurePacificNorthActivityList_PacificNorthActivityList_PacificNorthActivityLi
        }
    }
}