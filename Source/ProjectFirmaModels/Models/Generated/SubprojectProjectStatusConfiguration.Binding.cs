//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[SubprojectProjectStatus]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class SubprojectProjectStatusConfiguration : EntityTypeConfiguration<SubprojectProjectStatus>
    {
        public SubprojectProjectStatusConfiguration() : this("dbo"){}

        public SubprojectProjectStatusConfiguration(string schema)
        {
            ToTable("SubprojectProjectStatus", schema);
            HasKey(x => x.SubprojectProjectStatusID);
            Property(x => x.SubprojectProjectStatusID).HasColumnName(@"SubprojectProjectStatusID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TenantID).HasColumnName(@"TenantID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectID).HasColumnName(@"SubprojectID").HasColumnType("int").IsRequired();
            Property(x => x.ProjectStatusID).HasColumnName(@"ProjectStatusID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectProjectStatusUpdateDate).HasColumnName(@"SubprojectProjectStatusUpdateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.SubprojectProjectStatusCreatePersonID).HasColumnName(@"SubprojectProjectStatusCreatePersonID").HasColumnType("int").IsRequired();
            Property(x => x.SubprojectProjectStatusCreateDate).HasColumnName(@"SubprojectProjectStatusCreateDate").HasColumnType("datetime").IsRequired();
            Property(x => x.SubprojectProjectStatusLastEditedPersonID).HasColumnName(@"SubprojectProjectStatusLastEditedPersonID").HasColumnType("int").IsOptional();
            Property(x => x.SubprojectProjectStatusLastEditedDate).HasColumnName(@"SubprojectProjectStatusLastEditedDate").HasColumnType("datetime").IsOptional();
            Property(x => x.IsFinalStatusUpdate).HasColumnName(@"IsFinalStatusUpdate").HasColumnType("bit").IsRequired();
            Property(x => x.LessonsLearned).HasColumnName(@"LessonsLearned").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2500);
            Property(x => x.SubprojectProjectStatusRecentActivities).HasColumnName(@"SubprojectProjectStatusRecentActivities").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.SubprojectProjectStatusUpcomingActivities).HasColumnName(@"SubprojectProjectStatusUpcomingActivities").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.SubprojectProjectStatusRisksOrIssues).HasColumnName(@"SubprojectProjectStatusRisksOrIssues").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2000);
            Property(x => x.SubprojectProjectStatusComment).HasColumnName(@"SubprojectProjectStatusComment").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(2000);

            // Foreign keys
            HasRequired(a => a.Subproject).WithMany(b => b.SubprojectProjectStatuses).HasForeignKey(c => c.SubprojectID).WillCascadeOnDelete(false); // FK_SubprojectProjectStatus_Subproject_SubprojectID
            HasRequired(a => a.ProjectStatus).WithMany(b => b.SubprojectProjectStatuses).HasForeignKey(c => c.ProjectStatusID).WillCascadeOnDelete(false); // FK_SubprojectProjectStatus_ProjectStatus_ProjectStatusID
            HasRequired(a => a.SubprojectProjectStatusCreatePerson).WithMany(b => b.SubprojectProjectStatusesWhereYouAreTheSubprojectProjectStatusCreatePerson).HasForeignKey(c => c.SubprojectProjectStatusCreatePersonID).WillCascadeOnDelete(false); // FK_SubprojectProjectStatus_Person_SubprojectProjectStatusCreatePersonID_PersonID
            HasOptional(a => a.SubprojectProjectStatusLastEditedPerson).WithMany(b => b.SubprojectProjectStatusesWhereYouAreTheSubprojectProjectStatusLastEditedPerson).HasForeignKey(c => c.SubprojectProjectStatusLastEditedPersonID).WillCascadeOnDelete(false); // FK_SubprojectProjectStatus_Person_SubprojectProjectStatusLastEditedPersonID_PersonID
        }
    }
}