//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.TaxonomyTrunk
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class TaxonomyTrunkPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<TaxonomyTrunk>
    {
        public TaxonomyTrunkPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public TaxonomyTrunkPrimaryKey(TaxonomyTrunk taxonomyTrunk) : base(taxonomyTrunk){}

        public static implicit operator TaxonomyTrunkPrimaryKey(int primaryKeyValue)
        {
            return new TaxonomyTrunkPrimaryKey(primaryKeyValue);
        }

        public static implicit operator TaxonomyTrunkPrimaryKey(TaxonomyTrunk taxonomyTrunk)
        {
            return new TaxonomyTrunkPrimaryKey(taxonomyTrunk);
        }
    }
}