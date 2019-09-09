//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingPostedObligation]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingPostedObligationConfiguration : EntityTypeConfiguration<ReclamationStagingPostedObligation>
    {
        public ReclamationStagingPostedObligationConfiguration() : this("dbo"){}

        public ReclamationStagingPostedObligationConfiguration(string schema)
        {
            ToTable("ReclamationStagingPostedObligation", schema);
            HasKey(x => x.ReclamationStagingPostedObligationID);
            Property(x => x.ReclamationStagingPostedObligationID).HasColumnName(@"ReclamationStagingPostedObligationID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OriginalPostedObligationsID).HasColumnName(@"OriginalPostedObligationsID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalReclamationCostAuthorityAgreementID).HasColumnName(@"OriginalReclamationCostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalAgreementStatusID).HasColumnName(@"OriginalAgreementStatusID").HasColumnType("int").IsOptional();
            Property(x => x.Fund).HasColumnName(@"Fund").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Program).HasColumnName(@"Program").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.JobNumber).HasColumnName(@"JobNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.BOC).HasColumnName(@"BOC").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.FiscalYear).HasColumnName(@"FiscalYear").HasColumnType("int").IsOptional();
            Property(x => x.AgreementNumber).HasColumnName(@"AgreementNumber").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.ContractorName).HasColumnName(@"ContractorName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.Mods).HasColumnName(@"Mods").HasColumnType("float").IsOptional();
            Property(x => x.Line).HasColumnName(@"Line").HasColumnType("float").IsOptional();
            Property(x => x.BeginDate).HasColumnName(@"BeginDate").HasColumnType("datetime").IsOptional();
            Property(x => x.LastOfMonthEnding).HasColumnName(@"LastOfMonthEnding").HasColumnType("datetime").IsOptional();
            Property(x => x.LastOfAmount).HasColumnName(@"LastOfAmount").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.Amount).HasColumnName(@"Amount").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

        }
    }
}