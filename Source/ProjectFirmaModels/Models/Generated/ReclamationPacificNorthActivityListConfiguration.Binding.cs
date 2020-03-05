//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationPacificNorthActivityList]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPacificNorthActivityListConfiguration : EntityTypeConfiguration<ReclamationPacificNorthActivityList>
    {
        public ReclamationPacificNorthActivityListConfiguration() : this("Reclamation"){}

        public ReclamationPacificNorthActivityListConfiguration(string schema)
        {
            ToTable("ReclamationPacificNorthActivityList", schema);
            HasKey(x => x.ReclamationPacificNorthActivityListID);
            Property(x => x.ReclamationPacificNorthActivityListID).HasColumnName(@"ReclamationPacificNorthActivityListID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ActivityID).HasColumnName(@"ActivityID").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityName).HasColumnName(@"PacificNorthActivityName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.SortOrder).HasColumnName(@"SortOrder").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityTypeID).HasColumnName(@"PacificNorthActivityTypeID").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityStatusID).HasColumnName(@"PacificNorthActivityStatusID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.PacificNorthActivityType).WithMany(b => b.ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityType).HasForeignKey(c => c.PacificNorthActivityTypeID).WillCascadeOnDelete(false); // FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityType_PacificNorthActivityTypeID_ReclamationPacificNorthAct
            HasOptional(a => a.PacificNorthActivityStatus).WithMany(b => b.ReclamationPacificNorthActivityListsWhereYouAreThePacificNorthActivityStatus).HasForeignKey(c => c.PacificNorthActivityStatusID).WillCascadeOnDelete(false); // FK_ReclamationPacificNorthActivityList_ReclamationPacificNorthActivityStatus_PacificNorthActivityStatusID_ReclamationPacificNort
        }
    }
}