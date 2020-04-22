//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source View: [dbo].[vProjectEffectiveTaxonomyLeaf]
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ProjectFirmaModels.Models
{
    public class vProjectEffectiveTaxonomyLeafConfiguration : EntityTypeConfiguration<vProjectEffectiveTaxonomyLeaf>
    {
        public vProjectEffectiveTaxonomyLeafConfiguration() : this("dbo"){}

        public vProjectEffectiveTaxonomyLeafConfiguration(string schema)
        {
            ToTable("vProjectEffectiveTaxonomyLeaf", schema);
            HasKey(x => x.PrimaryKey);
            
            
            
            
            
        }
    }
}