//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[PacificNorthActivityList]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class PacificNorthActivityListConfiguration : EntityTypeConfiguration<PacificNorthActivityList>
    {
        public PacificNorthActivityListConfiguration() : this("Reclamation"){}

        public PacificNorthActivityListConfiguration(string schema)
        {
            ToTable("PacificNorthActivityList", schema);
            HasKey(x => x.PacificNorthActivityListID);
            Property(x => x.PacificNorthActivityListID).HasColumnName(@"PacificNorthActivityListID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ActivityID).HasColumnName(@"ActivityID").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityName).HasColumnName(@"PacificNorthActivityName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityTypeID).HasColumnName(@"PacificNorthActivityTypeID").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityStatusID).HasColumnName(@"PacificNorthActivityStatusID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.PacificNorthActivityType).WithMany(b => b.PacificNorthActivityLists).HasForeignKey(c => c.PacificNorthActivityTypeID).WillCascadeOnDelete(false); // FK_PacificNorthActivityList_PacificNorthActivityType_PacificNorthActivityTypeID
            HasOptional(a => a.PacificNorthActivityStatus).WithMany(b => b.PacificNorthActivityLists).HasForeignKey(c => c.PacificNorthActivityStatusID).WillCascadeOnDelete(false); // FK_PacificNorthActivityList_PacificNorthActivityStatus_PacificNorthActivityStatusID
        }
    }
}