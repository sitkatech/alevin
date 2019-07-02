//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContractType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ContractTypeConfiguration : EntityTypeConfiguration<ContractType>
    {
        public ContractTypeConfiguration() : this("dbo"){}

        public ContractTypeConfiguration(string schema)
        {
            ToTable("ContractType", schema);
            HasKey(x => x.ContractTypeID);
            Property(x => x.ContractTypeID).HasColumnName(@"ContractTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ContractTypeName).HasColumnName(@"ContractTypeName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);
            Property(x => x.ContractTypeDisplayName).HasColumnName(@"ContractTypeDisplayName").HasColumnType("varchar").IsOptional().IsUnicode(false).HasMaxLength(255);

            // Foreign keys

        }
    }
}