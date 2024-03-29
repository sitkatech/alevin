//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[Agreement]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class AgreementConfiguration : EntityTypeConfiguration<Agreement>
    {
        public AgreementConfiguration() : this("Reclamation"){}

        public AgreementConfiguration(string schema)
        {
            ToTable("Agreement", schema);
            HasKey(x => x.AgreementID);
            Property(x => x.AgreementID).HasColumnName(@"AgreementID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Original_ReclamationAgreementID).HasColumnName(@"Original_ReclamationAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.AgreementNumber).HasColumnName(@"AgreementNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContractorLU).HasColumnName(@"ContractorLU").HasColumnType("float").IsOptional();
            Property(x => x.IsContingent).HasColumnName(@"IsContingent").HasColumnType("bit").IsRequired();
            Property(x => x.IsIncrementalFunding).HasColumnName(@"IsIncrementalFunding").HasColumnType("bit").IsRequired();
            Property(x => x.OldAgreementNumber).HasColumnName(@"OldAgreementNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.COR).HasColumnName(@"COR").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.TechnicalRepresentative).HasColumnName(@"TechnicalRepresentative").HasColumnType("float").IsOptional();
            Property(x => x.BOC).HasColumnName(@"BOC").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContractNumber).HasColumnName(@"ContractNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ExpirationDate).HasColumnName(@"ExpirationDate").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FinancialReporting).HasColumnName(@"FinancialReporting").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.OrganizationID).HasColumnName(@"OrganizationID").HasColumnType("int").IsOptional();
            Property(x => x.ContractTypeID).HasColumnName(@"ContractTypeID").HasColumnType("int").IsRequired();
            Property(x => x.StartDate).HasColumnName(@"StartDate").HasColumnType("datetime").IsOptional();
            Property(x => x.EndDate).HasColumnName(@"EndDate").HasColumnType("datetime").IsOptional();

            // Foreign keys
            HasOptional(a => a.Organization).WithMany(b => b.Agreements).HasForeignKey(c => c.OrganizationID).WillCascadeOnDelete(false); // FK_Agreement_Organization_OrganizationID
            HasRequired(a => a.ContractType).WithMany(b => b.Agreements).HasForeignKey(c => c.ContractTypeID).WillCascadeOnDelete(false); // FK_Agreement_ContractType_ContractTypeID
        }
    }
}