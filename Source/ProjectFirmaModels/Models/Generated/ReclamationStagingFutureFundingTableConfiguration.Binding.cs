//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingFutureFundingTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingFutureFundingTableConfiguration : EntityTypeConfiguration<ReclamationStagingFutureFundingTable>
    {
        public ReclamationStagingFutureFundingTableConfiguration() : this("dbo"){}

        public ReclamationStagingFutureFundingTableConfiguration(string schema)
        {
            ToTable("ReclamationStagingFutureFundingTable", schema);
            HasKey(x => x.ReclamationStagingFutureFundingTableID);
            Property(x => x.ReclamationStagingFutureFundingTableID).HasColumnName(@"ReclamationStagingFutureFundingTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OriginalContractTrackingID).HasColumnName(@"OriginalContractTrackingID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalReclamationCostAuthorityAgreementID).HasColumnName(@"OriginalReclamationCostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.PlannedFundingYear).HasColumnName(@"PlannedFundingYear").HasColumnType("int").IsOptional();
            Property(x => x.ExpectedAmt).HasColumnName(@"ExpectedAmt").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.AwardAmt).HasColumnName(@"AwardAmt").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.AwardYear).HasColumnName(@"AwardYear").HasColumnType("float").IsOptional();
            Property(x => x.IsFunded).HasColumnName(@"IsFunded").HasColumnType("bit").IsRequired();
            Property(x => x.ContingencyYear).HasColumnName(@"ContingencyYear").HasColumnType("int").IsOptional();
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar").IsOptional().HasMaxLength(1000);

        }
    }
}