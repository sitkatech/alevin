//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContractorList]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ContractorListConfiguration : EntityTypeConfiguration<ContractorList>
    {
        public ContractorListConfiguration() : this("dbo"){}

        public ContractorListConfiguration(string schema)
        {
            ToTable("ContractorList", schema);
            HasKey(x => x.ContractorListID);
            Property(x => x.ContractorListID).HasColumnName(@"ContractorListID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ReclamationContractorID).HasColumnName(@"ReclamationContractorID").HasColumnType("float").IsOptional();
            Property(x => x.ContractorName).HasColumnName(@"ContractorName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.CompanyName).HasColumnName(@"CompanyName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.VendorNumber).HasColumnName(@"VendorNumber").HasColumnType("float").IsOptional();
            Property(x => x.Address1).HasColumnName(@"Address1").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Address2).HasColumnName(@"Address2").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.City).HasColumnName(@"City").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.State).HasColumnName(@"State").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Zip).HasColumnName(@"Zip").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContactFirstName).HasColumnName(@"ContactFirstName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContactLastName).HasColumnName(@"ContactLastName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContactPhone).HasColumnName(@"ContactPhone").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContactEmail).HasColumnName(@"ContactEmail").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}