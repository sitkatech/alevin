//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[DeliverableType]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class DeliverableTypeConfiguration : EntityTypeConfiguration<DeliverableType>
    {
        public DeliverableTypeConfiguration() : this("Reclamation"){}

        public DeliverableTypeConfiguration(string schema)
        {
            ToTable("DeliverableType", schema);
            HasKey(x => x.ReclamationDeliverableTypeID);
            Property(x => x.ReclamationDeliverableTypeID).HasColumnName(@"ReclamationDeliverableTypeID").HasColumnType("int").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.DeliverableTypeDisplayName).HasColumnName(@"DeliverableTypeDisplayName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);
            Property(x => x.DeliverableTypeName).HasColumnName(@"DeliverableTypeName").HasColumnType("nvarchar").IsOptional().HasMaxLength(255);

            // Foreign keys

        }
    }
}