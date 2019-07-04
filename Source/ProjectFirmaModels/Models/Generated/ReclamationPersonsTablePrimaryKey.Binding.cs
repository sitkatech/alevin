//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationPersonsTable
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationPersonsTablePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationPersonsTable>
    {
        public ReclamationPersonsTablePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationPersonsTablePrimaryKey(ReclamationPersonsTable reclamationPersonsTable) : base(reclamationPersonsTable){}

        public static implicit operator ReclamationPersonsTablePrimaryKey(int primaryKeyValue)
        {
            return new ReclamationPersonsTablePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationPersonsTablePrimaryKey(ReclamationPersonsTable reclamationPersonsTable)
        {
            return new ReclamationPersonsTablePrimaryKey(reclamationPersonsTable);
        }
    }
}