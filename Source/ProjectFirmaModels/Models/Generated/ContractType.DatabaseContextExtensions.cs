//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContractType]
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
        public static ContractType GetContractType(this IQueryable<ContractType> contractTypes, int contractTypeID)
        {
            var contractType = contractTypes.SingleOrDefault(x => x.ContractTypeID == contractTypeID);
            Check.RequireNotNullThrowNotFound(contractType, "ContractType", contractTypeID);
            return contractType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, List<int> contractTypeIDList)
        {
            if(contractTypeIDList.Any())
            {
                contractTypes.Where(x => contractTypeIDList.Contains(x.ContractTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, ICollection<ContractType> contractTypesToDelete)
        {
            if(contractTypesToDelete.Any())
            {
                var contractTypeIDList = contractTypesToDelete.Select(x => x.ContractTypeID).ToList();
                contractTypes.Where(x => contractTypeIDList.Contains(x.ContractTypeID)).Delete();
            }
        }

        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, int contractTypeID)
        {
            DeleteContractType(contractTypes, new List<int> { contractTypeID });
        }

        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, ContractType contractTypeToDelete)
        {
            DeleteContractType(contractTypes, new List<ContractType> { contractTypeToDelete });
        }
    }
}