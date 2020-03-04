//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[ObligationNumber]
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
        public static ObligationNumber GetObligationNumber(this IQueryable<ObligationNumber> obligationNumbers, int obligationNumberID)
        {
            var obligationNumber = obligationNumbers.SingleOrDefault(x => x.ObligationNumberID == obligationNumberID);
            Check.RequireNotNullThrowNotFound(obligationNumber, "ObligationNumber", obligationNumberID);
            return obligationNumber;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteObligationNumber(this IQueryable<ObligationNumber> obligationNumbers, List<int> obligationNumberIDList)
        {
            if(obligationNumberIDList.Any())
            {
                obligationNumbers.Where(x => obligationNumberIDList.Contains(x.ObligationNumberID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteObligationNumber(this IQueryable<ObligationNumber> obligationNumbers, ICollection<ObligationNumber> obligationNumbersToDelete)
        {
            if(obligationNumbersToDelete.Any())
            {
                var obligationNumberIDList = obligationNumbersToDelete.Select(x => x.ObligationNumberID).ToList();
                obligationNumbers.Where(x => obligationNumberIDList.Contains(x.ObligationNumberID)).Delete();
            }
        }

        public static void DeleteObligationNumber(this IQueryable<ObligationNumber> obligationNumbers, int obligationNumberID)
        {
            DeleteObligationNumber(obligationNumbers, new List<int> { obligationNumberID });
        }

        public static void DeleteObligationNumber(this IQueryable<ObligationNumber> obligationNumbers, ObligationNumber obligationNumberToDelete)
        {
            DeleteObligationNumber(obligationNumbers, new List<ObligationNumber> { obligationNumberToDelete });
        }
    }
}