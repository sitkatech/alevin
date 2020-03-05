//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationDeliverableType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class ReclamationDeliverableTypeConfiguration : EntityTypeConfiguration<ReclamationDeliverableType>
    {
        public ReclamationDeliverableTypeConfiguration() : this("Reclamation"){}

        public ReclamationDeliverableTypeConfiguration(string schema)
        {
            ToTable("ReclamationDeliverableType", schema);
            HasKey(x => x.ReclamationDeliverableTypeID);
            Property(x => x.ReclamationDeliverableTypeID).HasColumnName(@"ReclamationDeliverableTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DeliverableTypeDisplayName).HasColumnName(@"DeliverableTypeDisplayName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.DeliverableTypeName).HasColumnName(@"DeliverableTypeName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

            // Foreign keys

        }
    }
}