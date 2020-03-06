//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ContractType]
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
        public static ContractType GetContractType(this IQueryable<ContractType> contractTypes, int reclamationContractTypeID)
        {
            var contractType = contractTypes.SingleOrDefault(x => x.ReclamationContractTypeID == reclamationContractTypeID);
            Check.RequireNotNullThrowNotFound(contractType, "ContractType", reclamationContractTypeID);
            return contractType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, List<int> reclamationContractTypeIDList)
        {
            if(reclamationContractTypeIDList.Any())
            {
                contractTypes.Where(x => reclamationContractTypeIDList.Contains(x.ReclamationContractTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, ICollection<ContractType> contractTypesToDelete)
        {
            if(contractTypesToDelete.Any())
            {
                var reclamationContractTypeIDList = contractTypesToDelete.Select(x => x.ReclamationContractTypeID).ToList();
                contractTypes.Where(x => reclamationContractTypeIDList.Contains(x.ReclamationContractTypeID)).Delete();
            }
        }

        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, int reclamationContractTypeID)
        {
            DeleteContractType(contractTypes, new List<int> { reclamationContractTypeID });
        }

        public static void DeleteContractType(this IQueryable<ContractType> contractTypes, ContractType contractTypeToDelete)
        {
            DeleteContractType(contractTypes, new List<ContractType> { contractTypeToDelete });
        }
    }
}