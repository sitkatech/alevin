//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationStagingAgreementStatusTable]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingAgreementStatusTableConfiguration : EntityTypeConfiguration<ReclamationStagingAgreementStatusTable>
    {
        public ReclamationStagingAgreementStatusTableConfiguration() : this("dbo"){}

        public ReclamationStagingAgreementStatusTableConfiguration(string schema)
        {
            ToTable("ReclamationStagingAgreementStatusTable", schema);
            HasKey(x => x.ReclamationStagingAgreementStatusTableID);
            Property(x => x.ReclamationStagingAgreementStatusTableID).HasColumnName(@"ReclamationStagingAgreementStatusTableID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OriginalAgreementStatusID).HasColumnName(@"OriginalAgreementStatusID").HasColumnType("int").IsOptional();
            Property(x => x.OriginalReclamationCostAuthorityAgreementID).HasColumnName(@"OriginalReclamationCostAuthorityAgreementID").HasColumnType("int").IsOptional();
            Property(x => x.RequisitionNumber).HasColumnName(@"RequisitionNumber").HasColumnType("int").IsOptional();
            Property(x => x.Mods).HasColumnName(@"Mods").HasColumnType("int").IsOptional();
            Property(x => x.Line).HasColumnName(@"Line").HasColumnType("int").IsOptional();
            Property(x => x.Fund).HasColumnName(@"Fund").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.BeginDate).HasColumnName(@"BeginDate").HasColumnType("datetime").IsOptional();
            Property(x => x.EndDate).HasColumnName(@"EndDate").HasColumnType("datetime").IsOptional();
            Property(x => x.FiscalYear).HasColumnName(@"FiscalYear").HasColumnType("float").IsOptional();
            Property(x => x.OriginalObligation).HasColumnName(@"OriginalObligation").HasColumnType("money").IsOptional().HasPrecision(19,4);
            Property(x => x.Notes).HasColumnName(@"Notes").HasColumnType("nvarchar").IsOptional();
            Property(x => x.ModDeObligationOrClosed).HasColumnName(@"ModDeObligationOrClosed").HasColumnType("bit").IsRequired();

        }
    }
}