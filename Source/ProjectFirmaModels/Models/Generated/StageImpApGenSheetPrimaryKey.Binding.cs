//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.StageImpApGenSheet
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class StageImpApGenSheetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<StageImpApGenSheet>
    {
        public StageImpApGenSheetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public StageImpApGenSheetPrimaryKey(StageImpApGenSheet stageImpApGenSheet) : base(stageImpApGenSheet){}

        public static implicit operator StageImpApGenSheetPrimaryKey(int primaryKeyValue)
        {
            return new StageImpApGenSheetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator StageImpApGenSheetPrimaryKey(StageImpApGenSheet stageImpApGenSheet)
        {
            return new StageImpApGenSheetPrimaryKey(stageImpApGenSheet);
        }
    }
}