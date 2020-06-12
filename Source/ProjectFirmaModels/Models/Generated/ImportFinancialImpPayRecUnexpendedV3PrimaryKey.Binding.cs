//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ImportFinancialImpPayRecUnexpendedV3
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ImportFinancialImpPayRecUnexpendedV3PrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ImportFinancialImpPayRecUnexpendedV3>
    {
        public ImportFinancialImpPayRecUnexpendedV3PrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ImportFinancialImpPayRecUnexpendedV3PrimaryKey(ImportFinancialImpPayRecUnexpendedV3 importFinancialImpPayRecUnexpendedV3) : base(importFinancialImpPayRecUnexpendedV3){}

        public static implicit operator ImportFinancialImpPayRecUnexpendedV3PrimaryKey(int primaryKeyValue)
        {
            return new ImportFinancialImpPayRecUnexpendedV3PrimaryKey(primaryKeyValue);
        }

        public static implicit operator ImportFinancialImpPayRecUnexpendedV3PrimaryKey(ImportFinancialImpPayRecUnexpendedV3 importFinancialImpPayRecUnexpendedV3)
        {
            return new ImportFinancialImpPayRecUnexpendedV3PrimaryKey(importFinancialImpPayRecUnexpendedV3);
        }
    }
}