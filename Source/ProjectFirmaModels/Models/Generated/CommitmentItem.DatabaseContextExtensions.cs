//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [ImportFinancial].[CommitmentItem]
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
        public static CommitmentItem GetCommitmentItem(this IQueryable<CommitmentItem> commitmentItems, int commitmentItemID)
        {
            var commitmentItem = commitmentItems.SingleOrDefault(x => x.CommitmentItemID == commitmentItemID);
            Check.RequireNotNullThrowNotFound(commitmentItem, "CommitmentItem", commitmentItemID);
            return commitmentItem;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteCommitmentItem(this IQueryable<CommitmentItem> commitmentItems, List<int> commitmentItemIDList)
        {
            if(commitmentItemIDList.Any())
            {
                commitmentItems.Where(x => commitmentItemIDList.Contains(x.CommitmentItemID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteCommitmentItem(this IQueryable<CommitmentItem> commitmentItems, ICollection<CommitmentItem> commitmentItemsToDelete)
        {
            if(commitmentItemsToDelete.Any())
            {
                var commitmentItemIDList = commitmentItemsToDelete.Select(x => x.CommitmentItemID).ToList();
                commitmentItems.Where(x => commitmentItemIDList.Contains(x.CommitmentItemID)).Delete();
            }
        }

        public static void DeleteCommitmentItem(this IQueryable<CommitmentItem> commitmentItems, int commitmentItemID)
        {
            DeleteCommitmentItem(commitmentItems, new List<int> { commitmentItemID });
        }

        public static void DeleteCommitmentItem(this IQueryable<CommitmentItem> commitmentItems, CommitmentItem commitmentItemToDelete)
        {
            DeleteCommitmentItem(commitmentItems, new List<CommitmentItem> { commitmentItemToDelete });
        }
    }
}