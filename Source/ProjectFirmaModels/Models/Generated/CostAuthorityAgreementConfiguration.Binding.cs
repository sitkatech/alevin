//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[CostAuthorityAgreement]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class CostAuthorityAgreementConfiguration : EntityTypeConfiguration<CostAuthorityAgreement>
    {
        public CostAuthorityAgreementConfiguration() : this("dbo"){}

        public CostAuthorityAgreementConfiguration(string schema)
        {
            ToTable("CostAuthorityAgreement", schema);
            HasKey(x => x.CostAuthorityAgreementID);
            Property(x => x.CostAuthorityAgreementID).HasColumnName(@"CostAuthorityAgreementID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationCostAuthorityAgreementID).HasColumnName(@"ReclamationCostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.CostAuthorityWorkBreakdownStructure).HasColumnName(@"CostAuthorityWorkBreakdownStructure").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.CostAuthority).HasColumnName(@"CostAuthority").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.AgreementNumber).HasColumnName(@"AgreementNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.PacificNorthActivityNumber).HasColumnName(@"PacificNorthActivityNumber").HasColumnType("int").IsOptional();
            Property(x => x.PacificNorthActivityName).HasColumnName(@"PacificNorthActivityName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}