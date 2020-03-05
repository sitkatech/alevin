//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [Reclamation].[ReclamationContractType]
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
        public static ReclamationContractType GetReclamationContractType(this IQueryable<ReclamationContractType> reclamationContractTypes, int reclamationContractTypeID)
        {
            var reclamationContractType = reclamationContractTypes.SingleOrDefault(x => x.ReclamationContractTypeID == reclamationContractTypeID);
            Check.RequireNotNullThrowNotFound(reclamationContractType, "ReclamationContractType", reclamationContractTypeID);
            return reclamationContractType;
        }

        // Delete using an IDList (Firma style)
        public static void DeleteReclamationContractType(this IQueryable<ReclamationContractType> reclamationContractTypes, List<int> reclamationContractTypeIDList)
        {
            if(reclamationContractTypeIDList.Any())
            {
                reclamationContractTypes.Where(x => reclamationContractTypeIDList.Contains(x.ReclamationContractTypeID)).Delete();
            }
        }

        // Delete using an object list (Firma style)
        public static void DeleteReclamationContractType(this IQueryable<ReclamationContractType> reclamationContractTypes, ICollection<ReclamationContractType> reclamationContractTypesToDelete)
        {
            if(reclamationContractTypesToDelete.Any())
            {
                var reclamationContractTypeIDList = reclamationContractTypesToDelete.Select(x => x.ReclamationContractTypeID).ToList();
                reclamationContractTypes.Where(x => reclamationContractTypeIDList.Contains(x.ReclamationContractTypeID)).Delete();
            }
        }

        public static void DeleteReclamationContractType(this IQueryable<ReclamationContractType> reclamationContractTypes, int reclamationContractTypeID)
        {
            DeleteReclamationContractType(reclamationContractTypes, new List<int> { reclamationContractTypeID });
        }

        public static void DeleteReclamationContractType(this IQueryable<ReclamationContractType> reclamationContractTypes, ReclamationContractType reclamationContractTypeToDelete)
        {
            DeleteReclamationContractType(reclamationContractTypes, new List<ReclamationContractType> { reclamationContractTypeToDelete });
        }
    }
}