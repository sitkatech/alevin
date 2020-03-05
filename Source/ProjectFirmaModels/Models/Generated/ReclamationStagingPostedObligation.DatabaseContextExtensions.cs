//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationStagingPostedObligation]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ReclamationStagingPostedObligation GetReclamationStagingPostedObligation(this IQueryable<ReclamationStagingPostedObligation> reclamationStagingPostedObligations, int reclamationStagingPostedObligationID)
        {
            var reclamationStagingPostedObligation = reclamationStagingPostedObligations.SingleOrDefault(x => x.ReclamationStagingPostedObligationID == reclamationStagingPostedObligationID);
            Check.RequireNotNullThrowNotFound(reclamationStagingPostedObligation, "ReclamationStagingPostedObligation", reclamationStagingPostedObligationID);
            return reclamationStagingPostedObligation;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationStagingPostedObligation(this IQueryable<ReclamationStagingPostedObligation> reclamationStagingPostedObligations, List<int> reclamationStagingPostedObligationIDList)
        {
            if(reclamationStagingPostedObligationIDList.Any())
            {
                reclamationStagingPostedObligations.Where(x => reclamationStagingPostedObligationIDList.Contains(x.ReclamationStagingPostedObligationID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationStagingPostedObligation(this IQueryable<ReclamationStagingPostedObligation> reclamationStagingPostedObligations, ICollection<ReclamationStagingPostedObligation> reclamationStagingPostedObligationsToDelete)
        {
            if(reclamationStagingPostedObligationsToDelete.Any())
            {
                var reclamationStagingPostedObligationIDList = reclamationStagingPostedObligationsToDelete.Select(x => x.ReclamationStagingPostedObligationID).ToList();
                reclamationStagingPostedObligations.Where(x => reclamationStagingPostedObligationIDList.Contains(x.ReclamationStagingPostedObligationID)).Delete();
            }
        }

        public static void DeleteReclamationStagingPostedObligation(this IQueryable<ReclamationStagingPostedObligation> reclamationStagingPostedObligations, int reclamationStagingPostedObligationID)
        {
            DeleteReclamationStagingPostedObligation(reclamationStagingPostedObligations, new List<int> { reclamationStagingPostedObligationID });
        }

        public static void DeleteReclamationStagingPostedObligation(this IQueryable<ReclamationStagingPostedObligation> reclamationStagingPostedObligations, ReclamationStagingPostedObligation reclamationStagingPostedObligationToDelete)
        {
            DeleteReclamationStagingPostedObligation(reclamationStagingPostedObligations, new List<ReclamationStagingPostedObligation> { reclamationStagingPostedObligationToDelete });
        }
    }
}