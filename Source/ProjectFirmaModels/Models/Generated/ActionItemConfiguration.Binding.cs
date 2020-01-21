//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ActionItem]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ActionItemConfiguration : EntityTypeConfiguration<ActionItem>
    {
        public ActionItemConfiguration() : this("dbo"){}

        public ActionItemConfiguration(string schema)
        {
            ToTable("ActionItem", schema);
            HasKey(x => x.ActionItemID);
            Property(x => x.ActionItemID).HasColumnName(@"ActionItemID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.ActionItemStateID).HasColumnName(@"ActionItemStateID").HasColumnType("int").IsRequired();
            Property(x => x.ActionItemText).HasColumnName(@"ActionItemText").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(5000);
            Property(x => x.AssignedToPersonID).HasColumnName(@"AssignedToPersonID").HasColumnType("int").IsRequired();
            Property(x => x.AssignedOnDate).HasColumnName(@"AssignedOnDate").HasColumnType("datetime").IsRequired();
            Property(x => x.DueByDate).HasColumnName(@"DueByDate").HasColumnType("datetime").IsRequired();
            Property(x => x.CompletedOnDate).HasColumnName(@"CompletedOnDate").HasColumnType("datetime").IsOptional();
            Property(x => x.ProjectStatusID).HasColumnName(@"ProjectStatusID").HasColumnType("int").IsOptional();
            Property(x => x.ProjectID).HasColumnName(@"ProjectID").HasColumnType("int").IsRequired();

            // Foreign keys
            HasRequired(a => a.AssignedToPerson).WithMany(b => b.ActionItemsWhereYouAreTheAssignedToPerson).HasForeignKey(c => c.AssignedToPersonID).WillCascadeOnDelete(false); // FK_ActionItem_Person_AssignedToPersonID_PersonID
            HasOptional(a => a.ProjectStatus).WithMany(b => b.ActionItems).HasForeignKey(c => c.ProjectStatusID).WillCascadeOnDelete(false); // FK_ActionItem_ProjectStatus_ProjectStatusID
            HasRequired(a => a.Project).WithMany(b => b.ActionItems).HasForeignKey(c => c.ProjectID).WillCascadeOnDelete(false); // FK_ActionItem_Project_ProjectID
        }
    }
}