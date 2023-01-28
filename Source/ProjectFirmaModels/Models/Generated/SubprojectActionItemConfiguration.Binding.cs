//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectActionItem]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectActionItemConfiguration : EntityTypeConfiguration<SubprojectActionItem>
    {
        public SubprojectActionItemConfiguration() : this("dbo"){}

        public SubprojectActionItemConfiguration(string schema)
        {
            ToTable("SubprojectActionItem", schema);
            HasKey(x => x.SubprojectActionItemID);
            Property(x => x.SubprojectActionItemID).HasColumnName(@"SubprojectActionItemID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ActionItemStateID).HasColumnName(@"ActionItemStateID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectActionItemText).HasColumnName(@"SubprojectActionItemText").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(5000);
            Property(x => x.AssignedToPersonID).HasColumnName(@"AssignedToPersonID").HasColumnType("int").IsRequired();
            Property(x => x.AssignedOnDate).HasColumnName(@"AssignedOnDate").HasColumnType("datetime").IsRequired();
            Property(x => x.DueByDate).HasColumnName(@"DueByDate").HasColumnType("datetime").IsRequired();
            Property(x => x.CompletedOnDate).HasColumnName(@"CompletedOnDate").HasColumnType("datetime").IsOptional();
            Property(x => x.SubprojectProjectStatusID).HasColumnName(@"SubprojectProjectStatusID").HasColumnType("int").IsOptional();
            Property(x => x.SubprojectID).HasColumnName(@"SubprojectID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AssignedToPerson).WithMany(b => b.SubprojectActionItemsWhereYouAreTheAssignedToPerson).HasForeignKey(c => c.AssignedToPersonID).WillCascadeOnDelete(false); // FK_SubprojectActionItem_Person_AssignedToPersonID_PersonID
            HasOptional(a => a.SubprojectProjectStatus).WithMany(b => b.SubprojectActionItems).HasForeignKey(c => c.SubprojectProjectStatusID).WillCascadeOnDelete(false); // FK_SubprojectActionItem_SubprojectProjectStatus_SubprojectProjectStatusID
            HasRequired(a => a.Subproject).WithMany(b => b.SubprojectActionItems).HasForeignKey(c => c.SubprojectID).WillCascadeOnDelete(false); // FK_SubprojectActionItem_Subproject_SubprojectID
        }
    }
}