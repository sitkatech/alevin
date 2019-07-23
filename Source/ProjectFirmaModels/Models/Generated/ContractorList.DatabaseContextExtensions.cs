//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContractorList]
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
        public static ContractorList GetContractorList(this IQueryable<ContractorList> contractorLists, int contractorListID)
        {
            var contractorList = contractorLists.SingleOrDefault(x => x.ContractorListID == contractorListID);
            Check.RequireNotNullThrowNotFound(contractorList, "ContractorList", contractorListID);
            return contractorList;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteContractorList(this IQueryable<ContractorList> contractorLists, List<int> contractorListIDList)
        {
            if(contractorListIDList.Any())
            {
                contractorLists.Where(x => contractorListIDList.Contains(x.ContractorListID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteContractorList(this IQueryable<ContractorList> contractorLists, ICollection<ContractorList> contractorListsToDelete)
        {
            if(contractorListsToDelete.Any())
            {
                var contractorListIDList = contractorListsToDelete.Select(x => x.ContractorListID).ToList();
                contractorLists.Where(x => contractorListIDList.Contains(x.ContractorListID)).Delete();
            }
        }

        public static void DeleteContractorList(this IQueryable<ContractorList> contractorLists, int contractorListID)
        {
            DeleteContractorList(contractorLists, new List<int> { contractorListID });
        }

        public static void DeleteContractorList(this IQueryable<ContractorList> contractorLists, ContractorList contractorListToDelete)
        {
            DeleteContractorList(contractorLists, new List<ContractorList> { contractorListToDelete });
        }
    }
}