//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[CostAuthority]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityConfiguration : EntityTypeConfiguration<CostAuthority>
    {
        public CostAuthorityConfiguration() : this("Reclamation"){}

        public CostAuthorityConfiguration(string schema)
        {
            ToTable("CostAuthority", schema);
            HasKey(x => x.CostAuthorityID);
            Property(x => x.CostAuthorityID).HasColumnName(@"CostAuthorityID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CostAuthorityWorkBreakdownStructure).HasColumnName(@"CostAuthorityWorkBreakdownStructure").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.CostAuthorityNumber).HasColumnName(@"CostAuthorityNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.AccountStructureDescription).HasColumnName(@"AccountStructureDescription").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.CostCenter).HasColumnName(@"CostCenter").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.AgencyProjectType).HasColumnName(@"AgencyProjectType").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ProjectNumber).HasColumnName(@"ProjectNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Authority).HasColumnName(@"Authority").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Job).HasColumnName(@"Job").HasColumnType("nvarchar").IsOptional().HasMaxLength(3);
            Property(x => x.Number).HasColumnName(@"Number").HasColumnType("nvarchar").IsOptional().HasMaxLength(4);
            Property(x => x.JobNumber).HasColumnName(@"JobNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.WBSStatus).HasColumnName(@"WBSStatus").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.HCategoryLU).HasColumnName(@"HCategoryLU").HasColumnType("float").IsOptional();
            Property(x => x.WBSNoDot).HasColumnName(@"WBSNoDot").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.HabitatCategoryID).HasColumnName(@"HabitatCategoryID").HasColumnType("int").IsOptional();
            Property(x => x.BasinID).HasColumnName(@"BasinID").HasColumnType("int").IsOptional();
            Property(x => x.SubbasinID).HasColumnName(@"SubbasinID").HasColumnType("int").IsOptional();

            // Foreign keys
            HasOptional(a => a.HabitatCategory).WithMany(b => b.CostAuthoritiesWhereYouAreTheHabitatCategory).HasForeignKey(c => c.HabitatCategoryID).WillCascadeOnDelete(false); // FK_CostAuthority_HCategory_HabitatCategoryID_HCategoryID
            HasOptional(a => a.Basin).WithMany(b => b.CostAuthorities).HasForeignKey(c => c.BasinID).WillCascadeOnDelete(false); // FK_CostAuthority_Basin_BasinID
            HasOptional(a => a.Subbasin).WithMany(b => b.CostAuthorities).HasForeignKey(c => c.SubbasinID).WillCascadeOnDelete(false); // FK_CostAuthority_Subbasin_SubbasinID
        }
    }
}