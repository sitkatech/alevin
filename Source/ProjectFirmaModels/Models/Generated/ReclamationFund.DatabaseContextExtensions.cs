//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ReclamationFund]
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
        public static ReclamationFund GetReclamationFund(this IQueryable<ReclamationFund> reclamationFunds, int reclamationFundID)
        {
            var reclamationFund = reclamationFunds.SingleOrDefault(x => x.ReclamationFundID == reclamationFundID);
            Check.RequireNotNullThrowNotFound(reclamationFund, "ReclamationFund", reclamationFundID);
            return reclamationFund;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationFund(this IQueryable<ReclamationFund> reclamationFunds, List<int> reclamationFundIDList)
        {
            if(reclamationFundIDList.Any())
            {
                reclamationFunds.Where(x => reclamationFundIDList.Contains(x.ReclamationFundID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationFund(this IQueryable<ReclamationFund> reclamationFunds, ICollection<ReclamationFund> reclamationFundsToDelete)
        {
            if(reclamationFundsToDelete.Any())
            {
                var reclamationFundIDList = reclamationFundsToDelete.Select(x => x.ReclamationFundID).ToList();
                reclamationFunds.Where(x => reclamationFundIDList.Contains(x.ReclamationFundID)).Delete();
            }
        }

        public static void DeleteReclamationFund(this IQueryable<ReclamationFund> reclamationFunds, int reclamationFundID)
        {
            DeleteReclamationFund(reclamationFunds, new List<int> { reclamationFundID });
        }

        public static void DeleteReclamationFund(this IQueryable<ReclamationFund> reclamationFunds, ReclamationFund reclamationFundToDelete)
        {
            DeleteReclamationFund(reclamationFunds, new List<ReclamationFund> { reclamationFundToDelete });
        }
    }
}