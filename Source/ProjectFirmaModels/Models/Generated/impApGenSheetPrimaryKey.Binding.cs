//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.impApGenSheet
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class impApGenSheetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<impApGenSheet>
    {
        public impApGenSheetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public impApGenSheetPrimaryKey(impApGenSheet impApGenSheet) : base(impApGenSheet){}

        public static implicit operator impApGenSheetPrimaryKey(int primaryKeyValue)
        {
            return new impApGenSheetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator impApGenSheetPrimaryKey(impApGenSheet impApGenSheet)
        {
            return new impApGenSheetPrimaryKey(impApGenSheet);
        }
    }
}