//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ReclamationStagingPostedObligation
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ReclamationStagingPostedObligationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ReclamationStagingPostedObligation>
    {
        public ReclamationStagingPostedObligationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ReclamationStagingPostedObligationPrimaryKey(ReclamationStagingPostedObligation reclamationStagingPostedObligation) : base(reclamationStagingPostedObligation){}

        public static implicit operator ReclamationStagingPostedObligationPrimaryKey(int primaryKeyValue)
        {
            return new ReclamationStagingPostedObligationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ReclamationStagingPostedObligationPrimaryKey(ReclamationStagingPostedObligation reclamationStagingPostedObligation)
        {
            return new ReclamationStagingPostedObligationPrimaryKey(reclamationStagingPostedObligation);
        }
    }
}