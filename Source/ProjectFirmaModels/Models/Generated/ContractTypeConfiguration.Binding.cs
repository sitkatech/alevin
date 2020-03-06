//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ContractType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ContractTypeConfiguration : EntityTypeConfiguration<ContractType>
    {
        public ContractTypeConfiguration() : this("Reclamation"){}

        public ContractTypeConfiguration(string schema)
        {
            ToTable("ContractType", schema);
            HasKey(x => x.ReclamationContractTypeID);
            Property(x => x.ReclamationContractTypeID).HasColumnName(@"ReclamationContractTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ContractTypeName).HasColumnName(@"ContractTypeName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.ContractTypeDisplayName).HasColumnName(@"ContractTypeDisplayName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}