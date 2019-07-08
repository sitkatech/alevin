//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationWorkBreakdownStructure
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationWorkBreakdownStructurePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationWorkBreakdownStructure>
    {
        public ReclamationWorkBreakdownStructurePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationWorkBreakdownStructurePrimaryKey(ReclamationWorkBreakdownStructure reclamationWorkBreakdownStructure) : base(reclamationWorkBreakdownStructure){}

        public static implicit operator ReclamationWorkBreakdownStructurePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationWorkBreakdownStructurePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationWorkBreakdownStructurePrimaryKey(ReclamationWorkBreakdownStructure reclamationWorkBreakdownStructure)
        {
            return new ReclamationWorkBreakdownStructurePrimaryKey(reclamationWorkBreakdownStructure);
        }
    }
}