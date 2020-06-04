//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImpApGenSheet
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ImpApGenSheetPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImpApGenSheet>
    {
        public ImpApGenSheetPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImpApGenSheetPrimaryKey(ImpApGenSheet impApGenSheet) : base(impApGenSheet){}

        public static implicit operator ImpApGenSheetPrimaryKey(int primaryKeyValue)
        {
            return new ImpApGenSheetPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImpApGenSheetPrimaryKey(ImpApGenSheet impApGenSheet)
        {
            return new ImpApGenSheetPrimaryKey(impApGenSheet);
        }
    }
}